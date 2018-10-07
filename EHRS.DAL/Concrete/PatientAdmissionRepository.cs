using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System.Data.Entity;

namespace EHRS.DAL.Concrete
{
    public class PatientAdmissionRepository : Repository<PatientAdmission>, IPatientAdmissionRepository
    {
        public PatientAdmissionRepository(EHRSdbContext context) : base(context)
        {

        }
    }
}
