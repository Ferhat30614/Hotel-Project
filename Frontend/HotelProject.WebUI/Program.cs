using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Mapping;
using HotelProject.WebUI.ValidationRukes.GuestValidationRules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// Identyt için eklemeler 

builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
