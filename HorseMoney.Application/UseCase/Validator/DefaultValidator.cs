
using FluentValidation.Results;
using HorseMoney.Domain.Common;

namespace HorseMoney.Application.UseCase.Validator
{
    public static partial class DefaultValidator
    {
        public static void ValidateDto(ValidationResult validations)
        {
            if (!validations.IsValid)
            {
                ReturnError(validations);
            }
        }

        private static BasicResult ReturnError (ValidationResult validations)
        {
            return BasicResult.Failure(System.Net.HttpStatusCode.BadRequest, validations.Errors);
        }
    }
}
