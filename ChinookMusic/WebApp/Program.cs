using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Supplied database connection due to the fact that we created this web app to use individual accounts 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Add another GetConnection String to referance our DataBase
//connection string 
var connectionStringChinook = builder.Configuration.GetConnectionString("ChinookDB");

//Given for the db Connection to Defaultconnection string 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Code the dbConnection to the application db Context for chinook
//The implementation of the connect and registration of the chinook system services 
//Will be done in the ChinookSystem class library, to accomplish this task we will be using an extension method
//the extwnsion method will service the IserviceCollection 
//The extension requires a parameter options.useSqlServerxxx
//where xx is the connection sstring variable
//

//builder.Services.ChinookSystemBackendDependencies(options =>
//              options.UseSqlServer(connectionStringChinook));




builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
