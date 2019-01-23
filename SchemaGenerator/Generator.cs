using SchemaGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace SchemaGenerator
{
    public class Generator
    {
        public Object GetSchema(object test, string tableName)
        {
            var result = new
            {
                TableName = tableName,
                Fields = new List<ViewModelSchema>()
            };

            foreach (PropertyInfo pi in test.GetType().GetProperties())
            {
                string displayName = string.Empty;
                if (pi.PropertyType == typeof(string))
                {
                    object[] attrs = pi.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        DisplayNameAttribute authAttr = attr as DisplayNameAttribute;
                        if (authAttr != null)
                        {
                            displayName = authAttr.DisplayName;
                        }
                    }

                    result.Fields.Add(ViewModelSchema.NewViewModelSchema("input", displayName, "text", Char.ToLowerInvariant(pi.Name[0]) + pi.Name.Substring(1), true)
                                   .AddValidator(ViewModelValidation.NewRequiredValidation(displayName)));
                }

                if (pi.PropertyType.IsEnum)
                {
                    object[] attrs = pi.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        DisplayNameAttribute authAttr = attr as DisplayNameAttribute;
                        if (authAttr != null)
                        {
                            displayName = authAttr.DisplayName;
                        }
                    }

                    result.Fields.Add(ViewModelSchema.NewViewModelSchema("select", displayName, "text", Char.ToLowerInvariant(pi.Name[0]) + pi.Name.Substring(1), true)
                                   .AddValidator(ViewModelValidation.NewRequiredValidation(displayName)));
                }


            }
            return result;
        }
    }
}
