using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaGenerator.Models
{
    public class ViewModelValidation
    {
        public string Name { get; set; }
        public string Validator { get; set; }

        public string Message { get; set; }

        internal static ViewModelValidation NewRequiredValidation(string fieldName)
        {
            return new ViewModelValidation
            {
                Name = "required",
                Validator = "Validator.required",
                Message = fieldName + " is required."
            };
        }
    }
}
