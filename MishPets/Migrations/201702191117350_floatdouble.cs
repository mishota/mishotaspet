namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class floatdouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "SumOfInvoice", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "SumOfInvoice", c => c.Single());
        }
    }
}
