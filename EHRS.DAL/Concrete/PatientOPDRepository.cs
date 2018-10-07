using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System.Data.Entity;

namespace EHRS.DAL.Concrete
{
    public class PatientOPDRepository : Repository<PatientOPD>, IPatientOPDRepository
    {
        public PatientOPDRepository(EHRSdbContext context) : base(context)
        {
        }
    }
}
