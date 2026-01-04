using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace yemekhanemenusıstemı
{
    internal class categoriesList
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int ID { set; get; }
        public string category { set; get; }
        public string status { set; get; }
        public string DateInsert { set; get; }

        public List<categoriesList> categoriesListData()
        {
            List<categoriesList> listData = new List<categoriesList>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string selectData = "SELECT * FROM categories";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categoriesList cData = new categoriesList();
                        cData.ID = (int)reader["id"];
                        cData.category = reader["category"].ToString();
                        cData.status = reader["status"].ToString();
                        cData.DateInsert = ((DateTime)reader["date_insert"]).ToString("MM-dd-yyyy");

                        listData.Add(cData);
                    }
                }
            }

            return listData;
        }
    }
}
