using System.Threading.Tasks;
using Manero.Controllers;
using Manero.Models.Entities;
using Manero.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Manero.Tests;

public class DatabaseTests
{
    [Fact] 
    public void ConnectionString_SqlServer_ShouldBeAConnectionStringToLocalSqlDatabase()
    {
        //Arange
        var expected = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Besitzer\\Documents\\NewManeroDB.mdf;Integrated Security=True;Connect Timeout=30";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        //Act
        var result = configuration.GetConnectionString("SqlDatabase");

        //Assert
        Assert.Equal(expected, result);
    }
}
