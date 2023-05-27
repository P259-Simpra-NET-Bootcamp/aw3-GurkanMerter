

using Microsoft.EntityFrameworkCore;
using WS.Data.Context;

public static class DbContextExtension
{
    public static void AddDbContextExtension(this IServiceCollection services, IConfiguration Configuration)
    {
        var dbType = Configuration.GetConnectionString("DbType");
        if (dbType == "MsSql")
        {
            var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<WSDbContext>(opts =>
            opts.UseSqlServer(dbConfig));
        }
        else if(dbType== "PostgreSql")
        {
            var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
            services.AddDbContext<WSDbContext>(opts =>
              opts.UseNpgsql(dbConfig));
        }      

    }
}
