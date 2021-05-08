using Microsoft.EntityFrameworkCore.Migrations;

namespace AdditionBonusTask.Migrations
{
    public partial class initialcreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_FriendSenderId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FriendSenderId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "UserSenderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FriendSenderId",
                table: "Friends");

            migrationBuilder.AddColumn<int>(
                name: "DialogId",
                table: "Messages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FriendReceiverId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Friends",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Dialogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSenderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dialogs_AspNetUsers_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendSenderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AspNetUsers_FriendSenderId",
                        column: x => x.FriendSenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DialogId",
                table: "Messages",
                column: "DialogId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserReceiverId",
                table: "Messages",
                column: "UserReceiverId",
                unique: true,
                filter: "[UserReceiverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendReceiverId",
                table: "Friends",
                column: "FriendReceiverId",
                unique: true,
                filter: "[FriendReceiverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_PersonId",
                table: "Friends",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_UserSenderId",
                table: "Dialogs",
                column: "UserSenderId",
                unique: true,
                filter: "[UserSenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FriendSenderId",
                table: "Persons",
                column: "FriendSenderId",
                unique: true,
                filter: "[FriendSenderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_FriendReceiverId",
                table: "Friends",
                column: "FriendReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Persons_PersonId",
                table: "Friends",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Dialogs_DialogId",
                table: "Messages",
                column: "DialogId",
                principalTable: "Dialogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserReceiverId",
                table: "Messages",
                column: "UserReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_FriendReceiverId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Persons_PersonId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Dialogs_DialogId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserReceiverId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Dialogs");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DialogId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FriendReceiverId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_PersonId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "DialogId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Friends");

            migrationBuilder.AddColumn<string>(
                name: "UserSenderId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FriendReceiverId",
                table: "Friends",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FriendSenderId",
                table: "Friends",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserReceiverId",
                table: "Messages",
                column: "UserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendSenderId",
                table: "Friends",
                column: "FriendSenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_FriendSenderId",
                table: "Friends",
                column: "FriendSenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserReceiverId",
                table: "Messages",
                column: "UserReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
