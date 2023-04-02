
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
        var walletToInsert = new Wallet { Holder = "salah", Balance = 10000m };
        var sql = "INSERT INTO WAllets(Holder,Balance)" +
            "VALUES(@Holder,@Balance)"+
            "SELECT CAST(SCOPE_IDENTITY() AS INT)";
       var parameters=
            new {
                Holder=walletToInsert.Holder,
                Balance=walletToInsert.Balance
            };
        walletToInsert.Id = db.Query<int>(sql, parameters).Single();
        Console.WriteLine(walletToInsert);

        Console.ReadLine();

    }
}