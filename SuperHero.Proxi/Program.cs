using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var proxiBuilder = builder.Services.AddReverseProxy();

proxiBuilder.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseRouting();
app.MapReverseProxy();

app.Run();
