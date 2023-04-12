using devTestBackend.Entities.Data;
using devTestBackend.Repository;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        foreach (var repoType in typeof(GenericRepository<>).Assembly.ExportedTypes.Where(x => !x.IsGenericType))
        {
            var implementationType = repoType.GetInterfaces().FirstOrDefault(x => !x.IsGenericType);
            builder.Services.AddScoped(implementationType!, repoType);
        }

        builder.Services.AddDbContext<DevTestBackendContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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