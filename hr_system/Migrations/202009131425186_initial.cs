namespace hr_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Duration = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Single(nullable: false),
                        CourseId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SSN = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        HashedPassword = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        EmployeeRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeRoles", t => t.EmployeeRoleId, cascadeDelete: true)
                .Index(t => t.EmployeeRoleId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentPath = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        DocTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.DocTypeId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Legal_Holiday_count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DaysCount = c.Int(nullable: false),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Employee_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.PhoneNumbers", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.Holidays", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EmployeeRoleId", "dbo.EmployeeRoles");
            DropForeignKey("dbo.EmployeeCourses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Documents", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Documents", "DocTypeId", "dbo.DocumentTypes");
            DropIndex("dbo.PhoneNumbers", new[] { "Employee_id" });
            DropIndex("dbo.Holidays", new[] { "EmployeeId" });
            DropIndex("dbo.Documents", new[] { "DocTypeId" });
            DropIndex("dbo.Documents", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "EmployeeRoleId" });
            DropIndex("dbo.EmployeeCourses", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeCourses", new[] { "CourseId" });
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Holidays");
            DropTable("dbo.EmployeeRoles");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Documents");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeCourses");
            DropTable("dbo.Courses");
        }
    }
}
