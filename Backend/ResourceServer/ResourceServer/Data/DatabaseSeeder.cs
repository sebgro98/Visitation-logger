using Microsoft.EntityFrameworkCore;
using SharedModels.Hasher;
using SharedModels.Models;

namespace ResourceServer.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed data for PurposeType
            var service = new PurposeType { Id = Guid.NewGuid(), Name = "Service" };
            var eventType = new PurposeType { Id = Guid.NewGuid(), Name = "Event" };
            var meeting = new PurposeType { Id = Guid.NewGuid(), Name = "Meeting" };

            modelBuilder.Entity<PurposeType>().HasData(service, eventType, meeting);

            // Seed data for AdminTypes
            var masterAdmin = new AccountType { Id = Guid.NewGuid(), Name = "MasterAdmin" };
            var loggAdmin = new AccountType { Id = Guid.NewGuid(), Name = "LoggAdmin" };

            var visitorType = new AccountType { Id = Guid.NewGuid(), Name = "Visitor" };

            modelBuilder.Entity<AccountType>().HasData(masterAdmin, loggAdmin, visitorType);

            // Seed data for Countries
            var country1 = new Country { Id = Guid.NewGuid(), CountryName = "Sweden" };
            var country2 = new Country { Id = Guid.NewGuid(), CountryName = "Norway" };
            modelBuilder.Entity<Country>().HasData(country1, country2);

            // Seed data for Visitors
            var visitor1 = new Visitor
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                SSN = "123-45-6789",
                CountryId = country1.Id,
                PassportNo = "A1234567",
                Company = "TechCorp",
                City = "Stockholm",
                Status = new List<Status>()
            };
            var visitor2 = new Visitor
            {
                Id = Guid.NewGuid(),
                FullName = "Jane Smith",
                SSN = "987-65-4321",
                CountryId = country2.Id,
                PassportNo = "B7654321",
                Company = "InnovateInc",
                City = "Oslo",
                Status = new List<Status>()
            };
            modelBuilder.Entity<Visitor>().HasData(visitor1, visitor2);

            // Seed data for Nodes
            var node1 = new Node { Id = Guid.NewGuid(), NodeName = "Stockholm Office" };
            var node2 = new Node { Id = Guid.NewGuid(), NodeName = "Oslo Office" };
            modelBuilder.Entity<Node>().HasData(node1, node2);

            // Seed data for Admins
            modelBuilder
                .Entity<Admin>()
                .HasData(
                    new Admin
                    {
                        Id = Guid.NewGuid(),
                        Username = "Master-Admin",
                        Password = Hasher.HashPassword("Testpassword1!"),
                        AccountTypeId = masterAdmin.Id,
                        NodeId = node1.Id,
                        FullName = "Master Admin"
                    },
                    new Admin
                    {
                        Id = Guid.NewGuid(),
                        Username = "Logging-Admin",
                        Password = Hasher.HashPassword("Testpassword1!"),
                        AccountTypeId = loggAdmin.Id,
                        NodeId = node2.Id,
                        FullName = "Logging Admin"
                    }
                );

            // Seed data for VisitorAccounts
            var visitorAccount1 = new VisitorAccount
            {
                Id = Guid.NewGuid(),
                Username = "john.doe",
                Password = Hasher.HashPassword("Testpassword1!"),
                StartDate = new DateTime(2024, 1, 1, 8, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2023, 1, 16, 0, 0, 0, DateTimeKind.Utc),
                PurposeTypeId = service.Id,
                VisitorId = visitor1.Id,
                AccountTypeId = visitorType.Id,
                NodeId = node1.Id
            };
            var visitorAccount2 = new VisitorAccount
            {
                Id = Guid.NewGuid(),
                Username = "jane.smith",
                Password = Hasher.HashPassword("Testpassword1!"),
                StartDate = new DateTime(2024, 1, 1, 8, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2023, 1, 16, 0, 0, 0, DateTimeKind.Utc),
                PurposeTypeId = eventType.Id,
                VisitorId = visitor2.Id,
                AccountTypeId = visitorType.Id,
                NodeId = node2.Id
            };
            var visitorAccount3 = new VisitorAccount
            {
                Id = Guid.NewGuid(),
                Username = "Angel.man",
                Password = Hasher.HashPassword("Testpassword1!"),
                StartDate = new DateTime(2024, 1, 1, 8, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2023, 1, 16, 0, 0, 0, DateTimeKind.Utc),
                PurposeTypeId = service.Id,
                VisitorId = null,
                AccountTypeId = visitorType.Id,
                NodeId = node1.Id
            };
            modelBuilder
                .Entity<VisitorAccount>()
                .HasData(visitorAccount1, visitorAccount2, visitorAccount3);

            // Seed data for Status
            var status1 = new Status
            {
                Id = Guid.NewGuid(),
                VisitorAccountId = visitorAccount1.Id,
                NodeId = node1.Id,
                CheckInTime = new DateTime(2024, 1, 1, 8, 0, 0, DateTimeKind.Utc),
                CheckInSign = "JD123",
                CheckOutTime = new DateTime(2024, 1, 1, 17, 0, 0, DateTimeKind.Utc),
                CheckOutSign = "JD456",
                LastExportDate = new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc)
            };
            var status2 = new Status
            {
                Id = Guid.NewGuid(),
                VisitorAccountId = visitorAccount2.Id,
                NodeId = node2.Id,
                CheckInTime = new DateTime(2024, 1, 2, 9, 0, 0, DateTimeKind.Utc),
                CheckInSign = "JS321",
                CheckOutTime = new DateTime(2024, 1, 2, 18, 0, 0, DateTimeKind.Utc),
                CheckOutSign = "JS654",
                LastExportDate = new DateTime(2024, 1, 3, 0, 0, 0, DateTimeKind.Utc)
            };
            modelBuilder.Entity<Status>().HasData(status1, status2);
        }
    }
}
