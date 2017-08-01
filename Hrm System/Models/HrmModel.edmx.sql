
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/22/2017 10:59:00
-- Generated from EDMX file: C:\Users\ashbel\Documents\Visual Studio 2012\Projects\Hrm System\Hrm System\Models\HrmModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HRM];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeContacts_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployeeContacts] DROP CONSTRAINT [FK_EmployeeContacts_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAllowanceLnk_tblAllowances]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAllowanceLnk] DROP CONSTRAINT [FK_tblAllowanceLnk_tblAllowances];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAllowanceLnk_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAllowanceLnk] DROP CONSTRAINT [FK_tblAllowanceLnk_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCity_tblProvince]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCity] DROP CONSTRAINT [FK_tblCity_tblProvince];
GO
IF OBJECT_ID(N'[dbo].[FK_tblContracts_tblContractTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblContracts] DROP CONSTRAINT [FK_tblContracts_tblContractTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_tblContracts_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblContracts] DROP CONSTRAINT [FK_tblContracts_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDeductionLnk_tblDeductions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeductionLnk] DROP CONSTRAINT [FK_tblDeductionLnk_tblDeductions];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDeductionLnk_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeductionLnk] DROP CONSTRAINT [FK_tblDeductionLnk_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployeeContacts_tblCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployeeContacts] DROP CONSTRAINT [FK_tblEmployeeContacts_tblCity];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployeeContacts_tblRelationships]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployeeContacts] DROP CONSTRAINT [FK_tblEmployeeContacts_tblRelationships];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblEmployees1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblEmployees1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblEmployees2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblEmployees2];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblEmployeeStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblEmployeeStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblEmplStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblEmplStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblGender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblGender];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblImages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblImages];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblMarital]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblMarital];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblPositions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblPositions];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmployees_tblSalutation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmployees] DROP CONSTRAINT [FK_tblEmployees_tblSalutation];
GO
IF OBJECT_ID(N'[dbo].[FK_tblLeave_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblLeave] DROP CONSTRAINT [FK_tblLeave_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblLeave_tblLvType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblLeave] DROP CONSTRAINT [FK_tblLeave_tblLvType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblLvUsage_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblLvUsage] DROP CONSTRAINT [FK_tblLvUsage_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblLvUsage_tblLeave]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblLvUsage] DROP CONSTRAINT [FK_tblLvUsage_tblLeave];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPayroll_tblBanks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPayroll] DROP CONSTRAINT [FK_tblPayroll_tblBanks];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPayroll_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPayroll] DROP CONSTRAINT [FK_tblPayroll_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPayroll_tblPayMethod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPayroll] DROP CONSTRAINT [FK_tblPayroll_tblPayMethod];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPositionHistory_tblBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPositionHistory] DROP CONSTRAINT [FK_tblPositionHistory_tblBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPositionHistory_tblDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPositionHistory] DROP CONSTRAINT [FK_tblPositionHistory_tblDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPositionHistory_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPositionHistory] DROP CONSTRAINT [FK_tblPositionHistory_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPositionHistory_tblPositions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPositionHistory] DROP CONSTRAINT [FK_tblPositionHistory_tblPositions];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPositions_tblJobLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPositions] DROP CONSTRAINT [FK_tblPositions_tblJobLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUsers_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUsers] DROP CONSTRAINT [FK_tblUsers_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWkshftLink_tblEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWkshftLink] DROP CONSTRAINT [FK_tblWkshftLink_tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWkshftLink_tblWorkshifts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWkshftLink] DROP CONSTRAINT [FK_tblWkshftLink_tblWorkshifts];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tblAllowanceLnk]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAllowanceLnk];
GO
IF OBJECT_ID(N'[dbo].[tblAllowances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAllowances];
GO
IF OBJECT_ID(N'[dbo].[tblBanks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBanks];
GO
IF OBJECT_ID(N'[dbo].[tblBranch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBranch];
GO
IF OBJECT_ID(N'[dbo].[tblCity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCity];
GO
IF OBJECT_ID(N'[dbo].[tblContracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblContracts];
GO
IF OBJECT_ID(N'[dbo].[tblContractTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblContractTypes];
GO
IF OBJECT_ID(N'[dbo].[tblDeductionLnk]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDeductionLnk];
GO
IF OBJECT_ID(N'[dbo].[tblDeductions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDeductions];
GO
IF OBJECT_ID(N'[dbo].[tblDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDepartment];
GO
IF OBJECT_ID(N'[dbo].[tblEmployeeContacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEmployeeContacts];
GO
IF OBJECT_ID(N'[dbo].[tblEmployees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEmployees];
GO
IF OBJECT_ID(N'[dbo].[tblEmployeeStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEmployeeStatus];
GO
IF OBJECT_ID(N'[dbo].[tblEmplStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEmplStatus];
GO
IF OBJECT_ID(N'[dbo].[tblGender]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGender];
GO
IF OBJECT_ID(N'[dbo].[tblgrades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblgrades];
GO
IF OBJECT_ID(N'[dbo].[tblImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblImages];
GO
IF OBJECT_ID(N'[dbo].[tblJobLevels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblJobLevels];
GO
IF OBJECT_ID(N'[dbo].[tblLeave]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLeave];
GO
IF OBJECT_ID(N'[dbo].[tblLvType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLvType];
GO
IF OBJECT_ID(N'[dbo].[tblLvUsage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLvUsage];
GO
IF OBJECT_ID(N'[dbo].[tblMarital]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblMarital];
GO
IF OBJECT_ID(N'[dbo].[tblOrganisation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOrganisation];
GO
IF OBJECT_ID(N'[dbo].[tblPayMethod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPayMethod];
GO
IF OBJECT_ID(N'[dbo].[tblPayroll]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPayroll];
GO
IF OBJECT_ID(N'[dbo].[tblPositionHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPositionHistory];
GO
IF OBJECT_ID(N'[dbo].[tblPositions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPositions];
GO
IF OBJECT_ID(N'[dbo].[tblProvince]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProvince];
GO
IF OBJECT_ID(N'[dbo].[tblRelationships]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRelationships];
GO
IF OBJECT_ID(N'[dbo].[tblSalutation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalutation];
GO
IF OBJECT_ID(N'[dbo].[tblUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUsers];
GO
IF OBJECT_ID(N'[dbo].[tblWkshftLink]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWkshftLink];
GO
IF OBJECT_ID(N'[dbo].[tblWorkshifts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWorkshifts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblBranches'
CREATE TABLE [dbo].[tblBranches] (
    [br_id] int IDENTITY(1,1) NOT NULL,
    [br_name] varchar(50)  NULL,
    [br_address] varchar(50)  NULL,
    [br_contact] varchar(50)  NULL,
    [br_descr] varchar(50)  NULL
);
GO

-- Creating table 'tblDepartments'
CREATE TABLE [dbo].[tblDepartments] (
    [dpt_id] int IDENTITY(1,1) NOT NULL,
    [dpt_name] varchar(50)  NULL,
    [dpt_desc] varchar(50)  NULL
);
GO

-- Creating table 'tblEmployees'
CREATE TABLE [dbo].[tblEmployees] (
    [emp_id] int IDENTITY(1,1) NOT NULL,
    [emp_name] varchar(50)  NULL,
    [emp_lname] varchar(50)  NULL,
    [emp_email] varchar(50)  NULL,
    [emp_branch] int  NULL,
    [emp_dpt] int  NULL,
    [emp_status] int  NULL,
    [emp_bDate] datetime  NULL,
    [emp_jDate] datetime  NULL,
    [emp_cDate] datetime  NULL,
    [emp_pos_id] int  NULL,
    [emp_id_num] varchar(50)  NULL,
    [emp_ec_num] varchar(50)  NULL,
    [emp_nation] varchar(50)  NULL,
    [emp_state] int  NULL,
    [img_id] int  NULL,
    [emp_sex] int  NULL,
    [emp_marital] int  NULL,
    [emp_sal] int  NULL,
    [emp_mid_names] varchar(50)  NULL,
    [emp_passport_num] varchar(50)  NULL,
    [emp_passport_date] datetime  NULL,
    [emp_drv_num] varchar(50)  NULL
);
GO

-- Creating table 'tblEmployeeStatus'
CREATE TABLE [dbo].[tblEmployeeStatus] (
    [empst_id] int IDENTITY(1,1) NOT NULL,
    [empst_title] varchar(50)  NULL,
    [empst_descr] varchar(50)  NULL
);
GO

-- Creating table 'tblJobLevels'
CREATE TABLE [dbo].[tblJobLevels] (
    [lvl_id] int IDENTITY(1,1) NOT NULL,
    [lvl_title] varchar(50)  NULL,
    [lvl_desc] varchar(50)  NULL
);
GO

-- Creating table 'tblOrganisations'
CREATE TABLE [dbo].[tblOrganisations] (
    [org_id] int IDENTITY(1,1) NOT NULL,
    [org_name] varchar(50)  NULL,
    [org_logo] varchar(50)  NULL,
    [org_address] varchar(50)  NULL,
    [org_descr] varchar(50)  NULL,
    [org_phone] varchar(50)  NULL
);
GO

-- Creating table 'tblPositionHistories'
CREATE TABLE [dbo].[tblPositionHistories] (
    [ph_id] int IDENTITY(1,1) NOT NULL,
    [emp_id] int  NULL,
    [pos_id] int  NULL,
    [dpt_id] int  NULL,
    [ph_sal] decimal(19,4)  NULL,
    [br_id] int  NULL,
    [ph_sDate] datetime  NULL,
    [ph_eDate] datetime  NULL
);
GO

-- Creating table 'tblPositions'
CREATE TABLE [dbo].[tblPositions] (
    [pos_id] int IDENTITY(1,1) NOT NULL,
    [lvl_id] int  NULL,
    [pos_title] varchar(50)  NULL,
    [pos_desc] varchar(50)  NULL
);
GO

-- Creating table 'tblUsers'
CREATE TABLE [dbo].[tblUsers] (
    [user_id] int IDENTITY(1,1) NOT NULL,
    [user_name] varchar(50)  NULL,
    [user_password] varchar(50)  NULL,
    [user_role] varchar(50)  NULL,
    [emp_id] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'tblEmplStatus'
CREATE TABLE [dbo].[tblEmplStatus] (
    [stat_id] int IDENTITY(1,1) NOT NULL,
    [stat_name] varchar(50)  NULL,
    [stat_desc] varchar(50)  NULL
);
GO

-- Creating table 'tblImages'
CREATE TABLE [dbo].[tblImages] (
    [img_id] int IDENTITY(1,1) NOT NULL,
    [img_data] varbinary(max)  NULL,
    [img_desc] varchar(100)  NULL,
    [emp_id] int  NULL
);
GO

-- Creating table 'tblContracts'
CREATE TABLE [dbo].[tblContracts] (
    [cntrct_id] int IDENTITY(1,1) NOT NULL,
    [emp_id] int  NULL,
    [cntrct_title] varchar(50)  NULL,
    [cntrct_sdate] datetime  NULL,
    [cntrct_edate] datetime  NULL,
    [cntrct_state] varchar(50)  NULL,
    [cntcrt_typ_id] int  NULL,
    [cntrct_desc] varchar(1000)  NULL,
    [create_date] datetime  NULL
);
GO

-- Creating table 'tblLeaves'
CREATE TABLE [dbo].[tblLeaves] (
    [lv_id] int IDENTITY(1,1) NOT NULL,
    [lv_bal] decimal(18,2)  NULL,
    [lvtyp_id] int  NULL,
    [emp_id] int  NULL,
    [lv_period] datetime  NULL
);
GO

-- Creating table 'tblLvTypes'
CREATE TABLE [dbo].[tblLvTypes] (
    [lvtyp_id] int IDENTITY(1,1) NOT NULL,
    [lvtyp_title] varchar(50)  NULL,
    [lvtyp_num] decimal(18,2)  NULL
);
GO

-- Creating table 'tblLvUsages'
CREATE TABLE [dbo].[tblLvUsages] (
    [lv_u_id] int IDENTITY(1,1) NOT NULL,
    [emp_id] int  NULL,
    [lv_id] int  NULL,
    [lv_sdate] datetime  NULL,
    [lv_edate] datetime  NULL,
    [lv_days] decimal(18,2)  NULL,
    [lv_bal] decimal(18,2)  NULL,
    [lv_state] varchar(50)  NULL
);
GO

-- Creating table 'tblMaritals'
CREATE TABLE [dbo].[tblMaritals] (
    [marital_id] int IDENTITY(1,1) NOT NULL,
    [marital_status] varchar(50)  NULL
);
GO

-- Creating table 'tblGenders'
CREATE TABLE [dbo].[tblGenders] (
    [emp_sx_id] int IDENTITY(1,1) NOT NULL,
    [emp_sex] varchar(50)  NULL
);
GO

-- Creating table 'tblAllowanceLnks'
CREATE TABLE [dbo].[tblAllowanceLnks] (
    [allow_lnk_id] int IDENTITY(1,1) NOT NULL,
    [allowance_id] int  NULL,
    [allowance_amnt] decimal(19,4)  NULL,
    [allowance_sdate] datetime  NULL,
    [allowance_edate] datetime  NULL,
    [allowance_perm] bit  NULL,
    [allowance_month] datetime  NULL,
    [create_date] nchar(10)  NULL,
    [emp_id] int  NULL,
    [allowance_notes] varchar(500)  NULL
);
GO

-- Creating table 'tblAllowances'
CREATE TABLE [dbo].[tblAllowances] (
    [allowance_id] int IDENTITY(1,1) NOT NULL,
    [allowance_name] varchar(50)  NULL,
    [allowance_value] decimal(19,4)  NULL,
    [allowance_perc] varchar(50)  NULL,
    [allowance_desc] varchar(500)  NULL
);
GO

-- Creating table 'tblBanks'
CREATE TABLE [dbo].[tblBanks] (
    [bnk_id] int IDENTITY(1,1) NOT NULL,
    [bnk_name] varchar(50)  NOT NULL,
    [bnk_code] varchar(50)  NULL
);
GO

-- Creating table 'tblContractTypes'
CREATE TABLE [dbo].[tblContractTypes] (
    [cntcrt_typ_id] int IDENTITY(1,1) NOT NULL,
    [cntrct_typ] varchar(20)  NOT NULL,
    [cntrct_desc] varchar(100)  NOT NULL
);
GO

-- Creating table 'tblDeductionLnks'
CREATE TABLE [dbo].[tblDeductionLnks] (
    [ded_lnk_id] int IDENTITY(1,1) NOT NULL,
    [deduction_id] int  NULL,
    [deduction_amnt] decimal(19,4)  NULL,
    [deduction_sdate] datetime  NULL,
    [deduction_edate] datetime  NULL,
    [deduction_permanent] bit  NULL,
    [deduction_mnth] datetime  NULL,
    [create_date] varchar(50)  NULL,
    [emp_id] int  NULL,
    [deduction_notes] varchar(500)  NULL
);
GO

-- Creating table 'tblDeductions'
CREATE TABLE [dbo].[tblDeductions] (
    [deduction_id] int IDENTITY(1,1) NOT NULL,
    [deduction_name] varchar(50)  NULL,
    [deduction_value] decimal(19,4)  NULL,
    [deduction_perc] varchar(50)  NULL,
    [deduction_desc] varchar(500)  NULL
);
GO

-- Creating table 'tblEmployeeContacts'
CREATE TABLE [dbo].[tblEmployeeContacts] (
    [cnt_id] int IDENTITY(1,1) NOT NULL,
    [emp_id] int  NULL,
    [emp_strt] varchar(50)  NULL,
    [emp_nghbhd] varchar(50)  NULL,
    [emp_city] int  NULL,
    [emp_province] int  NULL,
    [emp_phone] varchar(50)  NULL,
    [emp_mobile] varchar(50)  NULL,
    [emp_kin] varchar(50)  NULL,
    [emp_kin_add] varchar(100)  NULL,
    [emp_kin_ph] varchar(50)  NULL,
    [rel_id] int  NULL
);
GO

-- Creating table 'tblgrades'
CREATE TABLE [dbo].[tblgrades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Grade] varchar(10)  NOT NULL,
    [Description] varchar(30)  NOT NULL
);
GO

-- Creating table 'tblPayMethods'
CREATE TABLE [dbo].[tblPayMethods] (
    [pay_method_id] int IDENTITY(1,1) NOT NULL,
    [pay_title] varchar(50)  NULL
);
GO

-- Creating table 'tblPayrolls'
CREATE TABLE [dbo].[tblPayrolls] (
    [pay_id] int IDENTITY(1,1) NOT NULL,
    [emp_id] int  NULL,
    [emp_Salary] decimal(19,4)  NULL,
    [emp_bnk] int  NULL,
    [emp_method] int  NULL,
    [emp_acc_num] varchar(50)  NULL,
    [pay_start_date] datetime  NULL,
    [pay_end_date] datetime  NULL,
    [pay_status] varchar(50)  NULL,
    [create_date] datetime  NULL
);
GO

-- Creating table 'tblSalutations'
CREATE TABLE [dbo].[tblSalutations] (
    [sal_id] int IDENTITY(1,1) NOT NULL,
    [sal_title] varchar(15)  NOT NULL
);
GO

-- Creating table 'tblWkshftLinks'
CREATE TABLE [dbo].[tblWkshftLinks] (
    [wk_lnk_id] int IDENTITY(1,1) NOT NULL,
    [wkshft_id] int  NULL,
    [emp_id] int  NULL,
    [wk_lnk_stDate] datetime  NULL,
    [wk_lnk_eDate] datetime  NULL,
    [wk_lnk_status] varchar(50)  NULL,
    [create_date] datetime  NULL
);
GO

-- Creating table 'tblWorkshifts'
CREATE TABLE [dbo].[tblWorkshifts] (
    [wkshft_id] int IDENTITY(1,1) NOT NULL,
    [wkshft_title] varchar(25)  NOT NULL,
    [wkshft_hrs] int  NULL,
    [wkshft_from] time  NULL,
    [wkshft_to] time  NULL,
    [wkshft_lunch_from] time  NULL,
    [wkshft_lunch_to] time  NULL,
    [wkshft_brk_from] time  NULL,
    [wkshft_brk_to] time  NULL,
    [wkshft_xtrabrk_from] time  NULL,
    [wkshft_xtrabrk_to] time  NULL,
    [wkshft_notes] varchar(1000)  NULL,
    [inputter] varchar(20)  NOT NULL,
    [create_date] datetime  NOT NULL
);
GO

-- Creating table 'tblRelationships'
CREATE TABLE [dbo].[tblRelationships] (
    [rel_id] int IDENTITY(1,1) NOT NULL,
    [rel_title] varchar(50)  NULL
);
GO

-- Creating table 'tblCities'
CREATE TABLE [dbo].[tblCities] (
    [cty_id] int IDENTITY(1,1) NOT NULL,
    [cty_name] varchar(50)  NULL,
    [prov_id] int  NULL
);
GO

-- Creating table 'tblProvinces'
CREATE TABLE [dbo].[tblProvinces] (
    [prov_id] int IDENTITY(1,1) NOT NULL,
    [prov_name] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [br_id] in table 'tblBranches'
ALTER TABLE [dbo].[tblBranches]
ADD CONSTRAINT [PK_tblBranches]
    PRIMARY KEY CLUSTERED ([br_id] ASC);
GO

-- Creating primary key on [dpt_id] in table 'tblDepartments'
ALTER TABLE [dbo].[tblDepartments]
ADD CONSTRAINT [PK_tblDepartments]
    PRIMARY KEY CLUSTERED ([dpt_id] ASC);
GO

-- Creating primary key on [emp_id] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [PK_tblEmployees]
    PRIMARY KEY CLUSTERED ([emp_id] ASC);
GO

-- Creating primary key on [empst_id] in table 'tblEmployeeStatus'
ALTER TABLE [dbo].[tblEmployeeStatus]
ADD CONSTRAINT [PK_tblEmployeeStatus]
    PRIMARY KEY CLUSTERED ([empst_id] ASC);
GO

-- Creating primary key on [lvl_id] in table 'tblJobLevels'
ALTER TABLE [dbo].[tblJobLevels]
ADD CONSTRAINT [PK_tblJobLevels]
    PRIMARY KEY CLUSTERED ([lvl_id] ASC);
GO

-- Creating primary key on [org_id] in table 'tblOrganisations'
ALTER TABLE [dbo].[tblOrganisations]
ADD CONSTRAINT [PK_tblOrganisations]
    PRIMARY KEY CLUSTERED ([org_id] ASC);
GO

-- Creating primary key on [ph_id] in table 'tblPositionHistories'
ALTER TABLE [dbo].[tblPositionHistories]
ADD CONSTRAINT [PK_tblPositionHistories]
    PRIMARY KEY CLUSTERED ([ph_id] ASC);
GO

-- Creating primary key on [pos_id] in table 'tblPositions'
ALTER TABLE [dbo].[tblPositions]
ADD CONSTRAINT [PK_tblPositions]
    PRIMARY KEY CLUSTERED ([pos_id] ASC);
GO

-- Creating primary key on [user_id] in table 'tblUsers'
ALTER TABLE [dbo].[tblUsers]
ADD CONSTRAINT [PK_tblUsers]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [stat_id] in table 'tblEmplStatus'
ALTER TABLE [dbo].[tblEmplStatus]
ADD CONSTRAINT [PK_tblEmplStatus]
    PRIMARY KEY CLUSTERED ([stat_id] ASC);
GO

-- Creating primary key on [img_id] in table 'tblImages'
ALTER TABLE [dbo].[tblImages]
ADD CONSTRAINT [PK_tblImages]
    PRIMARY KEY CLUSTERED ([img_id] ASC);
GO

-- Creating primary key on [cntrct_id] in table 'tblContracts'
ALTER TABLE [dbo].[tblContracts]
ADD CONSTRAINT [PK_tblContracts]
    PRIMARY KEY CLUSTERED ([cntrct_id] ASC);
GO

-- Creating primary key on [lv_id] in table 'tblLeaves'
ALTER TABLE [dbo].[tblLeaves]
ADD CONSTRAINT [PK_tblLeaves]
    PRIMARY KEY CLUSTERED ([lv_id] ASC);
GO

-- Creating primary key on [lvtyp_id] in table 'tblLvTypes'
ALTER TABLE [dbo].[tblLvTypes]
ADD CONSTRAINT [PK_tblLvTypes]
    PRIMARY KEY CLUSTERED ([lvtyp_id] ASC);
GO

-- Creating primary key on [lv_u_id] in table 'tblLvUsages'
ALTER TABLE [dbo].[tblLvUsages]
ADD CONSTRAINT [PK_tblLvUsages]
    PRIMARY KEY CLUSTERED ([lv_u_id] ASC);
GO

-- Creating primary key on [marital_id] in table 'tblMaritals'
ALTER TABLE [dbo].[tblMaritals]
ADD CONSTRAINT [PK_tblMaritals]
    PRIMARY KEY CLUSTERED ([marital_id] ASC);
GO

-- Creating primary key on [emp_sx_id] in table 'tblGenders'
ALTER TABLE [dbo].[tblGenders]
ADD CONSTRAINT [PK_tblGenders]
    PRIMARY KEY CLUSTERED ([emp_sx_id] ASC);
GO

-- Creating primary key on [allow_lnk_id] in table 'tblAllowanceLnks'
ALTER TABLE [dbo].[tblAllowanceLnks]
ADD CONSTRAINT [PK_tblAllowanceLnks]
    PRIMARY KEY CLUSTERED ([allow_lnk_id] ASC);
GO

-- Creating primary key on [allowance_id] in table 'tblAllowances'
ALTER TABLE [dbo].[tblAllowances]
ADD CONSTRAINT [PK_tblAllowances]
    PRIMARY KEY CLUSTERED ([allowance_id] ASC);
GO

-- Creating primary key on [bnk_id] in table 'tblBanks'
ALTER TABLE [dbo].[tblBanks]
ADD CONSTRAINT [PK_tblBanks]
    PRIMARY KEY CLUSTERED ([bnk_id] ASC);
GO

-- Creating primary key on [cntcrt_typ_id] in table 'tblContractTypes'
ALTER TABLE [dbo].[tblContractTypes]
ADD CONSTRAINT [PK_tblContractTypes]
    PRIMARY KEY CLUSTERED ([cntcrt_typ_id] ASC);
GO

-- Creating primary key on [ded_lnk_id] in table 'tblDeductionLnks'
ALTER TABLE [dbo].[tblDeductionLnks]
ADD CONSTRAINT [PK_tblDeductionLnks]
    PRIMARY KEY CLUSTERED ([ded_lnk_id] ASC);
GO

-- Creating primary key on [deduction_id] in table 'tblDeductions'
ALTER TABLE [dbo].[tblDeductions]
ADD CONSTRAINT [PK_tblDeductions]
    PRIMARY KEY CLUSTERED ([deduction_id] ASC);
GO

-- Creating primary key on [cnt_id] in table 'tblEmployeeContacts'
ALTER TABLE [dbo].[tblEmployeeContacts]
ADD CONSTRAINT [PK_tblEmployeeContacts]
    PRIMARY KEY CLUSTERED ([cnt_id] ASC);
GO

-- Creating primary key on [id] in table 'tblgrades'
ALTER TABLE [dbo].[tblgrades]
ADD CONSTRAINT [PK_tblgrades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [pay_method_id] in table 'tblPayMethods'
ALTER TABLE [dbo].[tblPayMethods]
ADD CONSTRAINT [PK_tblPayMethods]
    PRIMARY KEY CLUSTERED ([pay_method_id] ASC);
GO

-- Creating primary key on [pay_id] in table 'tblPayrolls'
ALTER TABLE [dbo].[tblPayrolls]
ADD CONSTRAINT [PK_tblPayrolls]
    PRIMARY KEY CLUSTERED ([pay_id] ASC);
GO

-- Creating primary key on [sal_id] in table 'tblSalutations'
ALTER TABLE [dbo].[tblSalutations]
ADD CONSTRAINT [PK_tblSalutations]
    PRIMARY KEY CLUSTERED ([sal_id] ASC);
GO

-- Creating primary key on [wk_lnk_id] in table 'tblWkshftLinks'
ALTER TABLE [dbo].[tblWkshftLinks]
ADD CONSTRAINT [PK_tblWkshftLinks]
    PRIMARY KEY CLUSTERED ([wk_lnk_id] ASC);
GO

-- Creating primary key on [wkshft_id] in table 'tblWorkshifts'
ALTER TABLE [dbo].[tblWorkshifts]
ADD CONSTRAINT [PK_tblWorkshifts]
    PRIMARY KEY CLUSTERED ([wkshft_id] ASC);
GO

-- Creating primary key on [rel_id] in table 'tblRelationships'
ALTER TABLE [dbo].[tblRelationships]
ADD CONSTRAINT [PK_tblRelationships]
    PRIMARY KEY CLUSTERED ([rel_id] ASC);
GO

-- Creating primary key on [cty_id] in table 'tblCities'
ALTER TABLE [dbo].[tblCities]
ADD CONSTRAINT [PK_tblCities]
    PRIMARY KEY CLUSTERED ([cty_id] ASC);
GO

-- Creating primary key on [prov_id] in table 'tblProvinces'
ALTER TABLE [dbo].[tblProvinces]
ADD CONSTRAINT [PK_tblProvinces]
    PRIMARY KEY CLUSTERED ([prov_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [emp_branch] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblBranch]
    FOREIGN KEY ([emp_branch])
    REFERENCES [dbo].[tblBranches]
        ([br_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblBranch'
CREATE INDEX [IX_FK_tblEmployees_tblBranch]
ON [dbo].[tblEmployees]
    ([emp_branch]);
GO

-- Creating foreign key on [br_id] in table 'tblPositionHistories'
ALTER TABLE [dbo].[tblPositionHistories]
ADD CONSTRAINT [FK_tblPositionHistory_tblBranch]
    FOREIGN KEY ([br_id])
    REFERENCES [dbo].[tblBranches]
        ([br_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPositionHistory_tblBranch'
CREATE INDEX [IX_FK_tblPositionHistory_tblBranch]
ON [dbo].[tblPositionHistories]
    ([br_id]);
GO

-- Creating foreign key on [emp_dpt] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblDepartment]
    FOREIGN KEY ([emp_dpt])
    REFERENCES [dbo].[tblDepartments]
        ([dpt_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblDepartment'
CREATE INDEX [IX_FK_tblEmployees_tblDepartment]
ON [dbo].[tblEmployees]
    ([emp_dpt]);
GO

-- Creating foreign key on [dpt_id] in table 'tblPositionHistories'
ALTER TABLE [dbo].[tblPositionHistories]
ADD CONSTRAINT [FK_tblPositionHistory_tblDepartment]
    FOREIGN KEY ([dpt_id])
    REFERENCES [dbo].[tblDepartments]
        ([dpt_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPositionHistory_tblDepartment'
CREATE INDEX [IX_FK_tblPositionHistory_tblDepartment]
ON [dbo].[tblPositionHistories]
    ([dpt_id]);
GO

-- Creating foreign key on [emp_status] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblEmployeeStatus]
    FOREIGN KEY ([emp_status])
    REFERENCES [dbo].[tblEmployeeStatus]
        ([empst_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblEmployeeStatus'
CREATE INDEX [IX_FK_tblEmployees_tblEmployeeStatus]
ON [dbo].[tblEmployees]
    ([emp_status]);
GO

-- Creating foreign key on [emp_id] in table 'tblPositionHistories'
ALTER TABLE [dbo].[tblPositionHistories]
ADD CONSTRAINT [FK_tblPositionHistory_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPositionHistory_tblEmployees'
CREATE INDEX [IX_FK_tblPositionHistory_tblEmployees]
ON [dbo].[tblPositionHistories]
    ([emp_id]);
GO

-- Creating foreign key on [emp_id] in table 'tblUsers'
ALTER TABLE [dbo].[tblUsers]
ADD CONSTRAINT [FK_tblUsers_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUsers_tblEmployees'
CREATE INDEX [IX_FK_tblUsers_tblEmployees]
ON [dbo].[tblUsers]
    ([emp_id]);
GO

-- Creating foreign key on [pos_id] in table 'tblPositionHistories'
ALTER TABLE [dbo].[tblPositionHistories]
ADD CONSTRAINT [FK_tblPositionHistory_tblPositions]
    FOREIGN KEY ([pos_id])
    REFERENCES [dbo].[tblPositions]
        ([pos_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPositionHistory_tblPositions'
CREATE INDEX [IX_FK_tblPositionHistory_tblPositions]
ON [dbo].[tblPositionHistories]
    ([pos_id]);
GO

-- Creating foreign key on [lvl_id] in table 'tblPositions'
ALTER TABLE [dbo].[tblPositions]
ADD CONSTRAINT [FK_tblPositions_tblJobLevels]
    FOREIGN KEY ([lvl_id])
    REFERENCES [dbo].[tblJobLevels]
        ([lvl_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPositions_tblJobLevels'
CREATE INDEX [IX_FK_tblPositions_tblJobLevels]
ON [dbo].[tblPositions]
    ([lvl_id]);
GO

-- Creating foreign key on [emp_pos_id] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblPositions]
    FOREIGN KEY ([emp_pos_id])
    REFERENCES [dbo].[tblPositions]
        ([pos_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblPositions'
CREATE INDEX [IX_FK_tblEmployees_tblPositions]
ON [dbo].[tblEmployees]
    ([emp_pos_id]);
GO

-- Creating foreign key on [emp_id] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [emp_state] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblEmplStatus]
    FOREIGN KEY ([emp_state])
    REFERENCES [dbo].[tblEmplStatus]
        ([stat_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblEmplStatus'
CREATE INDEX [IX_FK_tblEmployees_tblEmplStatus]
ON [dbo].[tblEmployees]
    ([emp_state]);
GO

-- Creating foreign key on [img_id] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblImages]
    FOREIGN KEY ([img_id])
    REFERENCES [dbo].[tblImages]
        ([img_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblImages'
CREATE INDEX [IX_FK_tblEmployees_tblImages]
ON [dbo].[tblEmployees]
    ([img_id]);
GO

-- Creating foreign key on [emp_id] in table 'tblLeaves'
ALTER TABLE [dbo].[tblLeaves]
ADD CONSTRAINT [FK_tblLeave_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblLeave_tblEmployees'
CREATE INDEX [IX_FK_tblLeave_tblEmployees]
ON [dbo].[tblLeaves]
    ([emp_id]);
GO

-- Creating foreign key on [emp_id] in table 'tblLvUsages'
ALTER TABLE [dbo].[tblLvUsages]
ADD CONSTRAINT [FK_tblLvUsage_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblLvUsage_tblEmployees'
CREATE INDEX [IX_FK_tblLvUsage_tblEmployees]
ON [dbo].[tblLvUsages]
    ([emp_id]);
GO

-- Creating foreign key on [lvtyp_id] in table 'tblLeaves'
ALTER TABLE [dbo].[tblLeaves]
ADD CONSTRAINT [FK_tblLeave_tblLvType]
    FOREIGN KEY ([lvtyp_id])
    REFERENCES [dbo].[tblLvTypes]
        ([lvtyp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblLeave_tblLvType'
CREATE INDEX [IX_FK_tblLeave_tblLvType]
ON [dbo].[tblLeaves]
    ([lvtyp_id]);
GO

-- Creating foreign key on [lv_id] in table 'tblLvUsages'
ALTER TABLE [dbo].[tblLvUsages]
ADD CONSTRAINT [FK_tblLvUsage_tblLeave]
    FOREIGN KEY ([lv_id])
    REFERENCES [dbo].[tblLeaves]
        ([lv_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblLvUsage_tblLeave'
CREATE INDEX [IX_FK_tblLvUsage_tblLeave]
ON [dbo].[tblLvUsages]
    ([lv_id]);
GO

-- Creating foreign key on [emp_marital] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblMarital]
    FOREIGN KEY ([emp_marital])
    REFERENCES [dbo].[tblMaritals]
        ([marital_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblMarital'
CREATE INDEX [IX_FK_tblEmployees_tblMarital]
ON [dbo].[tblEmployees]
    ([emp_marital]);
GO

-- Creating foreign key on [emp_sex] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblGender]
    FOREIGN KEY ([emp_sex])
    REFERENCES [dbo].[tblGenders]
        ([emp_sx_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblGender'
CREATE INDEX [IX_FK_tblEmployees_tblGender]
ON [dbo].[tblEmployees]
    ([emp_sex]);
GO

-- Creating foreign key on [emp_id] in table 'tblContracts'
ALTER TABLE [dbo].[tblContracts]
ADD CONSTRAINT [FK_tblContracts_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblContracts_tblEmployees'
CREATE INDEX [IX_FK_tblContracts_tblEmployees]
ON [dbo].[tblContracts]
    ([emp_id]);
GO

-- Creating foreign key on [allowance_id] in table 'tblAllowanceLnks'
ALTER TABLE [dbo].[tblAllowanceLnks]
ADD CONSTRAINT [FK_tblAllowanceLnk_tblAllowances]
    FOREIGN KEY ([allowance_id])
    REFERENCES [dbo].[tblAllowances]
        ([allowance_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAllowanceLnk_tblAllowances'
CREATE INDEX [IX_FK_tblAllowanceLnk_tblAllowances]
ON [dbo].[tblAllowanceLnks]
    ([allowance_id]);
GO

-- Creating foreign key on [emp_id] in table 'tblAllowanceLnks'
ALTER TABLE [dbo].[tblAllowanceLnks]
ADD CONSTRAINT [FK_tblAllowanceLnk_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAllowanceLnk_tblEmployees'
CREATE INDEX [IX_FK_tblAllowanceLnk_tblEmployees]
ON [dbo].[tblAllowanceLnks]
    ([emp_id]);
GO

-- Creating foreign key on [emp_bnk] in table 'tblPayrolls'
ALTER TABLE [dbo].[tblPayrolls]
ADD CONSTRAINT [FK_tblPayroll_tblBanks]
    FOREIGN KEY ([emp_bnk])
    REFERENCES [dbo].[tblBanks]
        ([bnk_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPayroll_tblBanks'
CREATE INDEX [IX_FK_tblPayroll_tblBanks]
ON [dbo].[tblPayrolls]
    ([emp_bnk]);
GO

-- Creating foreign key on [cntcrt_typ_id] in table 'tblContracts'
ALTER TABLE [dbo].[tblContracts]
ADD CONSTRAINT [FK_tblContracts_tblContractTypes]
    FOREIGN KEY ([cntcrt_typ_id])
    REFERENCES [dbo].[tblContractTypes]
        ([cntcrt_typ_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblContracts_tblContractTypes'
CREATE INDEX [IX_FK_tblContracts_tblContractTypes]
ON [dbo].[tblContracts]
    ([cntcrt_typ_id]);
GO

-- Creating foreign key on [deduction_id] in table 'tblDeductionLnks'
ALTER TABLE [dbo].[tblDeductionLnks]
ADD CONSTRAINT [FK_tblDeductionLnk_tblDeductions]
    FOREIGN KEY ([deduction_id])
    REFERENCES [dbo].[tblDeductions]
        ([deduction_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDeductionLnk_tblDeductions'
CREATE INDEX [IX_FK_tblDeductionLnk_tblDeductions]
ON [dbo].[tblDeductionLnks]
    ([deduction_id]);
GO

-- Creating foreign key on [emp_id] in table 'tblDeductionLnks'
ALTER TABLE [dbo].[tblDeductionLnks]
ADD CONSTRAINT [FK_tblDeductionLnk_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDeductionLnk_tblEmployees'
CREATE INDEX [IX_FK_tblDeductionLnk_tblEmployees]
ON [dbo].[tblDeductionLnks]
    ([emp_id]);
GO

-- Creating foreign key on [emp_id] in table 'tblEmployeeContacts'
ALTER TABLE [dbo].[tblEmployeeContacts]
ADD CONSTRAINT [FK_EmployeeContacts_tblEmployees1]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeContacts_tblEmployees1'
CREATE INDEX [IX_FK_EmployeeContacts_tblEmployees1]
ON [dbo].[tblEmployeeContacts]
    ([emp_id]);
GO

-- Creating foreign key on [emp_sal] in table 'tblEmployees'
ALTER TABLE [dbo].[tblEmployees]
ADD CONSTRAINT [FK_tblEmployees_tblSalutation]
    FOREIGN KEY ([emp_sal])
    REFERENCES [dbo].[tblSalutations]
        ([sal_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployees_tblSalutation'
CREATE INDEX [IX_FK_tblEmployees_tblSalutation]
ON [dbo].[tblEmployees]
    ([emp_sal]);
GO

-- Creating foreign key on [emp_id] in table 'tblPayrolls'
ALTER TABLE [dbo].[tblPayrolls]
ADD CONSTRAINT [FK_tblPayroll_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPayroll_tblEmployees'
CREATE INDEX [IX_FK_tblPayroll_tblEmployees]
ON [dbo].[tblPayrolls]
    ([emp_id]);
GO

-- Creating foreign key on [emp_id] in table 'tblWkshftLinks'
ALTER TABLE [dbo].[tblWkshftLinks]
ADD CONSTRAINT [FK_tblWkshftLink_tblEmployees]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tblEmployees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWkshftLink_tblEmployees'
CREATE INDEX [IX_FK_tblWkshftLink_tblEmployees]
ON [dbo].[tblWkshftLinks]
    ([emp_id]);
GO

-- Creating foreign key on [emp_method] in table 'tblPayrolls'
ALTER TABLE [dbo].[tblPayrolls]
ADD CONSTRAINT [FK_tblPayroll_tblPayMethod]
    FOREIGN KEY ([emp_method])
    REFERENCES [dbo].[tblPayMethods]
        ([pay_method_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPayroll_tblPayMethod'
CREATE INDEX [IX_FK_tblPayroll_tblPayMethod]
ON [dbo].[tblPayrolls]
    ([emp_method]);
GO

-- Creating foreign key on [wkshft_id] in table 'tblWkshftLinks'
ALTER TABLE [dbo].[tblWkshftLinks]
ADD CONSTRAINT [FK_tblWkshftLink_tblWorkshifts]
    FOREIGN KEY ([wkshft_id])
    REFERENCES [dbo].[tblWorkshifts]
        ([wkshft_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWkshftLink_tblWorkshifts'
CREATE INDEX [IX_FK_tblWkshftLink_tblWorkshifts]
ON [dbo].[tblWkshftLinks]
    ([wkshft_id]);
GO

-- Creating foreign key on [rel_id] in table 'tblEmployeeContacts'
ALTER TABLE [dbo].[tblEmployeeContacts]
ADD CONSTRAINT [FK_tblEmployeeContacts_tblRelationships]
    FOREIGN KEY ([rel_id])
    REFERENCES [dbo].[tblRelationships]
        ([rel_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployeeContacts_tblRelationships'
CREATE INDEX [IX_FK_tblEmployeeContacts_tblRelationships]
ON [dbo].[tblEmployeeContacts]
    ([rel_id]);
GO

-- Creating foreign key on [emp_city] in table 'tblEmployeeContacts'
ALTER TABLE [dbo].[tblEmployeeContacts]
ADD CONSTRAINT [FK_tblEmployeeContacts_tblCity]
    FOREIGN KEY ([emp_city])
    REFERENCES [dbo].[tblCities]
        ([cty_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmployeeContacts_tblCity'
CREATE INDEX [IX_FK_tblEmployeeContacts_tblCity]
ON [dbo].[tblEmployeeContacts]
    ([emp_city]);
GO

-- Creating foreign key on [prov_id] in table 'tblCities'
ALTER TABLE [dbo].[tblCities]
ADD CONSTRAINT [FK_tblCity_tblProvince]
    FOREIGN KEY ([prov_id])
    REFERENCES [dbo].[tblProvinces]
        ([prov_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCity_tblProvince'
CREATE INDEX [IX_FK_tblCity_tblProvince]
ON [dbo].[tblCities]
    ([prov_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------