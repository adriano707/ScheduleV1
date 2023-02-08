using FluentValidation;
using FluentValidation.AspNetCore;
using Schedule.API.V1.Configuration;
using Schedule.API.V1.Dtos;
using Schedule.API.V1.Identity;
using Schedule.API.V1.Settings;
using Schedule.API.V1.Swegger;
using Schedule.API.V1.Validations;
using Schedule.CrossCutting.Identity;
using Schedule.Data;
using Schedule.Data.Repositories;
using Schedule.Domain;
using Schedule.Domain.Entities.ScheduleAggregation.Services;
using Schedule.Domain.Entities.UserAggregation;
using Schedule.Domain.Entities.UserAggregation.Services;
using Schedule.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddAuthorizationConfiguration(builder.Configuration);

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddFluentValidation();
builder.Services.AddScoped<IValidator<CreateEventDto>, CreateEventValidation>();
builder.Services.AddScoped<IValidator<ScheduleDto>, CreateScheduleValidatio>();

builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSweggerConfiguration();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserIdentity, UserIdentity>();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors("corsapp");

app.MapControllers();

app.Run();
