using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Team1DatabaseProject
{
    class RentVehicleControl
    {
        public DataTable retrieveVehicleInfo(string id)
        {

            VehicleDAO vehicleDAO = VehicleDAO.getInstance();

            try
            {
                vehicleDAO.openConnection();
                DataTable AVList = vehicleDAO.retrieveVehicleInfo(id);
                return AVList;
            }
            catch (Exception)
            {
                throw;           // preserve stack trace     
            }
            finally
            {
                vehicleDAO.CloseConnection();
            }
        }

        public void updateVehicleInfo(Vehicle v)
        {
            VehicleDAO vehicleDAO = VehicleDAO.getInstance();

            try
            {
                vehicleDAO.openConnection();
                vehicleDAO.updateVehicleInfo(v);

                return;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                vehicleDAO.CloseConnection();
            }
        }

        public void createRental(Rental r)
        {
            RentalDAO rentalDAO = RentalDAO.getInstance();

            try
            {
                rentalDAO.openConnection();
                rentalDAO.createRental(r);

                return;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                rentalDAO.CloseConnection();
            }
        }


    }
}
