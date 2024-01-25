using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MK.RequirementsApp.Domain;

namespace MK.RequirementsApp.Infrastructure.Seeding
{
    public static class CompanySeeding
    {
        public static void Seed(this EntityTypeBuilder<Company> modelBuilder)
        {

            modelBuilder.HasData(
                new Company()
                {
                    Id = 1,
                    Name = "Albert Heijn",
                },
                new Company()
                {
                    Id = 2,
                    Name = "LIDL",
                },
                new Company()
                {
                    Id = 3,
                    Name = "Colruyt",
                },
                new Company()
                {
                    Id = 4,
                    Name = "Karadağ",
                },
                new Company()
                {
                    Id = 5,
                    Name = "ALDI",
                },
                new Company()
                {
                    Id = 6,
                    Name = "Halk Market",
                },
                new Company()
                {
                    Id = 7,
                    Name = "Apotheek De Jonghe",
                },
                new Company()
                {
                    Id = 8,
                    Name = "Kruidvat",
                }
            );
        }
    }
}
