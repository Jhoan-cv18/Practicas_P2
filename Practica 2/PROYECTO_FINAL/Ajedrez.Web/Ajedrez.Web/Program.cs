var builder = WebApplication.CreateBuilder(args);

// AGREGAR SERVICIOS AQUÍ
builder.Services.AddControllersWithViews();

// Registrar HttpClient AQUI, ANTES DEL BUILD
builder.Services.AddHttpClient("api", client =>
{
    client.BaseAddress = new Uri("http://localhost:5025/"); 
});

var app = builder.Build();

// CONFIGURACIÓN
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// RUTA PRINCIPAL
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
