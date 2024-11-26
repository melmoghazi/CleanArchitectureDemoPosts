using DemoPosts.Application.Contracts;
using DemoPosts.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DemoPosts.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PostConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPostRepository), typeof(PostRepository));

            return services;
        }
    }
}
