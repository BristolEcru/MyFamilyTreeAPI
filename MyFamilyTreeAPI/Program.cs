using Microsoft.EntityFrameworkCore;

using MediatR;
using MyFamilyTree.DataAccess;
using MyFamilyTree.DataAccess.Repositories;

using MyFamilyTree.ApplicationServices.Mapping;
using MyFamilyTree.DataAccess.CQRS.Queries.QueryManagement;
using MyFamilyTree.DataAccess.CQRS.Commands.CommandManagement;
using MyFamilyTree.ApplicationServices.API.Domain.Mediator.Handlers;
using MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

builder.Services.AddAutoMapper(typeof(PeopleProfile).Assembly);
builder.Services.AddMediatR(typeof(MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses.ResponseBase<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<PeopleCollectionDbContext>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("PeopleCollectionDatabaseConnection"));
    });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
