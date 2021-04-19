CREATE PROCEDURE [dbo].[spTransaction_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [TransactionId], [TransactionType], [IsWithdrawal], [PayeeName], [BankName], [AccountNo], [Location], [BankCharge], [Amount], [CardNo], [CardType], [CreateDate], [CreatedBy], [CustomerId]
	FROM [dbo].[Transaction]
END
