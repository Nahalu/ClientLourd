using System.Windows;
using Mygavolt.Login;

namespace Mygavolt
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            /*
            MainWindow app = new MainWindow();
            MainWindowViewModel context = new MainWindowViewModel();
            app.DataContext = context;
            app.ShowDialog();
            */

            LoginView app = new LoginView();
            LoginViewModel context = new LoginViewModel();
            app.DataContext = context;
            app.ShowDialog();


            /* protected override void OnStartup(StartupEventArgs e)
         {
             base.OnStartup(e);

             // Login
             var login = new LoginDialog();
             var loginVm = new LoginViewModel();

             login.DataContext = loginVm;
             login.ShowDialog();

             if (!login.DialogResult.GetValueOrDefault())
             {
                 // Error is handled in login class, not here
                 Environment.Exit(0);
             }

             // If login is successful, show main application
             var app = new ShellView();
             var appModel = new ShellViewModel();

             app.DataContext = viewModel;
             app.Show(); 
         } */
        }
    }
}