CREATE TABLE [dbo].[t_mon_Indicador]
(
	[ID_Indicador] BIGINT NOT NULL, 
    [Nombre] VARCHAR(150) NOT NULL, 
    [ID_ConfiguracionUnidadNegocio] BIGINT NOT NULL, 
    [ID_TipoIndicador] BIGINT NOT NULL, 
	CONSTRAINT [PK_t_mon_Indicador] PRIMARY KEY ([ID_Indicador]),
    CONSTRAINT [FK_t_mon_Indicador_t_mon_ConfiguracionUnidadNegocio] FOREIGN KEY ([ID_ConfiguracionUnidadNegocio]) REFERENCES [dbo].[t_mon_ConfiguracionUnidadNegocio]([ID_ConfiguracionUnidadNegocio]), 
    
)
