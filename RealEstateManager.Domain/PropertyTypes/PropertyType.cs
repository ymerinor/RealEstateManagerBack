namespace RealEstateManager.Domain.PropertyTypes
{

    /// <summary>
    /// Clase que representa un tipo de propiedad.
    /// </summary>
    public class PropertyType
    {
        /// <summary>
        /// Obtiene o establece el identificador del tipo de propiedad.
        /// </summary>
        public int IdPropertyType { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tipo de propiedad. No Puede ser nulo.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece un valor que indica si el tipo de propiedad está habilitado.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación del tipo de propiedad.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la última modificación del tipo de propiedad.
        /// </summary>
        public DateTime LastModified { get; set; }
    }

}
