namespace QOAM.Core
{
    public class QuestionScore : Entity
    {
        public Score Score { get; set; }
        public int ScoreCardId { get; set; }
        public int QuestionId { get; set; }
        public virtual BaseScoreCard BaseScoreCard { get; set; }
        public virtual ValuationScoreCard ValuationScoreCard { get; set; }
        public virtual Question Question { get; set; }
    }
}