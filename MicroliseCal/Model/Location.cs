using System;
using System.Collections.Generic;
using System.Text;

namespace MicroliseCal.Model
{
    class Location
    {
        #region Attributes

        private int _customerId;
        private int _houseNum;
        private string _streetName;
        private string _townCity;
        private string _postCode;
        private string _rawLocationString;

        #endregion Attributes

        #region Constructors

        public Location()
        {
            _customerId = -1;
            _houseNum = -1;
            _streetName = "";
            _townCity = "";
            _postCode = "";
            _rawLocationString = "";
        }

        #endregion Constructors

        #region Properties

        public string LocationString
        {
            get
            {
                return _rawLocationString;
            }
            set
            {
                _rawLocationString = value;
                // Ideally I would parse the string to extract the various aspects and store them in the relevant attributes.
            }
        }

        #endregion Properties
    }
}
