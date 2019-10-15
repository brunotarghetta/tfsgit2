using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BCR.Business.Domain.Base
{
    /// <summary>
    /// Provee una clase base estándar para facilitar la comparación de objetos.
    /// 
    /// Para una discusión de la implementación de Equals/GetHashCode, ver
    /// http://devlicio.us/blogs/billy_mccafferty/archive/2007/04/25/using-equals-gethashcode-effectively.aspx
    /// y http://groups.google.com/group/sharp-architecture/browse_thread/thread/f76d1678e68e3ece?hl=en para
    /// una profunda y definitiva resolución.
    /// </summary>
    public abstract class ComparableObject
    {
        /// <summary>
        /// Para ayudar a asegurar la unicidad del hashcode, en el cáluclo se usa un número aleatorio multiplicador
        /// cuidadosamente seleccionado. El libro "Data Structures and Algorithms in Java" de Goodrich y Tamassia
        /// afirma que 31, 33, 37, 39 y 41 producirán el menor número de colisiones.
        /// Ver http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/ para más
        /// información.
        /// </summary>
        private const Int32 HashMultiplier = 31;

        /// <summary>
        /// Este miembro estático cachea las propiedades que conforman la firma de dominio, para evitar
        /// buscarlas por cada instancia de la misma clase.
        /// </summary>
        [ThreadStatic]
        private static Dictionary<Type, IEnumerable<PropertyInfo>> signaturePropertiesDictionary;

        protected ComparableObject()
        {
        }

        public override Boolean Equals(Object obj)
        {
            ComparableObject compareTo = obj as ComparableObject;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            return compareTo != null && this.GetType().Equals(compareTo.GetTypeUnproxied()) &&
                this.HasSameObjectSignatureAs(compareTo);
        }

        /// <summary>
        /// Este método es utilizado para suministrar el identificador hashcode de un objeto utilizando las
        /// propiedades que conforman la firma del mismo. Ya que es recomendable que GetHashCode cambie
        /// con poca frecuencia, si es que cambia, en la vida de un objeto, es importante que las propiedades
        /// que realmente representan la firma de un objeto sean cuidadosamente seleccionadas.
        /// </summary>
        public override Int32 GetHashCode()
        {
            unchecked
            {
                IEnumerable<PropertyInfo> signatureProperties = this.GetSignatureProperties();

                // Es posible que dos objetos, incluso siendo instancias de distintas clases, devuelvan el mismo hashcode
                // basado en propiedades que contengan valores idénticos, así que se incluye el tipo del objeto en el
                // cálculo del hash.
                Int32 hashCode = this.GetType().GetHashCode();

                hashCode = signatureProperties.Select(property => property.GetValue(this))
                                              .Where(value => value != null)
                                              .Aggregate(hashCode, (current, value) => (current * HashMultiplier) ^ value.GetHashCode());

                if (signatureProperties.Any())
                {
                    return hashCode;
                }

                // Si no hay propiedades que hayan sido marcadas para ser parte de la firma del objeto, entonces
                // simplemente se devuelve el hashcode del objeto base.
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// Se puede hacer un override de este método para proporcionar una rutina de comparación propia.
        /// </summary>
        protected virtual Boolean HasSameObjectSignatureAs(ComparableObject compareTo)
        {
            IEnumerable<PropertyInfo> signatureProperties = this.GetSignatureProperties();

            // Se comparan los valores de las propiedades que conforman la firma del objeto entre esta instancia y compareTo,
            // si alguno de los valores no coincide se devuelve false.
            if ((from property in signatureProperties
                 let valueOfThisObject = property.GetValue(this)
                 let valueToCompareTo = property.GetValue(compareTo)
                 where valueOfThisObject != null || valueToCompareTo != null
                 where (valueOfThisObject == null ^ valueToCompareTo == null) || (!valueOfThisObject.Equals(valueToCompareTo))
                 select valueOfThisObject).Any())
            {
                return false;
            }

            // Si se llegó a este punto y se encontraron propiedades que conforman la firma, entonces podemos
            // asumir que todo ha emparejado (es igual); en el caso contrario, si no se encontraron propiedades
            // que conformen la firma del objeto, simplemente se utiliza el comportamiento por defecto de Equals.
            return signatureProperties.Any() || base.Equals(compareTo);
        }

        protected virtual IEnumerable<PropertyInfo> GetSignatureProperties()
        {
            IEnumerable<PropertyInfo> properties;

            // Se inicializa aquí signaturePropertiesDictionary por las razones descritas en
            // http://blogs.msdn.com/jfoscoding/archive/2006/07/18/670497.aspx
            if (signaturePropertiesDictionary == null)
            {
                signaturePropertiesDictionary = new Dictionary<Type, IEnumerable<PropertyInfo>>();
            }

            if (signaturePropertiesDictionary.TryGetValue(this.GetType(), out properties))
            {
                return properties;
            }

            return signaturePropertiesDictionary[this.GetType()] = this.GetTypeSpecificSignatureProperties();
        }

        /// <summary>
        /// Hace cumplir el patrón template method para que los objetos hijos determinen cuales propiedades
        /// específicas y cuales no deben ser incluidas en la comparación de firma del objeto. Notar que
        /// ComparableObject ya tiene en cuenta el caching por la performance.
        /// </summary>
        protected abstract IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties();

        /// <summary>
        /// Cuando NHibernate genera proxies de los objetos, enmascara el tipo real del objeto. Este wrapper
        /// se apropia del objeto "proxieado" para obtener su tipo real.
        /// 
        /// Aunque esto supone que se está utilizando NHibernate, no requiere dependencias relacionadas y
        /// no tiene efectos secundarios negativos si NHibernate no se está utilizando.
        /// </summary>
        protected virtual Type GetTypeUnproxied()
        {
            return this.GetType();
        }
    }
}
