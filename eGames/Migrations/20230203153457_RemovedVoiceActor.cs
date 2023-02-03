using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGames.Migrations
{
    /// <inheritdoc />
    public partial class RemovedVoiceActor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoiceActors_Games");

            migrationBuilder.DropTable(
                name: "VoiceActors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoiceActors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceActors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoiceActors_Games",
                columns: table => new
                {
                    VoiceActorId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceActors_Games", x => new { x.VoiceActorId, x.GameId });
                    table.ForeignKey(
                        name: "FK_VoiceActors_Games_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoiceActors_Games_VoiceActors_VoiceActorId",
                        column: x => x.VoiceActorId,
                        principalTable: "VoiceActors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoiceActors_Games_GameId",
                table: "VoiceActors_Games",
                column: "GameId");
        }
    }
}
