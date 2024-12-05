var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache(); // Necesario para sesiones en memoria
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Ejemplo.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(1000); // Tiempo de inactividad antes de que la sesión expire
    options.Cookie.HttpOnly = true; // Asegura que solo se pueda acceder a la cookie desde el servidor
    options.Cookie.IsEssential = true; // Asegura que la cookie esté disponible para el cumplimiento de GDPR
});




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

app.UseSession(); // Habilitar el middleware de sesiones

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();

