using System;
using System.Collections.Generic;
using System.Text;

namespace MicroliseCal.Model
{
    class BookedAppointments
    {
        #region Class Attributes

        private List<Appointment> _bookedAppointments;

        #endregion Class Attributes

        #region Constructors

        public BookedAppointments()
        {
           _bookedAppointments = new List<Appointment>();
        }

        #endregion Constructors

        #region Operations

        public void AddNewAppointment(Appointment newAppointment)
        {
            _bookedAppointments.Add(newAppointment);
        }

        public List<Appointment> GetMonthsAppointments(int monthNumber)
        {
            List<Appointment> monthsAppts = new List<Appointment>();

            foreach(Appointment appt in _bookedAppointments)
            {
                if(appt.AppointmentMonthNumber == monthNumber)
                {
                    monthsAppts.Add(appt);
                }
            }

            return monthsAppts;
        }

        #endregion Operations
    }
}
