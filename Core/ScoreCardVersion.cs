namespace QOAM.Core
{
    using System.Collections.Generic;

    public class ScoreCardVersion : Entity
    {
        public ScoreCardVersion()
        {
            this.ScoreCards = new List<BaseScoreCard>();
        }

        public int Number { get; set; }
        public int OverallNumberOfQuestions { get; set; }
        public int EditorialInformationNumberOfQuestions { get; set; }
        public int PeerReviewNumberOfQuestions { get; set; }
        public int GovernanceNumberOfQuestions { get; set; }
        public int ProcessNumberOfQuestions { get; set; }
        public int ValuationNumberOfQuestions { get; set; }

        public virtual ICollection<BaseScoreCard> ScoreCards { get; set; }
    }
}