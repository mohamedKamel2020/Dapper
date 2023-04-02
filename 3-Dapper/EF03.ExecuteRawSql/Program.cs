
using Dapper;
using EF03.ExecuteRawSql;
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
        var sql = "SELECT * FROM WALLETS";
        Console.WriteLine("-------------- using Dynamic Query----------------");
        var resultAsDynamic = db.Query(sql);
        foreach (var item in resultAsDynamic)
            Console.WriteLine(item);
        Console.WriteLine("--------------- using Typed Query----------------");
        var wallets=db.Query<Wallet>(sql);

        foreach(var wallet in wallets)
            Console.WriteLine(wallet);

        Console.ReadLine();

    }
}