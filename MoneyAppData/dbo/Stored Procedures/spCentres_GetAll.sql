CREATE PROCEDURE [dbo].[spCentres_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [CentreName], [CentreAddress], [CentreAccountNo], [Capital], [CentreTabNumber], [CentrePhone], [CentrePOSNumber]
	FROM [dbo].[Centres]
END
