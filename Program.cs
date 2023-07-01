using DemoNorthwindWithEF.Bussiness.Mapping;
using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.Bussiness.Repository;
using ProjectPRN_FAP.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped(typeof(ISemesterRepository), typeof(SemesterRepository));

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnectString")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnectString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
