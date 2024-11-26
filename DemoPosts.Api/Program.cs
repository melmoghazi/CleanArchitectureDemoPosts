
using DemoPosts.Application;
using DemoPosts.Persistence;

namespace DemoPosts.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<PostDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("PostConnectionString")));
            //builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            //builder.Services.AddScoped<IPostRepository, PostRepository>();
            //builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Add services to the container.

            //DI
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

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
}
