namespace QOAM.Core.Repositories
{
    using System;
    using System.Collections.Generic;

    using PagedList;

    using QOAM.Core.Repositories.Filters;

    public interface IScoreCardRepository
    {
        BaseScoreCard Find(int id);
        BaseScoreCard Find(int journalId, int userProfileId);
        IPagedList<BaseScoreCard> Find(ScoreCardFilter filter);
        void Insert(BaseScoreCard scoreCard);
        void Update(BaseScoreCard scoreCard);
        void Save();
        IPagedList<BaseScoreCard> FindForUser(ScoreCardFilter filter);
        ScoreCardStats CalculateStats(UserProfile userProfile);
        ScoreCardStats CalculateStats(Institution institution);
        IList<BaseScoreCard> FindScoreCardsToBeArchived();
        IList<BaseScoreCard> FindScoreCardsThatWillBeArchived(TimeSpan toBeArchivedWindow);
    }
}