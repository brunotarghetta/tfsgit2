using BCR.Crosscutting.Shared;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BCR.Crosscutting.Exceptions
{
    public class ValidationException : ExceptionBase
    {
        #region Constants

        private const string SIMBOLO_ITEM_VALIDACIONES = "- ";

        #endregion

        #region Constructors

        public ValidationException() : base() { }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, string code)
            : base(message, code)
        {
        }

        public ValidationException(ValidationResults validationResults)
           : this(GenerateExceptionMessage(validationResults))
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Properties

        protected List<ValidationResult> ValidationResults { get; private set; } = new List<ValidationResult>();

        public override int Type
        {
            get { return ExceptionTypes.ValidationException; }
        }

        #endregion

        #region Methods

        public void AddValidationResult(ValidationResult valResult)
        {
            ValidationResults.Add(valResult);
        }

        public void AddValidationResult(String message)
        {
            ValidationResults.Add(new ValidationResult
            {
                ID = Guid.NewGuid(),
                Message = message
            });
        }

        public void Throw()
        {
            if (this.ValidationResults.Any())
            {
                throw new ValidationException(this.GenerateExceptionMessage());
            }
        }

        public void Throw<TException>()
            where TException : ExceptionBase
        {
            if (this.ValidationResults.Any())
            {
                var excepction = (TException)Activator.CreateInstance(typeof(TException), this.GenerateExceptionMessage());

                throw excepction;
            }
        }

        private string GenerateExceptionMessage()
        {
            string exceptionMessage = String.Empty;

            if (this.ValidationResults.Any())
            {
                var sb = new StringBuilder();

                foreach (var vr in this.ValidationResults)
                {
                    sb.Append(SIMBOLO_ITEM_VALIDACIONES);
                    sb.Append(vr.Message);
                    sb.Append(Environment.NewLine);
                }

                exceptionMessage = sb.ToString();
            }

            return exceptionMessage;
        }

        private static string GenerateExceptionMessage(ValidationResults validationResults)
        {
            string exceptionMessage = String.Empty;

            if (validationResults != null)
            {
                var sb = new StringBuilder();

                foreach (Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResult vr in validationResults)
                {
                    sb.Append(vr.Message);
                    sb.Append(Environment.NewLine);
                }

                exceptionMessage = sb.ToString();
            }

            return exceptionMessage;
        }

        [System.Security.SecurityCritical]  // auto-generated_required
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

        }

        #endregion
    }
}