using Menu_Repository;
using Menu_Server.BLL;
using Menu_Server.Components;
using Menu_Server.Domain;
using Microsoft.EntityFrameworkCore;
using Plk.Blazor.DragDrop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
  

builder.Services.AddDbContext<AppDBContext>( options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

builder.Services.AddMemoryCache();

builder.Services.AddBlazorDragDrop();

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Recipe>, RecipeRepository>();

builder.Services.AddScoped<IRepository<Ingredient>, IngredientRepository>();

builder.Services.AddScoped<DishSender>();

builder.Services.AddScoped<OrderReceiver>();

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
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();

app.Run();
