using Microsoft.EntityFrameworkCore;
using Mvp.Domain.Entities;

namespace Mvp.Api.Database.Extensions;

public static class DataExtension
{
    public static void SeedData(this ModelBuilder builder)
    {
        builder.Entity<Company>()
            .HasData(
                new Company
                {
                    Id = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"),
                    Name = "Company",
                    Address = "123 Company Street",
                    Website = "https://company.com",
                    Description = "A leading company."
                },
                new Company
                {
                    Id = new Guid("18e795b5-c9da-4cbe-a3ed-9b50232791cb"),
                    Name = "Test",
                    Address = "456 Test Street",
                    Website = "https://test.com",
                    Description = "Test company."
                }
            );

        builder.Entity<Department>()
            .HasData(
                new Department
                {
                    Id = new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"),
                    Name = "IT Department",
                    Location = "Building A",
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Department
                {
                    Id = new Guid("8f2d33f9-d06a-45ce-872b-c4ddf384eabf"),
                    Name = "Marketing Department",
                    Location = "Building B",
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Department
                {
                    Id = new Guid("c2a761be-c44d-4cf3-b7c4-32ee80d036ca"),
                    Name = "Finance Department",
                    Location = "Building C",
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Department
                {
                    Id = new Guid("d1a761be-c44d-4cf3-b7c4-32ee80d036ca"),
                    Name = "Research Department",
                    Location = "Building D",
                    CompanyId = new Guid("18e795b5-c9da-4cbe-a3ed-9b50232791cb")
                }
            );

        builder.Entity<Employee>()
            .HasData(
                new Employee
                {
                    Id = new Guid("dd26e6f2-7d28-4dbd-a82e-c165ed480971"),
                    FirstName = "Gary",
                    LastName = "Smith",
                    Email = "gary.smith@company.com",
                    PhoneNumber = "555-1001",
                    Position = "Chief Executive Officer",
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Employee
                {
                    Id = new Guid("062cf920-2fca-4f83-afb3-e133c7ff5ff5"),
                    FirstName = "Mary",
                    LastName = "Johnson",
                    Email = "mary.johnson@company.com",
                    PhoneNumber = "555-1002",
                    Position = "IT Manager",
                    ManagerId = new Guid("dd26e6f2-7d28-4dbd-a82e-c165ed480971"),
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Employee
                {
                    Id = new Guid("b370958b-7b9b-4688-a8c9-db0b1cd61298"),
                    FirstName = "John",
                    LastName = "Williams",
                    Email = "john.williams@company.com",
                    PhoneNumber = "555-1003",
                    Position = "Marketing Specialist",
                    ManagerId = new Guid("dd26e6f2-7d28-4dbd-a82e-c165ed480971"),
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Employee
                {
                    Id = new Guid("19891195-af38-4d7b-afc9-ca5ec7aefc7a"),
                    FirstName = "Jane",
                    LastName = "Brown",
                    Email = "jane.brown@company.com",
                    PhoneNumber = "555-1004",
                    Position = "Financial Analyst",
                    ManagerId = new Guid("dd26e6f2-7d28-4dbd-a82e-c165ed480971"),
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Employee
                {
                    Id = new Guid("642d23a7-62ac-49cb-bdbc-b74dab2d0a06"),
                    FirstName = "Robert",
                    LastName = "Chen",
                    Email = "robert.chen@company.com",
                    PhoneNumber = "555-1005",
                    Position = "Software Developer",
                    ManagerId = new Guid("062cf920-2fca-4f83-afb3-e133c7ff5ff5"),
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Employee
                {
                    Id = new Guid("5ca3b0c3-62a2-484a-8d7a-7547feb3d05c"),
                    FirstName = "Sarah",
                    LastName = "Miller",
                    Email = "sarah.miller@company.com",
                    PhoneNumber = "555-1006",
                    Position = "System Analyst",
                    ManagerId = new Guid("062cf920-2fca-4f83-afb3-e133c7ff5ff5"),
                    CompanyId = new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5")
                },
                new Employee
                {
                    Id = new Guid("715714ec-a50e-45ff-8e07-ce5a6df80674"),
                    FirstName = "Alice",
                    LastName = "Green",
                    Email = "alice.green@test.com",
                    PhoneNumber = "555-2001",
                    Position = "Research Scientist",
                    CompanyId = new Guid("18e795b5-c9da-4cbe-a3ed-9b50232791cb")
                }
            );

        builder.Entity<EmployeeDepartment>()
            .HasData(
            new EmployeeDepartment
            {
                EmployeeId = new Guid("062cf920-2fca-4f83-afb3-e133c7ff5ff5"),
                DepartmentId = new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"),
                IsManager = true
            },
            new EmployeeDepartment
            {
                EmployeeId = new Guid("b370958b-7b9b-4688-a8c9-db0b1cd61298"),
                DepartmentId = new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"),
                IsManager = false
            },
            new EmployeeDepartment
            {
                EmployeeId = new Guid("b370958b-7b9b-4688-a8c9-db0b1cd61298"),
                DepartmentId = new Guid("8f2d33f9-d06a-45ce-872b-c4ddf384eabf"),
                IsManager = false
            },
            new EmployeeDepartment
            {
                EmployeeId = new Guid("19891195-af38-4d7b-afc9-ca5ec7aefc7a"),
                DepartmentId = new Guid("c2a761be-c44d-4cf3-b7c4-32ee80d036ca"),
                IsManager = false
            },
             new EmployeeDepartment
             {
                 EmployeeId = new Guid("19891195-af38-4d7b-afc9-ca5ec7aefc7a"),
                 DepartmentId = new Guid("8f2d33f9-d06a-45ce-872b-c4ddf384eabf"),
                 IsManager = false
             },
            new EmployeeDepartment
            {
                EmployeeId = new Guid("642d23a7-62ac-49cb-bdbc-b74dab2d0a06"),
                DepartmentId = new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"),
                IsManager = false
            },
            new EmployeeDepartment
            {
                EmployeeId = new Guid("5ca3b0c3-62a2-484a-8d7a-7547feb3d05c"),
                DepartmentId = new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"),
                IsManager = false
            }
        );
    }
}
