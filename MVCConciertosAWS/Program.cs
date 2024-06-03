using Amazon.S3;
using MVCConciertosAWS.Helpers;
using MVCConciertosAWS.Models;
using MVCConciertosAWS.Services;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
string jsonSecrets = await HelperSecretManager.GetSecretsAsync();
KeysModel keysModel = JsonConvert.DeserializeObject<KeysModel>(jsonSecrets);
builder.Services.AddSingleton<KeysModel>(x => keysModel);
//builder.Services.AddAWSService<IAmazonS3>();
    
builder.Services.AddAWSService<IAmazonS3>();    
builder.Services.AddTransient<ServiceStorageAWS>();
builder.Services.AddTransient<ServiceApiConciertos>();
builder.Services.AddControllersWithViews();
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
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
