using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hrm_SystemCore.Migrations
{
    /// <inheritdoc />
    public partial class IdentityInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAllowances",
                columns: table => new
                {
                    allowance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    allowance_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowance_value = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    allowance_perc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowance_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllowances", x => x.allowance_id);
                });

            migrationBuilder.CreateTable(
                name: "tblBanks",
                columns: table => new
                {
                    bnk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bnk_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bnk_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBanks", x => x.bnk_id);
                });

            migrationBuilder.CreateTable(
                name: "tblBranches",
                columns: table => new
                {
                    br_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    br_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    br_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    br_contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    br_descr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBranches", x => x.br_id);
                });

            migrationBuilder.CreateTable(
                name: "tblContractStates",
                columns: table => new
                {
                    cntrct_st_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cntrct_state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cntrct_st_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContractStates", x => x.cntrct_st_id);
                });

            migrationBuilder.CreateTable(
                name: "tblContractTypes",
                columns: table => new
                {
                    cntcrt_typ_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cntrct_typ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cntrct_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContractTypes", x => x.cntcrt_typ_id);
                });

            migrationBuilder.CreateTable(
                name: "tblCourseTypes",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typ_descr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCourseTypes", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "tblDeductions",
                columns: table => new
                {
                    deduction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deduction_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deduction_value = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    deduction_perc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deduction_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDeductions", x => x.deduction_id);
                });

            migrationBuilder.CreateTable(
                name: "tblDepartments",
                columns: table => new
                {
                    dpt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dpt_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dpt_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartments", x => x.dpt_id);
                });

            migrationBuilder.CreateTable(
                name: "tblEduLevels",
                columns: table => new
                {
                    edu_lv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    edu_lv_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEduLevels", x => x.edu_lv_id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeeStatus",
                columns: table => new
                {
                    empst_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empst_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empst_descr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeStatus", x => x.empst_id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmplStatus",
                columns: table => new
                {
                    stat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stat_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stat_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmplStatus", x => x.stat_id);
                });

            migrationBuilder.CreateTable(
                name: "tblGenders",
                columns: table => new
                {
                    emp_sx_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_sex = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenders", x => x.emp_sx_id);
                });

            migrationBuilder.CreateTable(
                name: "tblgrades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblgrades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblImages",
                columns: table => new
                {
                    img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    img_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    img_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblImages", x => x.img_id);
                });

            migrationBuilder.CreateTable(
                name: "tblJobLevels",
                columns: table => new
                {
                    lvl_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lvl_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lvl_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobLevels", x => x.lvl_id);
                });

            migrationBuilder.CreateTable(
                name: "tblLvTypes",
                columns: table => new
                {
                    lvtyp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lvtyp_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lvtyp_num = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLvTypes", x => x.lvtyp_id);
                });

            migrationBuilder.CreateTable(
                name: "tblMaritals",
                columns: table => new
                {
                    marital_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marital_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaritals", x => x.marital_id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrganisations",
                columns: table => new
                {
                    org_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    org_logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    org_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    org_descr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    org_phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrganisations", x => x.org_id);
                });

            migrationBuilder.CreateTable(
                name: "tblPayMethods",
                columns: table => new
                {
                    pay_method_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pay_title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayMethods", x => x.pay_method_id);
                });

            migrationBuilder.CreateTable(
                name: "tblProvinces",
                columns: table => new
                {
                    prov_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prov_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProvinces", x => x.prov_id);
                });

            migrationBuilder.CreateTable(
                name: "tblRelationships",
                columns: table => new
                {
                    rel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rel_title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRelationships", x => x.rel_id);
                });

            migrationBuilder.CreateTable(
                name: "tblSalutations",
                columns: table => new
                {
                    sal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sal_title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSalutations", x => x.sal_id);
                });

            migrationBuilder.CreateTable(
                name: "tblWorkshifts",
                columns: table => new
                {
                    wkshft_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wkshft_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wkshft_hrs = table.Column<int>(type: "int", nullable: true),
                    wkshft_from = table.Column<TimeSpan>(type: "time", nullable: true),
                    wkshft_to = table.Column<TimeSpan>(type: "time", nullable: true),
                    wkshft_lunch_from = table.Column<TimeSpan>(type: "time", nullable: true),
                    wkshft_lunch_to = table.Column<TimeSpan>(type: "time", nullable: true),
                    wkshft_brk_from = table.Column<TimeSpan>(type: "time", nullable: true),
                    wkshft_brk_to = table.Column<TimeSpan>(type: "time", nullable: true),
                    wkshft_xtrabrk_from = table.Column<TimeSpan>(type: "time", nullable: true),
                    wkshft_xtrabrk_to = table.Column<TimeSpan>(type: "time", nullable: true),
                    wkshft_notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inputter = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWorkshifts", x => x.wkshft_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCourses",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_nm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_dur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_descr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    tblCourseTypetype_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCourses", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_tblCourses_tblCourseTypes_tblCourseTypetype_id",
                        column: x => x.tblCourseTypetype_id,
                        principalTable: "tblCourseTypes",
                        principalColumn: "type_id");
                });

            migrationBuilder.CreateTable(
                name: "tblPositions",
                columns: table => new
                {
                    pos_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lvl_id = table.Column<int>(type: "int", nullable: true),
                    pos_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pos_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dp_id = table.Column<int>(type: "int", nullable: true),
                    tblJobLevellvl_id = table.Column<int>(type: "int", nullable: true),
                    tblDepartmentdpt_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPositions", x => x.pos_id);
                    table.ForeignKey(
                        name: "FK_tblPositions_tblDepartments_tblDepartmentdpt_id",
                        column: x => x.tblDepartmentdpt_id,
                        principalTable: "tblDepartments",
                        principalColumn: "dpt_id");
                    table.ForeignKey(
                        name: "FK_tblPositions_tblJobLevels_tblJobLevellvl_id",
                        column: x => x.tblJobLevellvl_id,
                        principalTable: "tblJobLevels",
                        principalColumn: "lvl_id");
                });

            migrationBuilder.CreateTable(
                name: "tblCities",
                columns: table => new
                {
                    cty_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cty_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prov_id = table.Column<int>(type: "int", nullable: true),
                    tblProvinceprov_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCities", x => x.cty_id);
                    table.ForeignKey(
                        name: "FK_tblCities_tblProvinces_tblProvinceprov_id",
                        column: x => x.tblProvinceprov_id,
                        principalTable: "tblProvinces",
                        principalColumn: "prov_id");
                });

            migrationBuilder.CreateTable(
                name: "tblTrainingSessions",
                columns: table => new
                {
                    tr_sess_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: true),
                    tr_sdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tr_edate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tr_sess_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tr_sess_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tr_sess_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblCourscourse_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrainingSessions", x => x.tr_sess_id);
                    table.ForeignKey(
                        name: "FK_tblTrainingSessions_tblCourses_tblCourscourse_id",
                        column: x => x.tblCourscourse_id,
                        principalTable: "tblCourses",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "tblEmployees",
                columns: table => new
                {
                    emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_branch = table.Column<int>(type: "int", nullable: true),
                    emp_dpt = table.Column<int>(type: "int", nullable: true),
                    emp_status = table.Column<int>(type: "int", nullable: true),
                    emp_bDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    emp_jDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    emp_cDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    emp_pos_id = table.Column<int>(type: "int", nullable: true),
                    emp_id_num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_ec_num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_nation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_state = table.Column<int>(type: "int", nullable: true),
                    img_id = table.Column<int>(type: "int", nullable: true),
                    emp_sex = table.Column<int>(type: "int", nullable: true),
                    emp_marital = table.Column<int>(type: "int", nullable: true),
                    emp_sal = table.Column<int>(type: "int", nullable: true),
                    emp_mid_names = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_passport_num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_passport_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    emp_drv_num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblBranchbr_id = table.Column<int>(type: "int", nullable: true),
                    tblDepartmentdpt_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeStatuempst_id = table.Column<int>(type: "int", nullable: true),
                    tblPositionpos_id = table.Column<int>(type: "int", nullable: true),
                    tblEmplStatustat_id = table.Column<int>(type: "int", nullable: true),
                    tblImageimg_id = table.Column<int>(type: "int", nullable: true),
                    tblMaritalmarital_id = table.Column<int>(type: "int", nullable: true),
                    tblGenderemp_sx_id = table.Column<int>(type: "int", nullable: true),
                    tblSalutationsal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployees", x => x.emp_id);
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblBranches_tblBranchbr_id",
                        column: x => x.tblBranchbr_id,
                        principalTable: "tblBranches",
                        principalColumn: "br_id");
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblDepartments_tblDepartmentdpt_id",
                        column: x => x.tblDepartmentdpt_id,
                        principalTable: "tblDepartments",
                        principalColumn: "dpt_id");
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblEmplStatus_tblEmplStatustat_id",
                        column: x => x.tblEmplStatustat_id,
                        principalTable: "tblEmplStatus",
                        principalColumn: "stat_id");
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblEmployeeStatus_tblEmployeeStatuempst_id",
                        column: x => x.tblEmployeeStatuempst_id,
                        principalTable: "tblEmployeeStatus",
                        principalColumn: "empst_id");
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblGenders_tblGenderemp_sx_id",
                        column: x => x.tblGenderemp_sx_id,
                        principalTable: "tblGenders",
                        principalColumn: "emp_sx_id");
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblImages_tblImageimg_id",
                        column: x => x.tblImageimg_id,
                        principalTable: "tblImages",
                        principalColumn: "img_id");
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblMaritals_tblMaritalmarital_id",
                        column: x => x.tblMaritalmarital_id,
                        principalTable: "tblMaritals",
                        principalColumn: "marital_id");
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblPositions_tblPositionpos_id",
                        column: x => x.tblPositionpos_id,
                        principalTable: "tblPositions",
                        principalColumn: "pos_id");
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblSalutations_tblSalutationsal_id",
                        column: x => x.tblSalutationsal_id,
                        principalTable: "tblSalutations",
                        principalColumn: "sal_id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAchievements",
                columns: table => new
                {
                    achvt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    achvt_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    achvt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    achvt_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAchievements", x => x.achvt_id);
                    table.ForeignKey(
                        name: "FK_tblAchievements_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblAllowanceLnks",
                columns: table => new
                {
                    allow_lnk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    allowance_id = table.Column<int>(type: "int", nullable: true),
                    allowance_amnt = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    allowance_sdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    allowance_edate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    allowance_perm = table.Column<bool>(type: "bit", nullable: true),
                    allowance_month = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    allowance_notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblAllowanceallowance_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllowanceLnks", x => x.allow_lnk_id);
                    table.ForeignKey(
                        name: "FK_tblAllowanceLnks_tblAllowances_tblAllowanceallowance_id",
                        column: x => x.tblAllowanceallowance_id,
                        principalTable: "tblAllowances",
                        principalColumn: "allowance_id");
                    table.ForeignKey(
                        name: "FK_tblAllowanceLnks_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblContracts",
                columns: table => new
                {
                    cntrct_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    cntrct_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cntrct_sdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cntrct_edate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cntrct_state = table.Column<int>(type: "int", nullable: true),
                    cntcrt_typ_id = table.Column<int>(type: "int", nullable: true),
                    cntrct_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dpt_id = table.Column<int>(type: "int", nullable: true),
                    br_id = table.Column<int>(type: "int", nullable: true),
                    pos_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true),
                    tblContractTypecntcrt_typ_id = table.Column<int>(type: "int", nullable: true),
                    tblContractStatecntrct_st_id = table.Column<int>(type: "int", nullable: true),
                    tblBranchbr_id = table.Column<int>(type: "int", nullable: true),
                    tblDepartmentdpt_id = table.Column<int>(type: "int", nullable: true),
                    tblPositionpos_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContracts", x => x.cntrct_id);
                    table.ForeignKey(
                        name: "FK_tblContracts_tblBranches_tblBranchbr_id",
                        column: x => x.tblBranchbr_id,
                        principalTable: "tblBranches",
                        principalColumn: "br_id");
                    table.ForeignKey(
                        name: "FK_tblContracts_tblContractStates_tblContractStatecntrct_st_id",
                        column: x => x.tblContractStatecntrct_st_id,
                        principalTable: "tblContractStates",
                        principalColumn: "cntrct_st_id");
                    table.ForeignKey(
                        name: "FK_tblContracts_tblContractTypes_tblContractTypecntcrt_typ_id",
                        column: x => x.tblContractTypecntcrt_typ_id,
                        principalTable: "tblContractTypes",
                        principalColumn: "cntcrt_typ_id");
                    table.ForeignKey(
                        name: "FK_tblContracts_tblDepartments_tblDepartmentdpt_id",
                        column: x => x.tblDepartmentdpt_id,
                        principalTable: "tblDepartments",
                        principalColumn: "dpt_id");
                    table.ForeignKey(
                        name: "FK_tblContracts_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_tblContracts_tblPositions_tblPositionpos_id",
                        column: x => x.tblPositionpos_id,
                        principalTable: "tblPositions",
                        principalColumn: "pos_id");
                });

            migrationBuilder.CreateTable(
                name: "tblDeductionLnks",
                columns: table => new
                {
                    ded_lnk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deduction_id = table.Column<int>(type: "int", nullable: true),
                    deduction_amnt = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    deduction_sdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deduction_edate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deduction_permanent = table.Column<bool>(type: "bit", nullable: true),
                    deduction_mnth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    deduction_notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblDeductiondeduction_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDeductionLnks", x => x.ded_lnk_id);
                    table.ForeignKey(
                        name: "FK_tblDeductionLnks_tblDeductions_tblDeductiondeduction_id",
                        column: x => x.tblDeductiondeduction_id,
                        principalTable: "tblDeductions",
                        principalColumn: "deduction_id");
                    table.ForeignKey(
                        name: "FK_tblDeductionLnks_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblDependants",
                columns: table => new
                {
                    dep_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    dep_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dep_dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dep_rltn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDependants", x => x.dep_id);
                    table.ForeignKey(
                        name: "FK_tblDependants_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblDocuments",
                columns: table => new
                {
                    doc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doc_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    doc_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    doc_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDocuments", x => x.doc_id);
                    table.ForeignKey(
                        name: "FK_tblDocuments_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblEducations",
                columns: table => new
                {
                    edu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    edu_lvl_id = table.Column<int>(type: "int", nullable: true),
                    edu_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edu_qlfcn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edu_score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edu_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edu_sdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    edu_edate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tblEduLeveledu_lv_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEducations", x => x.edu_id);
                    table.ForeignKey(
                        name: "FK_tblEducations_tblEduLevels_tblEduLeveledu_lv_id",
                        column: x => x.tblEduLeveledu_lv_id,
                        principalTable: "tblEduLevels",
                        principalColumn: "edu_lv_id");
                    table.ForeignKey(
                        name: "FK_tblEducations_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeeContacts",
                columns: table => new
                {
                    cnt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    emp_strt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_nghbhd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_city = table.Column<int>(type: "int", nullable: true),
                    emp_province = table.Column<int>(type: "int", nullable: true),
                    emp_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_kin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_kin_add = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_kin_ph = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rel_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true),
                    tblRelationshiprel_id = table.Column<int>(type: "int", nullable: true),
                    tblCitycty_id = table.Column<int>(type: "int", nullable: true),
                    tblProvinceprov_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeContacts", x => x.cnt_id);
                    table.ForeignKey(
                        name: "FK_tblEmployeeContacts_tblCities_tblCitycty_id",
                        column: x => x.tblCitycty_id,
                        principalTable: "tblCities",
                        principalColumn: "cty_id");
                    table.ForeignKey(
                        name: "FK_tblEmployeeContacts_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_tblEmployeeContacts_tblProvinces_tblProvinceprov_id",
                        column: x => x.tblProvinceprov_id,
                        principalTable: "tblProvinces",
                        principalColumn: "prov_id");
                    table.ForeignKey(
                        name: "FK_tblEmployeeContacts_tblRelationships_tblRelationshiprel_id",
                        column: x => x.tblRelationshiprel_id,
                        principalTable: "tblRelationships",
                        principalColumn: "rel_id");
                });

            migrationBuilder.CreateTable(
                name: "tblKPIs",
                columns: table => new
                {
                    kpi_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    kpi_score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kpi_prd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kpi_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    kpi_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kpi_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKPIs", x => x.kpi_id);
                    table.ForeignKey(
                        name: "FK_tblKPIs_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblLeaves",
                columns: table => new
                {
                    lv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lv_bal = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    lvtyp_id = table.Column<int>(type: "int", nullable: true),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    lv_period = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true),
                    tblLvTypelvtyp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeaves", x => x.lv_id);
                    table.ForeignKey(
                        name: "FK_tblLeaves_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_tblLeaves_tblLvTypes_tblLvTypelvtyp_id",
                        column: x => x.tblLvTypelvtyp_id,
                        principalTable: "tblLvTypes",
                        principalColumn: "lvtyp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblPayrolls",
                columns: table => new
                {
                    pay_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    emp_Salary = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    emp_bnk = table.Column<int>(type: "int", nullable: true),
                    emp_method = table.Column<int>(type: "int", nullable: true),
                    emp_acc_num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pay_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pay_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pay_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tblBankbnk_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true),
                    tblPayMethodpay_method_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayrolls", x => x.pay_id);
                    table.ForeignKey(
                        name: "FK_tblPayrolls_tblBanks_tblBankbnk_id",
                        column: x => x.tblBankbnk_id,
                        principalTable: "tblBanks",
                        principalColumn: "bnk_id");
                    table.ForeignKey(
                        name: "FK_tblPayrolls_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_tblPayrolls_tblPayMethods_tblPayMethodpay_method_id",
                        column: x => x.tblPayMethodpay_method_id,
                        principalTable: "tblPayMethods",
                        principalColumn: "pay_method_id");
                });

            migrationBuilder.CreateTable(
                name: "tblPositionHistories",
                columns: table => new
                {
                    ph_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    pos_id = table.Column<int>(type: "int", nullable: true),
                    dpt_id = table.Column<int>(type: "int", nullable: true),
                    ph_sal = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    br_id = table.Column<int>(type: "int", nullable: true),
                    ph_sDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ph_eDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tblBranchbr_id = table.Column<int>(type: "int", nullable: true),
                    tblDepartmentdpt_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true),
                    tblPositionpos_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPositionHistories", x => x.ph_id);
                    table.ForeignKey(
                        name: "FK_tblPositionHistories_tblBranches_tblBranchbr_id",
                        column: x => x.tblBranchbr_id,
                        principalTable: "tblBranches",
                        principalColumn: "br_id");
                    table.ForeignKey(
                        name: "FK_tblPositionHistories_tblDepartments_tblDepartmentdpt_id",
                        column: x => x.tblDepartmentdpt_id,
                        principalTable: "tblDepartments",
                        principalColumn: "dpt_id");
                    table.ForeignKey(
                        name: "FK_tblPositionHistories_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_tblPositionHistories_tblPositions_tblPositionpos_id",
                        column: x => x.tblPositionpos_id,
                        principalTable: "tblPositions",
                        principalColumn: "pos_id");
                });

            migrationBuilder.CreateTable(
                name: "tblTrainings",
                columns: table => new
                {
                    tr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    tr_sdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tr_edate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tr_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tr_score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tr_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tr_sess_id = table.Column<int>(type: "int", nullable: true),
                    tblCourscourse_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true),
                    tblTrainingSessiontr_sess_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrainings", x => x.tr_id);
                    table.ForeignKey(
                        name: "FK_tblTrainings_tblCourses_tblCourscourse_id",
                        column: x => x.tblCourscourse_id,
                        principalTable: "tblCourses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_tblTrainings_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_tblTrainings_tblTrainingSessions_tblTrainingSessiontr_sess_id",
                        column: x => x.tblTrainingSessiontr_sess_id,
                        principalTable: "tblTrainingSessions",
                        principalColumn: "tr_sess_id");
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_tblUsers_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "tblWkshftLinks",
                columns: table => new
                {
                    wk_lnk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wkshft_id = table.Column<int>(type: "int", nullable: true),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    wk_lnk_stDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    wk_lnk_eDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    wk_lnk_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true),
                    tblWorkshiftwkshft_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWkshftLinks", x => x.wk_lnk_id);
                    table.ForeignKey(
                        name: "FK_tblWkshftLinks_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_tblWkshftLinks_tblWorkshifts_tblWorkshiftwkshft_id",
                        column: x => x.tblWorkshiftwkshft_id,
                        principalTable: "tblWorkshifts",
                        principalColumn: "wkshft_id");
                });

            migrationBuilder.CreateTable(
                name: "tblWorks",
                columns: table => new
                {
                    wrk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    wk_company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wk_position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wk_sdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    wk_edate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    wk_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wk_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWorks", x => x.wrk_id);
                    table.ForeignKey(
                        name: "FK_tblWorks_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblLvUsages",
                columns: table => new
                {
                    lv_u_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    lv_id = table.Column<int>(type: "int", nullable: true),
                    lv_sdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lv_edate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lv_days = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    lv_bal = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    lv_state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblEmployeeemp_id = table.Column<int>(type: "int", nullable: true),
                    tblLeavelv_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLvUsages", x => x.lv_u_id);
                    table.ForeignKey(
                        name: "FK_tblLvUsages_tblEmployees_tblEmployeeemp_id",
                        column: x => x.tblEmployeeemp_id,
                        principalTable: "tblEmployees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_tblLvUsages_tblLeaves_tblLeavelv_id",
                        column: x => x.tblLeavelv_id,
                        principalTable: "tblLeaves",
                        principalColumn: "lv_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblAchievements_tblEmployeeemp_id",
                table: "tblAchievements",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllowanceLnks_tblAllowanceallowance_id",
                table: "tblAllowanceLnks",
                column: "tblAllowanceallowance_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllowanceLnks_tblEmployeeemp_id",
                table: "tblAllowanceLnks",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblCities_tblProvinceprov_id",
                table: "tblCities",
                column: "tblProvinceprov_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_tblBranchbr_id",
                table: "tblContracts",
                column: "tblBranchbr_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_tblContractStatecntrct_st_id",
                table: "tblContracts",
                column: "tblContractStatecntrct_st_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_tblContractTypecntcrt_typ_id",
                table: "tblContracts",
                column: "tblContractTypecntcrt_typ_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_tblDepartmentdpt_id",
                table: "tblContracts",
                column: "tblDepartmentdpt_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_tblEmployeeemp_id",
                table: "tblContracts",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_tblPositionpos_id",
                table: "tblContracts",
                column: "tblPositionpos_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblCourses_tblCourseTypetype_id",
                table: "tblCourses",
                column: "tblCourseTypetype_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeductionLnks_tblDeductiondeduction_id",
                table: "tblDeductionLnks",
                column: "tblDeductiondeduction_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeductionLnks_tblEmployeeemp_id",
                table: "tblDeductionLnks",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblDependants_tblEmployeeemp_id",
                table: "tblDependants",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblDocuments_tblEmployeeemp_id",
                table: "tblDocuments",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEducations_tblEduLeveledu_lv_id",
                table: "tblEducations",
                column: "tblEduLeveledu_lv_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEducations_tblEmployeeemp_id",
                table: "tblEducations",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeContacts_tblCitycty_id",
                table: "tblEmployeeContacts",
                column: "tblCitycty_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeContacts_tblEmployeeemp_id",
                table: "tblEmployeeContacts",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeContacts_tblProvinceprov_id",
                table: "tblEmployeeContacts",
                column: "tblProvinceprov_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeContacts_tblRelationshiprel_id",
                table: "tblEmployeeContacts",
                column: "tblRelationshiprel_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblBranchbr_id",
                table: "tblEmployees",
                column: "tblBranchbr_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblDepartmentdpt_id",
                table: "tblEmployees",
                column: "tblDepartmentdpt_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblEmployeeStatuempst_id",
                table: "tblEmployees",
                column: "tblEmployeeStatuempst_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblEmplStatustat_id",
                table: "tblEmployees",
                column: "tblEmplStatustat_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblGenderemp_sx_id",
                table: "tblEmployees",
                column: "tblGenderemp_sx_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblImageimg_id",
                table: "tblEmployees",
                column: "tblImageimg_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblMaritalmarital_id",
                table: "tblEmployees",
                column: "tblMaritalmarital_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblPositionpos_id",
                table: "tblEmployees",
                column: "tblPositionpos_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_tblSalutationsal_id",
                table: "tblEmployees",
                column: "tblSalutationsal_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblKPIs_tblEmployeeemp_id",
                table: "tblKPIs",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblLeaves_tblEmployeeemp_id",
                table: "tblLeaves",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblLeaves_tblLvTypelvtyp_id",
                table: "tblLeaves",
                column: "tblLvTypelvtyp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblLvUsages_tblEmployeeemp_id",
                table: "tblLvUsages",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblLvUsages_tblLeavelv_id",
                table: "tblLvUsages",
                column: "tblLeavelv_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayrolls_tblBankbnk_id",
                table: "tblPayrolls",
                column: "tblBankbnk_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayrolls_tblEmployeeemp_id",
                table: "tblPayrolls",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayrolls_tblPayMethodpay_method_id",
                table: "tblPayrolls",
                column: "tblPayMethodpay_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPositionHistories_tblBranchbr_id",
                table: "tblPositionHistories",
                column: "tblBranchbr_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPositionHistories_tblDepartmentdpt_id",
                table: "tblPositionHistories",
                column: "tblDepartmentdpt_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPositionHistories_tblEmployeeemp_id",
                table: "tblPositionHistories",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPositionHistories_tblPositionpos_id",
                table: "tblPositionHistories",
                column: "tblPositionpos_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPositions_tblDepartmentdpt_id",
                table: "tblPositions",
                column: "tblDepartmentdpt_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPositions_tblJobLevellvl_id",
                table: "tblPositions",
                column: "tblJobLevellvl_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainings_tblCourscourse_id",
                table: "tblTrainings",
                column: "tblCourscourse_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainings_tblEmployeeemp_id",
                table: "tblTrainings",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainings_tblTrainingSessiontr_sess_id",
                table: "tblTrainings",
                column: "tblTrainingSessiontr_sess_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingSessions_tblCourscourse_id",
                table: "tblTrainingSessions",
                column: "tblCourscourse_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_tblEmployeeemp_id",
                table: "tblUsers",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblWkshftLinks_tblEmployeeemp_id",
                table: "tblWkshftLinks",
                column: "tblEmployeeemp_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblWkshftLinks_tblWorkshiftwkshft_id",
                table: "tblWkshftLinks",
                column: "tblWorkshiftwkshft_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblWorks_tblEmployeeemp_id",
                table: "tblWorks",
                column: "tblEmployeeemp_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tblAchievements");

            migrationBuilder.DropTable(
                name: "tblAllowanceLnks");

            migrationBuilder.DropTable(
                name: "tblContracts");

            migrationBuilder.DropTable(
                name: "tblDeductionLnks");

            migrationBuilder.DropTable(
                name: "tblDependants");

            migrationBuilder.DropTable(
                name: "tblDocuments");

            migrationBuilder.DropTable(
                name: "tblEducations");

            migrationBuilder.DropTable(
                name: "tblEmployeeContacts");

            migrationBuilder.DropTable(
                name: "tblgrades");

            migrationBuilder.DropTable(
                name: "tblKPIs");

            migrationBuilder.DropTable(
                name: "tblLvUsages");

            migrationBuilder.DropTable(
                name: "tblOrganisations");

            migrationBuilder.DropTable(
                name: "tblPayrolls");

            migrationBuilder.DropTable(
                name: "tblPositionHistories");

            migrationBuilder.DropTable(
                name: "tblTrainings");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblWkshftLinks");

            migrationBuilder.DropTable(
                name: "tblWorks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblAllowances");

            migrationBuilder.DropTable(
                name: "tblContractStates");

            migrationBuilder.DropTable(
                name: "tblContractTypes");

            migrationBuilder.DropTable(
                name: "tblDeductions");

            migrationBuilder.DropTable(
                name: "tblEduLevels");

            migrationBuilder.DropTable(
                name: "tblCities");

            migrationBuilder.DropTable(
                name: "tblRelationships");

            migrationBuilder.DropTable(
                name: "tblLeaves");

            migrationBuilder.DropTable(
                name: "tblBanks");

            migrationBuilder.DropTable(
                name: "tblPayMethods");

            migrationBuilder.DropTable(
                name: "tblTrainingSessions");

            migrationBuilder.DropTable(
                name: "tblWorkshifts");

            migrationBuilder.DropTable(
                name: "tblProvinces");

            migrationBuilder.DropTable(
                name: "tblEmployees");

            migrationBuilder.DropTable(
                name: "tblLvTypes");

            migrationBuilder.DropTable(
                name: "tblCourses");

            migrationBuilder.DropTable(
                name: "tblBranches");

            migrationBuilder.DropTable(
                name: "tblEmplStatus");

            migrationBuilder.DropTable(
                name: "tblEmployeeStatus");

            migrationBuilder.DropTable(
                name: "tblGenders");

            migrationBuilder.DropTable(
                name: "tblImages");

            migrationBuilder.DropTable(
                name: "tblMaritals");

            migrationBuilder.DropTable(
                name: "tblPositions");

            migrationBuilder.DropTable(
                name: "tblSalutations");

            migrationBuilder.DropTable(
                name: "tblCourseTypes");

            migrationBuilder.DropTable(
                name: "tblDepartments");

            migrationBuilder.DropTable(
                name: "tblJobLevels");
        }
    }
}
