using Simplz.DND.Calculator.Components;

var builder = WebApplication.CreateBuilder(args);

var rolls = 10;

long a1Total = 0;
long a2Total = 0;
foreach(int i in Enumerable.Range(0, rolls))
{
    var a1 = Random.Shared.NextInt64(1, 9);
    if (a1 == 8)
        a1 += Random.Shared.NextInt64(1, 9);
    var a2 = Random.Shared.NextInt64(1, 11);
    a1Total += a1;
    a2Total += a2;
    Console.WriteLine($"a1: {a1}, a2: {a2}");
}
Console.WriteLine($"a1: {a1Total} ({a1Total / rolls})");
Console.WriteLine($"a2: {a2Total} ({a2Total / rolls})");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
