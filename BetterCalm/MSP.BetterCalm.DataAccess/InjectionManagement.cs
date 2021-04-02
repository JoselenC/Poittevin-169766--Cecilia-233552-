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
            services.AddScoped<CategoryRepository>();
            services.AddScoped<ProblematicRepository>();
            services.AddScoped<ManagerRepository>();
            services.AddScoped<IMapper<Category, CategoryDto>,CategoryMapper>();
            services.AddScoped<IMapper<Problematic, ProblematicDto>,ProblematicMapper>();
        }
        
        public void AddDbContext()
        {
         services.AddDbContext<ContextDB>();
        }
    }
}