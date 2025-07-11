using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IDoctorDal,DoctorDal>();

builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IBranchDal, BranchDal>();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientDal, PatientDal>();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentDal, AppointmentDal>();

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminDal, AdminDal>();

builder.Services.AddSession();



builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MainPage}/{action=Index}/{id?}");

app.Run();
