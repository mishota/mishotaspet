namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expense_Invoice", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Expense_Invoice", "SumExpense", c => c.Double());
            AlterColumn("dbo.Invoices", "SumOfInvoice", c => c.Single());
            AlterColumn("dbo.OverexposureContracts", "DateOverexpEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OverexposureContracts", "DateOverexpEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Invoices", "SumOfInvoice", c => c.Single(nullable: false));
            AlterColumn("dbo.Expense_Invoice", "SumExpense", c => c.Double(nullable: false));
            AlterColumn("dbo.Expense_Invoice", "Quantity", c => c.Double(nullable: false));
        }
    }
}
