﻿namespace QOAM.Website.Tests.Routes
{
    using System.Web.Mvc;

    using MvcContrib.TestHelper;

    using QOAM.Website.Controllers;
    using QOAM.Website.ViewModels.Journals;

    using Xunit;

    public class JournalsControllerRoutingTests : ControllerRoutingTests<JournalsController>
    {
        [Fact]
        public void IndexActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.Index(null));
        }

        [Fact]
        public void IndexActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Index(null)));
        }

        [Fact]
        public void PricesActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/5/prices/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.Prices(null));
        }

        [Fact]
        public void PricesActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Prices(null)));
        }

        [Fact]
        public void JournalPricesActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/5/journalprices/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.JournalPrices(null));
        }

        [Fact]
        public void JournalPricesActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.JournalPrices(null)));
        }

        [Fact]
        public void InstitutionJournalPricesActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/5/institutionalprices/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.InstitutionJournalPrices(null));
        }

        [Fact]
        public void InstitutionJournalPricesActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.InstitutionJournalPrices(null)));
        }

        [Fact]
        public void ScoresActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/5/scores/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.Scores(null));
        }

        [Fact]
        public void ScoresActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Scores(null)));
        }

        [Fact]
        public void CommentsActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/5/comments/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.Comments(null));
        }

        [Fact]
        public void CommentsActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Comments(null)));
        }

        [Fact]
        public void InstitutionJournalLicenseActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/5/institutionjournallicense/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.InstitutionJournalLicense(5, (string)null));
        }

        [Fact]
        public void InstitutionJournalLicenseActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.InstitutionJournalLicense(5, (string)null)));
        }

        [Fact]
        public void InstitutionJournalLicenseActionWithModelRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/5/institutionjournallicense/".WithMethod(HttpVerbs.Post).ShouldMapTo<JournalsController>(x => x.InstitutionJournalLicense(5, (InstitutionJournalLicenseViewModel)null));
        }

        [Fact]
        public void InstitutionJournalLicenseActionWithModelDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.InstitutionJournalLicense(5, (InstitutionJournalLicenseViewModel)null)));
        }

        [Fact]
        public void TitlesActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/titles/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.Titles(null));
        }

        [Fact]
        public void TitlesActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Titles(null)));
        }

        [Fact]
        public void IssnsActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/issns/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.Issns(null));
        }

        [Fact]
        public void IssnsActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Issns(null)));
        }

        [Fact]
        public void PublishersActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/journals/publishers/".WithMethod(HttpVerbs.Get).ShouldMapTo<JournalsController>(x => x.Publishers(null));
        }

        [Fact]
        public void PublishersActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Publishers(null)));
        }
    }
}