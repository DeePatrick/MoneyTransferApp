CREATE PROCEDURE [dbo].[spCustomers_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [CustomerId], [FirstName], [LastName], [FullName], [Address], [Phone], [Email], [PayCentreId], [UploadReceipts]
	FROM [dbo].[Customers]
END

