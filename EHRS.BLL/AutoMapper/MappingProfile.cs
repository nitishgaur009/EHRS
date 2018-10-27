using AutoMapper;
using EHRS.BLL.Models;
using EHRS.DAL.Entity;

namespace EHRS.BLL.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserLogin, UserAuthDataModel>();
            CreateMap<UserAuthDataModel, UserLogin>();
            CreateMap<UserLogin, UserModel>();
            CreateMap<UserModel, UserLogin>();
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();
        }
    }
}