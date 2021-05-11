using System.Diagnostics.CodeAnalysis;
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
            
            services.AddScoped<IGuidService,GuidService>();
            
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IProblematicService,ProblematicService>();
            services.AddScoped<IAudioService,AudioService>();
            services.AddScoped<IPatientService,PatientService>();
            services.AddScoped<IPlaylistService,PlaylistService>();
            services.AddScoped<IPsychologistService,PsychologistService>();
            services.AddScoped<IAdministratorService,AdministratorService>();

            services.AddScoped<ManagerProblematicRepository,ProblematicRepository>();
            services.AddScoped<ManagerCategoryRepository,CategoryRepository>();
            services.AddScoped<ManagerAudioRepository,AudioRepository>();
            services.AddScoped<ManagerPatientRepository,PatientRepository>();
            services.AddScoped<ManagerPlaylistRepository,PlaylistRepository>();
            services.AddScoped<ManagerPsychologistRepository,PsychologistRepository>();
            services.AddScoped<ManagerAdministratorRepository, AdministratorRepository>();
            services.AddScoped<ManagerMeetingRepository, MeetingRepository>();
            services.AddScoped<ManagerVideoRepository, VideoRepository>();
            
            services.AddScoped<IMapper<Category, CategoryDto>,CategoryMapper>();
            services.AddScoped<IMapper<Problematic, ProblematicDto>,ProblematicMapper>();
            services.AddScoped<IMapper<Audio, AudioDto>,AudioMapper>();
            services.AddScoped<IMapper<Playlist, PlaylistDto>,PlaylistMapper>();
            services.AddScoped<IMapper<Patient, PatientDto>, PatientMapper>();
            services.AddScoped<IMapper<Psychologist, PsychologistDto>, PsychologistMapper>();
            services.AddScoped<IMapper<Administrator, AdministratorDto>, AdministratorMapper>();
            services.AddScoped<IMapper<Meeting, MeetingDto>, MeetingMapper>();
            services.AddScoped<IMapper<Video, VideoDto>, VideoMapper>();
        }
        
        public void AddDbContext()
        {
         services.AddDbContext<ContextDB>();
        }
    }
}