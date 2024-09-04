using EduQuest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//To use angular as UI
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "Client/dist/Client/browser";
});
//builder.Services.AddSerilog();

//Register db context
builder.Services.AddDbContext<EduQuestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EduQuestConnStr"))
);

var app = builder.Build();

var env = app.Environment;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Use custom exception handler middleware early in the pipeline
    app.UseExceptionHandler("/Home/error"); // Custom path or middleware
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//To use angular as UI
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "Client/dist/Client/browser"; //this will be used for production...

    if (env.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer(builder.Configuration["SpaBaseUrl"] ?? "http://localhost:4200");
    }
});

app.Run();
