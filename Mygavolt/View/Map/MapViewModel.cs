﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mygavolt.View.Map
{
    public class MapViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }
    }
}
