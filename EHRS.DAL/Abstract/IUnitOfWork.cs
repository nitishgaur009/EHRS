using System;
using EHRS.DAL.Abstract;

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
    }
}