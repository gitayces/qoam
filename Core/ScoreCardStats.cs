namespace QOAM.Core
{
    public class ScoreCardStats
    {
        public int NumberOfUnpublishedBaseScoreCards { get; set; }
        public int NumberOfPublishedBaseScoreCards { get; set; }
        public int NumberOfExpiredBaseScoreCards { get; set; }
        public int NumberOfUnpublishedValuationScoreCards { get; set; }
        public int NumberOfPublishedValuationScoreCards { get; set; }
        public int NumberOfExpiredValuationScoreCards { get; set; }
    }
}