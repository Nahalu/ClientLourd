﻿using Mygavolt.APIMygavolt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mygavolt.View.Manage.Customer.Add
{
    public class AddCustomerViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }

        
    }
}
