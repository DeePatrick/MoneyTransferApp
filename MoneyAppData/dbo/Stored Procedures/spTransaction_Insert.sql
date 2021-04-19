CREATE PROCEDURE [dbo].[spTransaction_Insert]
	@TransactionType INT,
	@IsWithdrawal BIT, 
	@PayeeName NVARCHAR(MAX), 
	@BankName NVARCHAR(MAX), 
	@AccountNo NVARCHAR(10),
	@Location NVARCHAR(MAX),
	@BankCharge Money,
	@Amount Money,
	@CardNo NVARCHAR(MAX), 
	@CardType INT,
	@CreateDate DATETIME2,
	@CreatedBy NVARCHAR(MAX),
	@CustomerId INT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Transaction] 
		([TransactionType],[IsWithdrawal],[PayeeName],[BankName],[AccountNo],[Location] ,[BankCharge],[Amount],[CardNo],[CardType],[CreateDate],[CreatedBy],[CustomerId])
	VALUES 
		(@TransactionType,@IsWithdrawal,@PayeeName,@BankName,@AccountNo,@Location,@BankCharge,@Amount,@CardNo,@CardType,@CreateDate,CreatedBy,@CustomerId) 

END
