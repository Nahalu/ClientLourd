using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Windows;
using System.Windows.Input;

namespace Mygavolt.Login
{
    public class LoginViewModel : ObservableObject
    {
        public RelayCommand LoginCommandConnect { get; set; }
        public RelayCommand LoginCommandQuit { get; set; }
        
        public LoginViewModel()
        {
            LoginCommandConnect = new RelayCommand(DoLogin);
            LoginCommandQuit = new RelayCommand(o => ((Window)o).Close());

        }

        private string _Label = "";
        public string Label
        {
            get
            {
                return _Label;
            }
            set
            {
                if (_Label != value)
                {
                    _Label = value;
                }
            }
        }
        private string _Password = "";
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                }
            }
        }

        private void DoLogin(object a)
        {
            DirectoryEntry Ldap = new DirectoryEntry();
            Ldap.Path = "LDAP://anxium.fr/DC=mygavolt;DC=local";
            Ldap.Username = "administrateur";
            Ldap.Password = "apmq10*/59";
            DirectorySearcher searcher = new DirectorySearcher(Ldap);
            searcher.Filter = "(objectClass=user)";

            foreach (SearchResult sr in searcher.FindAll())
            {
                YourType newRecord = ConvertToYourType(sr);

                if (Label == newRecord.givenName)
                {
                    MainWindow app = new MainWindow();
                    MainWindowViewModel context = new MainWindowViewModel();
                    app.DataContext = context;
                    App.Current.MainWindow.Close();
                    app.ShowDialog();
                }
                else
                {

                }
            }

        }


            public class YourType
        {
            public string givenName { get; set; }

        }

        public YourType ConvertToYourType(SearchResult result)
        {
            YourType returnValue = new YourType();

            if (result.Properties["givenName"] != null && result.Properties["givenName"].Count > 0)
            {
                returnValue.givenName = result.Properties["givenName"][0].ToString();
            }

            // ..... and so on for each of your values you need to extracxt

            return returnValue;
        }


    }
}

