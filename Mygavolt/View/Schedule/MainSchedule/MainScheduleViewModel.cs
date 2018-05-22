using Mygavolt.APIMygavolt;
using Mygavolt.Filters;
using Mygavolt.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Mygavolt.View.Schedule.MainSchedule
{
    class MainScheduleViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }
        public IList<interventions> ListInterventions
        {
            get => listInterventions; set { listInterventions = value; OnPropertyChanged("ListInterventions"); }
        }
        public IList<employees> ListEmployees { get => listEmployees; set => listEmployees = value; }
        public IList<ICommand> ListCommand { get => listCommand; set => listCommand = value; }
        public List<Button> ListButton1 { get => listButton1; set { listButton1 = value; OnPropertyChanged("ListButton1"); } }
        public List<Button> ListButton2 { get => listButton2; set { listButton2 = value; OnPropertyChanged("ListButton2"); } }
        public List<Button> ListButton3 { get => listButton3; set { listButton3 = value; OnPropertyChanged("ListButton3"); } }
        public List<Button> ListButton4 { get => listButton4; set { listButton4 = value; OnPropertyChanged("ListButton4"); } }
        public List<Button> ListButton5 { get => listButton5; set { listButton5 = value; OnPropertyChanged("ListButton5"); } }
        public List<Button> ListButton6 { get => listButton6; set { listButton6 = value; OnPropertyChanged("ListButton6"); } }
        public List<Button> ListButton7 { get => listButton7; set { listButton7 = value; OnPropertyChanged("ListButton7"); } }


        private List<Button> listButton1 = new List<Button>();
        private List<Button> listButton2 = new List<Button>();
        private List<Button> listButton3 = new List<Button>();
        private List<Button> listButton4 = new List<Button>();
        private List<Button> listButton5 = new List<Button>();
        private List<Button> listButton6 = new List<Button>();
        private List<Button> listButton7 = new List<Button>();

        private IList<interventions> listInterventions;
        private IList<employees> listEmployees;
        private IList<ICommand> listCommand;
        public MainScheduleViewModel()
        {
            MondayOfTheWeek();




        }



        public void Button()
        {
            ListInterventions = new List<APIMygavolt.interventions>();
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                listInterventions = api.GetInterventions();
            }
            ListEmployees = new List<APIMygavolt.employees>();
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                listEmployees = api.GetEmployees();
            }

            //IList<interventions> interventionsEmpl = null;
            foreach (interventions inter in listInterventions)
            {
                if (inter.dateStart.Day == Date1.Day)
                {
                    foreach (employees empl in listEmployees)
                    {
                        if (inter.employee_id == empl.id)
                        {
                            //foreach (interventions interb in listInterventions)
                            //{
                            //    if (inter.employee_id == empl.id)
                            //    {
                            //        interventionsEmpl.Add(interb);
                            //    }
                            //}
                            Button x = new Button();
                            x.Height = 100;
                            x.Width = 90;
                            x.Background = new SolidColorBrush(Colors.BlueViolet);
                            x.Content = empl.lastname;
                            x.Command = ShowInterventions;
                            listButton1.Add(x);
                        }
                    }
                }
                else if (inter.dateStart.Day == Date2.Day)
                {
                    foreach (employees empl in listEmployees)
                    {
                        if (inter.employee_id == empl.id)
                        {
                            Button x = new Button();
                            x.Height = 100;
                            x.Width = 90;
                            x.Background = new SolidColorBrush(Colors.BlueViolet);
                            x.Content = empl.lastname;
                            x.Command = ShowInterventions;
                            ListButton2.Add(x);
                        }
                    }
                }
                else if (inter.dateStart.Day == Date3.Day)
                {
                    foreach (employees empl in listEmployees)
                    {
                        if (inter.employee_id == empl.id)
                        {
                            Button x = new Button();
                            x.Height = 100;
                            x.Width = 90;
                            x.Background = new SolidColorBrush(Colors.BlueViolet);
                            x.Content = empl.lastname;
                            x.Command = ShowInterventions;
                            ListButton3.Add(x);
                        }
                    }
                }
                else if (inter.dateStart.Day == Date4.Day)
                {
                    foreach (employees empl in listEmployees)
                    {
                        if (inter.employee_id == empl.id)
                        {
                            Button x = new Button();
                            x.Height = 100;
                            x.Width = 90;
                            x.Background = new SolidColorBrush(Colors.BlueViolet);
                            x.Content = empl.lastname;
                            x.Command = ShowInterventions;
                            ListButton4.Add(x);
                        }
                    }
                }
                else if (inter.dateStart.Day == Date5.Day)
                {
                    foreach (employees empl in listEmployees)
                    {
                        if (inter.employee_id == empl.id)
                        {
                            Button x = new Button();
                            x.Height = 100;
                            x.Width = 90;
                            x.Background = new SolidColorBrush(Colors.BlueViolet);
                            x.Content = empl.lastname;
                            x.Command = ShowInterventions;
                            ListButton5.Add(x);
                        }
                    }
                }
                else if (inter.dateStart.Day == Date6.Day)
                {
                    foreach (employees empl in listEmployees)
                    {
                        if (inter.employee_id == empl.id)
                        {
                            Button x = new Button();
                            x.Height = 100;
                            x.Width = 90;
                            x.Background = new SolidColorBrush(Colors.BlueViolet);
                            x.Content = empl.lastname;
                            x.Command = ShowInterventions;
                            ListButton6.Add(x);
                        }
                    }
                }
                else if (inter.dateStart.Day == Date7.Day)
                {
                    foreach (employees empl in listEmployees)
                    {
                        if (inter.employee_id == empl.id)
                        {
                            Button x = new Button();
                            x.Height = 100;
                            x.Width = 90;
                            x.Background = new SolidColorBrush(Colors.BlueViolet);
                            x.Content = empl.lastname;
                            x.Command = ShowInterventions;
                            ListButton7.Add(x);
                        }
                    }
                }
            }

        }

        private IList<interventions> _ListInterventionss = null;

        public IList<interventions> ListInterventionss
        {

            get
            {
                if (_ListInterventionss == null)
                {
                    _ListInterventionss = new List<interventions>();
                }
                return _ListInterventionss;
            }
        }







        private void SearchInterventionBase()
        {
            IList<interventions> ListInter = null;
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                {
                    ListInter = api.GetInterventions();
                }
            }
            _ListInterventionss = ListInter;
            RaisePropertyChanged("ListInterventionss");
        }

        public ICommand _ShowInterventions;
        public ICommand ShowInterventions
        {
            get
            {
                if (_ShowInterventions == null)
                {
                    _ShowInterventions = new RelayCommand(
                        p => SearchInterventionBase());
                }

                return _ShowInterventions;
            }
        }


        public void Today()
        {
            if (Date1 == DateTime.Today)
            {
                DateStr1 = "Aujourd'hui";
            }
            else if (Date2 == DateTime.Today)
            {
                DateStr2 = "Aujourd'hui";
            }
            else if (Date3 == DateTime.Today)
            {
                DateStr3 = "Aujourd'hui";
            }
            else if (Date4 == DateTime.Today)
            {
                DateStr4 = "Aujourd'hui";
            }
            else if (Date5 == DateTime.Today)
            {
                DateStr5 = "Aujourd'hui";
            }
            else if (Date6 == DateTime.Today)
            {
                DateStr6 = "Aujourd'hui";
            }
            else if (Date7 == DateTime.Today)
            {
                DateStr7 = "Aujourd'hui";
            }
        }

        DateTime date1;
        DateTime date2;
        DateTime date3;
        DateTime date4;
        DateTime date5;
        DateTime date6;
        DateTime date7;
        string datestr1;
        string datestr2;
        string datestr3;
        string datestr4;
        string datestr5;
        string datestr6;
        string datestr7;

        public DateTime Date1 { get => date1; set { date1 = value; OnPropertyChanged("Date1"); } }
        public DateTime Date2 { get => date2; set { date2 = value; OnPropertyChanged("Date2"); } }
        public DateTime Date3 { get => date3; set { date3 = value; OnPropertyChanged("Date3"); } }
        public DateTime Date4 { get => date4; set { date4 = value; OnPropertyChanged("Date4"); } }
        public DateTime Date5 { get => date5; set { date5 = value; OnPropertyChanged("Date5"); } }
        public DateTime Date6 { get => date6; set { date6 = value; OnPropertyChanged("Date6"); } }
        public DateTime Date7 { get => date7; set { date7 = value; OnPropertyChanged("Date7"); } }
        public string DateStr1 { get => datestr1; set { datestr1 = value; OnPropertyChanged("DateStr1"); } }
        public string DateStr2 { get => datestr2; set { datestr2 = value; OnPropertyChanged("DateStr2"); } }
        public string DateStr3 { get => datestr3; set { datestr3 = value; OnPropertyChanged("DateStr3"); } }
        public string DateStr4 { get => datestr4; set { datestr4 = value; OnPropertyChanged("DateStr4"); } }
        public string DateStr5 { get => datestr5; set { datestr5 = value; OnPropertyChanged("DateStr5"); } }
        public string DateStr6 { get => datestr6; set { datestr6 = value; OnPropertyChanged("DateStr6"); } }
        public string DateStr7 { get => datestr7; set { datestr7 = value; OnPropertyChanged("DateStr7"); } }

        public void MondayOfTheWeek()
        {
            DateTime currdate = DateTime.Today;
            int delta = DayOfWeek.Monday - currdate.DayOfWeek;
            DateTime monday = currdate.AddDays(delta);

            Date1 = monday;
            Date2 = monday.AddDays(1);
            Date3 = monday.AddDays(2);
            Date4 = monday.AddDays(3);
            Date5 = monday.AddDays(4);
            Date6 = monday.AddDays(5);
            Date7 = monday.AddDays(6);

            DateStr1 = Date1.ToString("dd/MM");
            DateStr2 = Date2.ToString("dd/MM");
            DateStr3 = Date3.ToString("dd/MM");
            DateStr4 = Date4.ToString("dd/MM");
            DateStr5 = Date5.ToString("dd/MM");
            DateStr6 = Date6.ToString("dd/MM");
            DateStr7 = Date7.ToString("dd/MM");

            Today();
            Button();
        }

        public void AddWeek()
        {
            Date1 = date1.AddDays(7);
            Date2 = date2.AddDays(7);
            Date3 = date3.AddDays(7);
            Date4 = date4.AddDays(7);
            Date5 = date5.AddDays(7);
            Date6 = date6.AddDays(7);
            Date7 = date7.AddDays(7);

            DateStr1 = Date1.ToString("dd/MM");
            DateStr2 = Date2.ToString("dd/MM");
            DateStr3 = Date3.ToString("dd/MM");
            DateStr4 = Date4.ToString("dd/MM");
            DateStr5 = Date5.ToString("dd/MM");
            DateStr6 = Date6.ToString("dd/MM");
            DateStr7 = Date7.ToString("dd/MM");

            MainScheduleView View = new MainScheduleView();


            Today();
            listButton1.Clear();
            ListButton2.Clear();
            ListButton3.Clear();
            ListButton4.Clear();
            ListButton5.Clear();
            ListButton6.Clear();
            ListButton7.Clear();
            Button();
            CollectionViewSource.GetDefaultView(ListButton1).Refresh();
            CollectionViewSource.GetDefaultView(ListButton2).Refresh();
            CollectionViewSource.GetDefaultView(ListButton3).Refresh();
            CollectionViewSource.GetDefaultView(ListButton4).Refresh();
            CollectionViewSource.GetDefaultView(ListButton5).Refresh();
            CollectionViewSource.GetDefaultView(ListButton6).Refresh();
            CollectionViewSource.GetDefaultView(ListButton7).Refresh();

        }

        public void RemoveWeek()
        {
            Date1 = date1.AddDays(-7);
            Date2 = date2.AddDays(-7);
            Date3 = date3.AddDays(-7);
            Date4 = date4.AddDays(-7);
            Date5 = date5.AddDays(-7);
            Date6 = date6.AddDays(-7);
            Date7 = date7.AddDays(-7);

            DateStr1 = Date1.ToString("dd/MM");
            DateStr2 = Date2.ToString("dd/MM");
            DateStr3 = Date3.ToString("dd/MM");
            DateStr4 = Date4.ToString("dd/MM");
            DateStr5 = Date5.ToString("dd/MM");
            DateStr6 = Date6.ToString("dd/MM");
            DateStr7 = Date7.ToString("dd/MM");

            Today();
            ListButton1.Clear();
            ListButton2.Clear();
            ListButton3.Clear();
            ListButton4.Clear();
            ListButton5.Clear();
            ListButton6.Clear();
            ListButton7.Clear();
            Button();
            CollectionViewSource.GetDefaultView(ListButton1).Refresh();
            CollectionViewSource.GetDefaultView(ListButton2).Refresh();
            CollectionViewSource.GetDefaultView(ListButton3).Refresh();
            CollectionViewSource.GetDefaultView(ListButton4).Refresh();
            CollectionViewSource.GetDefaultView(ListButton5).Refresh();
            CollectionViewSource.GetDefaultView(ListButton6).Refresh();
            CollectionViewSource.GetDefaultView(ListButton7).Refresh();
        }

        public ICommand _NextWeek;
        public ICommand NextWeek
        {
            get
            {
                if (_NextWeek == null)
                {
                    _NextWeek = new RelayCommand(
                        p => AddWeek());
                }
                return _NextWeek;
            }
        }

        public ICommand _PreviousWeek;
        public ICommand PreviousWeek
        {
            get
            {
                if (_PreviousWeek == null)
                {
                    _PreviousWeek = new RelayCommand(
                        p => RemoveWeek());
                }
                return _PreviousWeek;
            }
        }
    }
}
