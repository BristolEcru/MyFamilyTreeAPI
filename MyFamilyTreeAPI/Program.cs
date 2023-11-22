using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain;
using MyFamilyTree.Domain.Repositories;

using MyFamilyTree.ApplicationServices.Mapping;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MyFamilyTree.Domain.Interfaces;
using MyFamilyTree.ApplicationServices.Validators;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.BaseClasses;
using MagazynEdu.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using MyFamilyTree.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
        });
});


builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddPersonValidator>());
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

builder.Services.AddAutoMapper(typeof(PeopleProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ResponseBase<>).GetTypeInfo().Assembly));
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
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();


app.UseAuthorization();
app.MapControllers();

app.Run();
