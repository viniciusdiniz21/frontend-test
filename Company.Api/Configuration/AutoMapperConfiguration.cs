using AutoMapper;
using CompanyApi.Api.ViewModel;
using CompanyApi.Domain.Entities;

namespace CompanyApi.Api.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Company, CompanyViewModel>();
        }
    }
}
