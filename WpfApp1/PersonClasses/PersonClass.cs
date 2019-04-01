using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WpfApp1.PersonClasses
{
    class PersonClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        string connstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public bool Insert(PersonClass person)
        {
            bool issuccess = false;

            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("INSERT INTO Person(FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)", conn);
            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", person.LastName);
            cmd.Parameters.AddWithValue("@Age", person.Age);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                issuccess = true;
                return issuccess;
            }
            return issuccess;
        }

        public DataTable Return()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Person", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
