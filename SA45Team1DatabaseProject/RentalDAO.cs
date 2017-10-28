using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Threading.Tasks;

namespace SA45Team1DatabaseProject
{
    class RentalDAO
    {
        SqlConnection cn;
        SqlCommand cmRentVehicle;

        private static RentalDAO dbInstance;

        private RentalDAO()
        {
            // 
            // string strCN = @"Data Source=(local);" +
            //    "Integrated Security=SSPI;" +
            //   "Initial Catalog = RentalVehicle";

            string strCN = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                           @"AttachDbFilename =|DataDirectory|RentalVehicle.mdf;" +
                           @"Integrated Security = true";

            cn = new SqlConnection(strCN);

            initializeSQLCmd();
        }

        private void initializeSQLCmd()
        {
            cmRentVehicle = new SqlCommand();

            cmRentVehicle.CommandText =
               "Insert into Rental values (@customerID, @plateNum, @rentalDate, null)";
            cmRentVehicle.Connection = cn;
        } //, @returnDate

        public static RentalDAO getInstance()
        {

            if (dbInstance == null)
                dbInstance = new RentalDAO();

            return dbInstance;
        }

        public void openConnection()
        {
            cn.Open();
        }
        public void CloseConnection()
        {
            if (cn != null)
                cn.Close();
        }

        public void createRental(Rental r)
        {
            SqlParameter rCustomerID =
                 new SqlParameter("@customerID", SqlDbType.Int);
            SqlParameter rPlateNum =
                new SqlParameter("@plateNum", SqlDbType.NVarChar, 10);
            SqlParameter rRentalDate =
                new SqlParameter("@rentalDate", SqlDbType.DateTime);
            //SqlParameter rReturnDate =
            //new SqlParameter("@returnDate", SqlDbType.DateTime);

            cmRentVehicle.Parameters.Clear();
            rCustomerID.Value = r.customerID;
            rPlateNum.Value = r.plateNum;
            rRentalDate.Value = r.dateOfRental;
            //rReturnDate.Value = r.returnDate;
            cmRentVehicle.Parameters.AddRange(new SqlParameter[]
          { rCustomerID, rPlateNum, rRentalDate/*, rReturnDate*/ });

            cmRentVehicle.ExecuteNonQuery();
        }

    }
}
