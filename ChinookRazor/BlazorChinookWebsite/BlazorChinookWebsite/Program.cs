using BlazorChinookWebsite.Components;
using SmartComponents.Inference.OpenAI;
using SmartComponents.LocalEmbeddings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSmartComponents()
    .WithInferenceBackend<OpenAIInferenceBackend>();

builder.Services.AddSingleton<LocalEmbedder>();

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

var embedder = app.Services.GetRequiredService<LocalEmbedder>();
var artistlist = ChinookLibrary.Models.DbUtility.getArtists();
var listedTracks = embedder.EmbedRange(artistlist.ToArray());
app.MapSmartComboBox("/api/suggestions/artistlist",
    request => embedder.FindClosest(request.Query, listedTracks));


app.Run();