using BooksStore.DAO;
using BooksStore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookStoreDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDb")));

builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<CategoryRepository>();

builder.Services.AddTransient<AuthorService>();
builder.Services.AddTransient<AuthorRepository>();

builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<BookRepository>();

builder.Services.AddCors(o => o.AddPolicy("LowCorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


var app = builder.Build();

// initialize database using SeedData Seeder class
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("LowCorsPolicy");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
