using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EF.Migrations.ApplicationDb
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: false),
                    MessageText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "FriendshipId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "Age", "City", "Country", "Email", "FirstName", "LastName", "PhoneNumber", "University", "UserName" },
                values: new object[,]
                {
                    { 1, "In love with math and computing. Do you dare to complete? DM me then", 25, "London", "England", "ada.love@gmail.com", "Ada", "Lovelace", "+380 44 446 6356", "Oxford", "ada.love" },
                    { 2, "Shy fancy boy", 18, "New York", "USA", "tim@gmail.com", "Tim", "Delaney", "+380 44 538 6141", "Grand Army", "timmy" },
                    { 3, "I live in two worlds, one of them is the world of books", 23, "Starts Hollow", "USA", "rory.gilmore@gmail.com", "Lorelai", "Gilmore", "+380 44 193 0152", "Harvard", "rory" },
                    { 4, "I run the dinner in the downtown, come only hungry", 45, "Vinnytsia", "Ukraine", "luke.danes@gmail.com", "Luke", "Danes", "+380 44 038 0434", null, "luke`s" },
                    { 5, "In love with dancing and music, protecting girls` rights", 17, "New York", "USA", "del.marco@gmail.com", "Joey", "Del Marco", "+380 44 177 6783", "NYU", "jojo" }
                });

            migrationBuilder.InsertData(
                table: "Friendships",
                columns: new[] { "Id", "ChatId", "FriendId", "UserId" },
                values: new object[,]
                {
                    { 4, 1, 1, 3 },
                    { 7, 1, 1, 4 },
                    { 1, 1, 2, 5 },
                    { 5, 1, 2, 3 },
                    { 2, 1, 3, 1 },
                    { 3, 1, 3, 1 },
                    { 8, 1, 3, 4 },
                    { 9, 1, 3, 2 },
                    { 6, 1, 4, 3 },
                    { 10, 1, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_ChatId",
                table: "Friendships",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendId",
                table: "Friendships",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
