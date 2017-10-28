using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Team1DatabaseProject
{
    class EnquiryVehicleStatusControl
    {
        public Vehicle RetrievePlateNo(string plate)
        {

            VehicleDAO rentalDAO = VehicleDAO.getInstance();

            try
            {
                rentalDAO.openConnection();
                Vehicle c = rentalDAO.RetrieveVehicle(plate);
                return c;
            }
            catch (Exception)
            {
                throw;           // preserve stack trace     
            }
            finally
            {
                rentalDAO.CloseConnection();
            }

        }
    }
}
