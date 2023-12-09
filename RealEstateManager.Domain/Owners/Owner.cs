namespace RealEstateManager.Domain.Owners
{
    /// <summary>
    /// Clase que representa a un propietario.
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Obtiene o establece el identificador del propietario.
        /// </summary>
        public int IdOwner { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del propietario. Es obligatorio y puede ser nulo.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece la dirección del propietario. Es obligatoria y puede ser nula.
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece la ciudad del propietario.
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece el país del propietario.
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece el número de teléfono del propietario. Es obligatorio y puede ser nulo.
        /// </summary>
        public string Phone { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del propietario.
        /// </summary>
        public DateTime? Birthday { get; set; }
    }

}
