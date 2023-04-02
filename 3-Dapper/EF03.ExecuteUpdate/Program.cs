
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
        var walletToUpdate = new Wallet {Id=9, Holder = "Ayman", Balance = 16000m };
        var sql = "UPDATE Wallets SET Holder = @Holder , Balance = @Balance WHERE Id=@Id;";
       var parameters=
            new {
                Id=walletToUpdate.Id,
                Holder=walletToUpdate.Holder,
                Balance=walletToUpdate.Balance
            };
        db.Execute(sql, parameters);
        Console.ReadLine();

    }
}