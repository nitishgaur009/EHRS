using EHRS.DAL.Abstract;
using EHRS.DAL.Entity;
using EHRS.DAL.Concrete;

namespace EHRS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private EHRSdbContext _context;

        public UnitOfWork(EHRSdbContext context)
        {
            _context = context;
        }

        public IBillingRepository BillingRepository
        {
            get
            {
                return new BillingRepository(_context);
            }
        }

        public IPatientAdmissionDetailRepository PatientAdmissionDetailRepository
        {
            get
            {
                return new PatientAdmissionDetailRepository(_context);
            }
        }

        public IPatientAdmissionRepository PatientAdmissionRepository
        {
            get
            {
                return new PatientAdmissionRepository(_context);
            }
        }

        public IPatientLabReportBinaryDataRepository PatientLabReportBinaryDataRepository
        {
            get
            {
                return new PatientLabReportBinaryDataRepository(_context);
            }
        }

        public IPatientLabReportRepository PatientLabReportRepository
        {
            get
            {
                return new PatientLabReportRepository(_context);
            }
        }

        public IPatientOPDRepository PatientOPDRepository
        {
            get
            {
                return new PatientOPDRepository(_context);
            }
        }

        public IUserLoginRepository UserLoginRepository
        {
            get
            {
                return new UserLoginRepository(_context);
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                return new UserRoleRepository(_context);
            }
        }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
