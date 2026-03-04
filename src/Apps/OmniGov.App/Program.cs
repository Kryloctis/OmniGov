using Accounting.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OmniGov.App.Views.SignIn;
using OmniGov.Budget.Data.Services;
using OmniGov.Core.Services;
using OmniGov.PropertyAssessment.Data.Services;
using OmniGov.Treasury.Data.Services;
using Serilog;

namespace OmniGov.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OmniGov", "logs", "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7)
                .CreateLogger();

            try
            {
                Log.Information("Application starting up...");

                // Setup global WinForms exception handling
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += (s, e) => LogFatalError(e.Exception, "UI Thread Exception");
                AppDomain.CurrentDomain.UnhandledException += (s, e) => LogFatalError(e.ExceptionObject as Exception, "AppDomain Unhandled Exception");
                TaskScheduler.UnobservedTaskException += (s, e) =>
                {
                    LogFatalError(e.Exception, "Unobserved Task Exception");
                    e.SetObserved();
                };

                // Initialize Dependency Injection
                var services = new ServiceCollection();
                ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                // Initialize the Service Locator for WinForms access
                ServiceLocator.Initialize(serviceProvider);

                // Start the application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmSignIn());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
                MessageBox.Show($"A critical error occurred: {ex.Message}\n\nCheck logs for details.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void LogFatalError(Exception? ex, string source)
        {
            Log.Fatal(ex, "Unhandled exception from {Source}", source);

            // Show a user-friendly message
            string message = ex?.Message ?? "An unknown error occurred.";
            MessageBox.Show($"Oops! Something went wrong.\n\nSource: {source}\nError: {message}\n\nPlease contact IT support if this persists.",
                "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // In a terminal error, we might want to shut down,
            // but for WinForms ThreadException, we often let the user continue if possible.
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Add Serilog to the DI container
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(dispose: true);
            });

            // Add Core services (repositories, GenericCommands, etc.)
            services.AddCoreServices();

            // TODO: Add Budget services
            services.AddBudgetServices();

            // TODO: Add Accounting services
            services.AddAccountingServices();

            // TODO: Add Treasury services
            services.AddTreasuryServices();

            // TODO: Add RPT services
            services.AddPropertyAssessmentServices();
        }
    }
}