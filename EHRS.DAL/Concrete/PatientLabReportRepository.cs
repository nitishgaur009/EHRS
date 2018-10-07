
using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System.Data.Entity;

namespace EHRS.DAL.Concrete
{
    public class PatientLabReportRepository : Repository<PatientLabReport>, IPatientLabReportRepository
    {
        public PatientLabReportRepository(EHRSdbContext context) : base(context)
        {
        }
    }
}
