namespace QOAM.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using QOAM.Core.Scripts;

    public partial class SplitJSC : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ScoreCards", newName: "BaseScoreCards");
            RenameTable(name: "dbo.JournalPrices", newName: "BaseJournalPrices");
            RenameTable(name: "dbo.QuestionScores", newName: "BaseQuestionScores");
            RenameColumn(table: "dbo.BaseQuestionScores", name: "ScoreCardId", newName: "BaseScoreCardId");
            RenameColumn(table: "dbo.BaseJournalPrices", name: "ScoreCardId", newName: "BaseScoreCardId");
            CreateTable(
                "dbo.ValuationScoreCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStarted = c.DateTime(nullable: false),
                        DateExpiration = c.DateTime(),
                        DatePublished = c.DateTime(),
                        Remarks = c.String(),
                        PriceRemarks = c.String(),
                        UserProfileId = c.Int(nullable: false),
                        JournalId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                        Score_ValuationScore_AverageScore = c.Single(),
                        Score_ValuationScore_TotalScore = c.Int(),
                        State = c.Int(nullable: false),
                        Submitted = c.Boolean(nullable: false),
                        Editor = c.Boolean(nullable: false),
                        BaseScoreCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: false)
                .ForeignKey("dbo.Journals", t => t.JournalId, cascadeDelete: true)
                .ForeignKey("dbo.ScoreCardVersions", t => t.VersionId, cascadeDelete: true)
                .Index(t => t.UserProfileId)
                .Index(t => t.JournalId)
                .Index(t => t.VersionId);
            
            CreateTable(
                "dbo.ValuationQuestionScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        ValuationScoreCardId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ValuationScoreCards", t => t.ValuationScoreCardId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.ValuationScoreCardId)
                .Index(t => t.QuestionId);

            RenameColumn(table: "dbo.JournalScores", name: "NumberOfReviewers", newName: "NumberOfBaseReviewers");
            AddColumn("dbo.JournalScores", "NumberOfValuationReviewers", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.UserProfiles", name: "NumberOfScoreCards", newName: "NumberOfBaseScoreCards");
            AddColumn("dbo.UserProfiles", "NumberOfValuationScoreCards", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Institutions", name: "NumberOfScoreCards", newName: "NumberOfBaseScoreCards");
            AddColumn("dbo.Institutions", "NumberOfValuationScoreCards", c => c.Int(nullable: false));
            CreateIndex("dbo.BaseScoreCards", "UserProfileId");
            CreateIndex("dbo.BaseScoreCards", "JournalId");
            CreateIndex("dbo.BaseScoreCards", "VersionId");
            CreateIndex("dbo.Journals", "CountryId");
            CreateIndex("dbo.Journals", "PublisherId");
            CreateIndex("dbo.Journals", "JournalScoreId");
            CreateIndex("dbo.Journals", "JournalPriceId");
            CreateIndex("dbo.InstitutionJournals", "InstitutionId");
            CreateIndex("dbo.InstitutionJournals", "JournalId");
            CreateIndex("dbo.InstitutionJournals", "UserProfileId");
            CreateIndex("dbo.UserProfiles", "InstitutionId");
            CreateIndex("dbo.BaseJournalPrices", "JournalId");
            CreateIndex("dbo.BaseJournalPrices", "BaseScoreCardId");
            CreateIndex("dbo.BaseJournalPrices", "UserProfileId");
            CreateIndex("dbo.BaseQuestionScores", "BaseScoreCardId");
            CreateIndex("dbo.BaseQuestionScores", "QuestionId");
            CreateIndex("dbo.JournalScores", "JournalId");
            CreateIndex("dbo.LanguageJournals", "Language_Id");
            CreateIndex("dbo.LanguageJournals", "Journal_Id");
            CreateIndex("dbo.SubjectJournals", "Subject_Id");
            CreateIndex("dbo.SubjectJournals", "Journal_Id");

            AlterColumn("dbo.Institutions", "NumberOfBaseScoreCards", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.Institutions", "NumberOfValuationScoreCards", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.UserProfiles", "NumberOfBaseScoreCards", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.UserProfiles", "NumberOfValuationScoreCards", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "NumberOfBaseReviewers", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "NumberOfValuationReviewers", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "NumberOfBaseReviewers", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "NumberOfValuationReviewers", c => c.Int(nullable: false, defaultValue: 0));

            AlterColumn("dbo.JournalScores", "OverallScore_AverageScore", c => c.Single(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "EditorialInformationScore_AverageScore", c => c.Single(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "PeerReviewScore_AverageScore", c => c.Single(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "GovernanceScore_AverageScore", c => c.Single(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "ProcessScore_AverageScore", c => c.Single(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "ValuationScore_AverageScore", c => c.Single(nullable: false, defaultValue: 0));

            AlterColumn("dbo.JournalScores", "OverallScore_TotalScore", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "EditorialInformationScore_TotalScore", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "PeerReviewScore_TotalScore", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "GovernanceScore_TotalScore", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "ProcessScore_TotalScore", c => c.Int(nullable: false, defaultValue: 0));
            AlterColumn("dbo.JournalScores", "ValuationScore_TotalScore", c => c.Int(nullable: false, defaultValue: 0));

            Sql(ResourceReader.GetContentsOfResource("20140409_Trigger_BaseScorecards.Published.sql"));
            Sql(ResourceReader.GetContentsOfResource("20140409_Trigger_ValuationScorecards.Published.sql"));

        }
        
        public override void Down()
        {
            AddColumn("dbo.Institutions", "NumberOfScoreCards", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfiles", "NumberOfScoreCards", c => c.Int(nullable: false));
            AddColumn("dbo.JournalScores", "NumberOfReviewers", c => c.Int(nullable: false));
            DropForeignKey("dbo.ValuationQuestionScores", "QuestionId", "dbo.Questions");
            DropIndex("dbo.SubjectJournals", new[] { "Journal_Id" });
            DropIndex("dbo.SubjectJournals", new[] { "Subject_Id" });
            DropIndex("dbo.LanguageJournals", new[] { "Journal_Id" });
            DropIndex("dbo.LanguageJournals", new[] { "Language_Id" });
            DropIndex("dbo.JournalScores", new[] { "JournalId" });
            DropIndex("dbo.BaseQuestionScores", new[] { "QuestionId" });
            DropIndex("dbo.BaseQuestionScores", new[] { "BaseScoreCardId" });
            DropIndex("dbo.ValuationQuestionScores", new[] { "QuestionId" });
            DropIndex("dbo.ValuationQuestionScores", new[] { "ValuationScoreCardId" });
            DropIndex("dbo.ValuationScoreCards", new[] { "VersionId" });
            DropIndex("dbo.ValuationScoreCards", new[] { "JournalId" });
            DropIndex("dbo.ValuationScoreCards", new[] { "UserProfileId" });
            DropIndex("dbo.BaseJournalPrices", new[] { "UserProfileId" });
            DropIndex("dbo.BaseJournalPrices", new[] { "BaseScoreCardId" });
            DropIndex("dbo.BaseJournalPrices", new[] { "JournalId" });
            DropIndex("dbo.UserProfiles", new[] { "InstitutionId" });
            DropIndex("dbo.InstitutionJournals", new[] { "UserProfileId" });
            DropIndex("dbo.InstitutionJournals", new[] { "JournalId" });
            DropIndex("dbo.InstitutionJournals", new[] { "InstitutionId" });
            DropIndex("dbo.Journals", new[] { "JournalPriceId" });
            DropIndex("dbo.Journals", new[] { "JournalScoreId" });
            DropIndex("dbo.Journals", new[] { "PublisherId" });
            DropIndex("dbo.Journals", new[] { "CountryId" });
            DropIndex("dbo.BaseScoreCards", new[] { "VersionId" });
            DropIndex("dbo.BaseScoreCards", new[] { "JournalId" });
            DropIndex("dbo.BaseScoreCards", new[] { "UserProfileId" });
            DropColumn("dbo.Institutions", "NumberOfValuationScoreCards");
            DropColumn("dbo.Institutions", "NumberOfBaseScoreCards");
            DropColumn("dbo.UserProfiles", "NumberOfValuationScoreCards");
            DropColumn("dbo.UserProfiles", "NumberOfBaseScoreCards");
            DropColumn("dbo.JournalScores", "NumberOfValuationReviewers");
            DropColumn("dbo.JournalScores", "NumberOfBaseReviewers");
            DropTable("dbo.ValuationQuestionScores");
            DropTable("dbo.ValuationScoreCards");
            RenameColumn(table: "dbo.BaseJournalPrices", name: "BaseScoreCardId", newName: "ScoreCardId");
            RenameColumn(table: "dbo.ValuationQuestionScores", name: "ValuationScoreCardId", newName: "ScoreCardId");
            RenameColumn(table: "dbo.BaseQuestionScores", name: "BaseScoreCardId", newName: "ScoreCardId");
            RenameTable(name: "dbo.BaseQuestionScores", newName: "QuestionScores");
            RenameTable(name: "dbo.BaseJournalPrices", newName: "JournalPrices");
            RenameTable(name: "dbo.BaseScoreCards", newName: "ScoreCards");
        }
    }
}
