﻿namespace QOAM.Website.ViewModels.Score
{
    using QOAM.Core;

    public class JournalPriceViewModel
    {
        public int JournalPriceId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountPerArticle { get; set; }
        public decimal? AmountPerPage { get; set; }
        public Currency? Currency { get; set; }
        public FeeType? FeeType{ get; set; }

        public BaseJournalPrice ToJournalPrice()
        {
            return new BaseJournalPrice
                       {
                           Price = new Price { Amount = this.Amount, Currency = this.Currency, FeeType = this.FeeType}
                       };
        }
    }
}