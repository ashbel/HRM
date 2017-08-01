
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2017 09:00:49
-- Generated from EDMX file: C:\Users\Ashbel\documents\visual studio 2012\Projects\Hrm System\Hrm System\Models\MySqlModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[iohr].[tblachievements]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblachievements];
GO
IF OBJECT_ID(N'[iohr].[tblannouncement]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblannouncement];
GO
IF OBJECT_ID(N'[iohr].[tblassignments]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblassignments];
GO
IF OBJECT_ID(N'[iohr].[tblbankaccounttype]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblbankaccounttype];
GO
IF OBJECT_ID(N'[iohr].[tblbanks]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblbanks];
GO
IF OBJECT_ID(N'[iohr].[tblbloodgroop]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblbloodgroop];
GO
IF OBJECT_ID(N'[iohr].[tblcompany]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblcompany];
GO
IF OBJECT_ID(N'[iohr].[tblcompanytype]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblcompanytype];
GO
IF OBJECT_ID(N'[iohr].[tblcomplaint]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblcomplaint];
GO
IF OBJECT_ID(N'[iohr].[tblcontract]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblcontract];
GO
IF OBJECT_ID(N'[iohr].[tblcontracttype]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblcontracttype];
GO
IF OBJECT_ID(N'[iohr].[tblcountries]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblcountries];
GO
IF OBJECT_ID(N'[iohr].[tblcurrency]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblcurrency];
GO
IF OBJECT_ID(N'[iohr].[tbldepartment]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tbldepartment];
GO
IF OBJECT_ID(N'[iohr].[tblemployee]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblemployee];
GO
IF OBJECT_ID(N'[iohr].[tblemployeecategory]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblemployeecategory];
GO
IF OBJECT_ID(N'[iohr].[tblemployeedesignation]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblemployeedesignation];
GO
IF OBJECT_ID(N'[iohr].[tblemployeeexit]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblemployeeexit];
GO
IF OBJECT_ID(N'[iohr].[tblemployeetype]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblemployeetype];
GO
IF OBJECT_ID(N'[iohr].[tblexittype]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblexittype];
GO
IF OBJECT_ID(N'[iohr].[tblgender]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblgender];
GO
IF OBJECT_ID(N'[iohr].[tblgrade]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblgrade];
GO
IF OBJECT_ID(N'[iohr].[tblmaritalstatus]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblmaritalstatus];
GO
IF OBJECT_ID(N'[iohr].[tblmemo]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblmemo];
GO
IF OBJECT_ID(N'[iohr].[tblnationality]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblnationality];
GO
IF OBJECT_ID(N'[iohr].[tblperformanceevaluation]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblperformanceevaluation];
GO
IF OBJECT_ID(N'[iohr].[tblpriority]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblpriority];
GO
IF OBJECT_ID(N'[iohrModelStoreContainer].[tblprojects]', 'U') IS NOT NULL
    DROP TABLE [iohrModelStoreContainer].[tblprojects];
GO
IF OBJECT_ID(N'[iohr].[tblpromotions]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblpromotions];
GO
IF OBJECT_ID(N'[iohr].[tblreligion]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblreligion];
GO
IF OBJECT_ID(N'[iohr].[tblresignation]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblresignation];
GO
IF OBJECT_ID(N'[iohr].[tblsalutation]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblsalutation];
GO
IF OBJECT_ID(N'[iohr].[tblstation]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblstation];
GO
IF OBJECT_ID(N'[iohr].[tblstationtype]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblstationtype];
GO
IF OBJECT_ID(N'[iohr].[tbltermination]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tbltermination];
GO
IF OBJECT_ID(N'[iohr].[tblterminationtype]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblterminationtype];
GO
IF OBJECT_ID(N'[iohr].[tbltimezone]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tbltimezone];
GO
IF OBJECT_ID(N'[iohr].[tbltransfers]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tbltransfers];
GO
IF OBJECT_ID(N'[iohr].[tblwarning]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblwarning];
GO
IF OBJECT_ID(N'[iohr].[tblwarningtype]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblwarningtype];
GO
IF OBJECT_ID(N'[iohr].[tblworkshifts]', 'U') IS NOT NULL
    DROP TABLE [iohr].[tblworkshifts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblachievements'
CREATE TABLE [dbo].[tblachievements] (
    [id] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [FwdApplnTo] varchar(10)  NULL,
    [AchievementTitle] varchar(30)  NOT NULL,
    [AchievementDate] datetime  NOT NULL,
    [AchievementDescription] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblannouncements'
CREATE TABLE [dbo].[tblannouncements] (
    [id] int IDENTITY(1,1) NOT NULL,
    [title] varchar(30)  NOT NULL,
    [sendByEmail] bit  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [companyId] bigint  NULL,
    [stationId] bigint  NULL,
    [departmentId] int  NULL,
    [message] varchar(1000)  NOT NULL,
    [notes] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblassignments'
CREATE TABLE [dbo].[tblassignments] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [AssignedTo] varchar(10)  NOT NULL,
    [ProjectID] varchar(15)  NOT NULL,
    [AssignmentName] varchar(30)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [DueDate] datetime  NULL,
    [PriorityID] int  NOT NULL,
    [AssignmentEmployees] varchar(1000)  NULL,
    [AssignmentDescription] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblbankaccounttypes'
CREATE TABLE [dbo].[tblbankaccounttypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [BankAccountType] varchar(20)  NOT NULL
);
GO

-- Creating table 'tblbanks'
CREATE TABLE [dbo].[tblbanks] (
    [id] int IDENTITY(1,1) NOT NULL,
    [BankName] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblbloodgroops'
CREATE TABLE [dbo].[tblbloodgroops] (
    [id] int IDENTITY(1,1) NOT NULL,
    [BloodGroup] varchar(5)  NOT NULL
);
GO

-- Creating table 'tblcompanies'
CREATE TABLE [dbo].[tblcompanies] (
    [companyId] bigint IDENTITY(1,1) NOT NULL,
    [companyName] varchar(50)  NOT NULL,
    [legalTradingName] varchar(50)  NOT NULL,
    [registrationNumber] varchar(35)  NULL,
    [companyType] int  NULL,
    [companyLogo] varbinary(8000)  NULL,
    [contactPerson] varchar(35)  NULL,
    [contactDesignation] varchar(35)  NULL,
    [contactNumber] varchar(20)  NULL,
    [faxNumber] varchar(20)  NULL,
    [emailAddress] varchar(35)  NULL,
    [website] varchar(35)  NULL,
    [gvntTaxNumber] varchar(20)  NULL,
    [stateTaxNumber] varchar(20)  NULL,
    [companyPostalAddress] varchar(50)  NOT NULL,
    [companyPostalCity] varchar(30)  NOT NULL,
    [companyPostalProvince] varchar(30)  NOT NULL,
    [zipPostalCode] varchar(5)  NULL,
    [companyPostalCountry] int  NOT NULL,
    [companyPhyAddress] varchar(50)  NOT NULL,
    [companyPhyCity] varchar(30)  NOT NULL,
    [companyPhyProvince] varchar(30)  NOT NULL,
    [zipPhyPostalCode] varchar(5)  NULL,
    [companyPhyCountry] int  NOT NULL,
    [bankName] varchar(30)  NULL,
    [bankAccountTitle] varchar(30)  NULL,
    [bankAccountNumber] varchar(30)  NULL,
    [bankRoutingNumber] varchar(30)  NULL,
    [companyVision] varchar(1000)  NULL,
    [companyMission] varchar(1000)  NULL,
    [companyProfile] varchar(1000)  NULL,
    [additionalInformation] varchar(1000)  NULL,
    [inputter] varchar(30)  NULL,
    [dateAdded] datetime  NULL,
    [bankAccountType] int  NULL
);
GO

-- Creating table 'tblcompanytypes'
CREATE TABLE [dbo].[tblcompanytypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [description] varchar(30)  NOT NULL
);
GO

-- Creating table 'tblcomplaints'
CREATE TABLE [dbo].[tblcomplaints] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [FwdApplnTo] varchar(10)  NULL,
    [ComplaintTitle] varchar(30)  NOT NULL,
    [ComplaintDate] datetime  NOT NULL,
    [ComplaintAgainst] varchar(1000)  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblcontracts'
CREATE TABLE [dbo].[tblcontracts] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [ContractType] int  NOT NULL,
    [ContractTitle] varchar(20)  NOT NULL,
    [ContractStartDate] datetime  NULL,
    [ContractEndDate] datetime  NULL,
    [EmployeeDesignation] int  NOT NULL,
    [EmployeeType] int  NOT NULL,
    [EmployeeCategory] int  NOT NULL,
    [EmployeeGrade] int  NOT NULL,
    [Sation] bigint  NOT NULL,
    [Department] int  NOT NULL,
    [ContractDescription] varchar(1000)  NOT NULL,
    [AdditionalInformation] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblcontracttypes'
CREATE TABLE [dbo].[tblcontracttypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ContractType] varchar(20)  NOT NULL,
    [Desc] varchar(30)  NOT NULL
);
GO

-- Creating table 'tblcountries'
CREATE TABLE [dbo].[tblcountries] (
    [id] int IDENTITY(1,1) NOT NULL,
    [country] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblcurrencies'
CREATE TABLE [dbo].[tblcurrencies] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Currency] varchar(25)  NOT NULL
);
GO

-- Creating table 'tbldepartments'
CREATE TABLE [dbo].[tbldepartments] (
    [id] int IDENTITY(1,1) NOT NULL,
    [departmentStation] bigint  NOT NULL,
    [departmentName] varchar(35)  NOT NULL,
    [departmentHead] varchar(10)  NOT NULL,
    [departmentParent] int  NULL,
    [departmentSortOrd] int  NULL,
    [notes] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblemployees'
CREATE TABLE [dbo].[tblemployees] (
    [EmployeeID] varchar(10)  NOT NULL,
    [CompanyID] bigint  NULL,
    [StationID] bigint  NOT NULL,
    [DepartmentID] int  NOT NULL,
    [EmployeeType] int  NOT NULL,
    [EmployeeCategory] int  NOT NULL,
    [EmployeeDesignation] int  NOT NULL,
    [EmployeeGrade] int  NOT NULL,
    [WorkShift] int  NOT NULL,
    [AllowLogin] bit  NULL,
    [Username] varchar(30)  NULL,
    [Password] varchar(30)  NULL,
    [EmailAddress] varchar(50)  NOT NULL,
    [GoogleAppsUser] bit  NULL,
    [ShowInOrganogram] bit  NULL,
    [NotifyByEmail] bit  NULL,
    [ReportsTo] varchar(10)  NULL,
    [IndirectlyRepTo] varchar(10)  NULL,
    [Salutation] int  NOT NULL,
    [FirstName] varchar(35)  NOT NULL,
    [MiddleNames] varchar(70)  NULL,
    [LastName] varchar(35)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [GenderID] int  NOT NULL,
    [BloodGroopID] int  NULL,
    [NationalityID] int  NOT NULL,
    [ReligionID] int  NULL,
    [MaritalStatusID] int  NOT NULL,
    [EmpJoinDate] datetime  NOT NULL,
    [NatIDNumber] varchar(35)  NOT NULL,
    [EmpTaxNumber] varchar(20)  NULL,
    [PassportNumber] varchar(20)  NULL,
    [PassportExpDate] datetime  NULL,
    [DriversLicenseNo] varchar(20)  NULL,
    [DriversLicenseExpDate] datetime  NULL,
    [PermAddress] varchar(50)  NOT NULL,
    [PermCity] varchar(35)  NOT NULL,
    [PermProvince] varchar(35)  NOT NULL,
    [PermZipPostalCode] varchar(10)  NULL,
    [PermCountryID] int  NOT NULL,
    [PermContactNumber] varchar(20)  NOT NULL,
    [PresAddress] varchar(50)  NOT NULL,
    [PresCity] varchar(35)  NOT NULL,
    [PresProvince] varchar(35)  NOT NULL,
    [PresZipPostalCode] varchar(10)  NULL,
    [PresCountryID] int  NOT NULL,
    [PresContactNumber] varchar(20)  NOT NULL,
    [EmpHomePhoneNo] varchar(20)  NULL,
    [EmpOfficePhoneNo] varchar(20)  NULL,
    [EmpMobileNo] varchar(20)  NULL,
    [EmpEmmergencyContact] varchar(35)  NOT NULL,
    [EmpEmmergencyRel] varchar(20)  NOT NULL,
    [EmpEmmergencyPhoneNo] varchar(20)  NULL,
    [Notes] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblemployeecategories'
CREATE TABLE [dbo].[tblemployeecategories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Category] varchar(20)  NOT NULL,
    [Description] varchar(30)  NOT NULL
);
GO

-- Creating table 'tblemployeedesignations'
CREATE TABLE [dbo].[tblemployeedesignations] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Designation] varchar(30)  NOT NULL,
    [Description] int  NOT NULL
);
GO

-- Creating table 'tblemployeeexits'
CREATE TABLE [dbo].[tblemployeeexits] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [ExitDate] datetime  NOT NULL,
    [ExitType] int  NOT NULL,
    [InterviewConducted] bit  NOT NULL,
    [ExitReason] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblemployeetypes'
CREATE TABLE [dbo].[tblemployeetypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [EmployeeType] varchar(30)  NOT NULL,
    [Description] varchar(30)  NULL
);
GO

-- Creating table 'tblexittypes'
CREATE TABLE [dbo].[tblexittypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ExitType] varchar(20)  NOT NULL,
    [Description] varchar(50)  NULL
);
GO

-- Creating table 'tblgenders'
CREATE TABLE [dbo].[tblgenders] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Gender] varchar(15)  NOT NULL
);
GO

-- Creating table 'tblgrades'
CREATE TABLE [dbo].[tblgrades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Grade] varchar(10)  NOT NULL,
    [Description] varchar(30)  NOT NULL
);
GO

-- Creating table 'tblmaritalstatus'
CREATE TABLE [dbo].[tblmaritalstatus] (
    [id] int IDENTITY(1,1) NOT NULL,
    [MaritalStatus] varchar(25)  NOT NULL
);
GO

-- Creating table 'tblmemoes'
CREATE TABLE [dbo].[tblmemoes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [MemoFromEmpID] varchar(10)  NOT NULL,
    [Subject] varchar(30)  NOT NULL,
    [MemoDate] datetime  NOT NULL,
    [MemoTo] varchar(1000)  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblnationalities'
CREATE TABLE [dbo].[tblnationalities] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Nationality] varchar(35)  NOT NULL
);
GO

-- Creating table 'tblperformanceevaluations'
CREATE TABLE [dbo].[tblperformanceevaluations] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [Title] varchar(20)  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblpriorities'
CREATE TABLE [dbo].[tblpriorities] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Priority] varchar(20)  NOT NULL,
    [Description] varchar(30)  NULL
);
GO

-- Creating table 'tblprojects'
CREATE TABLE [dbo].[tblprojects] (
    [id] varchar(15)  NOT NULL,
    [projectTitle] varchar(25)  NOT NULL,
    [clientName] varchar(35)  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] int  NULL,
    [companyId] bigint  NULL,
    [stationId] bigint  NULL,
    [departmentId] int  NULL,
    [projectEmployees] varchar(1000)  NOT NULL,
    [projectDescription] mediumtext  NOT NULL,
    [additionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblpromotions'
CREATE TABLE [dbo].[tblpromotions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [FwdApplnTo] varchar(10)  NULL,
    [PromotionTitle] varchar(30)  NOT NULL,
    [PromotionDate] datetime  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblreligions'
CREATE TABLE [dbo].[tblreligions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Religion] varchar(35)  NOT NULL
);
GO

-- Creating table 'tblresignations'
CREATE TABLE [dbo].[tblresignations] (
    [id] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [FwdAplnTo] varchar(10)  NULL,
    [NoticeDate] datetime  NOT NULL,
    [ResignationDate] datetime  NOT NULL,
    [ResignationReason] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblsalutations'
CREATE TABLE [dbo].[tblsalutations] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Salutation] varchar(15)  NOT NULL
);
GO

-- Creating table 'tblstations'
CREATE TABLE [dbo].[tblstations] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [company] bigint  NOT NULL,
    [stationType] int  NOT NULL,
    [stationName] varchar(50)  NOT NULL,
    [parentStation] bigint  NULL,
    [stnTimeZone] int  NOT NULL,
    [stnCurrency] int  NOT NULL,
    [stnCurrencySign] varchar(1)  NOT NULL,
    [stnAddress] varchar(35)  NOT NULL,
    [stnCity] varchar(35)  NOT NULL,
    [stnStateProvince] varchar(35)  NULL,
    [stnZipPostalCode] varchar(10)  NULL,
    [stnCountry] int  NOT NULL,
    [stnPhoneNumber] varchar(20)  NULL,
    [stnFaxNumber] varchar(20)  NULL,
    [stnEmailAddress] varchar(50)  NULL,
    [stnWebsite] varchar(50)  NULL,
    [stnGeoLatitude] varchar(20)  NULL,
    [stnGeoLongitude] varchar(20)  NULL,
    [stnHead] varchar(10)  NULL,
    [stnHRManager] varchar(10)  NULL,
    [stnAccountsManager] varchar(10)  NULL,
    [notes] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblstationtypes'
CREATE TABLE [dbo].[tblstationtypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [StationType] varchar(30)  NOT NULL
);
GO

-- Creating table 'tblterminations'
CREATE TABLE [dbo].[tblterminations] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [FwdApplnTo] varchar(10)  NULL,
    [TerminationType] int  NOT NULL,
    [TerminationDate] datetime  NOT NULL,
    [NoticeDate] datetime  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblterminationtypes'
CREATE TABLE [dbo].[tblterminationtypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [TerminationType] varchar(30)  NOT NULL,
    [Description] int  NOT NULL
);
GO

-- Creating table 'tbltimezones'
CREATE TABLE [dbo].[tbltimezones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [TimeZone] varchar(50)  NOT NULL
);
GO

-- Creating table 'tbltransfers'
CREATE TABLE [dbo].[tbltransfers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(10)  NOT NULL,
    [FwdApplnTo] varchar(10)  NOT NULL,
    [TransferDate] datetime  NOT NULL,
    [TransferToDept] int  NOT NULL,
    [TransferToStation] bigint  NOT NULL,
    [TransferDescription] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [TransferFromDept] int  NOT NULL,
    [TransferFromStation] int  NOT NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblwarnings'
CREATE TABLE [dbo].[tblwarnings] (
    [id] int IDENTITY(1,1) NOT NULL,
    [WarningToEmpID] varchar(10)  NOT NULL,
    [FwdAppnTo] varchar(10)  NULL,
    [WarningByEmpID] varchar(10)  NOT NULL,
    [WarningDate] datetime  NOT NULL,
    [WarningType] int  NOT NULL,
    [Subject] varchar(30)  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [AdditionalInfo] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- Creating table 'tblwarningtypes'
CREATE TABLE [dbo].[tblwarningtypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Warning] varchar(20)  NOT NULL,
    [Description] varchar(40)  NULL
);
GO

-- Creating table 'tblworkshifts'
CREATE TABLE [dbo].[tblworkshifts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [title] varchar(25)  NOT NULL,
    [TotalHours] int  NULL,
    [RegHoursFrom] time  NULL,
    [RegHoursTo] time  NULL,
    [LunchHourFrom] time  NULL,
    [LunchHourTo] time  NULL,
    [AddBreakFrom] time  NULL,
    [AddBreakTo] time  NULL,
    [ExtraBreakFrom] time  NULL,
    [ExtraBreakTo] time  NULL,
    [notes] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [dateTimeCaptured] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'tblachievements'
ALTER TABLE [dbo].[tblachievements]
ADD CONSTRAINT [PK_tblachievements]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblannouncements'
ALTER TABLE [dbo].[tblannouncements]
ADD CONSTRAINT [PK_tblannouncements]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblassignments'
ALTER TABLE [dbo].[tblassignments]
ADD CONSTRAINT [PK_tblassignments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblbankaccounttypes'
ALTER TABLE [dbo].[tblbankaccounttypes]
ADD CONSTRAINT [PK_tblbankaccounttypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblbanks'
ALTER TABLE [dbo].[tblbanks]
ADD CONSTRAINT [PK_tblbanks]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblbloodgroops'
ALTER TABLE [dbo].[tblbloodgroops]
ADD CONSTRAINT [PK_tblbloodgroops]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [companyId] in table 'tblcompanies'
ALTER TABLE [dbo].[tblcompanies]
ADD CONSTRAINT [PK_tblcompanies]
    PRIMARY KEY CLUSTERED ([companyId] ASC);
GO

-- Creating primary key on [id] in table 'tblcompanytypes'
ALTER TABLE [dbo].[tblcompanytypes]
ADD CONSTRAINT [PK_tblcompanytypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblcomplaints'
ALTER TABLE [dbo].[tblcomplaints]
ADD CONSTRAINT [PK_tblcomplaints]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblcontracts'
ALTER TABLE [dbo].[tblcontracts]
ADD CONSTRAINT [PK_tblcontracts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblcontracttypes'
ALTER TABLE [dbo].[tblcontracttypes]
ADD CONSTRAINT [PK_tblcontracttypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblcountries'
ALTER TABLE [dbo].[tblcountries]
ADD CONSTRAINT [PK_tblcountries]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblcurrencies'
ALTER TABLE [dbo].[tblcurrencies]
ADD CONSTRAINT [PK_tblcurrencies]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbldepartments'
ALTER TABLE [dbo].[tbldepartments]
ADD CONSTRAINT [PK_tbldepartments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'tblemployees'
ALTER TABLE [dbo].[tblemployees]
ADD CONSTRAINT [PK_tblemployees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [id] in table 'tblemployeecategories'
ALTER TABLE [dbo].[tblemployeecategories]
ADD CONSTRAINT [PK_tblemployeecategories]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblemployeedesignations'
ALTER TABLE [dbo].[tblemployeedesignations]
ADD CONSTRAINT [PK_tblemployeedesignations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblemployeeexits'
ALTER TABLE [dbo].[tblemployeeexits]
ADD CONSTRAINT [PK_tblemployeeexits]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblemployeetypes'
ALTER TABLE [dbo].[tblemployeetypes]
ADD CONSTRAINT [PK_tblemployeetypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblexittypes'
ALTER TABLE [dbo].[tblexittypes]
ADD CONSTRAINT [PK_tblexittypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblgenders'
ALTER TABLE [dbo].[tblgenders]
ADD CONSTRAINT [PK_tblgenders]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblgrades'
ALTER TABLE [dbo].[tblgrades]
ADD CONSTRAINT [PK_tblgrades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblmaritalstatus'
ALTER TABLE [dbo].[tblmaritalstatus]
ADD CONSTRAINT [PK_tblmaritalstatus]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblmemoes'
ALTER TABLE [dbo].[tblmemoes]
ADD CONSTRAINT [PK_tblmemoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblnationalities'
ALTER TABLE [dbo].[tblnationalities]
ADD CONSTRAINT [PK_tblnationalities]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblperformanceevaluations'
ALTER TABLE [dbo].[tblperformanceevaluations]
ADD CONSTRAINT [PK_tblperformanceevaluations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblpriorities'
ALTER TABLE [dbo].[tblpriorities]
ADD CONSTRAINT [PK_tblpriorities]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [projectTitle], [clientName], [projectEmployees], [projectDescription], [inputter], [dateTimeCaptured] in table 'tblprojects'
ALTER TABLE [dbo].[tblprojects]
ADD CONSTRAINT [PK_tblprojects]
    PRIMARY KEY CLUSTERED ([id], [projectTitle], [clientName], [projectEmployees], [projectDescription], [inputter], [dateTimeCaptured] ASC);
GO

-- Creating primary key on [id] in table 'tblpromotions'
ALTER TABLE [dbo].[tblpromotions]
ADD CONSTRAINT [PK_tblpromotions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblreligions'
ALTER TABLE [dbo].[tblreligions]
ADD CONSTRAINT [PK_tblreligions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblresignations'
ALTER TABLE [dbo].[tblresignations]
ADD CONSTRAINT [PK_tblresignations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblsalutations'
ALTER TABLE [dbo].[tblsalutations]
ADD CONSTRAINT [PK_tblsalutations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblstations'
ALTER TABLE [dbo].[tblstations]
ADD CONSTRAINT [PK_tblstations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblstationtypes'
ALTER TABLE [dbo].[tblstationtypes]
ADD CONSTRAINT [PK_tblstationtypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblterminations'
ALTER TABLE [dbo].[tblterminations]
ADD CONSTRAINT [PK_tblterminations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblterminationtypes'
ALTER TABLE [dbo].[tblterminationtypes]
ADD CONSTRAINT [PK_tblterminationtypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbltimezones'
ALTER TABLE [dbo].[tbltimezones]
ADD CONSTRAINT [PK_tbltimezones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbltransfers'
ALTER TABLE [dbo].[tbltransfers]
ADD CONSTRAINT [PK_tbltransfers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblwarnings'
ALTER TABLE [dbo].[tblwarnings]
ADD CONSTRAINT [PK_tblwarnings]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblwarningtypes'
ALTER TABLE [dbo].[tblwarningtypes]
ADD CONSTRAINT [PK_tblwarningtypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblworkshifts'
ALTER TABLE [dbo].[tblworkshifts]
ADD CONSTRAINT [PK_tblworkshifts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------