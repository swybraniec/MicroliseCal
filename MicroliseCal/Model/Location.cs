using System;
using System.Collections.Generic;
using System.Text;

namespace MicroliseCal.Model
{
    class Location
    {
        private int _customerId;
        private int _houseNum;
        private string _streetName;
        private string _townCity;
        private string _postCode;

        public Location()
        {
            _customerId = -1;
            _houseNum = -1;
            _streetName = "";
            _townCity = "";
            _postCode = "";
        }
    }
}
