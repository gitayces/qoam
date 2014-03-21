﻿namespace QOAM.Core.Repositories
{
    using System;
    using System.Collections.Generic;

    using PagedList;

    using QOAM.Core.Repositories.Filters;

    public interface IScoreCardRepository
    {
        ScoreCard Find(int id);
        ScoreCard Find(int journalId, int userProfileId);
        IPagedList<ScoreCard> Find(ScoreCardFilter filter);
        void Insert(ScoreCard scoreCard);
        void Update(ScoreCard scoreCard);
        void Save();
        IPagedList<ScoreCard> FindForUser(ScoreCardFilter filter);
        ScoreCardStats CalculateStats(UserProfile userProfile);
        ScoreCardStats CalculateStats(Institution institution);
        IList<ScoreCard> FindScoreCardsToBeArchived();
        IList<ScoreCard> FindScoreCardsThatWillBeArchived(TimeSpan toBeArchivedWindow);
    }
}