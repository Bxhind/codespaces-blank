using LibraryApp.Data;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// use SQLite for local development to avoid external SQL Server dependency
#if DEBUG
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite("Data Source=library.db"));
#else
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endif

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ReaderService>();
builder.Services.AddScoped<LoanService>();

builder.Services.AddSession();

var app = builder.Build();

// create DB if missing
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "byAuthor",
    pattern: "books/by-author/{author}",
    defaults: new { controller = "Books", action = "ByAuthor" });

app.MapControllerRoute(
    name: "readerHistory",
    pattern: "readers/history/{id}",
    defaults: new { controller = "Readers", action = "History" });

app.MapControllerRoute(
    name: "activeLoans",
    pattern: "loans/active",
    defaults: new { controller = "Loans", action = "Active" });

app.Run();