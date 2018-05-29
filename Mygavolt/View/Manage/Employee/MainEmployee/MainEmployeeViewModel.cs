using Mygavolt.APIMygavolt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Mygavolt.View.Manage.Employee.MainEmployee
{
    public class MainEmployeeViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }

        private employees selectedEmployee;
        ICollectionView myDataView;
        private ObservableCollection<employees> myData;


        public IList<employees> MyData
        {
            get
            {
                
                myData = new ObservableCollection<employees>(SearchEmployeesBase());
                myDataView = CollectionViewSource.GetDefaultView(myData);

                myDataView.CurrentChanged += delegate
                {
                    //stores the current selected person
                    CurrentSelectedPerson = (employees)myDataView.CurrentItem;
                };
                return myData;
            }
        }


        private IList<employees> SearchEmployeesBase()
        {
            IList<employees> ListEmployees = null;
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                {
                    ListEmployees = api.GetEmployees();
                }
            }
            return ListEmployees;
        }

        //private IList<SPS_EMPLOYEES_Result> SearchEmployeesBaseCombo()
        //{
        //    IList<SPS_EMPLOYEES_Result> ListEmployeesCombo = null;
        //    using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
        //    {
        //        {
        //            ListEmployeesCombo = api.GetEmployeesCombo();
        //        }
        //    }
        //    return ListEmployeesCombo;
        //}
        
        //private IList<SPS_EMPLOYEES_Result> _EmploCombo = null;
        //public IList<SPS_EMPLOYEES_Result> EmploCombo
        //{
        //    get
        //    {
        //        _EmploCombo = SearchEmployeesBaseCombo();

        //        return _EmploCombo;
        //    }
        //}

        #region Properties used for Filtering
        string searchText = String.Empty;
        /// <summary>
        /// Gets and sets the text used for searching.
        /// Please note that when this property is set a search will be executed
        /// </summary>
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                myDataView.Filter = FilterData;
                OnPropertyChanged("SearchText");
            }
        }
        #endregion

        #region Properties used for sorting
        private bool sortById = false;
        /// <summary>
        /// Gets or sets a flag indicating if the data should be sorted by ID
        /// Please note that by setting this value the list of data will get sorted
        /// </summary>
        public bool SortById
        {
            get { return sortById; }
            set
            {
                sortById = value;
                SortData();
                OnPropertyChanged("SortById");
            }
        }

        private bool sortByName = false;
        /// <summary>
        /// Gets or sets a flag indicating if the data should be sorted by Name
        /// Please note that by setting this value the list of data will get sorted
        /// </summary>
        public bool SortByName
        {
            get { return sortByName; }
            set
            {
                sortByName = value;
                SortData();
                OnPropertyChanged("SortByName");
            }
        }

        private bool sortAscending = false;
        /// <summary>
        /// Gets or sets a flag indicating the order in which the data should be sorted
        /// Please note that by setting this value the list of data will get sorted
        /// </summary>
        public bool SortAscending
        {
            get { return sortAscending; }
            set
            {
                sortAscending = value;
                SortData();
                OnPropertyChanged("SortAscending");
            }
        }
        #endregion

        #region Grouping properties
        bool groupByVersion = false;
        /// <summary>
        /// Gets or sets a flag indicating if the data should be grouped
        /// Please note that by setting this value the list of data will get grouped
        /// </summary>
        public bool GroupByVersion
        {
            get { return groupByVersion; }
            set
            {
                groupByVersion = value;
                GroupData();
                OnPropertyChanged("GroupByVersion");
            }
        }
        #endregion

        #region Selected Item
        employees currentSelectedPerson;
        /// <summary>
        /// Gets the currently selected Person from the list
        /// </summary>
        public employees CurrentSelectedPerson
        {
            get { return currentSelectedPerson; }
            private set
            {
                currentSelectedPerson = value;
                OnPropertyChanged("CurrentSelectedPerson");
            }
        }
        #endregion




        private APIMygavolt.employees employe = null;
        public employees SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;

            }
        }

        #region Properties Employee
        private string _Lastname = "";
        public string Lastname
        {
            get
            {
                return _Lastname;
            }
            set
            {
                if (_Lastname != value)
                {
                    _Lastname = value;
                }
            }
        }


        private string _Firstname = "";
        public string Firstname
        {
            get
            {
                return _Firstname;
            }
            set
            {
                if (_Firstname != value)
                {
                    _Firstname = value;
                }
            }
        }

        private string _Email = "";
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                }
            }
        }

        private string _Phone = "";
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                if (_Phone != value)
                {
                    _Phone = value;
                }
            }
        }

        private string _Mobile = "";
        public string Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                if (_Mobile != value)
                {
                    _Mobile = value;
                }
            }
        }

        private string _StreetName = "";
        public string StreetName
        {
            get
            {
                return _StreetName;
            }
            set
            {
                if (_StreetName != value)
                {
                    _StreetName = value;
                }
            }
        }
        private string _StreetNumber = "";
        public string StreetNumber
        {
            get
            {
                return _StreetNumber;
            }
            set
            {
                if (_StreetNumber != value)
                {
                    _StreetNumber = value;
                }
            }
        }
        private string _ZipCode = "";
        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                if (_ZipCode != value)
                {
                    _ZipCode = value;
                }
            }
        }

        private string _City = "";
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                if (_City != value)
                {
                    _City = value;
                }
            }
        }

        private string _Country = "";
        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                if (_Country != value)
                {
                    _Country = value;
                }
            }
        }

        private string _SocialSecurityNumber = "";
        public string SocialSecurityNumber
        {
            get
            {
                return _SocialSecurityNumber;
            }
            set
            {
                if (_SocialSecurityNumber != value)
                {
                    _SocialSecurityNumber = value;
                }
            }
        }

        private string _BankAccount = "";
        public string BankAccount
        {
            get
            {
                return _BankAccount;
            }
            set
            {
                if (_BankAccount != value)
                {
                    _BankAccount = value;
                }
            }
        }
        
        public DateTime _BirthDate;
        public DateTime BirthDate
        {
            get
            {
                return _BirthDate = DateTime.Now.Date;
            }
            set
            {
                if (_BirthDate != value)
                {
                    _BirthDate = value;
                }
            }
        }

        public DateTime _ArrivalDate;
        public DateTime ArrivalDate
        {
            get
            {
                return _ArrivalDate = DateTime.Now.Date;
            }
            set
            {
                if (_ArrivalDate != value)
                {
                    _ArrivalDate = value;
                }
            }
        }
        




                /*  public string Birthdate
          {
              get
              {
                  if (employe.birthdate == null)
                  {
                      employe.birthdate = "";
                  }
                  return employe.birthdate;
              }
              set
              {
                  if (employe.birthdate != value)
                  {
                      employe.birthdate = value;
                  }
              }
          } */
        #endregion

        private roles _SelectedRole = null;
        public roles SelectedRole
        {
            get
            {
                if (_SelectedRole == null)
                {
                    _SelectedRole = _Roles[0];
                }
                return _SelectedRole;
            }
            set
            {
                if (_SelectedRole != value)
                {
                    _SelectedRole = value;
                }
            }
        }

        private IList<roles> ListRole()
        {
            IList<roles> listeRole = null;
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                listeRole = context.GetRoles();
            }
            return listeRole;

        }

        private IList<roles> _Roles = null;
        public IList<roles> Roles
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = ListRole();
                }
                return _Roles;
            }
        }

        public MainEmployeeViewModel()
        {
            employe = new APIMygavolt.employees();
            
        }


        public ICommand _AddEmployee;
        public ICommand _DeleteEmployee;
        public ICommand _ModifyEmployee;
        public ICommand AddEmployee
        {
            get
            {
                if (_AddEmployee == null)
                {
                    _AddEmployee = new RelayCommand(
                        p => AddEmployeeBase());
                }

                return _AddEmployee;
            }
        }
        public ICommand DeleteEmployee
        {
            get
            {
                if (_DeleteEmployee == null)
                {
                    _DeleteEmployee = new RelayCommand(
                        p => DeleteEmployeeBase());
                }

                return _DeleteEmployee;
            }
        }
        public ICommand ModifyEmployee
        {
            get
            {
                if (_ModifyEmployee == null)
                {
                    _ModifyEmployee = new RelayCommand(
                        p => ModifyEmployeeBase());
                }

                return _ModifyEmployee;
            }
        }



        private void AddEmployeeBase()
        {

            employees contact = new employees();
            address_employees ae = new address_employees();
            int id_contact = 0;
            contact.lastname = _Lastname;
            contact.firstname = _Firstname;
            contact.phone = _Phone;
            contact.mobile = _Mobile;
            contact.email = _Email;
            contact.bank_account = _BankAccount;
            contact.roles = _SelectedRole;
            contact.birthdate = _BirthDate;
            contact.arrival_date = _ArrivalDate;
            ae.street_name = _StreetName;
            ae.street_number = _StreetNumber;
            ae.zip_code = _ZipCode;
            ae.city = _City;
            ae.country = _Country;
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                    id_contact = api.SetEmployee(contact, ae);
            }
            if (id_contact > 0)
            {
                Lastname = "";
                Firstname = "";
                Phone = "";
                Mobile = "";
                Email = "";
                SocialSecurityNumber = "";
                BankAccount = "";
                StreetName = "";
                StreetNumber = "";
                ZipCode = "";
                City = "";
                Country = "";
                SelectedRole = Roles[0];
                ArrivalDate = DateTime.Now.AddYears(1);
                BirthDate = DateTime.Now;
                // Date_Fin_Validite = DateTime.Now.AddYears(1);

                RaisePropertyChanged("Lastname");
                RaisePropertyChanged("Firstname");
                RaisePropertyChanged("Email");
                RaisePropertyChanged("Phone");
                RaisePropertyChanged("Mobile");
                RaisePropertyChanged("SelectedRole");
                RaisePropertyChanged("SocialSecurityNumber");
                RaisePropertyChanged("Phone");
                RaisePropertyChanged("BankAccount");
                RaisePropertyChanged("SelectedRole");
                RaisePropertyChanged("StreetName");
                RaisePropertyChanged("StreetNumber");
                RaisePropertyChanged("City");
                RaisePropertyChanged("Country");
                RaisePropertyChanged("ZipCode");
                RaisePropertyChanged("ArrivalDate");
                RaisePropertyChanged("BirthDate");
            }
            RaisePropertyChanged("MyData");
        }
        private void DeleteEmployeeBase()
        {

            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                api.DeleteEmploye(SelectedEmployee);
                RaisePropertyChanged("MyData");
                RaisePropertyChanged("ListEmployees");
                RaisePropertyChanged("Employees");
                RaisePropertyChanged("SelectedEmployeeD");
                
            }

        }
        private void ModifyEmployeeBase()
        {

            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                api.ModifyEmployee(SelectedEmployee);
                RaisePropertyChanged("MyData");
            }

        }





        #region Filtering
        //Filter the list of data
        private bool FilterData(object item)
        {
            var value = (employees)item;
            if (value == null || value.lastname == null)
                return false;

            return value.lastname.Contains(SearchText);
        }
        #endregion

        #region Sorting

        //Sort the Data
        // for a custom way how to sort the data (and also a much more performant way see: http://ligao101.wordpress.com/2007/07/31/a-much-faster-sorting-for-listview-in-wpf/
        // I implemented this just to show how you can set up some easy sorting for an ICollectionView only.
        private void SortData()
        {
            //get the sort direction
            ListSortDirection direction = SortAscending ? ListSortDirection.Ascending : ListSortDirection.Descending;

            using (myDataView.DeferRefresh()) // we use the DeferRefresh so that we refresh only once
            {
                myDataView.SortDescriptions.Clear();

                if (SortById)
                    myDataView.SortDescriptions.Add(new SortDescription("id", direction));
                if (SortByName)
                    myDataView.SortDescriptions.Add(new SortDescription("lastname", direction));
            }
        }

        #endregion

        #region Grouping
        //groups the data by using a simple PropertyGroupDescription
        private void GroupData()
        {
            using (myDataView.DeferRefresh())
            {
                myDataView.GroupDescriptions.Clear();
                if (GroupByVersion)
                    myDataView.GroupDescriptions.Add(new PropertyGroupDescription("role"));
            }
        }
        #endregion

        #region Selection Navigation Code
        //The code for the Navigation may look like an overhead in the ViewModel but keep in mind that in a real life application you will be doing validation and what not inside here!

        public bool CanSelectFirstItem()
        {
            return myDataView.CurrentPosition > 0;
        }
        public void SelectFirstItem()
        {
            myDataView.MoveCurrentToFirst();
        }

        public bool CanSelectLastItem()
        {
            //Please note that this is done in such a way and not in myData.Count because if there is filtering being applied we need to make sure that the count of items is correct!
            return myDataView.CurrentPosition < myDataView.Cast<employees>().Count() - 1;
        }
        public void SelectLastItem()
        {
            myDataView.MoveCurrentToLast();
        }

        public bool CanSelectNextItem()
        {
            return CanSelectLastItem();
        }
        public void SelectNextItem()
        {
            myDataView.MoveCurrentToNext();
        }

        public bool CanSelectPreviousItem()
        {
            return CanSelectFirstItem();
        }
        public void SelectPreviousItem()
        {
            myDataView.MoveCurrentToPrevious();
        }
        #endregion




















        private int _Role;
        public int Role
        {
            get
            {
                return _Role;
            }
            set
            {
                if (_Role != value)
                {
                    _Role = value;
                }
            }
        }

        private IList<SPS_EMPLOYEESACTIVE_Result> _Employees = null;
        public IList<SPS_EMPLOYEESACTIVE_Result> Employees
        {
            get
            {

                    _Employees = ListEmployees();

                return _Employees;
            }
        }

        private IList<SPS_EMPLOYEESACTIVE_Result> ListEmployees()
        {
            IList<SPS_EMPLOYEESACTIVE_Result> listEmployee = null;
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                listEmployee = context.GetEmployeesActive();
            }
            return listEmployee;
        }

        //private SPS_EMPLOYEESACTIVE_Result _SelectedEmployeeD = null;
        //public SPS_EMPLOYEESACTIVE_Result SelectedEmployeeD
        //{
        //    get
        //    {
        //        if (_SelectedEmployeeD == null)
        //        {
        //            _SelectedEmployeeD = _Employees[0];
        //        }
        //        return _SelectedEmployeeD;
        //    }
        //    set
        //    {
        //        if (_SelectedEmployeeD != value)
        //        {
        //            _SelectedEmployeeD = value;
        //        }
        //    }
        //}

        // Une liste de matériel provennant de la base 
        private IList<devices> _DeviceBase;
        private IList<devices> SearchDeviceBase()
        {
            IList<devices> devicesTMP = null;
            devices deviceTMP = new devices();
            deviceTMP.label = "";
            deviceTMP.version = "";
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                devicesTMP = context.GetDevices();
            }
            return devicesTMP;
        }

        // Une liste de matériel qui sera affiché comme produit choisisable 
        public static bool ReloadDeviceIntervention;
        private IList<devices> _RemainingDevice;
        public IList<devices> RemainingDevice
        {
            get
            {
                if (_RemainingDevice == null || ReloadDeviceIntervention)
                {
                    _DeviceBase = SearchDeviceBase();
                    _RemainingDevice = _DeviceBase;
                    ReloadDeviceIntervention = false;
                }
                return _RemainingDevice;
            }
        }

        // Une liste d'employés provennant de la base 
        private IList<SPS_EMPLOYEESACTIVE_Result> _EmployeeBase;
        private IList<SPS_EMPLOYEESACTIVE_Result> SearchEmployeeBase()
        {
            IList<SPS_EMPLOYEESACTIVE_Result> employeesTMP = null;
            SPS_EMPLOYEESACTIVE_Result employeeTMP = new SPS_EMPLOYEESACTIVE_Result();
            employeeTMP.lastname = "";
            employeeTMP.firstname = "";
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                employeesTMP = context.GetEmployeesActive();
            }
            return employeesTMP;
        }



        // Une liste d'employés qui sera affiché comme produit choisisable 
        public static bool ReloadEmployeeIntervention;
        private IList<SPS_EMPLOYEESACTIVE_Result> _RemainingEmployee;
        public IList<SPS_EMPLOYEESACTIVE_Result> RemainingEmployee
        {
            get
            {
                if (_RemainingEmployee == null || ReloadEmployeeIntervention)
                {
                    _EmployeeBase = SearchEmployeeBase();
                    _RemainingEmployee = _EmployeeBase;
                    ReloadEmployeeIntervention = false;
                }
                return _RemainingEmployee;
            }
        }









        private IList<devices> _ProduitAAjouter;
        public devices ProduitAAjouter
        {
            get
            {
                return new devices();
            }
            set
            {
                if (_ProduitAAjouter == null)
                    _ProduitAAjouter = new List<devices>();
                if (value != null && value.id != null && value.id > 0)
                {
                    if (_ProduitAAjouter.Where(c => c.id == value.id).Count() == 0)
                    {
                        _ProduitAAjouter.Add(value);
                    }
                    value = null;
                }
            }
        }


        // une liste de produit a ajouter 
        private IList<devices> _ProduitASupprimer;
        public devices ProduitASupprimer
        {
            get
            {
                return new devices();
            }
            set
            {
                if (_ProduitASupprimer == null)
                    _ProduitASupprimer = new List<devices>();
                if (value != null && value.id != null && value.id > 0)
                {
                    if (_ProduitASupprimer.Where(c => c.id == value.id).Count() == 0)
                    {
                        _ProduitASupprimer.Add(value);
                    }
                    value = null;
                }
            }
        }

        // La liste des produit sélectionné
        private IList<devices> _ProduitSelectionne;
        public IList<devices> ProduitSelectionne
        {
            get
            {
                if (_ProduitSelectionne == null)
                {
                    _ProduitSelectionne = new List<devices>();

                }
                return _ProduitSelectionne;
            }
        }


        private IList<employees> _EmployeSelectionne;
        public IList<employees> EmployeSelectionne
        {
            get
            {
                if (_EmployeSelectionne == null)
                {
                    _EmployeSelectionne = new List<employees>();

                }
                return _EmployeSelectionne;
            }
        }






        public ICommand _AjouterProduit;
        public ICommand AjouterProduit
        {
            get
            {
                if (_AjouterProduit == null)
                {
                    _AjouterProduit = new RelayCommand(
                        p => AjouterProduitTemporaire());
                }

                return _AjouterProduit;
            }
        }
        private void AjouterProduitTemporaire()
        {
            if (_ProduitAAjouter != null && _ProduitAAjouter.Count > 0)
            {
                _ProduitSelectionne = _ProduitSelectionne.Union(_ProduitAAjouter).ToList();
                _RemainingDevice = _DeviceBase.Except(_ProduitSelectionne).ToList();
                RaisePropertyChanged("RemainingDevice");
                RaisePropertyChanged("ProduitSelectionne");
                _ProduitAAjouter.Clear();
                RaisePropertyChanged("ProduitAAjouter");

            }
        }

        public ICommand _SupprimerProduit;
        public ICommand SupprimerProduit
        {
            get
            {
                if (_SupprimerProduit == null)
                {
                    _SupprimerProduit = new RelayCommand(
                        p => SupprimerProduitTemporaire());
                }

                return _SupprimerProduit;
            }
        }


        public void SupprimerProduitTemporaire()
        {
            _ProduitSelectionne = _ProduitSelectionne.Except(_ProduitASupprimer).ToList();
            _RemainingDevice = _DeviceBase.Except(_ProduitSelectionne).ToList();

            _ProduitASupprimer.Clear();
            RaisePropertyChanged("RemainingDevice");
            RaisePropertyChanged("ProduitSelectionne");
            RaisePropertyChanged("ProduitASupprimer");

        }











    }
}
