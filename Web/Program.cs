using System.Reflection;
using Web.Components;
using Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var groups = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => typeof(EndpointGroupBase).IsAssignableFrom(t) && !t.IsAbstract)
    .Select(t => (EndpointGroupBase)Activator.CreateInstance(t)!);

foreach (var group in groups)
{
    group.Map(app);
}

app.Run();

