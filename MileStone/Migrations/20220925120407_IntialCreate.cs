using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MileStone.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IqamaExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PassportNumber = table.Column<string>(type: "text", nullable: true),
                    PassportExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ContractRenewalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Skills = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    SectorId = table.Column<Guid>(type: "uuid", nullable: false),
                    SectorName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "BusinessCases",
                columns: table => new
                {
                    BusinessCaseID = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessCaseName = table.Column<string>(type: "text", nullable: true),
                    BusinessCaseDescription = table.Column<string>(type: "text", nullable: true),
                    BusinessCaseIdea = table.Column<string>(type: "text", nullable: true),
                    BusinessCaseJustification = table.Column<string>(type: "text", nullable: true),
                    Importance = table.Column<string>(type: "text", nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ExpectedDuration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EstimatedBudget = table.Column<decimal>(type: "numeric", nullable: false),
                    CadresRequiredForTheProjectResources = table.Column<string>(type: "text", nullable: true),
                    BusinessCaseImplementationMechanismProjectExecution = table.Column<string>(type: "text", nullable: true),
                    TheExistenceOfTheRFPReadiness = table.Column<string>(type: "text", nullable: true),
                    AssociatedStrategicObjectives = table.Column<string>(type: "text", nullable: true),
                    AssociatedBudgetLineItem = table.Column<string>(type: "text", nullable: true),
                    AssociatedBudgetLineItemNumber = table.Column<int>(type: "integer", nullable: false),
                    ImplementationObjectives = table.Column<string>(type: "text", nullable: true),
                    ExpectedInvestmentValue = table.Column<decimal>(type: "numeric", nullable: false),
                    PaybackPeriodInMonths = table.Column<decimal>(type: "numeric", nullable: false),
                    FinalValueOfInvestmentInRiyals = table.Column<decimal>(type: "numeric", nullable: false),
                    ReturnOnInvestmentROI = table.Column<decimal>(type: "numeric", nullable: false),
                    SectorID = table.Column<Guid>(type: "uuid", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCases", x => x.BusinessCaseID);
                    table.ForeignKey(
                        name: "FK_BusinessCases_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessCases_Sectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCharters",
                columns: table => new
                {
                    ProjectCharterId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectName = table.Column<string>(type: "text", nullable: true),
                    ProjectCode = table.Column<int>(type: "integer", nullable: false),
                    ProjectSponsor = table.Column<string>(type: "text", nullable: true),
                    ProjectObjectives = table.Column<string>(type: "text", nullable: true),
                    ProjectDescription = table.Column<string>(type: "text", nullable: true),
                    ProjectBenefits = table.Column<string>(type: "text", nullable: true),
                    ReturnOnInvestment = table.Column<decimal>(type: "numeric", nullable: false),
                    ProjectDuration = table.Column<string>(type: "text", nullable: true),
                    ApprovedBudget = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProjectDeliverables = table.Column<string>(type: "text", nullable: true),
                    Assumptions = table.Column<string>(type: "text", nullable: true),
                    ProjectLimitations = table.Column<string>(type: "text", nullable: true),
                    Dependencies = table.Column<string>(type: "text", nullable: true),
                    ProjectPurchasesProcurement = table.Column<string>(type: "text", nullable: true),
                    KeySuccessFactors = table.Column<string>(type: "text", nullable: true),
                    ProjectLocation = table.Column<string>(type: "text", nullable: true),
                    ImplementingEntityCompanyName = table.Column<string>(type: "text", nullable: true),
                    PerformanceMeasurementStandard_CriteriaKeyPerformanceIndicators = table.Column<string>(type: "text", nullable: true),
                    RiskMeasurementCriteriaKeyRisksIndicators = table.Column<string>(type: "text", nullable: true),
                    QualityMeasurementStandardsKeyQualityIndicators = table.Column<string>(type: "text", nullable: true),
                    CriteriaForMeasuringTheAchievementOfBenefitsRealizationIndicat = table.Column<string>(name: "CriteriaForMeasuringTheAchievementOfBenefitsRealizationIndicat~", type: "text", nullable: true),
                    CriteriaForMeasuringreturnOnInvestmentROIIndicators = table.Column<string>(type: "text", nullable: true),
                    InScope = table.Column<string>(type: "text", nullable: true),
                    OutOfWork = table.Column<string>(type: "text", nullable: true),
                    ProjectManagerName = table.Column<string>(type: "text", nullable: true),
                    ValidityName = table.Column<string>(type: "text", nullable: true),
                    RecruitmentOfCadres = table.Column<string>(type: "text", nullable: true),
                    ApprovalOfContracts = table.Column<string>(type: "text", nullable: true),
                    ApproveChangeOrders = table.Column<string>(type: "text", nullable: true),
                    OutputAccreditation = table.Column<string>(type: "text", nullable: true),
                    NameOftheCriterion = table.Column<string>(type: "text", nullable: true),
                    CheckTheQualityOfTheOutput = table.Column<string>(type: "text", nullable: true),
                    ListOfFutilityOfCompletingTheProject = table.Column<string>(type: "text", nullable: true),
                    SectorID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCharters", x => x.ProjectCharterId);
                    table.ForeignKey(
                        name: "FK_ProjectCharters_Sectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectManagementPlans",
                columns: table => new
                {
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectManagementPlanName = table.Column<string>(type: "text", nullable: true),
                    ProjectCode = table.Column<int>(type: "integer", nullable: false),
                    ProjectSponsor = table.Column<string>(type: "text", nullable: true),
                    ProjectObjectives = table.Column<string>(type: "text", nullable: true),
                    ProjectDescription = table.Column<string>(type: "text", nullable: true),
                    ReturnOnInvestment = table.Column<decimal>(type: "numeric", nullable: false),
                    ProjectDuration = table.Column<string>(type: "text", nullable: true),
                    PlannedStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PlannedFinishDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ApprovedProjectBudget = table.Column<decimal>(type: "numeric", nullable: false),
                    Deliverables = table.Column<string>(type: "text", nullable: true),
                    Dependencies = table.Column<string>(type: "text", nullable: true),
                    Procurement = table.Column<string>(type: "text", nullable: true),
                    KeySuccessFactors = table.Column<string>(type: "text", nullable: true),
                    ProjectLocation = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    KeyPerformanceIndicators = table.Column<string>(type: "text", nullable: true),
                    KeyRisksIndicators = table.Column<string>(type: "text", nullable: true),
                    KeyQualityIndicators = table.Column<string>(type: "text", nullable: true),
                    BenefitsRealizationIndicators = table.Column<string>(type: "text", nullable: true),
                    ROIIndicators = table.Column<string>(type: "text", nullable: true),
                    NameOftheCriterion = table.Column<string>(type: "text", nullable: true),
                    CheckTheQualityOfTheOutput = table.Column<string>(type: "text", nullable: true),
                    ListOfFutilityOfCompletingTheProject = table.Column<string>(type: "text", nullable: true),
                    SectorID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManagementPlans", x => x.ProjectManagementPlanId);
                    table.ForeignKey(
                        name: "FK_ProjectManagementPlans_Sectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCaseWithProjects",
                columns: table => new
                {
                    ProjectID = table.Column<Guid>(type: "uuid", nullable: false),
                    BusienssCaseID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCaseWithProjects", x => new { x.BusienssCaseID, x.ProjectID });
                    table.ForeignKey(
                        name: "FK_BusinessCaseWithProjects_BusinessCases_BusienssCaseID",
                        column: x => x.BusienssCaseID,
                        principalTable: "BusinessCases",
                        principalColumn: "BusinessCaseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessCaseWithProjects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCashFlows",
                columns: table => new
                {
                    ProjectCashFlowId = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    BusinessCaseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCashFlows", x => x.ProjectCashFlowId);
                    table.ForeignKey(
                        name: "FK_ProjectCashFlows_BusinessCases_BusinessCaseId",
                        column: x => x.BusinessCaseId,
                        principalTable: "BusinessCases",
                        principalColumn: "BusinessCaseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    AttachmentUID = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    RelatedItemUID = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedItemType = table.Column<string>(type: "text", nullable: true),
                    PhysicalPath = table.Column<string>(type: "text", nullable: true),
                    Document = table.Column<byte[]>(type: "bytea", nullable: true),
                    BusinessCaseID = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectCharterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.AttachmentUID);
                    table.ForeignKey(
                        name: "FK_Attachment_BusinessCases_BusinessCaseID",
                        column: x => x.BusinessCaseID,
                        principalTable: "BusinessCases",
                        principalColumn: "BusinessCaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachment_ProjectCharters_ProjectCharterId",
                        column: x => x.ProjectCharterId,
                        principalTable: "ProjectCharters",
                        principalColumn: "ProjectCharterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachment_ProjectManagementPlans_ProjectManagementPlanId",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiariesandStakeholders",
                columns: table => new
                {
                    BeneficiariesandStakeholdersId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    LevelOfImpact = table.Column<string>(type: "text", nullable: true),
                    Entity = table.Column<string>(type: "text", nullable: true),
                    CommunicationTools = table.Column<string>(type: "text", nullable: true),
                    Requirements = table.Column<string>(type: "text", nullable: true),
                    Expectations = table.Column<string>(type: "text", nullable: true),
                    BusinessCaseId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectCharterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiariesandStakeholders", x => x.BeneficiariesandStakeholdersId);
                    table.ForeignKey(
                        name: "FK_BeneficiariesandStakeholders_BusinessCases_BusinessCaseId",
                        column: x => x.BusinessCaseId,
                        principalTable: "BusinessCases",
                        principalColumn: "BusinessCaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeneficiariesandStakeholders_ProjectCharters_ProjectCharter~",
                        column: x => x.ProjectCharterId,
                        principalTable: "ProjectCharters",
                        principalColumn: "ProjectCharterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeneficiariesandStakeholders_ProjectManagementPlans_Project~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BenefitRealizationPlans",
                columns: table => new
                {
                    BenefitRealizationPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescriptionOfBenefits = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Target = table.Column<string>(type: "text", nullable: true),
                    InvestigatorRatio = table.Column<string>(type: "text", nullable: true),
                    Responsible = table.Column<string>(type: "text", nullable: true),
                    RelatedOutputs = table.Column<string>(type: "text", nullable: true),
                    Observations = table.Column<string>(type: "text", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitRealizationPlans", x => x.BenefitRealizationPlanId);
                    table.ForeignKey(
                        name: "FK_BenefitRealizationPlans_ProjectManagementPlans_ProjectManag~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessCaseID = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectCharterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentsId);
                    table.ForeignKey(
                        name: "FK_Comments_BusinessCases_BusinessCaseID",
                        column: x => x.BusinessCaseID,
                        principalTable: "BusinessCases",
                        principalColumn: "BusinessCaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_ProjectCharters_ProjectCharterId",
                        column: x => x.ProjectCharterId,
                        principalTable: "ProjectCharters",
                        principalColumn: "ProjectCharterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_ProjectManagementPlans_ProjectManagementPlanId",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationPlans",
                columns: table => new
                {
                    CommunicationPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcernedParty = table.Column<string>(type: "text", nullable: true),
                    Entity = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Contact = table.Column<string>(type: "text", nullable: true),
                    CommunicationTiming = table.Column<string>(type: "text", nullable: true),
                    Observations = table.Column<string>(type: "text", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationPlans", x => x.CommunicationPlanId);
                    table.ForeignKey(
                        name: "FK_CommunicationPlans_ProjectManagementPlans_ProjectManagement~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImplementationTimeline",
                columns: table => new
                {
                    ImplementationTimelineId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityName = table.Column<string>(type: "text", nullable: true),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    DurationOfActivity = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Reliability = table.Column<string>(type: "text", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImplementationTimeline", x => x.ImplementationTimelineId);
                    table.ForeignKey(
                        name: "FK_ImplementationTimeline_ProjectManagementPlans_ProjectManage~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LimitationsAndAssumptions",
                columns: table => new
                {
                    LimitationsAndAssumptionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    ImpactOnProjectOutputs = table.Column<string>(type: "text", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimitationsAndAssumptions", x => x.LimitationsAndAssumptionsId);
                    table.ForeignKey(
                        name: "FK_LimitationsAndAssumptions_ProjectManagementPlans_ProjectMan~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectOutputsAndCosts",
                columns: table => new
                {
                    ProjectOutputsAndCostId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescriptionOfTheScopeOfWork = table.Column<string>(type: "text", nullable: true),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    MainMileStone = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectOutputsAndCosts", x => x.ProjectOutputsAndCostId);
                    table.ForeignKey(
                        name: "FK_ProjectOutputsAndCosts_ProjectManagementPlans_ProjectManage~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRolesAndResources",
                columns: table => new
                {
                    ProjectRolesandResourcesId = table.Column<Guid>(type: "uuid", nullable: false),
                    NameOfThePerson = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Impact = table.Column<string>(type: "text", nullable: true),
                    CommunicationTools = table.Column<string>(type: "text", nullable: true),
                    ProjectCharterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRolesAndResources", x => x.ProjectRolesandResourcesId);
                    table.ForeignKey(
                        name: "FK_ProjectRolesAndResources_ProjectCharters_ProjectCharterId",
                        column: x => x.ProjectCharterId,
                        principalTable: "ProjectCharters",
                        principalColumn: "ProjectCharterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRolesAndResources_ProjectManagementPlans_ProjectMana~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceAndCadreManagement",
                columns: table => new
                {
                    ResourceAndCadreManagementId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Genre = table.Column<string>(type: "text", nullable: true),
                    ExperienceLevel = table.Column<string>(type: "text", nullable: true),
                    Management = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Activities = table.Column<string>(type: "text", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceAndCadreManagement", x => x.ResourceAndCadreManagementId);
                    table.ForeignKey(
                        name: "FK_ResourceAndCadreManagement_ProjectManagementPlans_ProjectMa~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Risks",
                columns: table => new
                {
                    RiskId = table.Column<Guid>(type: "uuid", nullable: false),
                    RiskTitle = table.Column<string>(type: "text", nullable: true),
                    RiskStatus = table.Column<string>(type: "text", nullable: true),
                    DateOccurred = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateClose = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Severity = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Impact = table.Column<string>(type: "text", nullable: true),
                    IntialDispostion = table.Column<string>(type: "text", nullable: true),
                    Owner = table.Column<string>(type: "text", nullable: true),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    Administrator = table.Column<string>(type: "text", nullable: true),
                    BusinessCaseId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectCharterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risks", x => x.RiskId);
                    table.ForeignKey(
                        name: "FK_Risks_BusinessCases_BusinessCaseId",
                        column: x => x.BusinessCaseId,
                        principalTable: "BusinessCases",
                        principalColumn: "BusinessCaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Risks_ProjectCharters_ProjectCharterId",
                        column: x => x.ProjectCharterId,
                        principalTable: "ProjectCharters",
                        principalColumn: "ProjectCharterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Risks_ProjectManagementPlans_ProjectManagementPlanId",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StrategicObjectives",
                columns: table => new
                {
                    StrategicObjectivesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Goal = table.Column<string>(type: "text", nullable: true),
                    LevelOfImpact = table.Column<string>(type: "text", nullable: true),
                    ProjectCharterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectManagementPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategicObjectives", x => x.StrategicObjectivesId);
                    table.ForeignKey(
                        name: "FK_StrategicObjectives_ProjectCharters_ProjectCharterId",
                        column: x => x.ProjectCharterId,
                        principalTable: "ProjectCharters",
                        principalColumn: "ProjectCharterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrategicObjectives_ProjectManagementPlans_ProjectManagemen~",
                        column: x => x.ProjectManagementPlanId,
                        principalTable: "ProjectManagementPlans",
                        principalColumn: "ProjectManagementPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_BusinessCaseID",
                table: "Attachment",
                column: "BusinessCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ProjectCharterId",
                table: "Attachment",
                column: "ProjectCharterId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ProjectManagementPlanId",
                table: "Attachment",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiariesandStakeholders_BusinessCaseId",
                table: "BeneficiariesandStakeholders",
                column: "BusinessCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiariesandStakeholders_ProjectCharterId",
                table: "BeneficiariesandStakeholders",
                column: "ProjectCharterId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiariesandStakeholders_ProjectManagementPlanId",
                table: "BeneficiariesandStakeholders",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitRealizationPlans_ProjectManagementPlanId",
                table: "BenefitRealizationPlans",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCases_DepartmentId",
                table: "BusinessCases",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCases_SectorID",
                table: "BusinessCases",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCaseWithProjects_ProjectID",
                table: "BusinessCaseWithProjects",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BusinessCaseID",
                table: "Comments",
                column: "BusinessCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProjectCharterId",
                table: "Comments",
                column: "ProjectCharterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProjectManagementPlanId",
                table: "Comments",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationPlans_ProjectManagementPlanId",
                table: "CommunicationPlans",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ImplementationTimeline_ProjectManagementPlanId",
                table: "ImplementationTimeline",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LimitationsAndAssumptions_ProjectManagementPlanId",
                table: "LimitationsAndAssumptions",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCashFlows_BusinessCaseId",
                table: "ProjectCashFlows",
                column: "BusinessCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCharters_SectorID",
                table: "ProjectCharters",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagementPlans_SectorID",
                table: "ProjectManagementPlans",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectOutputsAndCosts_ProjectManagementPlanId",
                table: "ProjectOutputsAndCosts",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRolesAndResources_ProjectCharterId",
                table: "ProjectRolesAndResources",
                column: "ProjectCharterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRolesAndResources_ProjectManagementPlanId",
                table: "ProjectRolesAndResources",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAndCadreManagement_ProjectManagementPlanId",
                table: "ResourceAndCadreManagement",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_BusinessCaseId",
                table: "Risks",
                column: "BusinessCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_ProjectCharterId",
                table: "Risks",
                column: "ProjectCharterId");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_ProjectManagementPlanId",
                table: "Risks",
                column: "ProjectManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategicObjectives_ProjectCharterId",
                table: "StrategicObjectives",
                column: "ProjectCharterId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategicObjectives_ProjectManagementPlanId",
                table: "StrategicObjectives",
                column: "ProjectManagementPlanId");
        }

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
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "BeneficiariesandStakeholders");

            migrationBuilder.DropTable(
                name: "BenefitRealizationPlans");

            migrationBuilder.DropTable(
                name: "BusinessCaseWithProjects");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CommunicationPlans");

            migrationBuilder.DropTable(
                name: "ImplementationTimeline");

            migrationBuilder.DropTable(
                name: "LimitationsAndAssumptions");

            migrationBuilder.DropTable(
                name: "ProjectCashFlows");

            migrationBuilder.DropTable(
                name: "ProjectOutputsAndCosts");

            migrationBuilder.DropTable(
                name: "ProjectRolesAndResources");

            migrationBuilder.DropTable(
                name: "ResourceAndCadreManagement");

            migrationBuilder.DropTable(
                name: "Risks");

            migrationBuilder.DropTable(
                name: "StrategicObjectives");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "BusinessCases");

            migrationBuilder.DropTable(
                name: "ProjectCharters");

            migrationBuilder.DropTable(
                name: "ProjectManagementPlans");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
