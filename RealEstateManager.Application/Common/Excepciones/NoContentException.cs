using System.Diagnostics.CodeAnalysis;

namespace RealEstateManager.Application.Common.Excepciones
{
    /// <summary>
    /// Excepción lanzada cuando no se encuentra un recurso.
    /// </summary>

    [ExcludeFromCodeCoverage]
    public class NoContentException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NoContentException"/> con un mensaje de error.
        /// </summary>
        /// <param name="message">Mensaje de error que describe la excepción.</param>
        public NoContentException(string message)
        : base(message)
        {
        }
        public NoContentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NoContentException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
