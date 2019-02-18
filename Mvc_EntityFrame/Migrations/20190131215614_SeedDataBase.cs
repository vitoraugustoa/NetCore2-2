using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc_EntityFrame.Migrations
{
    public partial class SeedDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Alunos (Nome,Sexo,Email,Nascimento) VALUES('Vitor','Masculino','vitor@gmail.com','1997-09-08')");
            migrationBuilder.Sql("INSERT INTO Alunos (Nome,Sexo,Email,Nascimento) VALUES('Daniela','Feminino','Daniela@gmail.com','1978-09-22')");
            migrationBuilder.Sql("INSERT INTO Alunos (Nome,Sexo,Email,Nascimento) VALUES('Weslley','Masculino','Weslley@gmail.com','1977-03-12')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Alunos");   
        }
    }
}
