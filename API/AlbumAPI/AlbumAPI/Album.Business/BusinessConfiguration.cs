
using Album.Business.Album;
using Microsoft.Extensions.DependencyInjection;

namespace Album.Business
{
    public static class BusinessConfiguration
    {
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services)
        {            
            services.AddScoped<IAlbumBL, AlbumBL>();                   
            return services;
        }

    }
}