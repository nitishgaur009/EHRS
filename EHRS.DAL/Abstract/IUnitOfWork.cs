using System;
using EHRS.DAL.Abstract;
using System.Threading.Tasks;

namespace EHRS.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IBillingRepository BillingRepository { get; }
        IPatientAdmissionRepository PatientAdmissionRepository { get; }
        IPatientAdmissionDetailRepository PatientAdmissionDetailRepository { get; }
        IPatientLabReportRepository PatientLabReportRepository { get; }
        IPatientLabReportBinaryDataRepository PatientLabReportBinaryDataRepository { get; }
        IPatientOPDRepository PatientOPDRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IUserLoginRepository UserLoginRepository { get; }

        int Complete();

        Task<int> CompleteAsync();
    }
}