namespace QOAM.Core.Repositories
{
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    using PagedList;

    using QOAM.Core.Repositories.Filters;

    public class JournalPriceRepository : Repository, IJournalPriceRepository
    {
        public JournalPriceRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public BaseJournalPrice Find(int id)
        {
            return this.DbContext.JournalsPrices.Find(id);
        }

        public BaseJournalPrice Find(int journalId, int userProfileId)
        {
            return this.DbContext.JournalsPrices.FirstOrDefault(j => j.JournalId == journalId && j.UserProfileId == userProfileId);
        }

        public IPagedList<BaseJournalPrice> Find(JournalPriceFilter filter)
        {
            var query = this.DbContext.JournalsPrices.Include(j => j.UserProfile);

            if (filter.JournalId.HasValue)
            {
                query = query.Where(j => j.JournalId == filter.JournalId);
            }

            if (filter.UserProfileId.HasValue)
            {
                query = query.Where(j => j.UserProfileId == filter.UserProfileId);
            }

            return query.OrderByDescending(j => j.DateAdded).ToPagedList(filter.PageNumber, filter.PageSize);
        }

        public void Insert(BaseJournalPrice journalPrice)
        {
            this.DbContext.JournalsPrices.Add(journalPrice);
        }

        public void Update(BaseJournalPrice journalPrice)
        {
            this.DbContext.Entry(journalPrice).State = EntityState.Modified;
        }

        public void Delete(BaseJournalPrice journalPrice)
        {
            this.DbContext.JournalsPrices.Remove(journalPrice);
        }
    }
}