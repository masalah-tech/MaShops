using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaShops.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppartmentNo = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    PosterURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldPrice = table.Column<double>(type: "float", nullable: true),
                    NewPrice = table.Column<double>(type: "float", nullable: false),
                    MainPosterURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    HTMLDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreSaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreSaves_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreSaves_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPhotos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSaves_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSaves_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsReviews_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AppartmentNo", "City", "Country", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, 60, "Riyadh", "Saudi Arabia", "Tahlia Street", null },
                    { 2, 30, "Riyadh", "Saudi Arabia", "Al Sahafa Street", null },
                    { 3, 25, "Jeddah", "Saudi Arabia", "Hira Street", null }
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "Id", "PhotoURL", "Status" },
                values: new object[,]
                {
                    { 1, "/uploads/banner1.jpg", true },
                    { 2, "/uploads/banner2.jpg", true },
                    { 3, "/uploads/banner3.jpg", false },
                    { 4, "/uploads/banner4.jpg", false },
                    { 5, "/uploads/banner5.jpg", true }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Super Admin" },
                    { 2, "Admin" },
                    { 3, "Seller" },
                    { 4, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "EncPassword", "FirstName", "LastName", "Nationality", "PhoneNumber", "PhotoURL", "SecondName", "Status", "ThirdName", "Username" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohammedhamza@gmail.com", "slSe@#VSs1532", "Mohammed", "Hamza", "Saudi Arabia", "00966532071000", null, "Khalid", true, "Omar", "mohammedhamza" },
                    { 2, 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shaimaasalim@gmail.com", "slSe@#fSF3", "Shaimaa", "Salim", "Saudi Arabia", "00966532071001", null, "Sameer", true, "Osama", "shaimaasalim" },
                    { 3, 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "osamasameer@gmail.com", "@#$FSAF@#", "Osama", "Sameer", "Yemen", "00966532071002", null, "Hamza", true, "Salim", "osamasameer" },
                    { 4, 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohammednaser@gmail.com", "sF3#$Gs%#ss", "Mohammed", "Naser", "Saudi Arabia", "00966532071003", null, "Khalid", true, "Osama", "mohammednaser" },
                    { 5, 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "khalidamer@gmail.com", "Sfe34%#2#5%", "Khalid", "Osama", "Yemen", "00966532071004", null, "Naser", true, "Amer", "khalidamer" },
                    { 6, 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahmoudmansour@gmail.com", "@#FsdE323#", "Mahmoud", "Mansour", "Yemen", "00966532071005", null, "Khalid", true, "Osama", "mahmoudmansour" },
                    { 7, 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abdullahsaleh@gmail.com", "234SDFe3#$", "Abdullah", "Saleh", "Yemen", "00966532071006", null, "Mansour", true, "Mahmoud", "abdullahsaleh" },
                    { 8, 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hattanfaisal@gmail.com", "&%sdfSE323", "Hattan", "Faisal", "Saudi Arabia", "00966532071007", null, "Mahmoud", true, "Mansour", "hattanfaisal" },
                    { 9, 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "somayahomar@gmail.com", "((^77456FDg3", "Somayah", "Omar", "Saudi Arabia", "00966532071008", null, "Faisal", true, "Mahmoud", "somayahomar" },
                    { 10, 1, new DateTime(2000, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "masalah.tech@gmail.com", "M@zen852", "Mazen", "Salah", "Yemen", "00967774806897", "/uploads/mazen2.png", "Ameen", true, "Hamid", "masalah-tech" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CustomerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name", "OwnerId", "PosterURL", "Status" },
                values: new object[,]
                {
                    { 1, "Evergreen Emporium", 4, "/uploads/store-1-poster.jpg", true },
                    { 2, "GizmoTech Hub", 5, "/uploads/store-2-poster.png", true },
                    { 3, "iConnect Depot", 6, "/uploads/store-3-poster.jpeg", true }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 4, 2 },
                    { 3, 4, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 5 },
                    { 6, 3, 6 },
                    { 7, 2, 7 },
                    { 8, 2, 8 },
                    { 9, 2, 9 },
                    { 10, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "HTMLDescription", "InStock", "MainPosterURL", "Name", "NewPrice", "OldPrice", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, "<p>Rolled in sesame seeds, and fried until crispy on the outside, but still soft and chewy on the inside, DIMSUMCO Sesame Peanut Ball (Vegetarian) are actually an irresistible treat.</p><ul><li><b><i>1 pkt of 12 pieces of Sesame Peanut Ball (Vegetarian).</i></b></li><li><b><i>Halal Certified</i></b></li><li><b><i>300g</i></b></li></ul>", 5, "/uploads/prod-1-main-poster.png", "DIMSUMCO Sesame Peanut Ball (Vegetarian) – (12’s) 300g", 4.9900000000000002, null, 1 },
                    { 2, 2, "<ul> <li> Only compatible with iPad 9/8/7 (2021, 2020, 2019); Model numbers:A2602, A2604, A2603,A2605, A2270, A2428, A2429, A2430, A2197, A2200, A2198 </li> <li>Magnetic trifold stand supports both viewing and writing modes</li> <li>Instantly activate auto sleep/wake when you open or close the cover</li> <li>Front cover protects your screen from scratches while remaining slim</li> <li> Translucent matte back adds a colorful twist while leaving the logo visible </li> </ul>", 7, "/uploads/prod-2-main-poster.png", "ESR for iPad 9th Generation case(2021) Lightweight Hard Case,Auto Sleep/Wake, Ascend Series case for iPad 10.2 Inch, Lavender", 11.99, 17.989999999999998, 2 },
                    { 3, 2, "<ul> <li> Keys-To-Go is a super-slim, super-light keyboard that you can keep with you through the day whether you’re working or learning from the backyard or back at the office. </li> <li> The sealed keyboard protects against crumbs, spills, and almost anything else you (or your kids) can throw at it, and wipes clean in seconds. </li> <li> Works with the screens you use most including iPhone, iPad, and Apple TV, and even comes with a convenient stand for your phone. </li> <li> Comfortable, soft keys type silently so you and the people around you can focus on working or learning without distractions. </li> <li> Full row of iOS shortcut keys provide one-tap access to popular functions like volume up/down, mute, media controls, and more. </li> <li> An easy one-time Bluetooth pairing provides a reliable connection between Keys-To-Go and your device. </li> <li> Type for up to 3 months without needing to recharge the battery so you can spend more time typing and less time wondering where you left that charging cable. </li> </ul>", 5, "/uploads/prod-3-main-poster.jpg", "Logitech Keys-to-Go Super-Slim and Super-Light Bluetooth Keyboard for iPhone, iPad, Mac and Apple TV, Including iPad Air 5th Gen (2022) - Classic Blue", 29.989999999999998, 42.990000000000002, 3 }
                });

            migrationBuilder.InsertData(
                table: "StoreSaves",
                columns: new[] { "Id", "Date", "StoreId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 },
                    { 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 2, 2 },
                    { 3, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductPhotos",
                columns: new[] { "Id", "ProductId", "URL" },
                values: new object[,]
                {
                    { 1, 1, "/uploads/prod1-photo1.jpg" },
                    { 2, 1, "/uploads/prod1-photo2.jpeg" },
                    { 3, 1, "/uploads/prod1-photo3.jpg" },
                    { 4, 2, "/uploads/prod2-photo1.jpg" },
                    { 5, 2, "/uploads/prod2-photo2.jpg" },
                    { 6, 2, "/uploads/prod2-photo3.jpg" },
                    { 7, 3, "/uploads/prod3-photo1.jpeg" },
                    { 8, 3, "/uploads/prod3-photo2.jpg" },
                    { 9, 3, "/uploads/prod3-photo3.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "ProductSaves",
                columns: new[] { "Id", "Date", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 },
                    { 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 2, 2 },
                    { 3, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductsCarts",
                columns: new[] { "Id", "CartId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductsReviews",
                columns: new[] { "Id", "Comment", "CustomerId", "Date", "ProductId", "Rating" },
                values: new object[,]
                {
                    { 1, "Wow, this food product exceeded my expectations! The flavors are incredibly delicious and well-balanced. It's the perfect combination of sweet and savory. The texture is spot on, providing a delightful crunch with every bite. I highly recommend trying this. It has become my new favorite snack!", 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 1, 5 },
                    { 2, "I recently purchased the ESR for iPad and have mixed feelings about it. On the positive side, it offers decent protection for my iPad and fits well, providing a snug and secure fit. The design is sleek and visually appealing. However, I did encounter a few drawbacks. The stand functionality could be improved as it feels a bit flimsy and doesn't always hold the iPad at the desired angle. Additionally, I noticed that the case tends to attract fingerprints easily, requiring frequent cleaning. Overall, it's an average product that offers basic protection but could use some enhancements in terms of functionality and fingerprint resistance.", 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 2, 3 },
                    { 3, "The Logitech Keys-to-Go Bluetooth Keyboard for iPhone was a huge disappointment. Despite its sleek and slim design, the performance is severely lacking. The keys feel mushy and unresponsive, making typing a frustrating experience. Additionally, the Bluetooth connectivity is unreliable, frequently disconnecting and requiring constant reconnection. The battery life is abysmal, barely lasting a couple of hours before needing a recharge. It's incredibly disappointing to invest in a keyboard that falls so short in terms of usability and reliability. I would not recommend this product.", 3, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "DateTime", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 3, 3, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaves_ProductId",
                table: "ProductSaves",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaves_UserId",
                table: "ProductSaves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCarts_CartId",
                table: "ProductsCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCarts_ProductId",
                table: "ProductsCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReviews_CustomerId",
                table: "ProductsReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReviews_ProductId",
                table: "ProductsReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_OwnerId",
                table: "Stores",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSaves_StoreId",
                table: "StoreSaves",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSaves_UserId",
                table: "StoreSaves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                table: "UsersRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UserId",
                table: "UsersRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "ProductPhotos");

            migrationBuilder.DropTable(
                name: "ProductSaves");

            migrationBuilder.DropTable(
                name: "ProductsCarts");

            migrationBuilder.DropTable(
                name: "ProductsReviews");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "StoreSaves");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
