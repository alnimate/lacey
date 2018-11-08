﻿namespace Lacey.Medusa.Common.Validation.Validation
{
    public sealed class ValidationError
    {
        public ValidationError(
            string fieldName, 
            string errorMessage)
        {
            FieldName = fieldName;
            ErrorMessage = errorMessage;
        }

        public string FieldName { get; }
        
        public string ErrorMessage { get; }
    }
}