namespace QOAM.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using QOAM.Core.Scripts;

    public partial class ConvertDataAfterSplit : DbMigration
    {
        public override void Up()
        {
            Sql(ResourceReader.GetContentsOfResource("Copy after split JSC.sql"));
        }
        
        public override void Down()
        {
        }
    }
}
