using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AddingNewProductInProductsTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(Settings1.Default.NorthWindConnectionString);
            con.Open();
            using (con)
            {
                AddNewProduct("Krastavici", 1, 1, "Mnogo", 20, 2, 2, 2, 0, con);  
            }
        }

        private static void AddNewProduct(
            string ProductName,
            int SupplierID, 
            int CategoryID, 
            string QuantityPerUnit, 
            decimal UnitPrice, 
            int UnitsInStock, 
            int UnitsOnOrder, 
            int ReorderLevel,
            int Discontinued,
            SqlConnection Connection)
        {
            SqlCommand AddProduct = new SqlCommand("INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice,UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES " +
                                                                        "(@ProductName, @SuplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)",Connection);
            AddProduct.Parameters.AddWithValue("@ProductName", ProductName);
            AddProduct.Parameters.AddWithValue("@SuplierID", SupplierID);
            AddProduct.Parameters.AddWithValue("@CategoryID", CategoryID);
            AddProduct.Parameters.AddWithValue("@QuantityPerUnit", QuantityPerUnit);
            AddProduct.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            AddProduct.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
            AddProduct.Parameters.AddWithValue("@UnitsOnOrder", UnitsOnOrder);
            AddProduct.Parameters.AddWithValue("@ReorderLevel", ReorderLevel);
            AddProduct.Parameters.AddWithValue("@Discontinued", Discontinued);
            AddProduct.ExecuteNonQuery();

        }
    }
}
