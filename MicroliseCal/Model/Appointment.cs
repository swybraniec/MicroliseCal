﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroliseCal.Model
{
    class Appointment
    {
        #region Class Attributes

        private string _summary;
        private Location _location;
        private DateTime _start;
        private DateTime _end;

        #endregion Class Attributes

        #region Constructors

        public Appointment()
        {
            _summary = "Something";
            _location = new Location();
        }

        #endregion Constructors

        #region Properties

        public int AppointmentMonthNumber
        {
            get
            {
                return _start.Month;
            }
        }

        public int AppointmentDayNumber
        {
            get
            {
                return _start.Day;
            }
        }

        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
            }
        }

        public string Location
        {
            set
            {
                Location loc = new Location();
                loc.LocationString = value;
                _location = loc;
            }

            get
            {
                return _location.LocationString;
            }
        }

        public DateTime StartDate
        {
            set
            {
                _start = value;
            }
        }

        public DateTime EndDate
        {
            set
            {
                _end = value;
            }
        }

        #endregion Properties

        #region Overloaded Operators

        public bool Equals(Appointment otherAppt)
        {
            bool comparison = false;

            if ((AppointmentDayNumber == otherAppt.AppointmentDayNumber) &&
                (AppointmentMonthNumber == otherAppt.AppointmentMonthNumber))
                comparison = true;

            return comparison;
        }

        #endregion Overloaded Operators
    }
}
