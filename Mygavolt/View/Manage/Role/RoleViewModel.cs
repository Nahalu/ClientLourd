using Mygavolt.APIMygavolt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mygavolt.View.Manage.Role
{
    public class RoleViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }


        private roles selectedRole;


        public RoleViewModel()
        {
            // connexion à l'API a chaque chargement de la page


            // Si on veut initialiser des valeurs dès l'ouverture, il faut le faire ici


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


        public roles SelectedRole
        {
            get
            {
                return selectedRole;
            }
            set
            {
                selectedRole = value;

            }
        }






        private IList<roles> _Roles = null;
        public IList<roles> Roles
        {
            get
            {
                _Roles = SearchRolesBase();

                return _Roles;
            }
        }



        private IList<roles> SearchRolesBase()
        {
            IList<roles> ListRoles = null;
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                {
                    ListRoles = api.GetRoles();
                }
            }
            return ListRoles;
        }


        public ICommand _AddRole;
        public ICommand _DeleteRole;
        public ICommand _SearchRole;

        public ICommand AddRole
        {
            get
            {
                if (_AddRole == null)
                {
                    _AddRole = new RelayCommand(
                        p => AddRoleBase());
                }

                return _AddRole;
            }
        }

        public ICommand DeleteRole
        {
            get
            {
                if (_DeleteRole == null)
                {
                    _DeleteRole = new RelayCommand(
                        p => DeleteRoleBase());
                }

                return _DeleteRole;
            }
        }
        private void AddRoleBase()
        {
            roles contact = new roles();

            int id_contact = 0;
            contact.label = _Label;

            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                id_contact = api.SetRole(contact);
            }
            if (id_contact > 0)
            {
                Label = "";

                RaisePropertyChanged("Label");
            }
            RaisePropertyChanged("Roles");
        }

        private void DeleteRoleBase()
        {
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                api.DeleteRole(SelectedRole);
                RaisePropertyChanged("Roles");
            }
        }
    }
}
