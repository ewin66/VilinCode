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
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using Vilin.Models;
using Vilin.Common;

namespace Vilin.AlarmClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow dialog = new DialogWindow();
            dialog.DealogContent = "我是提示框";
            dialog.Show();
        }
    }

    public class TimeZoneResources : ObservableCollection<TimeZoneModel>
    {
        public TimeZoneResources()
        {
            List<TimeZoneModel> obs = XMLHelper<TimeZoneModel>.Get;
            foreach (TimeZoneModel item in obs)
            {
                this.Add(item);
            }
        }
    }
}
