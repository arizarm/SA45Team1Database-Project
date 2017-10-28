using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Team1DatabaseProject
{
    class VehicleDAO
    {
        SqlConnection cn;
        SqlCommand cmSelbyPNo, cmSelAll, cmUpdateVStatus;

        private static VehicleDAO dbInstance;

        private VehicleDAO()
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
            cmSelbyPNo = new SqlCommand();

            cmSelbyPNo.CommandText =
               "Select * from RentalStatus WHERE PlateNum = @PlateNum";
            cmSelbyPNo.Connection = cn;

            cmSelAll = new SqlCommand();

            cmSelAll.CommandText =
               "Select * from Vehicle v WHERE v.Status = 'Available' and v.category = " + "@category";
            cmSelAll.Connection = cn;

            cmUpdateVStatus = new SqlCommand();

            cmUpdateVStatus.CommandText =
               "Update Vehicle set status = 'Rented out' WHERE PlateNum = @PlateNum";
            cmUpdateVStatus.Connection = cn;

        }

        public static VehicleDAO getInstance()
        {

            if (dbInstance == null)
                dbInstance = new VehicleDAO();

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

        public Vehicle RetrieveVehicle(String givenPlate)
        {
            SqlParameter PlateNum =
                 new SqlParameter("@PlateNum", SqlDbType.NVarChar, 10);
            PlateNum.Value = givenPlate;

            cmSelbyPNo.Parameters.Clear();
            cmSelbyPNo.Parameters.Add(PlateNum);


            Vehicle V = new Vehicle(); ;

            SqlDataReader rd = cmSelbyPNo.ExecuteReader();
            if (rd.Read())
            {
                V.model = rd["Model"].ToString();
                V.plateNo = rd["PlateNum"].ToString();
                V.colour = rd["Colour"].ToString();
                V.engineNo = rd["EngineSerialNum"].ToString();
                V.status = rd["Status"].ToString();
            }
            else
            {
                throw new RVException(RVMessage.WrongPlateNo);
            }

            rd.Close();
            return V;
        }

        public DataTable retrieveVehicleInfo(string id)
        {
            SqlParameter pCategoryId =
     new SqlParameter("@category", SqlDbType.NVarChar, 10);
            pCategoryId.Value = id;

            cmSelAll.Parameters.Clear();
            cmSelAll.Parameters.Add(pCategoryId);


            SqlDataAdapter adapter = new SqlDataAdapter(cmSelAll);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "AvailableVehicles");

            return ds.Tables["AvailableVehicles"];

        }

        public void updateVehicleInfo(Vehicle c)
        {
            SqlParameter plateNo = new SqlParameter("@PlateNum", SqlDbType.NVarChar, 10);
            plateNo.Value = c.plateNo;

            cmUpdateVStatus.Parameters.Clear();
            cmUpdateVStatus.Parameters.Add(plateNo);

            cmUpdateVStatus.ExecuteNonQuery();
        }

    }
}
