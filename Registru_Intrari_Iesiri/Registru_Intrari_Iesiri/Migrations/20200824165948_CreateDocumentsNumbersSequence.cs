using Microsoft.EntityFrameworkCore.Migrations;

namespace Registru_Intrari_Iesiri.Migrations
{
    public partial class CreateDocumentsNumbersSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>("DocumentNumberSequence", startValue: 1, incrementBy: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence("DocumentNumberSequence");
        }
    }
}
