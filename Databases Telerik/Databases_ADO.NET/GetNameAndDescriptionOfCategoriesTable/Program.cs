using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace GetNameAndDescriptionOfCategoriesTable
{
    class Program
    {
        static void Main()
        {
            SqlConnection NorthWindCon = new SqlConnection(Settings1.Default.NorthWindConnectionString);
            NorthWindCon.Open();
            using (NorthWindCon)
            {
                SqlCommand GetNamesAndDescriptions = new SqlCommand("SELECT CategoryName, Description FROM Categories", NorthWindCon);
                SqlDataReader reader = GetNamesAndDescriptions.ExecuteReader();
                Console.WriteLine("The names and Description of Category Table are:");
                using (reader)
                {
                    while (reader.Read())
                    {
                        string CategoryName = (string)reader["CategoryName"];
                        string Description = (string)reader["Description"];
                        Console.WriteLine("Category: {0} - Description: {1}",CategoryName,Description );
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
