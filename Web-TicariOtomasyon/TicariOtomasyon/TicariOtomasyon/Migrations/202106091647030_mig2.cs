namespace TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Musterilers", "MusteriSoyad", c => c.String(nullable: false, maxLength: 25, unicode: false));
            AlterColumn("dbo.Musterilers", "MusteriSifre", c => c.String(nullable: false, maxLength: 11, unicode: false));
            AlterColumn("dbo.Musterilers", "MusteriTelNo", c => c.String(nullable: false, maxLength: 11, unicode: false));
            AlterColumn("dbo.Musterilers", "MusteriMail", c => c.String(nullable: false, maxLength: 25, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Musterilers", "MusteriMail", c => c.String(maxLength: 25, unicode: false));
            AlterColumn("dbo.Musterilers", "MusteriTelNo", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.Musterilers", "MusteriSifre", c => c.String(maxLength: 11, unicode: false));
            AlterColumn("dbo.Musterilers", "MusteriSoyad", c => c.String(maxLength: 25, unicode: false));
        }
    }
}
