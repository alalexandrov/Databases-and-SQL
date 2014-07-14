using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace ReadInfoFromExcelFile
{
    class Program
    {
        static void Main(string[] args)
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Alexander\Desktop\Info.xlsx; Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1""");
            Console.WriteLine(connection.Provider);
            connection.Open();
            using (connection)
            {
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                OleDbDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string Name = (string)reader[0];
                        string Score = (string)reader[1];
                        Console.WriteLine("{0} - {1}", Name, Score);
                    }
                }
            }
        }
    }
}
