﻿namespace QOAM.Website.Tests.Routes
{
    using System.Web.Mvc;

    using MvcContrib.TestHelper;

    using QOAM.Website.Controllers;
    using QOAM.Website.ViewModels.Profiles;

    using Xunit;

    public class ProfilesControllerRoutingTests : ControllerRoutingTests<ProfilesController>
    {
        [Fact]
        public void IndexActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/profiles/".WithMethod(HttpVerbs.Get).ShouldMapTo<ProfilesController>(x => x.Index(null));
        }

        [Fact]
        public void IndexActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Index(null)));
        }

        [Fact]
        public void DetailsActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/profiles/5/".WithMethod(HttpVerbs.Get).ShouldMapTo<ProfilesController>(x => x.Details(null));
        }

        [Fact]
        public void DetailsActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Details(null)));
        }

        [Fact]
        public void EditActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/profiles/5/edit/".WithMethod(HttpVerbs.Get).ShouldMapTo<ProfilesController>(x => x.Edit(5, (string)null));
        }

        [Fact]
        public void EditActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Edit(5, (string)null)));
        }

        [Fact]
        public void EditActionWithModelRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/profiles/5/edit/".WithMethod(HttpVerbs.Post).ShouldMapTo<ProfilesController>(x => x.Edit(5, (EditViewModel)null));
        }

        [Fact]
        public void EditActionWithModelDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Edit(5, (EditViewModel)null)));
        }

        [Fact]
        public void ScoreCardsActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/profiles/5/scorecards/".WithMethod(HttpVerbs.Get).ShouldMapTo<ProfilesController>(x => x.ScoreCards(null));
        }

        [Fact]
        public void ScoreCardsActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.ScoreCards(null)));
        }

        [Fact]
        public void NamesActionRoutedToWithCorrectUrlAndVerb()
        {
            // Assert    
            "~/profiles/names/".WithMethod(HttpVerbs.Get).ShouldMapTo<ProfilesController>(x => x.Names(null));
        }

        [Fact]
        public void NamesActionDoesNotRequireHttps()
        {
            // Assert
            Assert.False(ActionRequiresHttps(x => x.Names(null)));
        }
    }
}