INSERT INTO [OAMarket].[dbo].[ValuationScoreCards]
	( DateStarted, DateExpiration, DatePublished, Remarks, UserProfileId, JournalId
	, VersionId, Score_ValuationScore_AverageScore, Score_ValuationScore_TotalScore
	,State, Submitted, Editor, BaseScoreCardId)

	SELECT DateStarted, DateExpiration, DatePublished, Remarks, UserProfileId, JournalId
	, VersionId, Score_ValuationScore_AverageScore, Score_ValuationScore_TotalScore
	,State, Submitted, Editor, Id

	FROM [OAMarket].[dbo].[BaseScoreCards];

INSERT INTO [OAMarket].[dbo].[ValuationJournalPrices]
	( DateAdded, Price_Amount, Price_Currency, JournalId, UserProfileId, Price_FeeType, ValuationScoreCardId )

	SELECT b.DateAdded, b.Price_Amount, b.Price_Currency, b.JournalId, b.UserProfileId, b.Price_FeeType, v.Id

	FROM [OAMarket].[dbo].[BaseJournalPrices] b, [OAMarket].[dbo].[ValuationScoreCards] v

	WHERE (v.BaseScoreCardId=b.BaseScoreCardId) AND (v.Submitted=1);

DELETE FROM [OAMarket].[dbo].[BaseJournalPrices]
	WHERE BaseScoreCardId IN 

	( SELECT BaseScoreCardId 

	  FROM [OAMarket].[dbo].[ValuationScoreCards] v

	  WHERE (v.Submitted=1) )

INSERT INTO [OAMarket].[dbo].[ValuationQuestionScores]
	(Score,ValuationScoreCardId,QuestionId)

	SELECT Score, v.BaseScoreCardId, QuestionId
	
	FROM [OAMarket].[dbo].[BaseQuestionScores] b, [OAMarket].[dbo].[ValuationScoreCards] v

	WHERE (QuestionId >17) AND (v.BaseScoreCardId=b.BaseScoreCardId) ;

DELETE FROM [OAMarket].[dbo].[BaseQuestionScores]

	WHERE (QuestionId >17)