
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
        decimal amountToTransfer = 2000m;
        var walletFrom=db.QuerySingle<Wallet>(
            "SELECT * FROM Wallets WHERE Id=@Id")
        
        Console.ReadLine();

    }
}