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

namespace Mygavolt.View.Manage.Device.MainDevice
{
    public class MainDeviceViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }
        private devices selectedDevice;
        ICollectionView myDataView;
        private ObservableCollection<devices> myData;

        // initialisation de la page
        public MainDeviceViewModel()
        {
            // connexion à l'API a chaque chargement de la page
            CurrentDevice = new APIMygavolt.devices();

            // Si on veut initialiser des valeurs dès l'ouverture, il faut le faire ici


        }








        /// <summary>
        /// Gets the list of persons to show in the UI
        /// </summary>
        public IList<devices> MyData
        {
            get
            {

                myData = new ObservableCollection<devices>(SearchDevicesBase());
                myDataView = CollectionViewSource.GetDefaultView(myData);

                myDataView.CurrentChanged += delegate
                {
                    //stores the current selected person
                    CurrentSelectedPerson = (devices)myDataView.CurrentItem;
                };
                return myData;

            }
        }



        private IList<devices> _Devices = null;
        public IList<devices> Devices
        {
            get
            {
                    _Devices = SearchDevicesBase();

                return _Devices;
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
        devices currentSelectedPerson;
        /// <summary>
        /// Gets the currently selected Person from the list
        /// </summary>
        public devices CurrentSelectedPerson
        {
            get { return currentSelectedPerson; }
            private set
            {
                currentSelectedPerson = value;
                OnPropertyChanged("CurrentSelectedPerson");
            }
        }
        #endregion



        private IList<devices> SearchDevicesBase()
        {
           
            devices device = new devices();
            device.label = "";
            device.version = "";
            device.IMEI = "";
            device.mac_address = "";
            device.system = "";

            IList<devices> ListDevices = null;
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                {
                    ListDevices = api.GetDevices();
                }
            }
            return ListDevices;

        }

        #region Properties Device
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

        private string _Imei = "";
        public string Imei
        {
            get
            {
                return _Imei;
            }
            set
            {
                if (_Imei != value)
                {
                    _Imei = value;
                }
            }
        }
        private string _System = "";
        public string System
        {
            get
            {
                return _System;
            }
            set
            {
                if (_System != value)
                {
                    _System = value;
                }
            }
        }
        private string _Version = "";
        public string Version
        {
            get
            {
                return _Version;
            }
            set
            {
                if (_Version != value)
                {
                    _Version = value;
                }
            }
        }
        private string _Mac_address = "";
        public string Mac_address
        {
            get
            {
                return _Mac_address;
            }
            set
            {
                if (_Mac_address != value)
                {
                    _Mac_address = value;
                }
            }
        }
        #endregion

        private APIMygavolt.devices CurrentDevice;

        public devices SelectedDevice
        {
            get
            {
                return selectedDevice;
            }
            set
            {
                selectedDevice = value;

            }
        }


        #region Properties ICommand
        // Icommand => action du bouton
        public ICommand _AddDevice;
        public ICommand _DeleteDevice;
        public ICommand _ModifyDevice;
        #endregion 

        public ICommand AddDevice
        {
            get
            {
                if (_AddDevice == null)
                {
                    _AddDevice = new RelayCommand(
                        p => AddDeviceBase());
                }

                return _AddDevice;
            }
        }

        public ICommand DeleteDevice
        {
            get
            {
                if (_DeleteDevice == null)
                {
                    _DeleteDevice = new RelayCommand(
                        p => DeleteDeviceBase());
                }

                return _DeleteDevice;
            }
        }
        public ICommand ModifyDevice
        {
            get
            {
                if (_ModifyDevice == null)
                {
                    _ModifyDevice = new RelayCommand(
                        p => ModifyDeviceBase());
                }

                return _ModifyDevice;
            }
        }

        // Lier avec la fonction du web service
        private void AddDeviceBase()
        {
            devices contact = new devices();

            int id_contact = 0;
            contact.label = _Label;
            contact.IMEI = _Imei;
            contact.version = _Version;
            contact.system = _System;
            contact.mac_address = _Mac_address;


            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                id_contact = api.SetDevice(contact);
            }
            if (id_contact > 0)
            {
                Label = "";
                Imei = "";
                Version = "";
                System = "";
                Mac_address = "";


                RaisePropertyChanged("Label");
                RaisePropertyChanged("Imei");
                RaisePropertyChanged("Version");
                RaisePropertyChanged("System");
                RaisePropertyChanged("Mac_address");
            }
            RaisePropertyChanged("MyData");
        }

        private void DeleteDeviceBase()
        {
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                api.DeleteDevice(SelectedDevice);
                RaisePropertyChanged("MyData");
            }
            
        }
        private void ModifyDeviceBase()
        {
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                api.ModifyDevice(SelectedDevice);
                RaisePropertyChanged("MyData");
            }
        }




        #region Filtering
        //Filter the list of data
        private bool FilterData(object item)
        {
            var value = (devices)item;
            if (value == null || value.label == null)
                return false;

            return value.label.Contains(SearchText);
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
                    myDataView.SortDescriptions.Add(new SortDescription("label", direction));
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
                    myDataView.GroupDescriptions.Add(new PropertyGroupDescription("version"));
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
            return myDataView.CurrentPosition < myDataView.Cast<devices>().Count() - 1;
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
