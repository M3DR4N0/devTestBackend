using devTestBackend.Contract.Repository;
using devTestBackend.Contract.Service;
using devTestBackend.Entities.Data;
using devTestBackend.Repository;
using devTestBackend.Service.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DevTestBackendContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        foreach (var repoType in typeof(GenericRepository<>).Assembly.ExportedTypes.Where(x => !x.IsGenericType))
        {
            var implementationType = repoType.GetInterfaces().FirstOrDefault(x => !x.IsGenericType);
            builder.Services.AddScoped(implementationType!, repoType);
        }

        builder.Services.AddScoped<AnnouncementInnerService>();
        builder.Services.AddScoped<IAnnouncementService>(provider =>
        {
            var inner = provider.GetService<AnnouncementInnerService>()!;
            var validation = new AnnouncementValidationService(inner, provider.GetService<IAnnouncementRepository>()!);

            return new AnnouncementErrorService(validation);
        });

        // Add services to the container.

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
    }
}