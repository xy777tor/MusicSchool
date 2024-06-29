using MusicSchool.DataAccess;
using MusicSchool.Application;
using MusicSchool.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEventWindowService, EventWindowService>();
builder.Services.AddSingleton<IEventWindowRepository, EventWindowRepositoryMock>();
builder.Services.AddDbContext<MusicSchoolContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("MusicSchoolContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
