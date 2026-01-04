using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace yemekhanemenusıstemı
{
    internal class productsList
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int ID { set; get; }
        public string ProductId { set; get; }
        public string ProductName { set; get; }
        public string Category { set; get; }
        public string stock { set; get; }
        public string price { set; get; }
        public string status { set; get; }
        public string image { set; get; }
        public string DateInsert { set; get; }
        public string DateUpdate { set; get; }


        public List<productsList> productListData()
        {
            List<productsList> listData = new List<productsList>();
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open(); 
                string selectData = "SELECT * FROM products";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        productsList plist = new productsList();
                        plist.ID = (int)reader["id"];
                        plist.ProductId = reader["productid"].ToString();
                        plist.ProductName = reader["productname"].ToString();
                        plist.Category = reader["category"].ToString();
                        plist.stock = reader["stock"].ToString();
                        plist.price = reader["price"].ToString();
                        plist.status = reader["status"].ToString();
                        plist.image = reader["image"].ToString(); 
                        plist.DateInsert = ((DateTime)reader["date_insert"]).ToString("MM-dd-yyyy");
                        plist.DateUpdate = reader["date_update"] == DBNull.Value ? null : ((DateTime)reader["date_update"]).ToString("MM-dd-yyyy");
                        listData.Add(plist);
                    }

                    return listData;
                }
            }
        }
    }
}

