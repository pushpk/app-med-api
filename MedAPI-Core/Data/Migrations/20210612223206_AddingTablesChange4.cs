using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddingTablesChange4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "registroclinico");

            migrationBuilder.CreateTable(
                name: "chapter",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "establishment",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    deleted = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: false),
                    establishmentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    initials = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_establishment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exam",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicine",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    concentration = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    form = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fractions = table.Column<long>(type: "bigint", nullable: true),
                    healthRegistration = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    owner = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    presentation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "registroclinico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specialities",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "symptoms",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symptoms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    closed = table.Column<bool>(type: "bit", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    nroTicket = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    serie = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "upload",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    createdDate = table.Column<DateTime>(type: "date", nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_upload", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "diagnosis",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    chapter_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosis", x => x.id);
                    table.ForeignKey(
                        name: "diagnosis$FKdkejwjwwrvhod7ilsu9u62d4r",
                        column: x => x.chapter_id,
                        principalSchema: "registroclinico",
                        principalTable: "chapter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "department",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    country_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.ForeignKey(
                        name: "department$FK43w9v6odn5ebkcotastqgn1dw",
                        column: x => x.country_id,
                        principalSchema: "registroclinico",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "registroclinico",
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                schema: "registroclinico",
                columns: table => new
                {
                    Role_id = table.Column<long>(type: "bigint", nullable: false),
                    permissions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "role_permissions$FKr5u91l7q7yikdobgi0lhntse6",
                        column: x => x.Role_id,
                        principalSchema: "registroclinico",
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "triage",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abdominalPerimeter = table.Column<double>(type: "float", nullable: true),
                    bmi = table.Column<double>(type: "float", nullable: true),
                    breathingRate = table.Column<double>(type: "float", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    createdDate = table.Column<DateTime>(type: "date", nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    deposition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    diastolicBloodPressure = table.Column<double>(type: "float", nullable: true),
                    glycemia = table.Column<double>(type: "float", nullable: true),
                    hdlCholesterol = table.Column<double>(type: "float", nullable: true),
                    heartRate = table.Column<double>(type: "float", nullable: true),
                    heartRisk = table.Column<double>(type: "float", nullable: true),
                    hunger = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    hypertensionRisk = table.Column<double>(type: "float", nullable: true),
                    ldlCholesterol = table.Column<double>(type: "float", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "date", nullable: true),
                    size = table.Column<double>(type: "float", nullable: true),
                    sleep = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    systolicBloodPressure = table.Column<double>(type: "float", nullable: true),
                    temperature = table.Column<double>(type: "float", nullable: true),
                    thirst = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    totalCholesterol = table.Column<double>(type: "float", nullable: true),
                    urine = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    weight = table.Column<double>(type: "float", nullable: true),
                    weightEvolution = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    patient_id = table.Column<long>(type: "bigint", nullable: true),
                    ticket_id = table.Column<long>(type: "bigint", nullable: true),
                    speciality = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    saturation = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_triage", x => x.id);
                    table.ForeignKey(
                        name: "ticket -> triage",
                        column: x => x.ticket_id,
                        principalSchema: "registroclinico",
                        principalTable: "ticket",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "province",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    department_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.id);
                    table.ForeignKey(
                        name: "province$FK3joxh8ppnjhvvt1485efkpxm8",
                        column: x => x.department_id,
                        principalSchema: "registroclinico",
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "district",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ubigeo = table.Column<long>(type: "bigint", nullable: true),
                    province_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.id);
                    table.ForeignKey(
                        name: "district$FKft8pluvn8a75sbmt3bn3o11ph",
                        column: x => x.province_id,
                        principalSchema: "registroclinico",
                        principalTable: "province",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "registroclinico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: false),
                    cellphone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    deletable = table.Column<bool>(type: "bit", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    documentNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    documentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lastNameFather = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lastNameMother = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    maritalStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    organDonor = table.Column<bool>(type: "bit", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    sex = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    since = table.Column<DateTime>(type: "date", nullable: false),
                    country_id = table.Column<long>(type: "bigint", nullable: false),
                    district_id = table.Column<long>(type: "bigint", nullable: true),
                    role_id = table.Column<long>(type: "bigint", nullable: true),
                    department_id = table.Column<long>(type: "bigint", nullable: true),
                    province_id = table.Column<long>(type: "bigint", nullable: true),
                    token = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    reset_token = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_department",
                        column: x => x.department_id,
                        principalSchema: "registroclinico",
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "users$FK1eit3dhanvh8r59sd30a3vyaw",
                        column: x => x.country_id,
                        principalSchema: "registroclinico",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "users$FKdoiykqja8oxn78j7gf3l536ta",
                        column: x => x.district_id,
                        principalSchema: "registroclinico",
                        principalTable: "district",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "users$FKiod6nq5d7gqshxljomqccs7tp",
                        column: x => x.role_id,
                        principalSchema: "registroclinico",
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "registroclinico",
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lab",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    parentCompany = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    labName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ruc = table.Column<long>(type: "bigint", nullable: false),
                    IsFreezed = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDenied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab", x => x.id);
                    table.ForeignKey(
                        name: "user->labs",
                        column: x => x.user_id,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medic",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    cmp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    rne = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsFreezed = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDenied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medic", x => x.id);
                    table.ForeignKey(
                        name: "medic$FKa63sueb7mgdy1vvoejcxsafil",
                        column: x => x.id,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nurse",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    medicRegistration = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nurse", x => x.id);
                    table.ForeignKey(
                        name: "nurse$FKinc1dd4o81eetpkv731etxb34",
                        column: x => x.id,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    alcohol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    bloodType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cigaretteNumber = table.Column<long>(type: "bigint", nullable: true),
                    createdTicket = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dormNumber = table.Column<long>(type: "bigint", nullable: true),
                    educationalAttainment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    electricity = table.Column<bool>(type: "bit", nullable: false),
                    fractureNumber = table.Column<long>(type: "bigint", nullable: true),
                    fruitsVegetables = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    highGlucose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    homeMaterial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    homeOwnership = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    homeType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    occupation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    otherAllergies = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    otherFatherBackground = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    otherMedicines = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    otherMotherBackground = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    otherPersonalBackground = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    physicalActivity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    residentNumber = table.Column<long>(type: "bigint", nullable: true),
                    sewage = table.Column<bool>(type: "bit", nullable: false),
                    water = table.Column<bool>(type: "bit", nullable: false),
                    departmentId = table.Column<long>(type: "bigint", nullable: false),
                    race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_department",
                        column: x => x.departmentId,
                        principalSchema: "registroclinico",
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user->patients",
                        column: x => x.user_id,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lab_upload_result",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    lab_id = table.Column<long>(type: "bigint", nullable: true),
                    medic_user_id = table.Column<long>(type: "bigint", nullable: true),
                    fileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    dateUploaded = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab_upload_result", x => x.id);
                    table.ForeignKey(
                        name: "lab->lab_upload_result",
                        column: x => x.lab_id,
                        principalSchema: "registroclinico",
                        principalTable: "lab",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "medic->lab_upload_result",
                        column: x => x.medic_user_id,
                        principalSchema: "registroclinico",
                        principalTable: "medic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user->lab_upload_result",
                        column: x => x.user_id,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medic_specialties",
                schema: "registroclinico",
                columns: table => new
                {
                    Medic_id = table.Column<long>(type: "bigint", nullable: false),
                    specialties = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medic_specialties", x => x.Medic_id);
                    table.ForeignKey(
                        name: "medic_specialties$FKgyco417bacd28ti07gdpxwvsr",
                        column: x => x.Medic_id,
                        principalSchema: "registroclinico",
                        principalTable: "medic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nurse_specialties",
                schema: "registroclinico",
                columns: table => new
                {
                    Nurse_id = table.Column<long>(type: "bigint", nullable: false),
                    specialties = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "nurse_specialties$FK6nc16jusxlaag0qyhvwjs89fk",
                        column: x => x.Nurse_id,
                        principalSchema: "registroclinico",
                        principalTable: "nurse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "note",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    completed = table.Column<bool>(type: "bit", nullable: false),
                    control = table.Column<bool>(type: "bit", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    createdDate = table.Column<DateTime>(type: "date", nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "date", nullable: true),
                    physicalExam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secondOpinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sicknessTime = table.Column<long>(type: "bigint", nullable: true),
                    sicknessUnit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    specialty = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    stage = table.Column<long>(type: "bigint", nullable: true),
                    story = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    symptom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    treatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    establishment_id = table.Column<long>(type: "bigint", nullable: true),
                    medic_id = table.Column<long>(type: "bigint", nullable: true),
                    patient_id = table.Column<long>(type: "bigint", nullable: false),
                    ticket_id = table.Column<long>(type: "bigint", nullable: true),
                    triage_id = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'open')"),
                    category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    attached_attention = table.Column<int>(type: "int", nullable: true),
                    prognosis = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    notes = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    isSignatureDraw = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    signatuteText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    signatuteDraw = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_note", x => x.id);
                    table.ForeignKey(
                        name: "FK_note_establishment",
                        column: x => x.establishment_id,
                        principalSchema: "registroclinico",
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_note_medic",
                        column: x => x.medic_id,
                        principalSchema: "registroclinico",
                        principalTable: "medic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_note_patient",
                        column: x => x.patient_id,
                        principalSchema: "registroclinico",
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_note_ticket",
                        column: x => x.ticket_id,
                        principalSchema: "registroclinico",
                        principalTable: "ticket",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_note_triage",
                        column: x => x.triage_id,
                        principalSchema: "registroclinico",
                        principalTable: "triage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_note_users",
                        column: x => x.user_id,
                        principalSchema: "registroclinico",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_allergies",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<long>(type: "bigint", nullable: false),
                    allergies = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_allergies", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_allergies_patient",
                        column: x => x.patient_id,
                        principalSchema: "registroclinico",
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_fatherbackgrounds",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<long>(type: "bigint", nullable: false),
                    fatherBackgrounds = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_fatherbackgrounds", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_fatherbackgrounds_patient",
                        column: x => x.patient_id,
                        principalSchema: "registroclinico",
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_medic_permission",
                schema: "registroclinico",
                columns: table => new
                {
                    patient_id = table.Column<long>(type: "bigint", nullable: false),
                    medic_id = table.Column<long>(type: "bigint", nullable: false),
                    is_medic_authorized = table.Column<bool>(type: "bit", nullable: false),
                    is_future_request_blocked = table.Column<bool>(type: "bit", nullable: false),
                    is_request_sent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patient_medic", x => new { x.patient_id, x.medic_id });
                    table.ForeignKey(
                        name: "medic_$FKgyco417bacd28ti07gdpxwvsr",
                        column: x => x.medic_id,
                        principalSchema: "registroclinico",
                        principalTable: "medic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "patient_$FKgyco417bacd28ti07gdpxwvsr",
                        column: x => x.patient_id,
                        principalSchema: "registroclinico",
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_medicines",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<long>(type: "bigint", nullable: false),
                    medicines = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_medicines", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_medicines_patient",
                        column: x => x.patient_id,
                        principalSchema: "registroclinico",
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_motherbackgrounds",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<long>(type: "bigint", nullable: false),
                    motherBackgrounds = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_motherbackgrounds", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_motherbackgrounds_patient",
                        column: x => x.patient_id,
                        principalSchema: "registroclinico",
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_personalbackgrounds",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<long>(type: "bigint", nullable: false),
                    personalBackgrounds = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_personalbackgrounds", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_personalbackgrounds_patient",
                        column: x => x.patient_id,
                        principalSchema: "registroclinico",
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_symptoms",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<long>(type: "bigint", nullable: false),
                    symptoms_id = table.Column<long>(type: "bigint", nullable: true),
                    custom_symptom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_symptoms", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_symptoms_patient",
                        column: x => x.patient_id,
                        principalSchema: "registroclinico",
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_patient_symptoms_symptoms",
                        column: x => x.symptoms_id,
                        principalSchema: "registroclinico",
                        principalTable: "symptoms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cardiovascularnote",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    note_id = table.Column<long>(type: "bigint", nullable: true),
                    auscultationSite = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    capillaryRefillLLM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    capillaryRefillLRM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cardiacPressureIntensity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cardiacPressureRhythm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    diastolicPhase = table.Column<bool>(type: "bit", nullable: false),
                    edemaAnkle = table.Column<bool>(type: "bit", nullable: false),
                    edemaGeneralized = table.Column<bool>(type: "bit", nullable: false),
                    edemaLowerMembers = table.Column<bool>(type: "bit", nullable: false),
                    fourthNoise = table.Column<bool>(type: "bit", nullable: false),
                    gastrointestinalSemiology = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    murmurs = table.Column<bool>(type: "bit", nullable: false),
                    neckRadiation = table.Column<bool>(type: "bit", nullable: false),
                    otherSymptoms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pedalPulsesL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pedalPulsesR = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pulsesLLM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pulsesLRM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    radialPulsesL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    radialPulsesR = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    systolicPhase = table.Column<bool>(type: "bit", nullable: false),
                    thirdNoise = table.Column<bool>(type: "bit", nullable: false),
                    trophicChanges = table.Column<bool>(type: "bit", nullable: false),
                    vesicularWhisperL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    vesicularWhisperR = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardiovascularnote", x => x.id);
                    table.ForeignKey(
                        name: "FK_cardiovascularnote_note",
                        column: x => x.note_id,
                        principalSchema: "registroclinico",
                        principalTable: "note",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notediagnosis",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    diagnosisType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    diagnosis_id = table.Column<long>(type: "bigint", nullable: true),
                    note_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notediagnosis", x => x.id);
                    table.ForeignKey(
                        name: "FK_notediagnosis_diagnosis",
                        column: x => x.diagnosis_id,
                        principalSchema: "registroclinico",
                        principalTable: "diagnosis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notediagnosis_note",
                        column: x => x.note_id,
                        principalSchema: "registroclinico",
                        principalTable: "note",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "noteexam",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    observation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    specification = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    exam_id = table.Column<long>(type: "bigint", nullable: false),
                    note_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_noteexam", x => x.id);
                    table.ForeignKey(
                        name: "FK_noteexam_exam",
                        column: x => x.exam_id,
                        principalSchema: "registroclinico",
                        principalTable: "exam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_noteexam_note",
                        column: x => x.note_id,
                        principalSchema: "registroclinico",
                        principalTable: "note",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notemedicine",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    durationTime = table.Column<long>(type: "bigint", nullable: true),
                    durationUnit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    frequencyTime = table.Column<long>(type: "bigint", nullable: true),
                    frequencyUnit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    indication = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    medicine_id = table.Column<long>(type: "bigint", nullable: true),
                    note_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notemedicine", x => x.id);
                    table.ForeignKey(
                        name: "FK_notemedicine_medicine",
                        column: x => x.medicine_id,
                        principalSchema: "registroclinico",
                        principalTable: "medicine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notemedicine_note",
                        column: x => x.note_id,
                        principalSchema: "registroclinico",
                        principalTable: "note",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notereferral",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    specialty = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    note_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notereferral", x => x.id);
                    table.ForeignKey(
                        name: "FK_notereferral_note",
                        column: x => x.note_id,
                        principalSchema: "registroclinico",
                        principalTable: "note",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cardiovascularnote_cardiovascularsymptoms",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardiovascularNote_id = table.Column<long>(type: "bigint", nullable: false),
                    cardiovascularSymptoms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardiovascularnote_cardiovascularsymptoms", x => x.id);
                    table.ForeignKey(
                        name: "FK_cardiovascularnote_cardiovascularsymptoms_cardiovascularnote",
                        column: x => x.cardiovascularNote_id,
                        principalSchema: "registroclinico",
                        principalTable: "cardiovascularnote",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "noteexam_upload",
                schema: "registroclinico",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    noteExam_id = table.Column<long>(type: "bigint", nullable: true),
                    uploads_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_noteexam_upload", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_noteexam_upload_noteexam",
                        column: x => x.noteExam_id,
                        principalSchema: "registroclinico",
                        principalTable: "noteexam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_noteexam_upload_upload",
                        column: x => x.uploads_id,
                        principalSchema: "registroclinico",
                        principalTable: "upload",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                name: "IX_cardiovascularnote_note_id",
                schema: "registroclinico",
                table: "cardiovascularnote",
                column: "note_id");

            migrationBuilder.CreateIndex(
                name: "IX_cardiovascularnote_cardiovascularsymptoms_cardiovascularNote_id",
                schema: "registroclinico",
                table: "cardiovascularnote_cardiovascularsymptoms",
                column: "cardiovascularNote_id");

            migrationBuilder.CreateIndex(
                name: "country$UK_t81fgsgaq5hcgbixtau1ptk3",
                schema: "registroclinico",
                table: "country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "department$UK_biw7tevwc07g3iutlbmkes0cm",
                schema: "registroclinico",
                table: "department",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_department_country_id",
                schema: "registroclinico",
                table: "department",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosis_chapter_id",
                schema: "registroclinico",
                table: "diagnosis",
                column: "chapter_id");

            migrationBuilder.CreateIndex(
                name: "IX_district_province_id",
                schema: "registroclinico",
                table: "district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "establishment$UK_odanp3w4u1swk7mhgmv7rvxq0",
                schema: "registroclinico",
                table: "establishment",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lab_user_id",
                schema: "registroclinico",
                table: "lab",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_upload_result_lab_id",
                schema: "registroclinico",
                table: "lab_upload_result",
                column: "lab_id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_upload_result_medic_user_id",
                schema: "registroclinico",
                table: "lab_upload_result",
                column: "medic_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_upload_result_user_id",
                schema: "registroclinico",
                table: "lab_upload_result",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_note_establishment_id",
                schema: "registroclinico",
                table: "note",
                column: "establishment_id");

            migrationBuilder.CreateIndex(
                name: "IX_note_medic_id",
                schema: "registroclinico",
                table: "note",
                column: "medic_id");

            migrationBuilder.CreateIndex(
                name: "IX_note_patient_id",
                schema: "registroclinico",
                table: "note",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_note_ticket_id",
                schema: "registroclinico",
                table: "note",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_note_triage_id",
                schema: "registroclinico",
                table: "note",
                column: "triage_id");

            migrationBuilder.CreateIndex(
                name: "IX_note_user_id",
                schema: "registroclinico",
                table: "note",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_notediagnosis_diagnosis_id",
                schema: "registroclinico",
                table: "notediagnosis",
                column: "diagnosis_id");

            migrationBuilder.CreateIndex(
                name: "IX_notediagnosis_note_id",
                schema: "registroclinico",
                table: "notediagnosis",
                column: "note_id");

            migrationBuilder.CreateIndex(
                name: "IX_noteexam_exam_id",
                schema: "registroclinico",
                table: "noteexam",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "IX_noteexam_note_id",
                schema: "registroclinico",
                table: "noteexam",
                column: "note_id");

            migrationBuilder.CreateIndex(
                name: "IX_noteexam_upload_noteExam_id",
                schema: "registroclinico",
                table: "noteexam_upload",
                column: "noteExam_id");

            migrationBuilder.CreateIndex(
                name: "noteexam_upload$UK_ff7t6g8kbapqe17vt5yjio5da",
                schema: "registroclinico",
                table: "noteexam_upload",
                column: "uploads_id",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_notemedicine_medicine_id",
                schema: "registroclinico",
                table: "notemedicine",
                column: "medicine_id");

            migrationBuilder.CreateIndex(
                name: "IX_notemedicine_note_id",
                schema: "registroclinico",
                table: "notemedicine",
                column: "note_id");

            migrationBuilder.CreateIndex(
                name: "IX_notereferral_note_id",
                schema: "registroclinico",
                table: "notereferral",
                column: "note_id");

            migrationBuilder.CreateIndex(
                name: "IX_nurse_specialties_Nurse_id",
                schema: "registroclinico",
                table: "nurse_specialties",
                column: "Nurse_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_departmentId",
                schema: "registroclinico",
                table: "patient",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_user_id",
                schema: "registroclinico",
                table: "patient",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_allergies_patient_id",
                schema: "registroclinico",
                table: "patient_allergies",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_fatherbackgrounds_patient_id",
                schema: "registroclinico",
                table: "patient_fatherbackgrounds",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_medic_permission_medic_id",
                schema: "registroclinico",
                table: "patient_medic_permission",
                column: "medic_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_medicines_patient_id",
                schema: "registroclinico",
                table: "patient_medicines",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_motherbackgrounds_patient_id",
                schema: "registroclinico",
                table: "patient_motherbackgrounds",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_personalbackgrounds_patient_id",
                schema: "registroclinico",
                table: "patient_personalbackgrounds",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_symptoms_patient_id",
                schema: "registroclinico",
                table: "patient_symptoms",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_symptoms_symptoms_id",
                schema: "registroclinico",
                table: "patient_symptoms",
                column: "symptoms_id");

            migrationBuilder.CreateIndex(
                name: "IX_province_department_id",
                schema: "registroclinico",
                table: "province",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "province$UK_moejme3ohebd07k2d4b70l8vh",
                schema: "registroclinico",
                table: "province",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "registroclinico",
                table: "role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_Role_id",
                schema: "registroclinico",
                table: "role_permissions",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "symptom$UK_t81fgsgaq5hcgbixtau1ptk3",
                schema: "registroclinico",
                table: "symptoms",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_triage_ticket_id",
                schema: "registroclinico",
                table: "triage",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "registroclinico",
                table: "users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_users_country_id",
                schema: "registroclinico",
                table: "users",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_department_id",
                schema: "registroclinico",
                table: "users",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_district_id",
                schema: "registroclinico",
                table: "users",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                schema: "registroclinico",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "registroclinico",
                table: "users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
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
                name: "cardiovascularnote_cardiovascularsymptoms",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "lab_upload_result",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "medic_specialties",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "notediagnosis",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "noteexam_upload",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "notemedicine",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "notereferral",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "nurse_specialties",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "patient_allergies",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "patient_fatherbackgrounds",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "patient_medic_permission",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "patient_medicines",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "patient_motherbackgrounds",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "patient_personalbackgrounds",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "patient_symptoms",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "role_permissions",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "specialities",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "cardiovascularnote",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "lab",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "diagnosis",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "noteexam",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "upload",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "medicine",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "nurse",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "symptoms",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "chapter",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "exam",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "note",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "establishment",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "medic",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "patient",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "triage",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "users",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "ticket",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "district",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "role",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "province",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "department",
                schema: "registroclinico");

            migrationBuilder.DropTable(
                name: "country",
                schema: "registroclinico");
        }
    }
}
