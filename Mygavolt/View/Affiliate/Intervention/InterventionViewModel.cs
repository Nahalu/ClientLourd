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
        public InterventionViewModel()
        {
        }
        public string Name
        {
            get { return "Ajouter Intervention"; }
        }


        public static bool ReloadIntervention;
        public static bool ReloadInterventionForfait;


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

        private employees _SelectedEmployee = null;
        public employees SelectedEmployee
        {
            get
            {
                if (_SelectedEmployee == null)
                {
                    _SelectedEmployee = _Employees[0];
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
        private IList<employees> _EmployeeBase;
        private IList<employees> SearchEmployeeBase()
        {
            IList<employees> employeesTMP = null;
            employees employeeTMP = new employees();
            employeeTMP.lastname = "";
            employeeTMP.firstname = "";
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                employeesTMP = context.GetEmployees();
            }
            return employeesTMP;
        }

        // Une liste d'employés qui sera affiché comme produit choisisable 
        public static bool ReloadEmployeeIntervention;
        private IList<employees> _RemainingEmployee;
        public IList<employees> RemainingEmployee
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


        public ICommand _AjouterIntervention;
        public ICommand AjouterIntervention
        {
            get
            {
                if (_AjouterIntervention == null)
                {
                    _AjouterIntervention = new RelayCommand(
                        p => AjouterInterventionBase());
                }

                return _AjouterIntervention;
            }
        }

        private void AjouterInterventionBase()
        {
            int codeErr = -1;
            //  employees myIntervention = new employees();
            employees myEmployee = SelectedEmployee;
            
           // myEmployee.device_id = _ProduitSelectionne.ToArray();
            using (APIMygavolt.Service1Client context = new APIMygavolt.Service1Client())
            {
                codeErr = context.ModifyEmployee(myEmployee); // , _ProduitSelectionne.ToArray()

            }

            if (codeErr > 0)
            {
                // _Motive = "";
                if (_ProduitSelectionne != null)
                    _ProduitSelectionne.Clear();
                if (_ProduitAAjouter != null)
                    _ProduitAAjouter.Clear();
                if (_ProduitASupprimer != null)
                    _ProduitASupprimer.Clear();

                RaisePropertyChanged("Motive");
                RaisePropertyChanged("ProduitSelectionne");
                RaisePropertyChanged("ProduitAAjouter");
                RaisePropertyChanged("ProduitASupprimer");
                ReloadIntervention = true;
                ReloadInterventionForfait = true;
            }

        }



    }
}
