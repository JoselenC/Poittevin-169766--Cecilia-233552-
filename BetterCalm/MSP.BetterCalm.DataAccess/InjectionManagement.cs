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
            services.AddScoped<IPatientService,PatientService>();
            services.AddScoped<IPlaylistLogic,PlaylistLogic>();
            
            services.AddScoped<ManagerProblematicRepository,ProblematicRepository>();
            services.AddScoped<ManagerCategoryRepository,CategoryRepository>();
            services.AddScoped<ManagerSongRepository,SongRepository>();
            services.AddScoped<ManagerPatientRepository,PatientRepository>();
            services.AddScoped<ManagerPlaylistRepository,PlaylistRepository>();
            
            services.AddScoped<IMapper<Category, CategoryDto>,CategoryMapper>();
            services.AddScoped<IMapper<Problematic, ProblematicDto>,ProblematicMapper>();
            services.AddScoped<IMapper<Song, SongDto>,SongMapper>();
            services.AddScoped<IMapper<Playlist, PlaylistDto>,PlaylistMapper>();
            services.AddScoped<IMapper<Patient, PatientDto>, PatientMapper>();
        }
        
        public void AddDbContext()
        {
         services.AddDbContext<ContextDB>();
        }
    }
}