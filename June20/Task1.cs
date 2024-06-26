 // Connect and Query a Database Write a C# program that connects to a SQL database and retrieves the names of all tables within it. Use SqlConnection and SqlCommand objects. 

using System.Threading.Tasks;
namespace DbSQL
{
  internal class Program
  {
      static void Main(string[] args)
      {
      
        string con = "data source-DESKTOP-TIC5DM4\\SQLEXPRESS; initial catalog employee; integrated security="true";
      
        SqlConnection connection = new SqlConnection(con);
      
        string command = "select name from sys.tables";
      
        SqlCommand cmd = new SqlCommand(command, connection);
      
        connection.Open();
      
        SqlDataReader reader = cmd.ExecuteReader();
      
        Console.WriteLine("Tables are: ");
      
        while (reader.Read()) 
      
        {
      
          Console.WriteLine(reader.GetString(0));
      
        }
   
        connection.Close();
    }
  }
}
