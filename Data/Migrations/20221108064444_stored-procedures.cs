using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class storedprocedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                        CREATE PROCEDURE getTalleresPorEdificioId(IN IdEd Int(9))
                        BEGIN
                        SELECT *
                        FROM Taller
                        WHERE idEdificio = IdEd;
                        END
                        ");

            migrationBuilder.Sql(@"
                        CREATE PROCEDURE obtenerHerramientasPorId(IN IdHer Int(9))
                        BEGIN
                        SELECT *
                        FROM herramienta
                        WHERE idTaller = IdHer;
                        END
                        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE getTalleresPorEdificioId");
            migrationBuilder.Sql("DROP PROCEDURE obtenerHerramientasPorId");
        }
    }
}
