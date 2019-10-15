using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.Crosscutting.Exceptions
{
    public class ValidationResult
    {
        public ValidationResult()
        {
        }

        public ValidationResult(String message)
            : this()
        {
            ID = Guid.NewGuid();
            Message = message;
        }

        public Guid ID { get; set; }

        public String Message { get; set; }
    }
}
