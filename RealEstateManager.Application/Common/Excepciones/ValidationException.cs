using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateManager.Application.Common.Excepciones
{
    [ExcludeFromCodeCoverage]
    public class ValidationException : Exception
    {
        [ExcludeFromCodeCoverage]
        public ValidationException()
            : base("Existe uno a o mas validaciones fallidas")
        {
            Errors = new Dictionary<string, string[]>();
        }

        [ExcludeFromCodeCoverage]
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
        [ExcludeFromCodeCoverage]
        public IDictionary<string, string[]> Errors { get; }
    }
}
