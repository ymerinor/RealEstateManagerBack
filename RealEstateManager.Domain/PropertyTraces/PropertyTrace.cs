using RealEstateManager.Domain.Propertys;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateManager.Domain.PropertyTraces
{
    /// <summary>
    /// Clase que representa el historial de transacciones de una propiedad inmobiliaria.
    /// </summary>
    public class PropertyTrace
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro en el historial de transacciones.
        /// </summary>
        public int IdPropertyTrace { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la propiedad asociada mediante la clave externa.
        /// </summary>
        [ForeignKey(nameof(IdProperty))]
        public int IdProperty { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la transacción de venta de la propiedad.
        /// </summary>
        public DateTime DateSale { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre asociado a la transacción. Es obligatorio.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el valor de la transacción.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Obtiene o establece el monto de impuestos asociados a la transacción.
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación del registro en el historial.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la última modificación del registro en el historial.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Obtiene o establece la relación con la propiedad asociada al historial de transacciones.
        /// </summary>
        public virtual required Property Property { get; set; }
    }

}
