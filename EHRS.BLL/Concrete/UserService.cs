using EHRS.BLL.Abstract;
using EHRS.BLL.AutoMapper;
using EHRS.BLL.Models;
using EHRS.Common.Enums;
using EHRS.DAL;
using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public UserAuthDataModel Login(LoginModel loginModel)
        {
            UserAuthDataModel userDataModel = null;
            byte[] passwordByte = Encoding.ASCII.GetBytes(loginModel.Password);
            var userLoginEntity = _userDataRepo.SingleOrDefault(u => u.Email == loginModel.Email && u.Password == passwordByte);
            if (userLoginEntity != null)
            {
                userDataModel = Mapping.Mapper.Map<UserAuthDataModel>(userLoginEntity);
                userDataModel.Roles = GetPermissions(userLoginEntity).ToList();
            }

            return userDataModel;
        }

        public bool RegisterUser(UserAuthDataModel userDataModel, string password, UserAuthDataModel loggedUser)
        {
            byte[] passwordByte = Encoding.ASCII.GetBytes(password);
            UserLogin userLoginEntity = Mapping.Mapper.Map<UserLogin>(userDataModel);
            userLoginEntity.Password = passwordByte;
            userLoginEntity.Active = true;

            foreach(var role in userDataModel.Roles)
            {
                //userLoginEntity.UserRole.Add(new UserRole
                //{
                //    RoleId = role.Id
                //});
            }

            _unitOfWork.UserLoginRepository.Add(userLoginEntity);

            return _unitOfWork.Complete() > 0;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
           return _userDataRepo.GetAll().ToUserModel();
        }

        private IEnumerable<string> GetPermissions(UserLogin userLoginEntity)
        {
            IEnumerable<string> permissions = new List<string>();
            if(userLoginEntity.UserRole.FirstOrDefault(ur => ur.Id == (int)RoleEnum.Admin) != null)
            {
                permissions = Enum.GetNames(typeof(PermissionsEnum)).ToList();
            }
            else
            {
                foreach (var role in userLoginEntity.UserRole)
                {
                    permissions = permissions.Union(GetPermissionOnRole((RoleEnum)role.Id));
                }
            }

            return permissions;
        }

        private IEnumerable<string> GetPermissionOnRole(RoleEnum role)
        {
            IEnumerable<string> permissions = new List<string>();

            switch(role)
            {
                case RoleEnum.Operator:
                    permissions = new List<string>
                    {
                        PermissionsEnum.CanManagePatients.ToString(),
                        PermissionsEnum.CanSchedulePatientOPD.ToString(),
                        PermissionsEnum.CanSchedulePatientAdmission.ToString(),
                        PermissionsEnum.CanViewAllPatientsHealthRecords.ToString()
                    };
                    break;

                case RoleEnum.Compounder:
                    permissions = new List<string>
                    {
                        PermissionsEnum.CanUpdateAdmittedPatientData.ToString()
                    };
                    break;

                case RoleEnum.Doctor:
                    permissions = new List<string>
                    {
                        PermissionsEnum.CanUpdateAdmittedPatientData.ToString(),
                        PermissionsEnum.CanUpdatePatientOpdData.ToString(),
                        PermissionsEnum.CanViewAllPatientsHealthRecords.ToString()
                    };
                    break;

                case RoleEnum.LabTechnician:
                    permissions = new List<string>
                    {
                        PermissionsEnum.CanUpdatePatientLabReport.ToString()
                    };
                    break;

                case RoleEnum.Accountant:
                    permissions = new List<string>
                    {
                        PermissionsEnum.CanManageBilling.ToString()
                    };
                    break;

                case RoleEnum.Patient:
                    permissions = new List<string>
                    {
                        PermissionsEnum.CanViewOwnHealthRecord.ToString()
                    };
                    break;
            }

            return permissions;
        }
    }
}