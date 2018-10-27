class AppUrls {
    baseUrl = 'http://localhost:53205/';
    loginUrl = this.baseUrl + '/api/token';
    getUsers = this.baseUrl + '/api/User/GetAll';
    getUser = this.baseUrl + '/api/User/Get';
}

class AppConstants {
    private static _instance: AppConstants;
    public urls: AppUrls = new AppUrls();

    private constructor() {
        if (AppConstants._instance) {
            throw new Error('Error: Instantiation failed: Use AppConstants.getInstance() instead of new.');
        }
        AppConstants._instance = this;
    }

    public static getInstance(): AppConstants {
        return this._instance || new AppConstants();
    }
}

export enum PermissionsEnum {
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

export enum RoleEnum {
    Admin = 1,
    Patient = 2,
    Doctor = 3,
    LabTechnician = 4,
    Operator = 5,
    Accountant = 6,
    Compounder = 7
}

export const appConstants = AppConstants.getInstance();