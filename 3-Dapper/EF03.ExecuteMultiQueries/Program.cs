
using Dapper;
using EF03.ExecuteInsert;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json")
          .Build();
        IDbConnection db = new SqlConnection(configuration.GetSection("constr").Value);
        
        var sql = "SELECT MIN(Balance) FROM Wallets;"+
                  "SELECT MAX(Balance) FROM Wallets;";
        var multi = db.QueryMultiple(sql);
        Console.WriteLine(
            $"MIN={multi.ReadSingle<decimal>()}\n"+
            $"MAX={multi.ReadSingle<decimal>()}");
       
        Console.ReadLine();

    }
}