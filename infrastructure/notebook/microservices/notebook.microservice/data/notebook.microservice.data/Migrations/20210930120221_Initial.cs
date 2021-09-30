using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace notebook.microservice.data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataStatus = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserID = table.Column<long>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataStatus = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserID = table.Column<long>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserID = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    NoteTypeID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Note_NoteType_NoteTypeID",
                        column: x => x.NoteTypeID,
                        principalTable: "NoteType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_NoteTypeID",
                table: "Note",
                column: "NoteTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "NoteType");
        }
    }
}
