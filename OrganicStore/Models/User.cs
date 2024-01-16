using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace OrganicStore.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confpwd { get; set; }

        public int SaveUserDetails()
        {
            SqlConnection conn = new SqlConnection(ConnectionMod.getConnString());
            string query = "insert into Users (username, password, confpwd) values('" + username + "', '" + password + "','" + confpwd + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected;
        }

    }
}
