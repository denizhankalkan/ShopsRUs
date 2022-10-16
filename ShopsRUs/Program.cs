using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopsRUs.Repository;
using ShopsRUs.Services;
using ShopsRUs.Services.Discounts;

static WebApplication BeanConfigure(WebApplicationBuilder appBuilder)
{
    appBuilder.Services.AddSingleton<ICustomerRepository, MockCustomerRepository>();
    appBuilder.Services.AddSingleton<IDiscountBillService, DiscountBillService>();
    appBuilder.Services.AddSingleton<ICustomerService, CustomerService>();
    appBuilder.Services.AddSingleton<IAmountDiscountService, AmountDiscountService>();
    appBuilder.Services.AddSingleton<IPercentsDiscountService, EmployeeDiscountService>();
    appBuilder.Services.AddSingleton<IPercentsDiscountService, AffiliateDiscountService>();
    appBuilder.Services.AddSingleton<IPercentsDiscountService, OverTwoYearsDiscountService>();
    
    appBuilder.Services.AddControllers();
    
    appBuilder.Services
        .Configure<JsonOptions>(
            o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    var webApplication = appBuilder.Build();
    return webApplication;
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var app = BeanConfigure(builder);

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
app.MapControllers();
app.UseAuthorization();
app.MapRazorPages();
app.Run();