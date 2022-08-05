using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductWebsiteApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public static List<Category> GetAll()
        {
            List<Category> list = new List<Category>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practise;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";

            con.Open();
            SqlCommand s = new SqlCommand();
            s.Connection = con;
            s.CommandType = System.Data.CommandType.Text;
            s.CommandText = "select * from Categories";

            var e = s.ExecuteReader();
            while (e.Read())
            {
                Category c = new Category();
                c.CategoryId = (int)e[0];
                c.CategoryName = (string)e[1];
                list.Add(c);

            }
            e.Close();
            con.Close();
            return list;
        }

    }
}