using EHRS.BLL.Abstract;
using EHRS.BLL.Models;
using EHRS.DAL.Abstract;
using EHRS.DAL;
using AutoMapper;
using EHRS.DAL.Entity;

namespace EHRS.BLL.Concrete
{
    public class UserService : IUserService
    {
        IUserLoginRepository _userDataRepo;
        IUnitOfWork _unitOfWork;

        public UserService(IUserLoginRepository repo, IUnitOfWork unitOfWork)
        {
            _userDataRepo = repo;
            _unitOfWork = unitOfWork;
        }

        public UserService()
        {

        }

        public UserLoginModel Login(string email, string password)
        {
            UserLoginModel userLoginModel = null;
            byte[] passwordByte = new byte[] { };//= Convert.ToSByte(password);
            var userLoginEntity = _userDataRepo.SingleOrDefault(u => u.Email == email && u.Password == passwordByte);
            if (userLoginEntity != null)
            {
                userLoginModel = Mapper.Map<UserLoginModel>(userLoginEntity);
            }

            return userLoginModel;
        }

        public bool RegisterUser(UserLoginModel userLoginModel, string password)
        {
            byte[] passwordByte = new byte[] { };//= Convert.ToSByte(password);
            UserLogin userLoginEntity = Mapper.Map<UserLogin>(userLoginModel);

            userLoginEntity.Password = passwordByte;
            // _unitOfWork.UserLoginRepository.Add(userLoginEntity);
            //return _unitOfWork.Complete() > 0;        

            return true;   
        }
    }
}
