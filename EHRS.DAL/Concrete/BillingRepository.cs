using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System.Data.Entity;

namespace EHRS.DAL.Concrete
{
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {
        public BillingRepository(DbContext context) : base(context)
        {

        }
    }
}
