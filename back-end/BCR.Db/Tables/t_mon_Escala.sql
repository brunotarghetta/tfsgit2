CREATE TABLE [dbo].[t_mon_Escala]
(
	[ID_Escala] BIGINT NOT NULL, 
    [Desde] BIGINT NULL, 
    [Hasta] BIGINT NULL, 
    [ID_Semaforo] BIGINT NOT NULL, 
    [Orden] INT NOT NULL, 
    [ID_Indicador] BIGINT NOT NULL, 
    CONSTRAINT [PK_t_mon_Escala] PRIMARY KEY ([ID_Escala]), 
    CONSTRAINT [FK_t_mon_Escala_t_mon_Semaforo] FOREIGN KEY ([ID_Semaforo]) REFERENCES [t_mon_Semaforo]([ID_Semaforo]), 
    CONSTRAINT [FK_t_mon_Escala_t_mon_Indicador] FOREIGN KEY ([ID_Indicador]) REFERENCES [t_mon_Indicador]([ID_Indicador]) 
)
