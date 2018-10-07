using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using System.Data.Entity;

namespace EHRS.DAL.Concrete
{
    public class PatientLabReportBinaryDataRepository : Repository<PatientLabReportBinaryData>, IPatientLabReportBinaryDataRepository
    {
        public PatientLabReportBinaryDataRepository(EHRSdbContext context) : base(context)
        {
        }
    }
}
