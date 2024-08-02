var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificationOrigins = "Permisos";

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app=>
                       
                        {

                            app.AllowAnyHeader().
                            AllowAnyMethod().
                            AllowAnyOrigin();
                        });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseCors("NuevaPolitica");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
