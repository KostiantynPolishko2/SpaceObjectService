using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceObject.Migrations
{
    /// <inheritdoc />
    public partial class Space_Objects_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "asteroid_items",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "asteroid_items",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "asteroid_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_IdAsteroidItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asteroid_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_asteroid_images_asteroid_items_FK_IdAsteroidItem",
                        column: x => x.FK_IdAsteroidItem,
                        principalTable: "asteroid_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsteroidImage_idAsteroidItem",
                table: "asteroid_images",
                column: "FK_IdAsteroidItem",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asteroid_images");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "asteroid_items",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "asteroid_items",
                newName: "name");
        }
    }
}
