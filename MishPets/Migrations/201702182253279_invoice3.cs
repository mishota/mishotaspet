namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoice3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expense_Invoice", "Expense_ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.Expense_Invoice", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "OverexposureContracts_OverexposureContractId", "dbo.OverexposureContracts");
            DropForeignKey("dbo.Payments", "OverexposureContract_OverexposureContractId", "dbo.OverexposureContracts");
            DropIndex("dbo.Expense_Invoice", new[] { "Expense_ExpenseId" });
            DropIndex("dbo.Expense_Invoice", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "OverexposureContracts_OverexposureContractId" });
            DropIndex("dbo.Payments", new[] { "OverexposureContract_OverexposureContractId" });
            RenameColumn(table: "dbo.Expense_Invoice", name: "Expense_ExpenseId", newName: "ExpenseId");
            RenameColumn(table: "dbo.Expense_Invoice", name: "Invoice_InvoiceId", newName: "InvoiceId");
            RenameColumn(table: "dbo.Invoices", name: "OverexposureContracts_OverexposureContractId", newName: "OverexposureContractId");
            RenameColumn(table: "dbo.Payments", name: "OverexposureContract_OverexposureContractId", newName: "OverexposureContractId");
            AddColumn("dbo.Expense_Invoice", "OverexposureContractId", c => c.Int(nullable: false));
            AlterColumn("dbo.Expense_Invoice", "ExpenseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Expense_Invoice", "InvoiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "OverexposureContractId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "OverexposureContractId", c => c.Int(nullable: false));
            CreateIndex("dbo.Expense_Invoice", "InvoiceId");
            CreateIndex("dbo.Expense_Invoice", "ExpenseId");
            CreateIndex("dbo.Invoices", "OverexposureContractId");
            CreateIndex("dbo.Payments", "OverexposureContractId");
            AddForeignKey("dbo.Expense_Invoice", "ExpenseId", "dbo.Expenses", "ExpenseId", cascadeDelete: true);
            AddForeignKey("dbo.Expense_Invoice", "InvoiceId", "dbo.Invoices", "InvoiceId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "OverexposureContractId", "dbo.OverexposureContracts", "OverexposureContractId", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "OverexposureContractId", "dbo.OverexposureContracts", "OverexposureContractId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "OverexposureContractId", "dbo.OverexposureContracts");
            DropForeignKey("dbo.Invoices", "OverexposureContractId", "dbo.OverexposureContracts");
            DropForeignKey("dbo.Expense_Invoice", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Expense_Invoice", "ExpenseId", "dbo.Expenses");
            DropIndex("dbo.Payments", new[] { "OverexposureContractId" });
            DropIndex("dbo.Invoices", new[] { "OverexposureContractId" });
            DropIndex("dbo.Expense_Invoice", new[] { "ExpenseId" });
            DropIndex("dbo.Expense_Invoice", new[] { "InvoiceId" });
            AlterColumn("dbo.Payments", "OverexposureContractId", c => c.Int());
            AlterColumn("dbo.Invoices", "OverexposureContractId", c => c.Int());
            AlterColumn("dbo.Expense_Invoice", "InvoiceId", c => c.Int());
            AlterColumn("dbo.Expense_Invoice", "ExpenseId", c => c.Int());
            DropColumn("dbo.Expense_Invoice", "OverexposureContractId");
            RenameColumn(table: "dbo.Payments", name: "OverexposureContractId", newName: "OverexposureContract_OverexposureContractId");
            RenameColumn(table: "dbo.Invoices", name: "OverexposureContractId", newName: "OverexposureContracts_OverexposureContractId");
            RenameColumn(table: "dbo.Expense_Invoice", name: "InvoiceId", newName: "Invoice_InvoiceId");
            RenameColumn(table: "dbo.Expense_Invoice", name: "ExpenseId", newName: "Expense_ExpenseId");
            CreateIndex("dbo.Payments", "OverexposureContract_OverexposureContractId");
            CreateIndex("dbo.Invoices", "OverexposureContracts_OverexposureContractId");
            CreateIndex("dbo.Expense_Invoice", "Invoice_InvoiceId");
            CreateIndex("dbo.Expense_Invoice", "Expense_ExpenseId");
            AddForeignKey("dbo.Payments", "OverexposureContract_OverexposureContractId", "dbo.OverexposureContracts", "OverexposureContractId");
            AddForeignKey("dbo.Invoices", "OverexposureContracts_OverexposureContractId", "dbo.OverexposureContracts", "OverexposureContractId");
            AddForeignKey("dbo.Expense_Invoice", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
            AddForeignKey("dbo.Expense_Invoice", "Expense_ExpenseId", "dbo.Expenses", "ExpenseId");
        }
    }
}
