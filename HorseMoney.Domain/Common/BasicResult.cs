using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace HorseMoney.Domain.Common
{
    public class BasicResult
    {
        #region Properties

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        #endregion Properties

        #region Constructors

        protected BasicResult(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        #endregion Constructors

        #region Success

        public static BasicResult Success() => new(true, Error.None);

        public static BasicResult<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

        #endregion Sucess

        #region Failure

        public static BasicResult Failure(Error error) => new(false, error);

        public static BasicResult Failure(HttpStatusCode statusCode, List<ValidationFailure> errors) =>
            new(false, ReturnErrorMessage(statusCode, errors));

        public static BasicResult<TValue> Failure<TValue>(Error error) => new(default, false, error);

        public static BasicResult<TValue> Failure<TValue>(HttpStatusCode statusCode, List<ValidationFailure> errors) =>
            new(default, false, ReturnErrorMessage(statusCode, errors));

        #endregion Failure

        protected static BasicResult<TValue> Create<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(Error.None);

        private static Error ReturnErrorMessage(HttpStatusCode statusCode, List<ValidationFailure> errors)
        {
            var errorMessage = string.Join(Environment.NewLine,
                errors.SelectMany(e => e.ErrorMessage!.Split('\n'))
                    .Select(s => s.Trim()));

            return new Error(statusCode, errorMessage);
        }
    }
}