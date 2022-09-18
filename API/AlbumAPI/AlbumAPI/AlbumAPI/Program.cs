using Album.Business;
using Album.Data;
using AlbumAPI.Extension;
using AlbumAPI.Middleware;
using AlbumAPI.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddContextConfiguration(builder.Configuration);
builder.Services.AddDataConfiguration();
builder.Services.AddBusinessConfiguration();
builder.Services.AddLogging(config =>
{
    config.ClearProviders();
    config.AddConsole();
    config.AddFile(builder.Configuration);
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

app.UseExceptionHandler(appError =>
{
    appError.Run(async (context) =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            var errorDetail = new ErrorDetails();
            errorDetail.StatusCode = context.Response.StatusCode;
            errorDetail.Message = "Internal Server Error.";

            if (errorDetail != null) {

                await context.Response.WriteAsJsonAsync<ErrorDetails>(errorDetail);               
            }            
            app.Logger.LogError($"Something went wrong: {contextFeature.Error}");
        }
    });
});

app.UseRequestLogger();

app.Run();
