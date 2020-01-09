using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MicroliseCal.UserControls
{
    /// <summary>
    /// Interaction logic for NewAppointmentDlg.xaml
    /// </summary>
    public partial class NewAppointmentDlg : Window
    {
        #region Attributes

        MainWindow _parentDialog;

        #endregion Attributes

        #region Constructors

        public NewAppointmentDlg()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Operations

        public void SetParentWindow(MainWindow mainDlg)
        {
            _parentDialog = mainDlg;
        }

        #endregion Operations


        #region Event Handlers
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = dpStartDate.SelectedDate;
            DateTime? endDate = dpEndDate.SelectedDate;

            if ((startDate.HasValue) && (endDate.HasValue))
            {
                _parentDialog.SaveAppointmentDetails(txtSummary.Text, txtLocation.Text, startDate.Value, endDate.Value);
            }
            
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion Event Handlers
    }
}
