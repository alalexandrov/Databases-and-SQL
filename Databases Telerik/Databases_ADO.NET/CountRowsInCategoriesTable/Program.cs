using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CountRowsInCategoriesTable
{
    class Program
    {
        static void Main(string[] args)
        {
           SqlConnection NorthWindCon = new SqlConnection(Settings1.Default.NorthWindConnectionString);
           NorthWindCon.Open();
           using (NorthWindCon)
           {
               SqlCommand GetNumberOfRows = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories", NorthWindCon);
               int numberOfRows = (int)GetNumberOfRows.ExecuteScalar();
               Console.WriteLine("Number of rows in Category Table in Northwind is: " + numberOfRows);
           }
        }
    }
}
