namespace QOAM.Core.Repositories
{
    using PagedList;

    using QOAM.Core.Repositories.Filters;

    public interface IJournalPriceRepository
    {
        BaseJournalPrice Find(int id);
        BaseJournalPrice Find(int journalId, int userProfileId);
        IPagedList<BaseJournalPrice> Find(JournalPriceFilter filter);

        void Insert(BaseJournalPrice journalPrice);
        void Update(BaseJournalPrice journalPrice);
        void Delete(BaseJournalPrice journalPrice);
        void Save();
    }
}