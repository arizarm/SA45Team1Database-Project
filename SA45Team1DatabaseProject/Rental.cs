using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Team1DatabaseProject
{
    class Rental
    {
        private string CustomerID, PlateNum, DateOfRental, ReturnDate;
        public string customerID
        {
            get { return CustomerID; }
            set { CustomerID = value; }
        }

        public string plateNum
        {
            get { return PlateNum; }
            set { PlateNum = value; }
        }
        public string dateOfRental
        {
            get { return DateOfRental; }
            set { DateOfRental = value; }
        }

        public string returnDate
        {
            get { return ReturnDate; }
            set { ReturnDate = value; }
        }

    }
}
