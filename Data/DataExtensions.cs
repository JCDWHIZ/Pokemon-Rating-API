using System;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Data.Migrations;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app){
    using var scope = app.Services.CreateScope();
    var DbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    DbContext.Database.Migrate();
}
}