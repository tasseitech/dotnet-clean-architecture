namespace TasseiTech.Sample.Core.Domain.Enums;
public enum ErrorCodeEnum
{
    // NOTE: General (1000 - 1099)
    CodeRequired = 1000,
    CodeLength10 = 1001,
    RecordNotFound = 1050,
    TitleRequired = 1060,

    // NOTE: Date and Remarks (1100 - 1999)
    InvalidDate = 1100,
    DescriptionRequired = 1130,
    DescriptionLength100 = 1131,

    // NOTE: Employee Details (2000 - 2999)
    FirstNameRequired = 2000,
    FirstNameLength50 = 2001,
    MiddleNameLength50 = 2002,
    LastNameRequired = 2003,
    LastNameLength50 = 2004,
    InvalidGenderType = 2005,
    InvalidEmployeeStatus = 2006,
    InvalidEmploymentType = 2007,
    InvalidEmployee = 2008,
    InvalidMaritalStatus = 2009,
    JobTitleLength50 = 2010,
    InvalidTitle = 2011,
    LastHireDateCannotBeLessThanStartDate = 2012,
    TerminationDateGreaterThanLastHireDate = 2013,
    InvalidEmployeeId = 2014,
    InvalidCompanyEmailAddress = 2015,
    InvalidPersonalEmailAddress = 2016,
    CompanyEmailRequired = 2017,
    CompanyEmailLength255 = 2018,
    PersonalEmailRequired = 2095,
    PersonalEmailLength255 = 2096,
    MobileNoLength15 = 2020,
    EmployeeWorkSummeryIsNotSetuped = 2035,
    EmployeeIsNotSetuped = 2100,
    CompanyEmailAlreadyExists = 2050,
    PersonalEmailAlreadyExists = 2060,
    InvalidPayrollCycle = 2090,
    InvalidEmployeeWorkSummary = 2105,
    // NOTE: Address Details (3000 - 3999)
    Address1Length50 = 3000,
    Address2Length50 = 3001,
    CityLength50 = 3002,
    PostalCodeLength10 = 3003,

    // NOTE: Country (4000 - 4999)
    InvalidCountry = 4000,

    // NOTE: Financial Details (5000 - 5999)
    InvalidAmount = 5000,
    AccountNameLength100 = 5051,
    BankNameLength100 = 5052,
    InvalidPayType = 5053,
    InvalidOvertimePay = 5054,
    InvalidBasicPay = 5055,
    InvalidSalaryType = 5056,
    BankNameLength50 = 5057,
    AccountNameLength50 = 5058,
    AccountNoLength = 5024,
    InvalidCurrency = 5022,
    InvalidPaymentType = 5023,
    InvalidPayFrequency = 5033,
    BankNameRequired = 5050,
    AccountNoRequired = 5060,
    AccountNameRequired = 5065,

    // NOTE: Payroll Details (6000 - 6999)
    InvalidPayrollPeriod = 6000,
    InvalidTotalBasicHours = 6001,
    InvalidTotalOvertimeHours = 6002,
    InvalidTotalLeaveHours = 6003,
    InvalidPayrollPeriodId = 6004,
    PaymentRateIsNotSetuped = 6006,
    PayrollCycleAssignedToEmployees = 6060,
    InvalidPayrollCycleId = 6065,

    // NOTE: User Details (7000-7999)
    UserNameRequired = 7000,
    UserNameLengthExceeded = 7010,
    PasswordRequired = 7020,
    PasswordLengthExceeded = 7030,
    InvalidUserId = 7031,
    MissingUserToken = 7032,
    InvalidUserToken = 7033,
    UserTokenNotFound = 7034,
    UserNotFound = 7035,
    InvalidPassword = 7036,

    // NOTE: PayShedule Details(8000-8999)
    InvalidPayAdjustmentType = 8000,
    InvalidPayAdjustmentName = 8005,
    InvalidPayAdjustmentAmount = 8010,
    InvalidPayAdjustmentClass = 8020,
    PayAdjustmentsNotSetuped = 8021,
    OrderIsExist = 8023,
    InvalidPayAdjustmentOrder = 8024,
    InvalidPayAdjustment = 8025,
    InvalidOrderIndex = 8028,
}
