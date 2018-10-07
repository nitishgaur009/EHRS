using EHRS.BLL.Abstract;
using EHRS.BLL.AutoMapper;
using EHRS.BLL.Models;
using EHRS.DAL;
using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System.Text;

namespace EHRS.BLL.Concrete
{
    public class UserService : IUserService
    {
        IUserLoginRepository _userDataRepo;
        IUnitOfWork _unitOfWork;

        public UserService(IUserLoginRepository userRepo, IUnitOfWork unitOfWork)
        {
            _userDataRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public UserDataModel Login(LoginModel loginModel)
        {
            UserDataModel userDataModel = null;
            byte[] passwordByte = Encoding.ASCII.GetBytes(loginModel.Password);
            var userLoginEntity = _userDataRepo.SingleOrDefault(u => u.Email == loginModel.Email && u.Password == passwordByte);
            if (userLoginEntity != null)
            {
                userDataModel = Mapping.Mapper.Map<UserDataModel>(userLoginEntity);
                foreach(var role in userLoginEntity.UserRole)
                {
                    userDataModel.Roles.Add(Mapping.Mapper.Map<RoleModel>(role.Role));
                }
            }

            return userDataModel;
        }

        public bool RegisterUser(UserDataModel userDataModel, string password, UserDataModel loggedUser)
        {
            byte[] passwordByte = Encoding.ASCII.GetBytes(password);
            UserLogin userLoginEntity = Mapping.Mapper.Map<UserLogin>(userDataModel);
            userLoginEntity.Password = passwordByte;
            userLoginEntity.Active = true;

            foreach(var role in userDataModel.Roles)
            {
                userLoginEntity.UserRole.Add(new UserRole
                {
                    RoleId = role.Id
                });
            }

            _unitOfWork.UserLoginRepository.Add(userLoginEntity);

            return _unitOfWork.Complete() > 0;
        }
    }
}