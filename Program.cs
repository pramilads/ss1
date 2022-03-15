
using Microsoft.EntityFrameworkCore;
using SchoolHealthReporting;


//using Microsoft.EntityFrameworkCore;
//using SchoolHealthReporting;
using SchoolHealthReporting.Data;

//var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

//var builder = WebApplication.CreateBuilder(args);
//ConfigurationManager configuration = builder.Configuration;

//// Add services to the container.
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


////var startup = new Startup(builder.Configuration);
////startup.ConfigureServices(builder.Services);


//// Add services to the container.
////builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<SchoolReportDBContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
//});

////Enable CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: myAllowSpecificOrigins, builder =>
//    {
//        builder.WithOrigins("http://localhost:4200")
//        .AllowAnyMethod()
//        .AllowAnyHeader();
//    });
//}); 

//var app = builder.Build();


//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//   // app.UseHsts();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseHttpsRedirection();
//app.UseCors(myAllowSpecificOrigins);

//app.UseAuthorization();
//app.MapControllers();

////app.Use(async (context, next) => {
////    await next();

////    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
////    {
////        context.Request.Path = "/index.html";
////        await next();
////    }
////});


////app.UseStaticFiles();
////app.UseRouting();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html"); ;



//app.Run();



var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<SchoolReportDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SCHDatabase"));
});

//Enable CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: myAllowSpecificOrigins, builder =>
//    {
//        builder.WithOrigins("http://localhost:4200")
//        .AllowAnyMethod()
//        .AllowAnyHeader();
//    });
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);


app.UseAuthorization();

app.MapControllers();

app.Run();
