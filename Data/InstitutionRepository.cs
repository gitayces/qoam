﻿namespace RU.Uci.OAMarket.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Helpers;

    using PagedList;

    using RU.Uci.OAMarket.Domain;
    using RU.Uci.OAMarket.Domain.Repositories;
    using RU.Uci.OAMarket.Domain.Repositories.Filters;

    public class InstitutionRepository : Repository, IInstitutionRepository
    {
        public InstitutionRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IList<Institution> All
        {
            get
            {
                return this.DbContext.Institutions.OrderBy(i => i.Name).ToList();
            }
        }

        public IQueryable<string> Names(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Enumerable.Empty<string>().AsQueryable();
            }

            return this.DbContext.Institutions.Where(u => u.Name.ToLower().StartsWith(query.ToLower())).Select(j => j.Name);
        }

        public IPagedList<Institution> Search(InstitutionFilter filter)
        {
            var query = this.DbContext.Institutions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(u => u.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            return ApplyOrdering(query, filter).ToPagedList(filter.PageNumber, filter.PageSize);
        }

        public Institution Find(string shortName)
        {
            return this.DbContext.Institutions.FirstOrDefault(i => i.ShortName == shortName);
        }

        public Institution Find(int id)
        {
            return this.DbContext.Institutions.Find(id);
        }

        public void Insert(Institution publisher)
        {
            this.DbContext.Institutions.Add(publisher);
        }

        private static IOrderedQueryable<Institution> ApplyOrdering(IQueryable<Institution> query, InstitutionFilter filter)
        {
            switch (filter.SortMode)
            {
                case InstitutionSortMode.Name:
                    return filter.SortDirection == SortDirection.Ascending ? query.OrderBy(u => u.Name) : query.OrderByDescending(u => u.Name);
                case InstitutionSortMode.NumberOfJournalScoreCards:
                    return filter.SortDirection == SortDirection.Ascending ?
                        query.OrderBy(u => u.NumberOfScoreCards).ThenBy(u => u.Name) :
                        query.OrderByDescending(u => u.NumberOfScoreCards).ThenBy(u => u.Name);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}