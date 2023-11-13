using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manero.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PostalCode = table.Column<string>(type: "char(5)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    ExpiryMonth = table.Column<int>(type: "int", nullable: false),
                    ExpiryYear = table.Column<int>(type: "int", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: true),
                    StandardCurrency = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ArticleNumber);
                });

            migrationBuilder.CreateTable(
                name: "Promocodes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: false),
                    ValidUntilDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "UserAdresses",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdresses", x => new { x.UserId, x.AdressId });
                    table.ForeignKey(
                        name: "FK_UserAdresses_Adresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentMethods",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentMethods", x => new { x.UserId, x.PaymentId });
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_PaymentMethods_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ProductImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductArticleNumber",
                        column: x => x.ProductArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    PromocodeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubtotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "money", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Promocodes_PromocodeId",
                        column: x => x.PromocodeId,
                        principalTable: "Promocodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPromocodes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPromocodes", x => new { x.UserId, x.CodeId });
                    table.ForeignKey(
                        name: "FK_UserPromocodes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPromocodes_Promocodes_CodeId",
                        column: x => x.CodeId,
                        principalTable: "Promocodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductArticleNumber",
                        column: x => x.ProductArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    StatusCodeId = table.Column<int>(type: "int", nullable: false),
                    UpdateStatusDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutEntities_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutEntities_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutEntities_StatusCodes_StatusCodeId",
                        column: x => x.StatusCodeId,
                        principalTable: "StatusCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRows",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductVariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRows", x => new { x.OrderId, x.ProductArticleNumber, x.ProductVariantId });
                    table.ForeignKey(
                        name: "FK_OrderRows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRows_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "City", "PostalCode", "StreetName" },
                values: new object[,]
                {
                    { 1, "Solna", "17165", "Tomtebodavägen 3A" },
                    { 2, "Örebro", "70225", "Stenbackevägen 6" },
                    { 3, "Göteborg", "41301", "Haga Östergata 12" },
                    { 4, "Halmstad", "30248", "Nässjögatan 10" },
                    { 5, "Malmö", "21212", "Östra Förstadsgatan 46" },
                    { 6, "Helsingborg", "25237", "Södergatan 78" },
                    { 7, "Karlshamn", "37431", "Västra Kajen 8" },
                    { 8, "Malmö", "21422", "Barkgatan 6" },
                    { 9, "Stockholm", "11137", "Adolf Fredriks Kyrkogata 2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", 0, "1ba50391-1bae-4304-92e1-183b69c16624", "jacob@example.com", true, "Jacob", "Jones", null, true, null, "JACOB@EXAMPLE.COM", "JACOBJONES", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "0706789012", false, "/images/profiles/jacob-jones.jpg", "81fa12e1-b9f1-4fa2-819d-d478a5a01eb8", false, "jacobjones" },
                    { "1f75883b-125b-49b9-a3f1-931b83d05199", 0, "65de4279-0f13-4d45-8116-395bcb628eee", "jenny@example.com", true, "Jenny", "Wilson", null, true, null, "JENNY@EXAMPLE.COM", "JENNYWILSON", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "0707890123", false, "/images/profiles/jenny-wilson.jpg", "06c058ab-9366-4be7-bcc0-dcf7b0a94e79", false, "jennywilson" },
                    { "3b21a87a-aa26-4c90-9a2d-4c81205a0721", 0, "46b34db9-151f-43c3-af0d-2a63a90b57ab", "theresa@example.com", true, "Theresa", "Webb", null, true, null, "THERESA@EXAMPLE.COM", "THERESAWEBB", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "0709012345", false, "/images/profiles/theresa-webb.jpg", "09b7f820-6d5f-4005-8b70-b23962dadc5d", false, "theresawebb" },
                    { "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3", 0, "1be50a10-03b0-42f9-a51d-3fc09245771f", "marvin@example.com", true, "Marvin", "McKinney", null, true, null, "MARVIN@EXAMPLE.COM", "MARVINMCKINNEY", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "0708901234", false, "/images/profiles/marvin-mckinney.jpg", "e90372cf-6ede-4296-847a-dbc55fd8eb6d", false, "marvinmckinney" },
                    { "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", 0, "e48e8961-101a-4b94-8299-c1640a72af72", "cameron@example.com", true, "Cameron", "Williamson", null, true, null, "CAMERON@EXAMPLE.COM", "CAMERONWILLIAMSON", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "0705678901", false, "/images/profiles/cameron-williamson.jpg", "9e521546-f054-42b9-b505-bc5d8b43e744", false, "cameronwilliamson" },
                    { "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", 0, "cb8aa037-fb24-4f06-a69e-7706a48d1a95", "annette@example.com", true, "Annette", "Hill", null, true, null, "ANNETTE@EXAMPLE.COM", "ANNETTEHILL", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "0704567890", false, "/images/profiles/annette-hill.jpg", "8d854789-ebd1-4926-87fc-2ea0637dc6d4", false, "annettehill" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Men" },
                    { 2, "Women" },
                    { 3, "Kids" },
                    { 4, "Sport" },
                    { 5, "Accessories" },
                    { 6, "Dresses" },
                    { 7, "Shoes" },
                    { 8, "Pants" },
                    { 9, "T-shirt" },
                    { 10, "Bag" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ColorCode", "ColorName" },
                values: new object[,]
                {
                    { 1, "#FF6262", "red" },
                    { 2, "#63C7FF", "lightblue" },
                    { 3, "#323858", "navyblue" },
                    { 4, "#111111", "black" },
                    { 5, "#F8E7CD", "beige" },
                    { 6, "#82614b", "brown" },
                    { 7, "#ec7322", "orange" },
                    { 8, "#c3c2c1", "lightgrey" },
                    { 9, "#900603", "ruby" },
                    { 10, "#edc729", "yellow" },
                    { 11, "#667a65", "forestgreen" },
                    { 12, "#ffffff", "white" },
                    { 13, "#bb9195", "lightpink" },
                    { 14, "#75797c", "grey" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageName", "ImageUrl" },
                values: new object[,]
                {
                    { new Guid("02f03e93-4e4e-4c9d-8620-e8a40a986b36"), "white t-shirt", "/images/products/white-tshirt.jpg" },
                    { new Guid("041e3b6f-1a52-44ca-9981-88c785c7c9e7"), "orange pants for kids", "/images/products/orange-kidspants.jpg" },
                    { new Guid("1b172b64-5462-4a20-bef3-8c6f04c62e87"), "vans canvas shoes", "/images/products/vans-canvas-shoes.jpg" },
                    { new Guid("25c8d39e-cc8b-44b4-b3e4-76872d3f22b5"), "jeans", "/images/products/jeans.jpg" },
                    { new Guid("2e5247f9-3d88-48d0-8c47-9939e6e7eaa4"), "sneakers", "/images/products/sneakers.jpg" },
                    { new Guid("2fcf10b4-9a25-4c9b-a7c1-8a4c05a30fc6"), "black t-shirt", "/images/products/black-tshirt.jpg" },
                    { new Guid("33d33f47-5b7b-4f29-98c6-c3e51edc1b0c"), "black warm hat", "/images/products/black-warm-hat.jpg" },
                    { new Guid("35acca4d-0ff1-4d9c-b5d3-6db3ca5c7c13"), "white body for kids", "/images/products/white-body-kids.jpg" },
                    { new Guid("3a37d8c5-5c36-4f68-a256-22d24ca88576"), "colorful dress for kids", "/images/products/colorful-kidsdress.jpg" },
                    { new Guid("4d4a7df3-6ed1-4ef0-8ea7-4fc92ea31de2"), "red handbag", "/images/products/red-handbag.jpg" },
                    { new Guid("521d06b5-d524-4a9e-bf99-4e3e4896790d"), "beach shoes", "/images/products/beach-shoes.jpg" },
                    { new Guid("679f8dd5-9f41-4773-8f57-3bf99f06cd9b"), "white t-shirt for men", "/images/products/white-tshirt-men.jpg" },
                    { new Guid("6c1321f8-7c17-4e63-938c-1b6eab1d83aa"), "denim shorts", "/images/products/denim-shorts.jpg" },
                    { new Guid("74220f01-6d1f-4e24-ba98-3b01704aeb86"), "brown shoulder handbag", "/images/products/brown-shoulder-handbag.jpg" },
                    { new Guid("81b1a8e6-3211-487a-bab5-3c2825d108d7"), "checkered dress for kids", "/images/products/checkered-kidsdress.jpg" },
                    { new Guid("8b58ee69-119b-4efc-9b80-92c78c6d6f1a"), "black sneakers", "/images/products/black-sneakers.jpg" },
                    { new Guid("8d0bd08c-9930-4e0c-8f15-88cde5d8490b"), "nike sneakers", "/images/products/nike-sneakers.jpg" },
                    { new Guid("8e0ee96a-773b-4be5-b907-e3da505f9ca4"), "grey t-shirt for women", "/images/products/grey-tshirt-women.jpg" },
                    { new Guid("98363f68-96c9-44ab-b3d3-e32ac25ea6ac"), "striped shirt for kids", "/images/products/striped-shirt-kids.jpg" },
                    { new Guid("9b59db9a-7c0d-4880-9c60-5575ef1e5b85"), "hat", "/images/products/hat.jpg" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "extra product image", "/images/products/extra-product-image.png" },
                    { new Guid("b03f66c5-6c50-487b-b620-37e9da2c2b33"), "summer dress", "/images/products/summer-dress.jpg" },
                    { new Guid("b3a41c96-17d2-4649-9d8c-28448a29ce7c"), "knitted shirt", "/images/products/knitted-shirt.jpg" },
                    { new Guid("b67f013c-87d9-42ef-8922-cdc0f0ee0075"), "blue dress for kids", "/images/products/blue-dress-kids.jpg" },
                    { new Guid("d1b5b5f3-46ce-4a24-b86c-f79937df44b6"), "checkered handbag", "/images/products/checkered-handbag.jpg" },
                    { new Guid("d5a0abf6-34d5-4ed3-9c31-d73f25640b1d"), "warm hat for kids", "/images/products/kids-warm-hat.jpg" },
                    { new Guid("e80d078e-7405-4d04-8d85-90a8c3d1bfe7"), "beige pants", "/images/products/beige-pants.jpg" },
                    { new Guid("f226f5d4-9c33-45c0-9531-d540ef06c168"), "green shoes for kids", "/images/products/green-shoes-kids.jpg" },
                    { new Guid("f88c17b0-6111-4620-bc3a-284bca392176"), "funny owl hat for kids", "/images/products/owl-hat-kids.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ArticleNumber", "Description", "Discount", "Price", "ProductName", "StandardCurrency" },
                values: new object[,]
                {
                    { "BEACHSHOES016", "Make a statement on the beach with these stylish and comfortable beach shoes. Crafted for sandy adventures, they provide the perfect blend of fashion and function.", 3.49m, 8.99m, "Beach Shoes - Step into Paradise", "USD" },
                    { "BEIGEPANTS017", "Elevate your style with these timeless beige pants. Crafted for comfort and sophistication, they are a versatile addition to your wardrobe.", null, 39.99m, "Beige Pants - Timeless Elegance ", "USD" },
                    { "BLACKSNEAKERS018", "Step out in style with these bold black sneakers. They are designed to enhance your fashion game while providing comfort. A must-have for sneaker enthusiasts.", null, 69.99m, "Black Sneakers - Bold and Versatile Footwear", "USD" },
                    { "BLACKTEE019", "This black t-shirt is a classic wardrobe staple that combines style and versatility. Whether you're dressing up or keeping it casual, this t-shirt is the perfect choice.", null, 9.99m, "Black T-Shirt - The Classic Wardrobe Staple", "USD" },
                    { "BLACKWARMHAT020", "Stay warm and fashionable with this black warm hat. Crafted with soft materials, it's perfect for colder days. Add a touch of style to your winter wardrobe.", null, 14.99m, "Black Warm Hat - Cozy and Fashionable", "USD" },
                    { "BROWNHANDBAG022", "Elevate your style with this sophisticated brown shoulder handbag. Crafted for both fashion and functionality, it's the ideal accessory for any occasion.", null, 38.99m, "Brown Shoulder Handbag - Sophisticated and Practical", "USD" },
                    { "CHECKEREDHANDBAG023", "Add a touch of trendiness to your outfit with this checkered handbag. Perfect for elevating your style, it's designed to keep you chic and organized.", null, 29.99m, "Checkered Handbag - Trendy and Chic", "USD" },
                    { "CHECKEREDKIDSDRESS024", "Dress your child in this playful checkered dress. Crafted with love and care, it's perfect for your little one's adventures. Let them stand out with this unique piece.", null, 24.99m, "Checkered Kids' Dress - Playful Patterns for Little Ones", "USD" },
                    { "COLORFULKIDSDRESS025", "Dress your child in this vibrant and charming dress. Made with quality materials, it ensures both comfort and style for your little one. Ideal for any special occasion.", null, 35.99m, "Colorful Kids' Dress - Vibrant and Charming", "USD" },
                    { "DENIMSHORTS026", "Stay comfortable and stylish with these denim shorts. Designed for ease of movement, they are the perfect choice for casual days.", null, 24.99m, "Denim Shorts - Casual Comfort with a Stylish Twist", "USD" },
                    { "GREENKIDSSHOES027", "Add a pop of color to your child's outfit with these fun and practical green shoes. Crafted for comfort and style, they're perfect for everyday adventures.", null, 19.99m, "Green Shoes for Kids - Fun and Practical Footwear", "USD" },
                    { "GREYWOMENSTEE028", "This grey t-shirt for women offers both style and comfort. A versatile addition to your wardrobe, it's perfect for casual outings and everyday wear.", null, 14.99m, "Grey T-Shirt for Women - Effortless Elegance", "USD" },
                    { "HANDBAG008", "Elevate your style with this chic red handbag. Perfect for any occasion, this handbag combines elegance with functionality. Carry your essentials in style with this stunning accessory.", null, 39.99m, "Red Handbag - Elegance Meets Functionality", "USD" },
                    { "HAT001", "This versatile and fashionable hat is the perfect accessory to complete your look. Crafted with high-quality materials, it offers both style and protection from the elements. Whether you're heading out for a casual day or a special occasion, this hat will be your go-to choice.", 16.99m, 19.99m, "Stylish Hat for All Seasons", "USD" },
                    { "JEANS002", "Elevate your fashion game with these classic denim jeans. Tailored for comfort and durability, these jeans are a wardrobe essential for any occasion.", 44.99m, 49.99m, "Classic Denim Jeans for Every Wardrobe", "USD" },
                    { "KIDBLUEDRESS021", "Dress your child in this playful and elegant blue dress. Made with care, it's perfect for special occasions and casual outings. Your little one will shine in this lovely piece.", null, 17.99m, "Blue Dress for Kids - Playful and Elegant", "USD" },
                    { "KIDHAT003", "Keep your little ones warm and stylish with this adorable kids' warm hat. Crafted with love and care, it's perfect for colder days. Your child will be both snug and cute in this cozy accessory.", 10.99m, 12.99m, "Cozy Kids' Warm Hat - Stay Toasty in Style", "USD" },
                    { "KIDPANTS006", "These vibrant orange kids' pants are a delightful addition to your child's wardrobe. Designed with comfort in mind, they provide both style and ease of movement. Make your child stand out with this eye-catching piece.", null, 29.99m, "Orange Kids' Pants - Vibrant and Comfy Bottoms", "USD" },
                    { "KIDSBODYSUIT013", "Keep your child comfortable and stylish with this white bodysuit. Crafted with care, it's perfect for all-day wear. Your little one will look adorable in this classic piece.", null, 8.99m, "White Bodysuit for Kids - Pure Comfort and Style", "USD" },
                    { "KNITTED004", "Embrace the perfect blend of comfort and style with this knitted shirt. Crafted with soft, breathable fabric, it's a versatile addition to your wardrobe. Ideal for a casual day out or dressing up for a special occasion.", null, 34.99m, "Knitted Shirt - Comfort and Elegance Combined", "USD" },
                    { "MENSWHITETEE015", "This classic white t-shirt for men offers both style and comfort. A versatile addition to your wardrobe, it's perfect for casual outings and everyday wear.", null, 14.99m, "White T-Shirt for Men - Classic and Comfy", "USD" },
                    { "OWLHAT007", "Your little one will adore this adorable owl hat. Designed to keep them warm and looking cute, it's the perfect accessory for your child. Let your kid show off their unique style with this charming hat.", 9.99m, 14.99m, "Owl Hat for Kids - Cute and Cuddly Headwear", "USD" },
                    { "SNEAKERS005", "Get ready to walk in style with these Nike sneakers. Designed for both fashion and performance, these shoes offer the best of both worlds. Elevate your footwear game with these iconic kicks.", 74.99m, 79.99m, "Nike Sneakers - Step into Style and Comfort", "USD" },
                    { "SNEAKERS009", "These sneakers are your go-to choice for both style and comfort. Crafted with care, they are perfect for everyday wear. Whether you're running errands or going for a walk, these sneakers have got you covered.", 50m, 59.99m, "Sneakers - A Step in the Right Direction", "USD" },
                    { "STRIPEDSHIRT010", "Dress your child in this playful and stylish striped shirt. Made with quality materials, it ensures both comfort and fashion for your little one. Ideal for any casual occasion.", null, 19.99m, "Striped Shirt for Kids - Stylish and Playful", "USD" },
                    { "SUMMERDRESS011", "Beat the heat in style with this stunning summer dress. Perfect for sunny days and special events, this dress is designed to keep you cool and looking elegant.", null, 49.99m, "Summer Dress - Stay Cool and Elegant", "USD" },
                    { "VANSSHOES012", "Step into the classic world of Vans with these canvas shoes. Known for their timeless appeal and comfort, these shoes are a must-have for any sneaker enthusiast.", null, 89.99m, "Vans Canvas Shoes - Classic Comfort and Style", "USD" },
                    { "WHITETEE014", "This white t-shirt is a wardrobe essential that combines versatility and style. Whether you're dressing up or down, this t-shirt is a timeless choice.", null, 9.99m, "White T-Shirt - The Wardrobe Essential ", "USD" }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "Discount", "ImageUrl", "Title", "ValidUntilDate" },
                values: new object[,]
                {
                    { "20DERL5LOT", 20m, "~/images/promocodes/20.png", "Big Savings: Take 20% Off Your Purchase!", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "APIK85WQRT", 10m, "~/images/promocodes/10.png", "Enjoy a 10% Discount on Your Next Order!", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "WIN5IQP658", 5m, "~/images/promocodes/5.png", "Get 5% Off Your Purchase Today!", new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "SizeName" },
                values: new object[,]
                {
                    { 1, "XS" },
                    { 2, "S" },
                    { 3, "M" },
                    { 4, "L" },
                    { 5, "XL" },
                    { 6, "XXL" },
                    { 7, "XXXL" },
                    { 8, "EU38" },
                    { 9, "EU39" },
                    { 10, "EU40" },
                    { 11, "EU41" },
                    { 12, "EU42" },
                    { 13, "EU43" },
                    { 14, "EU44" },
                    { 15, "EU45" },
                    { 16, "EU46" },
                    { 17, "0-1y" },
                    { 18, "1-2y" },
                    { 19, "2-4y" },
                    { 20, "4-6y" },
                    { 21, "6-9y" }
                });

            migrationBuilder.InsertData(
                table: "StatusCodes",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Order being processed" },
                    { 2, "Shipping" },
                    { 3, "Delivered" },
                    { 4, "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 1, "sale" },
                    { 2, "new" },
                    { 3, "top" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 7, "BEACHSHOES016" },
                    { 2, "BEIGEPANTS017" },
                    { 8, "BEIGEPANTS017" },
                    { 1, "BLACKSNEAKERS018" },
                    { 4, "BLACKSNEAKERS018" },
                    { 7, "BLACKSNEAKERS018" },
                    { 9, "BLACKTEE019" },
                    { 5, "BLACKWARMHAT020" },
                    { 5, "BROWNHANDBAG022" },
                    { 10, "BROWNHANDBAG022" },
                    { 5, "CHECKEREDHANDBAG023" },
                    { 10, "CHECKEREDHANDBAG023" },
                    { 3, "CHECKEREDKIDSDRESS024" },
                    { 6, "CHECKEREDKIDSDRESS024" },
                    { 3, "COLORFULKIDSDRESS025" },
                    { 6, "COLORFULKIDSDRESS025" },
                    { 2, "DENIMSHORTS026" },
                    { 8, "DENIMSHORTS026" },
                    { 3, "GREENKIDSSHOES027" },
                    { 7, "GREENKIDSSHOES027" },
                    { 2, "GREYWOMENSTEE028" },
                    { 9, "GREYWOMENSTEE028" },
                    { 5, "HANDBAG008" },
                    { 10, "HANDBAG008" },
                    { 5, "HAT001" },
                    { 8, "JEANS002" },
                    { 3, "KIDBLUEDRESS021" },
                    { 6, "KIDBLUEDRESS021" },
                    { 3, "KIDHAT003" },
                    { 5, "KIDHAT003" },
                    { 3, "KIDPANTS006" },
                    { 8, "KIDPANTS006" },
                    { 3, "KIDSBODYSUIT013" },
                    { 2, "KNITTED004" },
                    { 1, "MENSWHITETEE015" },
                    { 9, "MENSWHITETEE015" },
                    { 3, "OWLHAT007" },
                    { 5, "OWLHAT007" },
                    { 1, "SNEAKERS005" },
                    { 7, "SNEAKERS005" },
                    { 4, "SNEAKERS009" },
                    { 7, "SNEAKERS009" },
                    { 3, "STRIPEDSHIRT010" },
                    { 2, "SUMMERDRESS011" },
                    { 6, "SUMMERDRESS011" },
                    { 7, "VANSSHOES012" },
                    { 2, "WHITETEE014" },
                    { 9, "WHITETEE014" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("521d06b5-d524-4a9e-bf99-4e3e4896790d"), "BEACHSHOES016" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "BEACHSHOES016" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "BEIGEPANTS017" },
                    { new Guid("e80d078e-7405-4d04-8d85-90a8c3d1bfe7"), "BEIGEPANTS017" },
                    { new Guid("8b58ee69-119b-4efc-9b80-92c78c6d6f1a"), "BLACKSNEAKERS018" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "BLACKSNEAKERS018" },
                    { new Guid("2fcf10b4-9a25-4c9b-a7c1-8a4c05a30fc6"), "BLACKTEE019" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "BLACKTEE019" },
                    { new Guid("33d33f47-5b7b-4f29-98c6-c3e51edc1b0c"), "BLACKWARMHAT020" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "BLACKWARMHAT020" },
                    { new Guid("74220f01-6d1f-4e24-ba98-3b01704aeb86"), "BROWNHANDBAG022" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "BROWNHANDBAG022" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "CHECKEREDHANDBAG023" },
                    { new Guid("d1b5b5f3-46ce-4a24-b86c-f79937df44b6"), "CHECKEREDHANDBAG023" },
                    { new Guid("81b1a8e6-3211-487a-bab5-3c2825d108d7"), "CHECKEREDKIDSDRESS024" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "CHECKEREDKIDSDRESS024" },
                    { new Guid("3a37d8c5-5c36-4f68-a256-22d24ca88576"), "COLORFULKIDSDRESS025" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "COLORFULKIDSDRESS025" },
                    { new Guid("6c1321f8-7c17-4e63-938c-1b6eab1d83aa"), "DENIMSHORTS026" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "DENIMSHORTS026" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "GREENKIDSSHOES027" },
                    { new Guid("f226f5d4-9c33-45c0-9531-d540ef06c168"), "GREENKIDSSHOES027" },
                    { new Guid("8e0ee96a-773b-4be5-b907-e3da505f9ca4"), "GREYWOMENSTEE028" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "GREYWOMENSTEE028" },
                    { new Guid("4d4a7df3-6ed1-4ef0-8ea7-4fc92ea31de2"), "HANDBAG008" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "HANDBAG008" },
                    { new Guid("9b59db9a-7c0d-4880-9c60-5575ef1e5b85"), "HAT001" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "HAT001" },
                    { new Guid("25c8d39e-cc8b-44b4-b3e4-76872d3f22b5"), "JEANS002" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "JEANS002" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "KIDBLUEDRESS021" },
                    { new Guid("b67f013c-87d9-42ef-8922-cdc0f0ee0075"), "KIDBLUEDRESS021" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "KIDHAT003" },
                    { new Guid("d5a0abf6-34d5-4ed3-9c31-d73f25640b1d"), "KIDHAT003" },
                    { new Guid("041e3b6f-1a52-44ca-9981-88c785c7c9e7"), "KIDPANTS006" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "KIDPANTS006" },
                    { new Guid("35acca4d-0ff1-4d9c-b5d3-6db3ca5c7c13"), "KIDSBODYSUIT013" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "KIDSBODYSUIT013" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "KNITTED004" },
                    { new Guid("b3a41c96-17d2-4649-9d8c-28448a29ce7c"), "KNITTED004" },
                    { new Guid("679f8dd5-9f41-4773-8f57-3bf99f06cd9b"), "MENSWHITETEE015" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "MENSWHITETEE015" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "OWLHAT007" },
                    { new Guid("f88c17b0-6111-4620-bc3a-284bca392176"), "OWLHAT007" },
                    { new Guid("8d0bd08c-9930-4e0c-8f15-88cde5d8490b"), "SNEAKERS005" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "SNEAKERS005" },
                    { new Guid("2e5247f9-3d88-48d0-8c47-9939e6e7eaa4"), "SNEAKERS009" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "SNEAKERS009" },
                    { new Guid("98363f68-96c9-44ab-b3d3-e32ac25ea6ac"), "STRIPEDSHIRT010" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "STRIPEDSHIRT010" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "SUMMERDRESS011" },
                    { new Guid("b03f66c5-6c50-487b-b620-37e9da2c2b33"), "SUMMERDRESS011" },
                    { new Guid("1b172b64-5462-4a20-bef3-8c6f04c62e87"), "VANSSHOES012" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "VANSSHOES012" },
                    { new Guid("02f03e93-4e4e-4c9d-8620-e8a40a986b36"), "WHITETEE014" },
                    { new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), "WHITETEE014" }
                });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "Comment", "Created", "ProductArticleNumber", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ad7551d-9a60-43ce-b475-7a19e0e1d18a"), "This product is dependable and stylish. It fulfills its purpose effectively and features an appealing design. While it's not without minor flaws, it's a solid choice for those seeking reliability and style.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7833), "BROWNHANDBAG022", 4, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("0c2bd56c-2ec9-4a27-8b25-c51ca5e6f6db"), "Highly recommended! It's a worthwhile addition to your collection.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7882), "HANDBAG008", 5, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("0ce7d3f6-0c8e-46a2-8e70-7a9a86e2a00d"), "Kids' fashion should be fun and functional, and these clothes deliver on both fronts. The designs are playful and appealing to children, while the quality ensures they last through playdates and adventures. A must-have for young fashionistas!", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7814), "KIDBLUEDRESS021", 5, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("0e9eddba-88db-480f-8a12-2e8ebaf9bde8"), "This product is rather ordinary. It doesn't have any standout features but gets the job done. The quality is average, and it's suitable for everyday use.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7875), "KIDSBODYSUIT013", 3, "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d" },
                    { new Guid("15d775e1-6ed2-487a-81d4-d7ca9e6f4e9a"), "A good product overall. It's worth considering", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7851), "SNEAKERS009", 4, "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d" },
                    { new Guid("18a2a186-631f-475a-8d83-190c16f9c525"), "I'm very impressed with this purchase. It exceeded my expectations.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7844), "JEANS002", 4, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("1cb6f65d-1f22-4c14-9c6b-3fc7a4f9b8ed"), "I wholeheartedly recommend this product. It's an outstanding addition to any wardrobe. The craftsmanship is top-notch, and it's incredibly comfortable to wear, even for extended periods. The attention to detail in the design is commendable, and the versatility of this item is unparalleled. It's worth every penny, and the value you receive far exceeds the price. If you're searching for a product that consistently delivers excellence, look no further.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7881), "HANDBAG008", 5, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("1edf8dc8-07ea-41e4-8c1f-8a1f7ff0e0d7"), "This product offers great value. It's a must-buy.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7893), "GREYWOMENSTEE028", 5, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("218e882b-ae56-4a9a-8fc0-1f5da0f7f2c5"), "Overall, this product is good. It serves its purpose and offers good value for the price.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7868), "BLACKWARMHAT020", 4, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("2b17df60-c61d-4fb3-9f2b-27132d57d2d3"), "These green kids' shoes are stylish and comfy", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7828), "GREENKIDSSHOES027", 4, "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284" },
                    { new Guid("34f7c62e-d7d9-4bd3-98ad-8c6c3b16839f"), "The quality is decent for the price. It serves its purpose.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7847), "VANSSHOES012", 3, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("3b4b3c38-5eb6-4e36-8a23-1bba8ed82f3d"), "Kids' fashion should be fun and functional, and these clothes deliver on both fronts. The designs are playful and appealing to children, while the quality ensures they last through playdates and adventures. A must-have for young fashionistas!", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7884), "OWLHAT007", 5, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("3bce2f0d-1d42-4b11-af2a-8d59ac6b87f7"), "This product is reliable and affordable. It's a good choice for those seeking a budget-friendly option.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7877), "KIDSBODYSUIT013", 4, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("48c3f19f-2eeb-4e15-8f75-6d1e2dd408c9"), "I couldn't be happier with my choice. The vibrant green color immediately caught my eye, and it's just as stylish in person. These shoes are not only fashionable but also incredibly comfortable for my little one to wear all day long. The quality is top-notch, and I appreciate the attention to detail in their design. These green shoes have quickly become a favorite in our child's wardrobe. I highly recommend them to parents looking for both style and comfort in kids' footwear.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7826), "GREENKIDSSHOES027", 5, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("4a9c16d5-3e61-4a07-bffe-c24f21a2aabb"), "It's a solid pick. It's reliable and serves its purpose effectively. There are some areas for improvement, but it's a good choice.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7871), "BLACKWARMHAT020", 4, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("4f8c9c3c-ae0d-44e9-82c9-899cead3e8c8"), "I'm delighted with this purchase. It's a great product considering the price. The quality is good, and it serves its intended purpose well. While there's room for improvement, it's still a solid choice for those looking for a reliable and budget-friendly option.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7855), "MENSWHITETEE015", 4, "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d" },
                    { new Guid("631a44dd-7f0e-44e9-9fa6-08e2c4ee8ecb"), "This product offers great value. It's a must-buy.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7849), "VANSSHOES012", 5, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("6d0a69eb-51a7-4c21-bba6-780de40bc3ca"), "This item is fantastic!", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7809), "BEIGEPANTS017", 5, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("6e6a4be1-0b08-4c18-ae90-3ec1d2cf30cb"), "A good product overall. It's worth considering.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7862), "STRIPEDSHIRT010", 4, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("6f9a4c8f-6cc3-49db-9a79-c6fe3a29fc3d"), "This is an average purchase. It's neither exceptional nor disappointing.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7865), "STRIPEDSHIRT010", 3, "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d" },
                    { new Guid("7a9a4502-3f42-4c0e-95e3-774fe9d1a96c"), "Overall, this product is good. It serves its purpose and offers good value for the price.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7831), "GREENKIDSSHOES027", 3, "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d" },
                    { new Guid("7b9d3e7c-c4ed-44d2-8dcd-d5a0c3b4f7ed"), "This product is simply outstanding.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7873), "SUMMERDRESS011", 5, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("7cc7cf7a-e8a7-46ef-9e17-c4ac3b74a9bc"), "This product is absolutely amazing. The quality, design, and overall performance exceed all expectations. It's a versatile addition to any collection and offers exceptional value for its price. I highly recommend it to anyone seeking a top-tier product.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7860), "STRIPEDSHIRT010", 5, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("7d8c89db-4ea3-4e3f-8a47-3e2ea1b6e4bc"), "These kids' clothes are perfect for playdates and parties. They are stylish and practical, allowing children to look their best while having fun. While they may have minor room for improvement, they're a solid choice.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7888), "KIDPANTS006", 4, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("a15e3c6a-691d-443e-82b6-cffce1dc3dc3"), "This is an average purchase. It's neither exceptional nor disappointing.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7853), "MENSWHITETEE015", 3, "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3" },
                    { new Guid("a7ef79fb-4a19-46f3-8300-8b17a9715b0d"), "This product is a true gem. The quality is exceptional, and it has quickly become a favorite in my wardrobe. The attention to detail in the craftsmanship is evident, and it's incredibly comfortable to wear. I can confidently say that I would recommend it to anyone seeking a versatile and high-quality addition to their collection. The value you get from this item is unmatched, making it a fantastic investment.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7742), "BEIGEPANTS017", 5, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("b20cd82f-8f11-4a13-b0fc-d71dd9f4b9eb"), "This product is dependable and stylish. It fulfills its purpose effectively and features an appealing design. While it's not without minor flaws, it's a solid choice for those seeking reliability and style.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7886), "HAT001", 4, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("b2e4f8ec-1e88-47b3-9f43-850b9ad37e1f"), "I'm delighted with this purchase. It's a great product considering the price. The quality is good, and it serves its intended purpose well. While there's room for improvement, it's still a solid choice for those looking for a reliable and budget-friendly option.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7858), "DENIMSHORTS026", 4, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("c2b1bf4a-8cc4-4a59-9361-710c4eef7b45"), "These kids' clothes strike a great balance between affordability and trendiness. They allow your children to stay fashionable without breaking the bank. The quality is good, making them suitable for everyday wear.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7879), "KIDSBODYSUIT013", 4, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("c7b8c9ae-2a8f-4c11-9f5d-8f95e9728ff1"), "I'm not satisfied with this item. It didn't meet my expectations, and I've encountered several problems. The quality is disappointing, and I would caution against purchasing it.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7857), "DENIMSHORTS026", 2, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("ccedf9cd-4fb4-4a07-98f6-853d165a85cd"), "I recently bought a pair of green kids' shoes for my child, and they've proven to be a fun and practical choice. The green color is eye-catching and adds a playful touch to their outfits. These shoes are well-constructed and offer good support for little feet. They are suitable for both outdoor play and casual outings. While they're not perfect, they strike a good balance between style and functionality, making them a solid option for active kids.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7820), "GREENKIDSSHOES027", 4, "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3" },
                    { new Guid("d3dd10e3-8f3d-49ea-92ec-8f7cd2b5b0cd"), "Highly recommended! It's a worthwhile addition to your collection.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7890), "GREYWOMENSTEE028", 5, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("d78a5d59-3d22-4d24-9a72-9a0c5d64e962"), "I had high hopes for these kids' clothes, but they fell short of my expectations. The quality is disappointing, and they didn't hold up well to regular use. I wouldn't recommend them.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7818), "KIDBLUEDRESS021", 2, "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284" },
                    { new Guid("d7d8b2ef-e7dd-45c5-9a77-9d5695d2b6f1"), "I highly recommend this product. It's a standout choice and is worth every penny.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7835), "JEANS002", 5, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("e499542e-83e5-4a11-b1c3-184c3be4a8a4"), "Shopping for kids' clothes can be a joy when you find items like these. The designs are adorable, and the durability is a big plus. These clothes can withstand the wear and tear of active little ones while keeping them looking stylish.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7816), "KIDBLUEDRESS021", 5, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("e4f2f0ff-85a6-40c9-8c14-962d2a28ff75"), "I'm not impressed. It didn't live up to my expectations, and there were some issues.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7837), "JEANS002", 2, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("e8cf3f5c-1c7d-45ed-9ea6-cac3c4db07e1"), "This product is a true gem. The quality is exceptional, and it has quickly become a favorite in my wardrobe. The attention to detail in the craftsmanship is evident, and it's incredibly comfortable to wear. I can confidently say that I would recommend it to anyone seeking a versatile and high-quality addition to their collection. The value you get from this item is unmatched, making it a fantastic investment.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7892), "GREYWOMENSTEE028", 5, "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { new Guid("e99881b5-90e6-4a15-91ec-2c1c3a685c0e"), "They are rather average in terms of design and quality. The green color is nice, and they do serve their purpose as everyday shoes. However, they lack the standout features or exceptional comfort that I was hoping for. If you're looking for basic green shoes for your child, these might fit the bill, but don't expect anything extraordinary.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7822), "GREENKIDSSHOES027", 3, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" },
                    { new Guid("f3ecfaec-8eb5-4e60-af1b-7f2a4d3d08ca"), "This product falls in the 'acceptable' range for me. It serves its purpose decently, but I believe there is room for improvement. The quality is average, and while it gets the job done, it doesn't particularly stand out. If you're seeking a basic, budget-friendly option, this might work for you. However, I'd be more inclined to explore other alternatives for a more satisfactory experience.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7866), "WHITETEE014", 3, "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { new Guid("f4242cc7-7dd3-4b7d-91f3-85d6cfe24222"), "It's a solid pick. It's reliable and serves its purpose effectively. There are some areas for improvement, but it's a good choice.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7840), "JEANS002", 4, "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d" },
                    { new Guid("f7e0ecf2-0da4-49a2-980a-9b8a703b34cb"), "These kids' clothes are perfect for playdates and parties. They are stylish and practical, allowing children to look their best while having fun. While they may have minor room for improvement, they're a solid choice.", new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7812), "KIDBLUEDRESS021", 4, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984" }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "ProductId", "TagId" },
                values: new object[,]
                {
                    { "BEACHSHOES016", 1 },
                    { "BEIGEPANTS017", 3 },
                    { "CHECKEREDHANDBAG023", 2 },
                    { "GREENKIDSSHOES027", 2 },
                    { "GREYWOMENSTEE028", 3 },
                    { "HANDBAG008", 3 },
                    { "HAT001", 1 },
                    { "JEANS002", 1 },
                    { "KIDHAT003", 1 },
                    { "KIDPANTS006", 2 },
                    { "KNITTED004", 2 },
                    { "OWLHAT007", 1 },
                    { "SNEAKERS005", 1 },
                    { "SNEAKERS009", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "ColorId", "ProductArticleNumber", "Quantity", "SizeId" },
                values: new object[,]
                {
                    { new Guid("0a83d9c2-67c5-4432-9e8d-ee02a8fb3bf0"), 2, "SNEAKERS005", 2, 12 },
                    { new Guid("0d8b1c3e-4f5a-42d1-9c7e-8b6d2f1a4c9e"), 6, "CHECKEREDHANDBAG023", 8, 2 },
                    { new Guid("0e83f6a7-97c1-4b4a-8d0a-10b8f9d2d1af"), 12, "MENSWHITETEE015", 2, 2 },
                    { new Guid("0f251c6c-02ce-4b97-a352-5692d23cc8e0"), 10, "VANSSHOES012", 6, 8 },
                    { new Guid("10b5e2c4-7f96-46a2-8cfa-5d85a6d0e4f2"), 4, "BLACKSNEAKERS018", 1, 10 },
                    { new Guid("16c9f4d8-9c41-4a02-9e78-dfe328efb6fc"), 12, "WHITETEE014", 5, 3 },
                    { new Guid("1c3bd0e2-8b7f-4c58-9f0e-7e5e0cf19fb1"), 10, "BEACHSHOES016", 5, 8 },
                    { new Guid("1d21d5db-0b07-490e-a2cf-9a1c8f3bf50f"), 2, "SNEAKERS005", 2, 14 },
                    { new Guid("1f7e6c8a-4d5b-49e2-9c3a-2b7f0d4e1a5c"), 2, "DENIMSHORTS026", 1, 2 },
                    { new Guid("27b94599-398f-48f6-935c-8ebf181fcbbd"), 7, "KIDPANTS006", 4, 21 },
                    { new Guid("29c17a1a-3a27-4e1d-8a0e-9674d7e5f8d2"), 4, "JEANS002", 2, 1 },
                    { new Guid("2a8e03c1-7252-45f9-9f5c-56ab9bf3c11b"), 10, "SUMMERDRESS011", 5, 2 },
                    { new Guid("2a8f7e3d-6c4a-4d1b-8e5d-9f1c2a4b7c8e"), 13, "COLORFULKIDSDRESS025", 4, 19 },
                    { new Guid("2d8c4f3a-4a7d-42b8-8e0f-1e5b7c6d0f4a"), 4, "BLACKTEE019", 3, 4 },
                    { new Guid("347f12a5-d8b1-4565-8c6d-0a5c8edc2c26"), 6, "KNITTED004", 5, 3 },
                    { new Guid("37e9ac13-08a2-4902-ae3f-55f6f2b8790e"), 14, "GREYWOMENSTEE028", 2, 3 },
                    { new Guid("39246b6e-433b-4571-8f3a-49a2b8c3dace"), 8, "OWLHAT007", 2, 18 },
                    { new Guid("3b8da2e1-964b-4ff2-aa65-4f67b69de2b0"), 12, "WHITETEE014", 2, 2 },
                    { new Guid("43f8e1c0-6d21-4cda-9e7c-2c6a9bf7a8f5"), 5, "BEIGEPANTS017", 1, 4 },
                    { new Guid("44f05c4e-3b60-4c53-84c9-3b16d8b5c020"), 11, "GREENKIDSSHOES027", 1, 17 },
                    { new Guid("45ed8f8d-c5e3-4623-ba85-d3a8ecdbf78c"), 12, "WHITETEE014", 3, 4 },
                    { new Guid("48c1b5e8-6a91-478d-9c0d-85f6946c6b33"), 4, "JEANS002", 2, 3 },
                    { new Guid("49b8e2c1-7a2d-4b89-8f1e-d6b7f0c2e3a4"), 4, "BLACKWARMHAT020", 4, 3 },
                    { new Guid("4a5bd9c6-6b89-45ce-a8e5-69dfec2d2a1f"), 9, "STRIPEDSHIRT010", 1, 21 },
                    { new Guid("4b18d5e7-9e32-4a0b-a8a2-efdc7f3d4b2e"), 5, "BEIGEPANTS017", 2, 2 },
                    { new Guid("4e2f3d45-6210-4c84-ae22-83a7454697ea"), 10, "VANSSHOES012", 4, 9 },
                    { new Guid("4e5d2c9f-7b6c-4d8a-8e9f-2a1c8d9e0f6b"), 4, "CHECKEREDKIDSDRESS024", 7, 18 },
                    { new Guid("4f9d61a2-927d-4901-bb6e-c4e2bf20d87b"), 10, "SNEAKERS009", 3, 10 },
                    { new Guid("51fb2941-879a-4ea6-a7d2-0cbac775e636"), 10, "SUMMERDRESS011", 4, 4 },
                    { new Guid("5640a6f3-4312-4a2f-aa8e-f5f17a01e262"), 6, "KNITTED004", 1, 4 },
                    { new Guid("65b9c2f0-413a-4f98-9f92-ef2a7c2b1c84"), 10, "BEACHSHOES016", 2, 9 },
                    { new Guid("6a4d3f0e-3d7b-4bdc-9a1a-3a9e6d0f4e1b"), 4, "BLACKSNEAKERS018", 6, 12 },
                    { new Guid("6d2c4b7f-9a1e-4c8d-8b7e-2f3a1c9b0e5d"), 2, "DENIMSHORTS026", 2, 1 },
                    { new Guid("6d6f7dbd-8d94-43bf-a56e-4a6e4d9c7f9c"), 3, "JEANS002", 2, 2 },
                    { new Guid("6d7ea51e-9f40-48d1-a75d-0ef47b46311c"), 11, "GREENKIDSSHOES027", 6, 18 },
                    { new Guid("6d8b3f2a-4f6e-49c1-a7d0-8f5e2a9c1b7d"), 3, "KIDBLUEDRESS021", 2, 19 },
                    { new Guid("6e427f7d-982e-4f3b-ba79-5d0f17f73dfc"), 10, "SNEAKERS009", 2, 14 },
                    { new Guid("6f8f3a5e-00a4-4c7b-8dd3-7efbb3a6f99e"), 7, "KIDPANTS006", 2, 20 },
                    { new Guid("7080b9b1-6f92-4ee1-8a57-0329a226d0f7"), 3, "JEANS002", 2, 5 },
                    { new Guid("728c3e5b-9d4f-4bf1-8c87-6b4b6a7a3c91"), 5, "BEIGEPANTS017", 1, 3 },
                    { new Guid("72e2ff20-0ea6-4e2a-9c4c-e5e1f1692e5a"), 4, "KIDHAT003", 9, 19 },
                    { new Guid("791cb653-7e36-47b1-8a19-eb9cfaf0e84b"), 12, "KIDSBODYSUIT013", 2, 17 },
                    { new Guid("7a4e5f1c-8c9b-4d3f-9a7e-1b2d0e6f5c8a"), 2, "DENIMSHORTS026", 1, 4 },
                    { new Guid("7b4d8a99-3b8e-47c7-89d1-e01a7c19d5e4"), 12, "WHITETEE014", 4, 1 },
                    { new Guid("7b6f2d8c-0a9e-4bf5-8c7e-6e8c4b9d2a8e"), 4, "BLACKTEE019", 2, 6 },
                    { new Guid("7e21c4d9-8ca5-464e-9b23-4a7e3c6d8d59"), 12, "MENSWHITETEE015", 5, 5 },
                    { new Guid("81d22c44-12e5-4e79-9f2b-13a63e1e7601"), 7, "KIDPANTS006", 1, 19 },
                    { new Guid("81d2f5a9-48c1-4a86-a79b-d39bf4c8d5e6"), 4, "BLACKTEE019", 4, 2 },
                    { new Guid("834a820f-0b4b-49b3-a05c-1e7c131c5883"), 5, "HAT001", 5, 3 },
                    { new Guid("84f7cde0-7b9e-4f17-af2a-d0d0ef3a7d9c"), 12, "MENSWHITETEE015", 1, 6 },
                    { new Guid("8a79e5a1-621c-4f0e-b3d9-4c4f6e67f52e"), 12, "WHITETEE014", 1, 5 },
                    { new Guid("8c245f6a-6e6d-43e3-9d0e-45f67aaf2e31"), 14, "GREYWOMENSTEE028", 4, 1 },
                    { new Guid("8c9e1a4d-0f6b-49a2-9c5d-1f3e8b2d4c1a"), 6, "BROWNHANDBAG022", 4, 3 },
                    { new Guid("8d9f4c2e-6a3d-4f1b-9c7a-0e5f7c8b2a1d"), 2, "DENIMSHORTS026", 2, 3 },
                    { new Guid("8e548b7f-6a08-432d-b9b5-5c8b7fc2da59"), 12, "KIDSBODYSUIT013", 8, 18 },
                    { new Guid("943b4ff9-4b16-42ab-8d63-3ddcc741c73e"), 2, "SNEAKERS005", 2, 15 },
                    { new Guid("9a48bcf9-afcd-4b1b-8df1-6fc1ec5f17b7"), 14, "GREYWOMENSTEE028", 2, 5 },
                    { new Guid("9b51f7e6-49d0-40e5-bc27-2c8d2efc5f01"), 12, "MENSWHITETEE015", 3, 4 },
                    { new Guid("9c31d8ed-463e-4c76-8a2c-c99fc8219fb1"), 9, "HANDBAG008", 3, 3 },
                    { new Guid("9e0f7ca2-4a1b-41d5-ae9c-8bca0f8d39f2"), 4, "BLACKSNEAKERS018", 3, 13 },
                    { new Guid("a3f1e8d2-6c9b-4a5d-8e2f-9d4c1b7a0e6d"), 4, "CHECKEREDKIDSDRESS024", 2, 19 },
                    { new Guid("a4c9d1f7-0b7e-4a23-9e8f-8d7e1c5b3f0d"), 4, "BLACKWARMHAT020", 1, 4 },
                    { new Guid("a6d9c3f8-9c25-4b79-a76d-2f09a8c6f71e"), 12, "WHITETEE014", 2, 6 },
                    { new Guid("a75c4a16-5a16-457f-8e5a-77c6e9b309cb"), 9, "STRIPEDSHIRT010", 5, 19 },
                    { new Guid("c3430e76-6df9-4c9d-8d8b-655e22db6f53"), 2, "SNEAKERS005", 2, 11 },
                    { new Guid("cfb38a58-792e-45b2-8b1c-8e6317e512ca"), 9, "STRIPEDSHIRT010", 2, 18 },
                    { new Guid("d3b7b08d-1c65-4d01-8e9a-69ac6d977972"), 10, "SUMMERDRESS011", 3, 3 },
                    { new Guid("d3c2f9b4-0e6a-42a3-9dfe-8f8ea1c8b3f2"), 12, "MENSWHITETEE015", 6, 3 },
                    { new Guid("d4c1815f-42e1-47c2-9c4b-ff5c22771f0e"), 2, "SNEAKERS005", 2, 13 },
                    { new Guid("d7f5c3e0-8b2a-4d1c-9f7e-6c5a8d1b4e9f"), 13, "COLORFULKIDSDRESS025", 6, 20 },
                    { new Guid("db8a6f0d-d7c5-4eeb-9404-91a6eac0377d"), 14, "GREYWOMENSTEE028", 1, 4 },
                    { new Guid("e1d4b7c0-8c2a-43f5-b9d2-7f6e8d3a1c5b"), 3, "KIDBLUEDRESS021", 3, 20 },
                    { new Guid("e2b91a7a-0e02-4f18-a6c4-5ef42491b4ca"), 6, "KNITTED004", 2, 2 },
                    { new Guid("e5a4d6c1-7c8d-44c9-81a4-8b27f0e3a45d"), 10, "BEACHSHOES016", 3, 11 },
                    { new Guid("e82c1f57-656b-4bde-92a6-0f4151a9e6e2"), 8, "OWLHAT007", 2, 19 },
                    { new Guid("e9f23d6a-fdcd-44f9-a163-35a67b1d9905"), 10, "SNEAKERS009", 2, 13 },
                    { new Guid("f5d131ab-9353-421c-9e25-19e9c7d9d3c1"), 3, "JEANS002", 2, 4 },
                    { new Guid("f9d1d88f-864a-4d19-a91d-8a4a4e2d34e6"), 10, "SUMMERDRESS011", 2, 5 },
                    { new Guid("faa2e4a3-739c-41e7-82d4-2489d2c25ba6"), 14, "GREYWOMENSTEE028", 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserAdresses",
                columns: new[] { "AdressId", "UserId", "Title" },
                values: new object[,]
                {
                    { 3, "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", "Home" },
                    { 9, "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", "Work" },
                    { 2, "1f75883b-125b-49b9-a3f1-931b83d05199", "Home" },
                    { 3, "1f75883b-125b-49b9-a3f1-931b83d05199", "Work" },
                    { 5, "1f75883b-125b-49b9-a3f1-931b83d05199", "Other" },
                    { 1, "3b21a87a-aa26-4c90-9a2d-4c81205a0721", "Home" },
                    { 3, "3b21a87a-aa26-4c90-9a2d-4c81205a0721", "Parents" },
                    { 7, "3b21a87a-aa26-4c90-9a2d-4c81205a0721", "Other" },
                    { 8, "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3", "Home" },
                    { 2, "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", "Home" },
                    { 4, "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", "Work" },
                    { 5, "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", "Other" },
                    { 7, "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", "Parents" },
                    { 1, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", "Home" },
                    { 4, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", "Other" },
                    { 6, "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", "Parents" }
                });

            migrationBuilder.InsertData(
                table: "UserPromocodes",
                columns: new[] { "CodeId", "UserId" },
                values: new object[,]
                {
                    { "APIK85WQRT", "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d" },
                    { "APIK85WQRT", "1f75883b-125b-49b9-a3f1-931b83d05199" },
                    { "20DERL5LOT", "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { "WIN5IQP658", "3b21a87a-aa26-4c90-9a2d-4c81205a0721" },
                    { "APIK85WQRT", "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3" },
                    { "WIN5IQP658", "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3" }
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutEntities_OrderId",
                table: "CheckoutEntities",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutEntities_PaymentMethodId",
                table: "CheckoutEntities",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutEntities_StatusCodeId",
                table: "CheckoutEntities",
                column: "StatusCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_ProductVariantId",
                table: "OrderRows",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromocodeId",
                table: "Orders",
                column: "PromocodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ImageId",
                table: "ProductImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductArticleNumber",
                table: "ProductReviews",
                column: "ProductArticleNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_UserId",
                table: "ProductReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ColorId",
                table: "ProductVariants",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductArticleNumber",
                table: "ProductVariants",
                column: "ProductArticleNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_SizeId",
                table: "ProductVariants",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdresses_AdressId",
                table: "UserAdresses",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_PaymentId",
                table: "UserPaymentMethods",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPromocodes_CodeId",
                table: "UserPromocodes",
                column: "CodeId");
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
                name: "CheckoutEntities");

            migrationBuilder.DropTable(
                name: "OrderRows");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "UserAdresses");

            migrationBuilder.DropTable(
                name: "UserPaymentMethods");

            migrationBuilder.DropTable(
                name: "UserPromocodes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "StatusCodes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Promocodes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
