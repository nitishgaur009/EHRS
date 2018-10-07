
using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System.Data.Entity;

namespace EHRS.DAL.Concrete
{
    public class PatientAdmissionDetailRepository : Repository<PatientAdmissonDetail>, IPatientAdmissionDetailRepository
    {
        public PatientAdmissionDetailRepository(EHRSdbContext context) : base(context)
        {
        }
    }
}
