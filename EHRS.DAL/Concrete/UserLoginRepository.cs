using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System.Data.Entity;

namespace EHRS.DAL.Concrete
{
    public class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(EHRSdbContext context) : base(context)
        {
        }
    }
}
