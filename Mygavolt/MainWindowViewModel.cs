// A ajouter pour chaque nouvelle vue 
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Mygavolt.View.Home;
using Mygavolt.View.Map;
using Mygavolt.View.Manage.Customer.Add;
using Mygavolt.View.Manage.Customer.Search;
using Mygavolt.View.Manage.Customer.MainCustomer;
using Mygavolt.View.Manage.Device.Add;
using Mygavolt.View.Manage.Device.Search;
using Mygavolt.View.Manage.Device.MainDevice;
using Mygavolt.View.Manage.Employee.Add;
using Mygavolt.View.Manage.Employee.Search;
using Mygavolt.View.Manage.Employee.MainEmployee;
using Mygavolt.View.Schedule.MainSchedule;
using Mygavolt.View.Affiliate.Intervention;
using Mygavolt.View.Schedule.Planning;
using Mygavolt.View.Manage.Role;

namespace Mygavolt
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields

        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        #endregion
        public MainWindowViewModel()
        {
            //A ajouter pour chaque nouvelle view


            PageViewModels.Add(new HomeViewModel());
            PageViewModels.Add(new MapViewModel());
            PageViewModels.Add(new AddCustomerViewModel());
            PageViewModels.Add(new SearchCustomerViewModel());
            PageViewModels.Add(new AddDeviceViewModel());
            PageViewModels.Add(new SearchDeviceViewModel());
            PageViewModels.Add(new AddEmployeeViewModel());
            PageViewModels.Add(new SearchEmployeeViewModel());
            PageViewModels.Add(new MainEmployeeViewModel());
            PageViewModels.Add(new MainDeviceViewModel());
            PageViewModels.Add(new MainCustomerViewModel());
            PageViewModels.Add(new MainScheduleViewModel());
            PageViewModels.Add(new InterventionViewModel());
            PageViewModels.Add(new PlanningViewModel());
            PageViewModels.Add(new RoleViewModel());

            CurrentPageViewModel = PageViewModels[0];

        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }

        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }


        #endregion

        // A ajouter pour chaque view appelée par un bouton
        #region Methods

        public IPageViewModel Home
        {
            get
            {
                return PageViewModels[0];
            }
        }
        public IPageViewModel Map
        {
            get
            {
                return PageViewModels[1];
            }
        }
        public IPageViewModel AddCustomer
        {
            get
            {
                return PageViewModels[2];
            }
        }
        public IPageViewModel SearchCustomer
        {
            get
            {
                return PageViewModels[3];
            }
        }
        public IPageViewModel AddDevice
        {
            get
            {
                return PageViewModels[4];
            }
        }
        public IPageViewModel SearchDevice
        {
            get
            {
                return PageViewModels[5];
            }
        }
        public IPageViewModel AddEmployee
        {
            get
            {
                return PageViewModels[6];
            }
        }
        public IPageViewModel SearchEmployee
        {
            get
            {
                return PageViewModels[7];
            }
        }
        public IPageViewModel MainEmployee
        {
            get
            {
                return PageViewModels[8];
            }
        }
        public IPageViewModel MainDevice
        {
            get
            {
                return PageViewModels[9];
            }
        }
        public IPageViewModel MainCustomer
        {
            get
            {
                return PageViewModels[10];
            }
        }
        public IPageViewModel MainSchedule
        {
            get
            {
                return PageViewModels[11];
            }
        }
        public IPageViewModel Intervention
        {
            get
            {
                return PageViewModels[12];
            }
        }
        public IPageViewModel Planning
        {
            get
            {
                return PageViewModels[13];
            }
        }
        public IPageViewModel Role
        {
            get
            {
                return PageViewModels[14];
            }
        }
        #endregion
    }

}
