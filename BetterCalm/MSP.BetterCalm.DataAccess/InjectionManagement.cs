using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    [ExcludeFromCodeCoverage]
    public class InjectionManagement
    {
        private IServiceCollection services;
        
        public InjectionManagement(IServiceCollection services)
        {
        this.services = services;
        }
        
        public void AddScopped()
        {
            services.AddScoped<ICategoryLogic,CategoryLogic>();
            services.AddScoped<IProblematicLogic,ProblematicLogic>();
            services.AddScoped<ISongLogic,SongLogic>();
            
            services.AddScoped<ManagerProblematicRepository,ProblematicRepository>();
            services.AddScoped<ManagerCategoryRepository,CategoryRepository>();
            services.AddScoped<ManagerSongRepository,SongRepository>();
            
            services.AddScoped<IMapper<Category, CategoryDto>,CategoryMapper>();
            services.AddScoped<IMapper<Problematic, ProblematicDto>,ProblematicMapper>();
            services.AddScoped<IMapper<Song, SongDto>,SongMapper>();
        }
        
        public void AddDbContext()
        {
         services.AddDbContext<ContextDB>();
        }
    }
}