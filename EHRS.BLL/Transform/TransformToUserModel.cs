using EHRS.BLL.AutoMapper;
using EHRS.BLL.Models;
using EHRS.DAL.Entity;
using System.Collections.Generic;
using System.Linq;

namespace EHRS.BLL
{
    public static class TransformToUserModel
    {
        public static IEnumerable<UserModel> ToUserModel(this IEnumerable<UserLogin> usersEntity)
        {
            List<UserModel> usersModel = new List<UserModel>();

            foreach (var user in usersEntity)
            {
                UserModel userModel = Mapping.Mapper.Map<UserModel>(user);
                userModel.Roles = user.UserRole.Select(u => new RoleModel {
                    Id = u.RoleId,
                    Name = u.Role.Name
                }).ToList();

                usersModel.Add(userModel);
            }

            return usersModel;
        }
    }
}