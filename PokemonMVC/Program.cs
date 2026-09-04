using PokemonMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Adding services to the container.
// Enables MVC controller and Razor views
builder.Services.AddControllersWithViews();
// registers IHttpclientFactory, which is the recommended way to use HttpClient in .NET Core applications.
// It manages the lifecycle of HttpClient instances and helps avoid common issues like socket exhaustion.
builder.Services.AddHttpClient();
// Tells dependency injection to provide an instance of PokemonService whenever IPokemonService is requested.
builder.Services.AddScoped<IPokemonService, PokemonService>(); // PokemonService yet to come

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
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();