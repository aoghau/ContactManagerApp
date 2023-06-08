using ContactManagerApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("ContactsDB");
builder.Services.AddDbContext<ContactDataContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseRouting();
app.MapControllers();

app.Run();
