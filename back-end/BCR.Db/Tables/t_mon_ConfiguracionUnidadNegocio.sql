CREATE TABLE [dbo].[t_mon_ConfiguracionUnidadNegocio]
(
	[ID_ConfiguracionUnidadNegocio] BIGINT NOT NULL, 
    [Nombre] VARCHAR(150) NOT NULL, 
    [Activa] BIT NOT NULL, 
    [ID_UnidadNegocio] BIGINT NOT NULL, 
    CONSTRAINT [PK_t_mon_Configuracion] PRIMARY KEY ([ID_ConfiguracionUnidadNegocio]), 
    CONSTRAINT [FK_t_mon_ConfiguracionSector_t_mon_UnidadNegocio] FOREIGN KEY ([ID_UnidadNegocio]) REFERENCES [t_mon_UnidadNegocio]([ID_UnidadNegocio]) 
)
