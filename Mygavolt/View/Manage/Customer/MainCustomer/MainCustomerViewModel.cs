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

namespace Mygavolt.View.Manage.Customer.MainCustomer
{
    public class MainCustomerViewModel: ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }
        private customers selectedCustomer;
        ICollectionView myDataView;
        private ObservableCollection<customers> myData;


        public IList<customers> MyData
        {
            get
            {
                myData = new ObservableCollection<customers>(SearchCustomersBase());
                myDataView = CollectionViewSource.GetDefaultView(myData);

                myDataView.CurrentChanged += delegate
                {
                    //stores the current selected person
                    CurrentSelectedPerson = (customers)myDataView.CurrentItem;
                };
                return myData;
            }
        }

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
        customers currentSelectedPerson;
        /// <summary>
        /// Gets the currently selected Person from the list
        /// </summary>
        public customers CurrentSelectedPerson
        {
            get { return currentSelectedPerson; }
            private set
            {
                currentSelectedPerson = value;
                OnPropertyChanged("CurrentSelectedPerson");
            }
        }
        #endregion

        private IList<customers> SearchCustomersBase()
        {
            customers customer = new customers();
            customer.lastname = "";
            customer.firstname = "";
            customer.email = "";
            customer.mobile = "";
            customer.phone = "";

            IList<customers> ListCustumers = null;
            using (APIMygavolt.Service1Client api = new Service1Client())
            {
                {
                    ListCustumers = api.GetCustomers();
                }
            }
            return ListCustumers;
        }


        #region Properties Customer
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
        private string _BusinessName = "";
        public string BusinessName
        {
            get
            {
                return _BusinessName;
            }
            set
            {
                if (_BusinessName != value)
                {
                    _BusinessName = value;
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
        #endregion

        private APIMygavolt.customers customer = null;

        public customers SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
            }
        }

        public MainCustomerViewModel()
        {
             customer = new APIMygavolt.customers();
            
        }

        public ICommand _AddCustomer;
        public ICommand AddCustomer
        {
            get
            {
                if (_AddCustomer == null)
                {
                    _AddCustomer = new RelayCommand(
                        p => AddCustomerBase());
                }

                return _AddCustomer;
            }
        }


        public ICommand _DeleteCustomer;
        public ICommand DeleteCustomer
        {
            get
            {
                if (_DeleteCustomer == null)
                {
                    _DeleteCustomer = new RelayCommand(
                        p => DeleteCustomerBase());
                }

                return _DeleteCustomer;
            }
        }

        public ICommand _ModifyCustomer;
        public ICommand ModifyCustomer
        {
            get
            {
                if (_ModifyCustomer == null)
                {
                    _ModifyCustomer = new RelayCommand(
                        p => ModifyCustomerBase());
                }

                return _ModifyCustomer;
            }
        }

        private void AddCustomerBase()
        {
            customers contact = new customers();
            address_customers addre = new address_customers();
            int id_contact = 0;
            contact.lastname = _Lastname;
            contact.firstname = _Firstname;
            contact.mobile = _Mobile;
            contact.phone = _Phone;
            contact.email = _Email;
            contact.business_name = _BusinessName;
            addre.street_name = _StreetName;
            addre.street_number = _StreetNumber;
            addre.zip_code = _ZipCode;
            addre.city = _City;
            addre.country = _Country;


            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                id_contact = api.SetCustomer(contact, addre);
            }
            if (id_contact > 0)
            {
                Lastname = "";
                Firstname = "";
                Mobile = "";
                Phone = "";
                Email = "";
                BusinessName = "";
                StreetName = "";
                StreetNumber = "";
                ZipCode = "";
                City = "";
                Country = "";

                RaisePropertyChanged("Lastname");
                RaisePropertyChanged("Firstname");
                RaisePropertyChanged("Mobile");
                RaisePropertyChanged("Phone");
                RaisePropertyChanged("Email");
                RaisePropertyChanged("BusinessName");
                RaisePropertyChanged("StreetName");
                RaisePropertyChanged("StreetNumber");
                RaisePropertyChanged("ZipCode");
                RaisePropertyChanged("City");
                RaisePropertyChanged("Country");
            }
            RaisePropertyChanged("MyData");
        }

        private void DeleteCustomerBase()
        {

            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                api.DeleteCustomer(SelectedCustomer);
                RaisePropertyChanged("MyData");
            }

        }
        private void ModifyCustomerBase()
        {
            
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                api.ModifyCustomer(SelectedCustomer);
                RaisePropertyChanged("MyData");
            }
        }

        #region Filtering
        //Filter the list of data
        private bool FilterData(object item)
        {
            var value = (customers)item;
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
                    myDataView.GroupDescriptions.Add(new PropertyGroupDescription("business_name"));
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
            return myDataView.CurrentPosition < myDataView.Cast<customers>().Count() - 1;
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


    }
}
