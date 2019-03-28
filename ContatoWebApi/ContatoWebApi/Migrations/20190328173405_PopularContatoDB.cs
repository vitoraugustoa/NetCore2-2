using Microsoft.EntityFrameworkCore.Migrations;

namespace ContatoWebApi.Migrations
{
    public partial class PopularContatoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Contatos (Nome, Email, Telefone) VALUES ('vitor', 'vitor@gmail.com' , '2569-1599')");
            migrationBuilder.Sql("INSERT INTO Contatos (Nome, Email, Telefone) VALUES ('weslley', 'weslley@gmail.com' , '2569-1256')");
            migrationBuilder.Sql("INSERT INTO Contatos (Nome, Email, Telefone) VALUES ('daniela', 'daniela@gmail.com' , '2569-1578')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Contatos");
        }
    }
}
