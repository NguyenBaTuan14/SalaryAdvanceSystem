using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Components;
using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.Mapping;
using SalaryAdvanceSource.Services;

var builder = WebApplication.CreateBuilder(args);

// Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // nếu chưa login thì redirect về /login
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<Idpsalary>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")!));


builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IEmployeesService, EmployeesService>();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped< AuthService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<UserState>();

builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
