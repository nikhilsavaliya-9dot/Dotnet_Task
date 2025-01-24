using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System;
using test.Data;
using test.Extensions;
using test.Helpers;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:AppConnection"], options => options.EnableRetryOnFailure());
});

builder.Services.AddControllers();

// Add dependency injection services
builder.Services.AddDependencyInjection(configuration);
// Add JWT Bearer authentication
builder.Services.AddJwtBearerAuthentication(configuration);
// Get the base URL of the application (http(s)://www.api.com) from the HTTP Request and Context.
builder.Services.AddHttpContextAccessor();
// Configure JWT Bearer
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

// Multipart body length limit
builder.Services.Configure<FormOptions>(options =>
{
    // Set the limit to 104 MB
    options.MultipartBodyLengthLimit = 109051904; // Bytes
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandling();
}

app.UseHttpsRedirection();
app.UseJwt();
app.UseAuthorization();
app.MapControllers();
app.Run();
