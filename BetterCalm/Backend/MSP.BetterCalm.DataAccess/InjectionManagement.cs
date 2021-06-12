using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;

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
            services.AddScoped<IContentService,ContentService>();
            services.AddScoped<IPatientService,PatientService>();
            services.AddScoped<IPlaylistService,PlaylistService>();
            services.AddScoped<IPsychologistService,PsychologistService>();
            services.AddScoped<IAdministratorService,AdministratorService>();
            services.AddScoped<IVoucherService,VoucherService>();
            services.AddScoped<IImportService,ImportService>();
            
            services.AddScoped<ManagerProblematicRepository,ProblematicRepository>();
            services.AddScoped<ManagerCategoryRepository,CategoryRepository>();
            services.AddScoped<ManagerContentRepository,ContentRepository>();
            services.AddScoped<ManagerPatientRepository,PatientRepository>();
            services.AddScoped<ManagerPlaylistRepository,PlaylistRepository>();
            services.AddScoped<ManagerPsychologistRepository,PsychologistRepository>();
            services.AddScoped<ManagerAdministratorRepository, AdministratorRepository>();
            services.AddScoped<ManagerMeetingRepository, MeetingRepository>();
            services.AddScoped<ManagerVoucherRepository, VoucherRepository>();
           
            services.AddScoped<IMapper<Category, CategoryDto>,CategoryMapper>();
            services.AddScoped<IMapper<Problematic, ProblematicDto>,ProblematicMapper>();
            services.AddScoped<IMapper<Content, ContentDto>,ContentMapper>();
            services.AddScoped<IMapper<Playlist, PlaylistDto>,PlaylistMapper>();
            services.AddScoped<IMapper<Patient, PatientDto>, PatientMapper>();
            services.AddScoped<IMapper<Psychologist, PsychologistDto>, PsychologistMapper>();
            services.AddScoped<IMapper<Administrator, AdministratorDto>, AdministratorMapper>();
            services.AddScoped<IMapper<Voucher, VoucherDto>, VoucherMapper>();
            services.AddScoped<IMapper<Meeting, MeetingDto>, MeetingMapper>();
       }
        
        public void AddDbContext()
        {
         services.AddDbContext<ContextDb>();
        }
    }
}