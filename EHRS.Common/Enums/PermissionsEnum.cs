namespace EHRS.Common.Enums
{
    public enum PermissionsEnum
    {
        CanManageDoctors = 1,
        CanManagePatients = 2,
        CanManageOperators = 3,
        CanManageLabTechnicians = 4,
        CanManageAccountants = 5,
        CanManageCompounders = 6,
        CanManageBilling = 7,
        CanSchedulePatientOPD = 8,
        CanSchedulePatientAdmission = 9,
        CanUpdateAdmittedPatientData = 10,
        CanUpdatePatientLabReport = 11,
        CanUpdatePatientOpdData = 12,
        CanViewAllPatientsHealthRecords = 13,
        CanViewOwnHealthRecord = 14,
        CanOperateAllUser = 15,
        CanRegisterPatient = 16
    }
}