using Simplz.DND.Calculator.Components;

var builder = WebApplication.CreateBuilder(args);

var rolls = 100;

long a1Total = 0;
long a2Total = 0;
int abilityModifier = 5;
foreach (int i in Enumerable.Range(0, rolls))
{
    long a1 = 0;
    foreach (int j in Enumerable.Range(0, abilityModifier + 1))
    {
        var a = Random.Shared.NextInt64(1, 9);
        a1Total += a;
        a1 += a;
        if (a < 8)
            break;
    }

    var a2 = Random.Shared.NextInt64(1, 11);
    a2Total += a2;
    // Console.WriteLine($"a1: {a1}, a2: {a2}");
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
