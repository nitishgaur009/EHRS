using AutoMapper;
using EHRS.BLL.Models;
using EHRS.DAL.Entity;

namespace EHRS.BLL.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserLogin, UserLoginModel>();
            CreateMap<UserLoginModel, UserLogin>();
        }
    }
}