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
using System.Timers;
using Vilin.AlarmClock.Model;
using Vilin.AlarmClock.Core;

namespace Vilin.AlarmClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Timer timerClock = new Timer();

        public MainWindow()
        {
            InitializeComponent();

            //BandingTimeZone();
            InitTimer();
            InitList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cbCity.Focus();
        }

        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void autoCities_PatternChanged(object sender, Vilin.AlarmClock.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
                args.DataSource = MainWindow.GetCities(args.Pattern);
        }

        /// <summary>
        /// Get a list of cities that follow a pattern
        /// </summary>
        /// <returns></returns>
        private static ObservableCollection<TimeZoneModel> GetCities(string Pattern)
        {
            // match on contain (could do starts with)
            return new ObservableCollection<TimeZoneModel>(
                XMLCacheHelper<TimeZoneModel>.Get.
                Where((city, match) => city.CityName.Contains(Pattern.ToLower())));
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;

            List<AlarmClockModel> obs = AlarmClockCore.Get((int)now.DayOfWeek, now.ToString("HH:mm"));
            if (obs != null && obs.Count > 0)
            {
                foreach (var item in obs)
                {
                    item.State = 1;
                    MessageBox.Show(item.Remark);
                    //DialogWindow dialog = new DialogWindow();
                    //dialog.DealogContent = item.Remark;
                    //dialog.Show();
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AlarmClockModel ob = new AlarmClockModel();

            ob.code = Guid.NewGuid().ToString();
            ob.CityName = cbCity.SelectedItem.ToString();
            ob.TimeZone = cbCity.SelectedValue.ToString();
            ob.Week = Convert.ToInt32(cbWeek.Text);

            double timeZone = 0;
            DateTime now = Convert.ToDateTime(tpTime.Value);
            if (ob.TimeZone.Contains("+"))
            {
                timeZone = -8 + Convert.ToDouble(ob.TimeZone.Replace("+", ""));
            }
            else
            {
                timeZone = -8 - Convert.ToDouble(ob.TimeZone.Replace("-", ""));
            }
            now = now.AddHours(timeZone * -1);

            ob.Time = now.ToString("HH:mm");
            ob.Remark = tbRemark.Text;

            AlarmClockCore.Add(ob);
            InitList();

            //DialogWindow dialog = new DialogWindow();
            //dialog.DealogContent = "mmmm";
            //dialog.Show();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbList.SelectedValue.ToString()))
            {
                AlarmClockCore.Del(lbList.SelectedValue.ToString());
            }

            InitList();
        }

        //private void BandingTimeZone()
        //{
        //    cbCity.ItemsSource = XMLCacheHelper<TimeZoneModel>.Get;
        //    cbCity.DisplayMemberPath = "CityName";
        //    cbCity.SelectedValuePath = "TimeZone";
        //}

        private void InitTimer()
        {
            timerClock.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timerClock.Interval = 1000;
            timerClock.Enabled = true;
        }

        private void InitList()
        {
            lbList.Items.Clear();
            foreach (AlarmClockModel item in AlarmClockCore.GetAll())
            {
                lbList.Items.Add(item.Remark);
            }
        }

        private void lbList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbList.SelectedIndex == -1)
            {
                return;
            }

            if (!string.IsNullOrEmpty(lbList.SelectedValue.ToString()))
            {
                AlarmClockModel ob = AlarmClockCore.GetBy(lbList.SelectedValue.ToString());
                if (ob != null)
                {
                    cbCity.SelectedItem = ob.CityName;
                    cbWeek.SelectedItem = ob.Week;
                    tpTime.DefaultValue = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") +" "+ ob.Time);
                    tbRemark.Text = ob.Remark;

                }
            }
        }
    }
}
