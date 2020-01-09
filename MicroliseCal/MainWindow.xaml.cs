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
using MicroliseCal.Model;
using MicroliseCal.UserControls;

namespace MicroliseCal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class Attributes

        List<StackPanel> _daysInMonth;
        BookedAppointments _bookedAppointments;
        int _currentMonthDisplay;

        #endregion Class Attributes


        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            // Create the 'day controls' for each day and display them on the main grid.
            _daysInMonth = new List<StackPanel>();
            for(int createDays = 0; createDays < 31; createDays++)
            {
                _daysInMonth.Add(CreateDayControl(createDays));
            }

            int currentDay = 0;
            for (int populateRow = 2; populateRow < 8; populateRow++)
            {
                for (int populateCol = 0; populateCol < 7; populateCol++)
                {
                    Grid.SetRow(_daysInMonth[currentDay], populateRow);
                    Grid.SetColumn(_daysInMonth[currentDay], populateCol);
                    MonthViewGrid.Children.Add(_daysInMonth[currentDay]);
                    currentDay++;
                    if (currentDay == 31)
                        break;
                }
                if (currentDay == 31)
                    break;
            }

            // Create the appointment instances.
            _bookedAppointments = new BookedAppointments();

            // Initialise the calendar by getting the current month and displaying all the appointments.
            _currentMonthDisplay = DateTime.Now.Month;
            txtMonthName.Text = GetMonthName(_currentMonthDisplay);
            ShowMonthsAppointments(_currentMonthDisplay);
        }

        #endregion Constructors

        #region Operations

        public void SaveAppointmentDetails(string summary, string location, DateTime startDate, DateTime endDate)
        {
            Appointment newAppt = new Appointment();
            Location loc = new Location();
            newAppt.Summary = summary;
            newAppt.Location = location;
            newAppt.StartDate = startDate;
            newAppt.EndDate = endDate;
            _bookedAppointments.AddNewAppointment(newAppt);
            ShowMonthsAppointments(_currentMonthDisplay);
        }

        #endregion Operations

        #region Helper methods

        private StackPanel CreateDayControl(int index)
        {
            StackPanel day = new StackPanel();
            Border outline = new Border();
            outline.BorderBrush = Brushes.Black;
            outline.Background = Brushes.Black;
            outline.BorderThickness = new Thickness(2);
            Label dayNumber = new Label();
            dayNumber.Background = Brushes.Gray;
            dayNumber.Name = "dayNumberLabel";
            day.Children.Add(dayNumber);
            dayNumber.Content = (index + 1).ToString();
            TextBlock appointmentDetails = new TextBlock();
            appointmentDetails.Name = "txtApptDetails";
            day.Children.Add(appointmentDetails);

            return day;
        }

        private string GetMonthName(int monthNum)
        {
            string monthName = "";

            switch(monthNum)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
            }

            return monthName;
        }

        private void ShowMonthsAppointments(int monthNumber)
        {
            ClearCalendar();
            List<Appointment> appts = _bookedAppointments.GetMonthsAppointments(monthNumber);
            foreach(Appointment appt in appts)
            {
                StackPanel dayViewToUpdate = _daysInMonth[appt.AppointmentDayNumber-1];
                TextBlock txt = (TextBlock)dayViewToUpdate.Children[1];
                string displayString = string.Format("{0}\n{1}", appt.Summary, appt.Location);
                txt.Text = displayString;
            }
        }

        private void ClearCalendar()
        {
            foreach(StackPanel day in _daysInMonth)
            {
                TextBlock txt = (TextBlock)day.Children[1];
                txt.Text = "";
            }
        }

        #endregion Helper methods

        #region Event Handlers
        private void btnNewAppt_Click(object sender, RoutedEventArgs e)
        {
            NewAppointmentDlg newApptDlg = new NewAppointmentDlg();
            newApptDlg.SetParentWindow(this);
            newApptDlg.Show();
        }

        private void btnShowNextMonth_Click(object sender, RoutedEventArgs e)
        {
            if (_currentMonthDisplay < 12)
                _currentMonthDisplay++;
            txtMonthName.Text = GetMonthName(_currentMonthDisplay);
            ShowMonthsAppointments(_currentMonthDisplay);
        }

        private void btnPrevNextMonth_Click(object sender, RoutedEventArgs e)
        {
            if (_currentMonthDisplay > 1)
                _currentMonthDisplay--;
            txtMonthName.Text = GetMonthName(_currentMonthDisplay);
            ShowMonthsAppointments(_currentMonthDisplay);
        }

        #endregion Event Handlers
    }
}
