namespace RealEstateManager.Application.Propertys.Dto
{
    /// <summary>
    /// Clase que representa los filtros de consulta para la entidad Property.
    /// </summary>
    public class FiltersQuery
    {
        /// <summary>
        /// Obtiene o establece el identificador de la propiedad.
        /// </summary>
        public int? IdProperty { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del propietario.
        /// </summary>
        public int? IdOwner { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tipo de propiedad.
        /// </summary>
        public int? IdPropertyType { get; set; }

        /// <summary>
        /// Obtiene o establece el código interno de la propiedad.
        /// </summary>
        public string? CodeInternal { get; set; }
    }

}
