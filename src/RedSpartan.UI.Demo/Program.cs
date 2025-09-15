using RedSpartan.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages (required for _Host.cshtml)
builder.Services.AddRazorPages();

// Add Blazor Server
builder.Services.AddServerSideBlazor();

// Add RedSpartan UI services
builder.Services.AddRedSpartanUI();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Map Razor Pages (for _Host.cshtml)
app.MapRazorPages();

// Map Blazor Hub
app.MapBlazorHub();

// Fallback to _Host page
app.MapFallbackToPage("/_Host");

app.Run();
