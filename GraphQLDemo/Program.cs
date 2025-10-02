using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite();
});

builder.Services.AddScoped<IBookRepository, BookRepository>();


var app = builder.Build();

app.MapGraphQL();

app.Run();
