var builder = WebApplication.CreateBuilder(args);

// Configuración del puerto personalizado
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5116); // Puerto para el frontend
});

// Agregar HttpClient para la comunicación con la API
builder.Services.AddHttpClient("ProductsApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5245/"); // URL de la API
});

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 días
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
