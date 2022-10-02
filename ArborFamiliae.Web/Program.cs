using ArborFamiliae.Data;
using Microsoft.EntityFrameworkCore;
using static ArborFamiliae.Web.Provider;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddDbContext<ArborFamiliaeContext>(options =>
{
    var provider = config.GetValue("provider", MySql.Name);

    if (provider == MySql.Name)
    {
        options.UseMySql(
            config.GetConnectionString(MySql.Name)!,
            ServerVersion.AutoDetect(config.GetConnectionString(MySql.Name)),
            x => x.MigrationsAssembly(MySql.Assembly)
        );
    }

    //if (provider == Postgres.Name)
    //{
    //    options.UseNpgsql(
    //        config.GetConnectionString(Postgres.Name)!,
    //        x => x.MigrationsAssembly(Postgres.Assembly)
    //    );
    //}
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
