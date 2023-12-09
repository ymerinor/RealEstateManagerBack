namespace RealEstateManager.Application.Common.Excepciones
{
    /// <summary>
    /// Excepción lanzada cuando no se encuentra un recurso.
    /// </summary>
    internal class NoFoundException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NoFoundException"/> con un mensaje de error.
        /// </summary>
        /// <param name="message">Mensaje de error que describe la excepción.</param>
        public NoFoundException(string message)
        : base(message)
        {
        }
        public NoFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NoFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
