using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mygavolt.View.Schedule.Calendar
{
    public class CalendarViewModel : ObservableObject, IPageViewModel

    {
        private string name;
        public string Name { get => name; set => name = value; }
    }
}
