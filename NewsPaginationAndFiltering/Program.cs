using BLL.IServices;
using BLL.Mapping;
using BLL.Services;
using DAL.IRepositories;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//var jsonNewsPath = Path.Combine(builder.Environment.ContentRootPath, "DAL", "JsonData", "anasayfa.json");
//builder.Services.AddSingleton<CategoryRepository>(new CategoryRepository(jsonNewsPath));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<INewsRepository, NewsRepository>();
builder.Services.AddTransient<INewsService, NewsService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<INewsDetailRepository, NewsDetailRepository>();
builder.Services.AddTransient<INewsDetailService, NewsDetailService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
