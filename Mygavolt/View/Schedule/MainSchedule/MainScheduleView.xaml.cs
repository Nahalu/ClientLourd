using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mygavolt.View.Schedule.MainSchedule
{
    /// <summary>
    /// Logique d'interaction pour MainScheduleView.xaml
    /// </summary>
    /// 

    public partial class MainScheduleView : UserControl
    {
        MainScheduleViewModel ViewModel = new MainScheduleViewModel();
        public MainScheduleView()
        {
            InitializeComponent();
            this.DataContext = ViewModel; 
        }
    }
}
