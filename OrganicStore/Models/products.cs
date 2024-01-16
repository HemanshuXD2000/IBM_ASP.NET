using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Reflection.Metadata;

namespace OrganicStore.Models
{
    public class products
    {
        /*id, p_name, details, category, s_price, o_price, img*/
        public int id { get; set; }

        public string p_name { get; set; }

        public string details { get; set; }

        public string category { get; set; }

        public float s_price { get; set; }

        public float o_price { get; set; }

        public string img { get; set; }      


        public List<products> GetProducts()
        {
            List<Models.products> list = new List<Models.products>();

            SqlConnection conn = new SqlConnection(ConnectionMod.getConnString());
            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products products = new products();
                    products pd = new Models.products();
                    pd.id = reader.GetInt32("id");
                    pd.p_name = reader.GetString("p_name");
                    pd.details = reader.GetString("details");
                    pd.category = reader.GetString("category");
                    pd.o_price = (float)reader.GetDouble("o_price");
                    pd.s_price = (float)reader.GetDouble("s_price");
                    pd.img = reader.GetString("img");
                 

                    list.Add(pd);
                }
            }
            conn.Close();
            return list;
            
        }
    }
 }