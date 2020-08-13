CREATE PROCEDURE [dbo].[pr_ObtenerIndicadorQuimico]
	@param1 int = 0,
	@param2 int
AS
	SELECT * FROM dbo.t_sol_AccionSolicitudDeConvenio;
RETURN 0
