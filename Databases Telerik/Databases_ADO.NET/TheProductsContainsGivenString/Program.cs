using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace TheProductsContainsGivenString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string to search in Products: ");
            string input = Console.ReadLine();
            ProductsContains(input);
        }

        public static void ProductsContains(string word)
        {

            SqlConnection NorthWind = new SqlConnection(Settings1.Default.NorthWindConnectionString);
            NorthWind.Open();
            using (NorthWind)
            {
                SqlCommand Products = new SqlCommand("SELECT * FROM Products " +
                                                            "WHERE ProductName LIKE '%' + @Word + '%'", NorthWind);
                Products.Parameters.AddWithValue("@Word", word);

                SqlDataReader reader = Products.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int ProductID = (int)reader[0];
                        string ProductName = (string)reader[1];
                        Console.WriteLine("{0} - {1}", ProductID, ProductName);
                    }
                }
            }
        }
    }
}
