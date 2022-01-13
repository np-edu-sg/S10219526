using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentFinal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisine",
                columns: table => new
                {
                    CuisineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisine", x => x.CuisineID);
                });

            migrationBuilder.CreateTable(
                name: "Eatery",
                columns: table => new
                {
                    EatyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EatyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EatyClHr = table.Column<TimeSpan>(type: "time", nullable: false),
                    EatyOpHr = table.Column<TimeSpan>(type: "time", nullable: false),
                    EatyCapacity = table.Column<int>(type: "int", nullable: false),
                    EatyLoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eatery", x => x.EatyID);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    ETID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ETName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.ETID);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategory",
                columns: table => new
                {
                    FcID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FcName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FcDescr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategory", x => x.FcID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredID);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    PgrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PgrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PgrEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PgrDOB = table.Column<DateTime>(type: "date", nullable: false),
                    PgrGender = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.PgrID);
                    table.CheckConstraint("CK_Passenger_Gender", "[PgrGender] IN ('M', 'F')");
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    DishID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DishDescr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuisineID = table.Column<int>(type: "int", nullable: false),
                    EatyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.DishID);
                    table.ForeignKey(
                        name: "FK_Dish_Cuisine_CuisineID",
                        column: x => x.CuisineID,
                        principalTable: "Cuisine",
                        principalColumn: "CuisineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dish_Eatery_EatyID",
                        column: x => x.EatyID,
                        principalTable: "Eatery",
                        principalColumn: "EatyID");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventCapacity = table.Column<int>(type: "int", nullable: false),
                    EventDuration = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    AdultPrice = table.Column<int>(type: "int", nullable: false),
                    ChildPrice = table.Column<int>(type: "int", nullable: false),
                    EventTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_EventType_EventTypeID",
                        column: x => x.EventTypeID,
                        principalTable: "EventType",
                        principalColumn: "ETID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassengerContactNo",
                columns: table => new
                {
                    PassengerID = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerContactNo", x => new { x.PassengerID, x.ContactNo });
                    table.ForeignKey(
                        name: "FK_PassengerContactNo_Passenger_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "Passenger",
                        principalColumn: "PgrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfPax = table.Column<short>(type: "smallint", nullable: false),
                    EateryID = table.Column<int>(type: "int", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservID);
                    table.ForeignKey(
                        name: "FK_Reservation_Eatery_EateryID",
                        column: x => x.EateryID,
                        principalTable: "Eatery",
                        principalColumn: "EatyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Passenger_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "Passenger",
                        principalColumn: "PgrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorisedIn",
                columns: table => new
                {
                    DishID = table.Column<int>(type: "int", nullable: false),
                    FoodCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorisedIn", x => new { x.DishID, x.FoodCategoryID });
                    table.ForeignKey(
                        name: "FK_CategorisedIn_Dish_DishID",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorisedIn_FoodCategory_FoodCategoryID",
                        column: x => x.FoodCategoryID,
                        principalTable: "FoodCategory",
                        principalColumn: "FcID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contains",
                columns: table => new
                {
                    DishID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contains", x => new { x.DishID, x.IngredientID });
                    table.ForeignKey(
                        name: "FK_Contains_Dish_DishID",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contains_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "IngredID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CsDish",
                columns: table => new
                {
                    DishID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsDish", x => new { x.DishID, x.Price });
                    table.ForeignKey(
                        name: "FK_CsDish_Dish_DishID",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PgrID = table.Column<int>(type: "int", nullable: false),
                    DishID = table.Column<int>(type: "int", nullable: false),
                    OrderQty = table.Column<int>(type: "int", nullable: false),
                    OrderPrice = table.Column<double>(type: "float", nullable: false),
                    DeliverTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => new { x.PgrID, x.OrderDateTime, x.DishID });
                    table.ForeignKey(
                        name: "FK_Order_Dish_DishID",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Passenger_PgrID",
                        column: x => x.PgrID,
                        principalTable: "Passenger",
                        principalColumn: "PgrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventSession",
                columns: table => new
                {
                    SessionNo = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSession", x => new { x.SessionNo, x.EventID });
                    table.ForeignKey(
                        name: "FK_EventSession_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfAdultTicket = table.Column<int>(type: "int", nullable: false),
                    NoOfChildTicket = table.Column<int>(type: "int", nullable: false),
                    AdultSalesPrice = table.Column<int>(type: "int", nullable: false),
                    ChildSalesPrice = table.Column<int>(type: "int", nullable: false),
                    BookDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: false),
                    EventSessionEventID = table.Column<int>(type: "int", nullable: false),
                    EventSessionSessionNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_EventSession_EventSessionSessionNo_EventSessionEventID",
                        columns: x => new { x.EventSessionSessionNo, x.EventSessionEventID },
                        principalTable: "EventSession",
                        principalColumns: new[] { "SessionNo", "EventID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Passenger_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "Passenger",
                        principalColumn: "PgrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cuisine",
                columns: new[] { "CuisineID", "CuisineName" },
                values: new object[] { 1, "Chinese" });

            migrationBuilder.InsertData(
                table: "FoodCategory",
                columns: new[] { "FcID", "FcDescr", "FcName" },
                values: new object[] { 1, "Halal food for Muslims", "Halal" });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "IngredID", "IngredName" },
                values: new object[,]
                {
                    { 1, "Chicken" },
                    { 2, "Rice" }
                });

            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "PgrID", "PgrDOB", "PgrEmail", "PgrGender", "PgrName" },
                values: new object[] { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@gmail.com", "M", "Bob" });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_EventSessionSessionNo_EventSessionEventID",
                table: "Booking",
                columns: new[] { "EventSessionSessionNo", "EventSessionEventID" });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PassengerID",
                table: "Booking",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorisedIn_FoodCategoryID",
                table: "CategorisedIn",
                column: "FoodCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Contains_IngredientID",
                table: "Contains",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_CsDish_DishID",
                table: "CsDish",
                column: "DishID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CuisineID",
                table: "Dish",
                column: "CuisineID");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_EatyID",
                table: "Dish",
                column: "EatyID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeID",
                table: "Event",
                column: "EventTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EventSession_EventID",
                table: "EventSession",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DishID",
                table: "Order",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerContactNo_PassengerID",
                table: "PassengerContactNo",
                column: "PassengerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_EateryID",
                table: "Reservation",
                column: "EateryID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PassengerID",
                table: "Reservation",
                column: "PassengerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "CategorisedIn");

            migrationBuilder.DropTable(
                name: "Contains");

            migrationBuilder.DropTable(
                name: "CsDish");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PassengerContactNo");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "EventSession");

            migrationBuilder.DropTable(
                name: "FoodCategory");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Cuisine");

            migrationBuilder.DropTable(
                name: "Eatery");

            migrationBuilder.DropTable(
                name: "EventType");
        }
    }
}
