using System.Windows;


namespace Mygavolt.Login
{
    public class LoginViewModel : ObservableObject
    {

        public RelayCommand LoginCommandConnect { get; set; }
        public RelayCommand LoginCommandQuit { get; set; }

        public LoginViewModel()
        {

            LoginCommandConnect = new RelayCommand(DoLogin);
            LoginCommandQuit = new RelayCommand(QuitLogin);
        }

        private void DoLogin(object obj)
        {
 
            MainWindow app = new MainWindow();
            MainWindowViewModel context = new MainWindowViewModel();
            app.DataContext = context;
            app.Show();
        }

        private void QuitLogin(object obj)
        {


        }

        /*
        private void Connect(object sender, RoutedEventArgs e)
        {


            MainWindow app = new MainWindow();
            MainWindowViewModel context = new MainWindowViewModel();
            app.DataContext = context;
            //app.ShowDialog();
            app.Show();
        }
        private void Quit(object sender, RoutedEventArgs e)
        {
            LoginView closeLogin = new LoginView();
            closeLogin.Close();

        }

        */
    }
}
