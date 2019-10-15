using BCR.Business.Domain.Base;
using BCR.Business.Queries;
using BCR.DataAccess.Base;
using StructureMap;

namespace BCR.Service.Infrastructure
{
    public class ContainerRegistry : Registry
    {
        public ContainerRegistry()            
        {
            this.AutoregistrarTiposPorConvencion();
            this.RegistrarTiposFueraConvencion();
        }

        private void AutoregistrarTiposPorConvencion()
        {
            this.Scan(scanner =>
            {
                // Escanear para auto-registración todos los assemblies propios de la solución.
                scanner.AssembliesFromApplicationBaseDirectory(assembly => assembly.FullName.StartsWith("BCR."));

                // Conectar todas las implementaciones de ICommandHandler<> (no sigue la convención ILoQueSea -> LoQueSea).
                scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));

                // Conectar todas las implementaciones de IQueryHandler<,> (no sigue la convención ILoQueSea -> LoQueSea).
                scanner.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));

                // Excluimos la auto-registración de los tipos que manualmente registraremos (fuera de convención).
                //scanner.Exclude(type =>
                //    type.IsAssignableFrom(typeof(Repository<>))
                //    ||
                //    type.IsAssignableFrom(typeof(WcfClientManager<>))
                //    ||
                //    type.IsAssignableFrom(typeof(SessionScopeCommandHandlerDecorator<>))
                //    );

                // Convención por defecto: ILoQueSea -> LoQueSea.
                scanner.WithDefaultConventions();
            });
        }

        private void RegistrarDecoradores()
        {
            // Decoramos todas las instancias de ICommandHandler<> con el SessionScope correspondiente.
            this.For(typeof(ICommandHandler<>)).DecorateAllWith(typeof(SessionScopeCommandHandlerDecorator<>));
        }

        private void RegistrarTiposFueraConvencion()
        {
            this.RegistrarDecoradores();

            // Registramos el repositorio genérico.
            this.For(typeof(IRepository<>)).Use(typeof(Repository<>));
        }

    }
}
