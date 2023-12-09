using FluentValidation.Results;

namespace RealEstateManager.Application.Common.Excepciones
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Existe uno a o mas validaciones fallidas")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
