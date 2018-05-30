using Mygavolt.APIMygavolt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mygavolt.View.Affiliate.Intervention
{
    public class InterventionViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }

        public InterventionViewModel()
        {
        }


        private IList<employees> _Employees = null;
        public IList<employees> Employees
        {
            get
            {
                if (_Employees == null)
                {
                    _Employees = ListEmployees();
                }
                return _Employees;
            }
        }

        private IList<employees> ListEmployees()
        {
            IList<employees> listEmployee = null;
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                listEmployee = context.GetEmployees();
            }
            return listEmployee;
        }

        private IList<motives> _Motives = null;
        public IList<motives> Motives
        {
            get
            {
                if (_Motives == null)
                {
                    _Motives = ListMotives();
                }
                return _Motives;
            }
        }

        private IList<motives> ListMotives()
        {
            IList<motives> listMotives = null;
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                listMotives = context.GetMotives();
            }
            return listMotives;
        }

        private IList<customers> _ListCustomer = null;
        public IList<customers> ListCustomer
        {
            get
            {
                if (_ListCustomer == null)
                {
                    _ListCustomer = ListCustomerBase();
                }
                return _ListCustomer;
            }
        }

        private IList<customers> ListCustomerBase()
        {
            IList<customers> listCustomer = null;
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                listCustomer = context.GetCustomers();
            }
            return listCustomer;
        }

        #region Properties Intervention
        private DateTime _DateStart;
        public DateTime DateStart
        {
            get
            {
                return _DateStart;
            }
            set
            {
                if (_DateStart != value)
                {
                    _DateStart = value;
                }
            }
        }

        private DateTime _DateEnd;
        public DateTime DateEnd
        {
            get
            {
                return _DateEnd;
            }
            set
            {
                if (_DateEnd != value.Date)
                {
                    _DateEnd = value.Date;
                }
            }
        }
        private IList<employees> _Employee = null;
        public IList<employees> Employee
        {
            get
            {
                if (_Employee == null)
                {
                    _Employee = ListEmployee();
                }
                return _Employee;
            }
        }
        private IList<motives> _Motive = null;
        public IList<motives> Motive
        {
            get
            {
                if (_Motive == null)
                {
                    _Motive = ListMotive();
                }
                return _Motive;
            }
        }

        private customers selectedCustomer;
        private customers customer = null;
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

        private employees _SelectedEmployee = null;
        public employees SelectedEmployee
        {
            get
            {
                if (_SelectedEmployee == null)
                {
                    _SelectedEmployee = _Employee[0];
                }
                return _SelectedEmployee;
            }
            set
            {
                if (_SelectedEmployee != value)
                {
                    _SelectedEmployee = value;
                }
            }
        }
        private motives _SelectedMotive = null;
        public motives SelectedMotive
        {
            get
            {
                if (_SelectedMotive == null)
                {
                    _SelectedMotive = _Motive[0];
                }
                return _SelectedMotive;
            }
            set
            {
                if (_SelectedMotive != value)
                {
                    _SelectedMotive = value;
                }
            }
        }
        #endregion

        private IList<employees> ListEmployee()
        {
            IList<employees> listeEmployee = null;
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                listeEmployee = context.GetEmployees();
            }
            return listeEmployee;

        }

        private IList<motives> ListMotive()
        {
            IList<motives> listeMotive = null;
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                listeMotive = context.GetMotives();
            }
            return listeMotive;

        }

        public ICommand _AddIntervention;
        public ICommand AddIntervention
        {
            get
            {
                if (_AddIntervention == null)
                {
                    _AddIntervention = new RelayCommand(
                        p => AddInterventionBase());
                }

                return _AddIntervention;
            }
        }


        private void AddInterventionBase()
        {
            interventions inter = new interventions();

            int id_inter = 0;
            inter.customer_id = selectedCustomer.id;
            inter.employee_id = _SelectedEmployee.id;
            inter.motive_id = _SelectedMotive.id;
            inter.dateStart = _DateStart;
            inter.dateEnd = _DateEnd;


            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                id_inter = api.SetIntervention(inter);
            }
            if (id_inter > 0)
            {
                SelectedMotive = Motive[0];
                SelectedEmployee = Employee[0];
                DateStart = DateTime.Now;
                DateEnd = DateTime.Now;


                RaisePropertyChanged("SelectedMotive");
                RaisePropertyChanged("SelectedEmployee");
                RaisePropertyChanged("DateStart");
                RaisePropertyChanged("DateEnd");
            }
            RaisePropertyChanged("ListCustomer");
        }



    }
}
