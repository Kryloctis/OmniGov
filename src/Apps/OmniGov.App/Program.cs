using Accounting.Data.Services;
using Budget.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using OmniGov.App.Views.SignIn;
using OmniGov.Core.Services;
using PropertyAssessment.Data.Services;
using Treasury.Data.Services;

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

        private static void ConfigureServices(IServiceCollection services)
        {
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