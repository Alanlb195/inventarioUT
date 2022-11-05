using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class storedprocedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                        CREATE PROCEDURE dbo.getTalleresPorEdificioId
                        @id int
                        AS
                        BEGIN
                        SELECT *
                        FROM Taller
                        WHERE idEdificio = @id;
                        END
                        ");

            migrationBuilder.Sql(@"
                        CREATE PROCEDURE dbo.obtenerHerramientasPorId
                        @id int
                        AS
                        BEGIN
                        SELECT *
                        FROM herramienta
                        WHERE idTaller = @id;
                        END
                        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.getTalleresPorEdificioId");
            migrationBuilder.Sql("DROP PROCEDURE dbo.obtenerHerramientasPorId");
        }
    }
}
