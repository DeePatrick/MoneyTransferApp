CREATE PROCEDURE [dbo].[spStaff_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [ApplicationUserId], [FirstName], [LastName], [FullName], [DOB], [Gender], [LocalGovt], [Address], [Town], [State], [Position], [Salary], [UpdateDate], [ProfilePicture], [Loan], [Debt], [PayCentreId]
	FROM [dbo].[Staff]
END
