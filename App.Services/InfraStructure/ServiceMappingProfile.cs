using App.Data.Models;
using AutoMapper;

namespace App.Services.InfraStructure
{
    class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            //this.CreateMap<Article, ArticleListingServiceModel>()
            //    .ForMember(m => m.AuthorName, cfg => cfg.MapFrom(a => a.Author.UserName));

            
        }
    }
}
