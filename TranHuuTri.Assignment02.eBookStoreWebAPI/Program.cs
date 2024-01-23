using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using TranHuuTri.Assignment02.eBookStoreWebAPI.AutoMappers;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.BookAuthor;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Publisher;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Role;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.User;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.Repositories;
using TranHuuTri.Assignment02.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//======
builder.Services.AddDbContext<EBookStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookAuthorService, BookAuthorService>();

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Publisher>();
modelBuilder.EntityType<User>();
modelBuilder.EntityType<Book>();
modelBuilder.EntitySet<AuthorVM>("Authors");
modelBuilder.EntitySet<BookAuthorVM>("BookAuthors");
modelBuilder.EntitySet<PublisherVM>("Publishers");
modelBuilder.EntitySet<UserVM>("Users");
modelBuilder.EntitySet<BookVM>("Books");

//modelBuilder.EntitySet<RoleVM>("Roles");

builder.Services.AddControllers()
    .AddOData(
    options => options
    .Select()
    .Filter()
    .OrderBy()
    .Expand()
    .Count()
    .SetMaxTop(null)
    .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

builder.Services.AddAutoMapper(typeof(AutoMapping).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Minimal API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
