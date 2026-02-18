using Accounting.Data.Services;
using Budget.Data.Services;
using LFS.Views.SignIn;
using Microsoft.Extensions.DependencyInjection;
using OmniGov.Core.Services;
using System;
using System.Windows.Forms;
using Treasury.Data.Services;

namespace LFS
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
            // services.AddRptServices();
        }
    }
}