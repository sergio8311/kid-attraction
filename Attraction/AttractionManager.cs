using System;
using System.Collections.Generic;
using System.Text;

namespace Attraction
{
    class AttractionManager
    {
        private static decimal _cash { get; set; }

        public AttractionManager(decimal cash)
        {
            _cash = cash;
        }

        public bool CheckCash()
        {
            if (_cash >= 200)
            {
                Console.WriteLine("Attractions are closed");
                return false;
            }

            return true;
        }

        public void IsKidAllowedToRide(bool isAllowed, Kid kid)
        {
            if (isAllowed)
            {
                kid.Ride();
                _cash =_cash + AttractionSettings.GetAttractionsCost();
            }

            else
            {
                kid.Cry();
            }

        }

    }
}
