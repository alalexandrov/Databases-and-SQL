using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace GetCategoryAndProductNames
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection NorthWindCon = new SqlConnection(Settings1.Default.NorthWindConnectionString);
            NorthWindCon.Open();
            using (NorthWindCon)
            {
                SqlCommand GetCategoryAndProductNames = new SqlCommand("SELECT p.ProductName, c.CategoryName" +
                                                                       " FROM Products p" +
                                                                       " JOIN Categories c" +
                                                                       " ON p.CategoryID = c.CategoryID" + 
                                                                       " ORDER BY c.CategoryName", NorthWindCon);
                SqlDataReader reader = GetCategoryAndProductNames.ExecuteReader();
                Console.WriteLine("Product  -  Category");
                Console.WriteLine();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string ProductName = (string)reader["ProductName"];
                        string CategoryName = (string)reader["CategoryName"];
                        Console.WriteLine("{0} - {1}", ProductName, CategoryName);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
