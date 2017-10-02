namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expense_Invoice",
                c => new
                    {
                        Expense_InvoiceId = c.Int(nullable: false, identity: true),
                        Quantity = c.Double(nullable: false),
                        SumExpense = c.Double(nullable: false),
                        Expense_ExpenseId = c.Int(),
                        Invoice_InvoiceId = c.Int(),
                    })
                .PrimaryKey(t => t.Expense_InvoiceId)
                .ForeignKey("dbo.Expenses", t => t.Expense_ExpenseId)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId)
                .Index(t => t.Expense_ExpenseId)
                .Index(t => t.Invoice_InvoiceId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        TypeOfExpense = c.String(),
                        CostOfExpense = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        DateOfInvoice = c.DateTime(nullable: false),
                        SumOfInvoice = c.Single(nullable: false),
                        OverexposureContract_OverexposureContractId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.OverexposureContracts", t => t.OverexposureContract_OverexposureContractId)
                .Index(t => t.OverexposureContract_OverexposureContractId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        SumOfPayment = c.Double(nullable: false),
                        DateOfPayment = c.DateTime(nullable: false),
                        OverexposureContract_OverexposureContractId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.OverexposureContracts", t => t.OverexposureContract_OverexposureContractId)
                .Index(t => t.OverexposureContract_OverexposureContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "OverexposureContract_OverexposureContractId", "dbo.OverexposureContracts");
            DropForeignKey("dbo.Invoices", "OverexposureContract_OverexposureContractId", "dbo.OverexposureContracts");
            DropForeignKey("dbo.Expense_Invoice", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Expense_Invoice", "Expense_ExpenseId", "dbo.Expenses");
            DropIndex("dbo.Payments", new[] { "OverexposureContract_OverexposureContractId" });
            DropIndex("dbo.Invoices", new[] { "OverexposureContract_OverexposureContractId" });
            DropIndex("dbo.Expense_Invoice", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.Expense_Invoice", new[] { "Expense_ExpenseId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Invoices");
            DropTable("dbo.Expenses");
            DropTable("dbo.Expense_Invoice");
        }
    }
}
