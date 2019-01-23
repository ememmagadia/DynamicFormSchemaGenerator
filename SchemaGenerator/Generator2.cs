using SchemaGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SchemaGenerator
{
    public class Generator2<T> where T : class
    {
        public Object GenerateSchema(Type baseClass, string tableName, List<T> dataList)
        {
            var result = new
            {
                TableName = tableName,
                Fields = new List<ViewModelSchema>()
            };

            foreach (PropertyInfo pi in baseClass.GetProperties())
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

                if (pi.PropertyType == typeof(int))
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

                    result.Fields.Add(ViewModelSchema.NewViewModelSchema("input", displayName, "number", Char.ToLowerInvariant(pi.Name[0]) + pi.Name.Substring(1), true)
                                   .AddValidator(ViewModelValidation.NewRequiredValidation(displayName)));
                }


                if (pi.PropertyType.IsGenericType)
                {
                    object[] attrs = pi.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        PropertyInfo x = attr.GetType().GetProperty("Identifier");

                        var identifier = (String)(x.GetValue(attr, null));

                        foreach (var item in dataList)
                        {
                            PropertyInfo itemInfo = item.GetType().GetProperty("Key");
                            var keyIdentifier = (String)(itemInfo.GetValue(item, null));

                            PropertyInfo itemList = item.GetType().GetProperty("Value");
                            var itemListObject = (List<ViewModelDataList>)(itemList.GetValue(item, null));


                            if (keyIdentifier.ToUpper().Equals(identifier.ToUpper()))
                            {
                                result.Fields.Add(ViewModelSchema.NewViewModelSchema("select", "DataList", "select", "listId", displayFieldName: "ListName")
                                              .AddValidator(ViewModelValidation.NewRequiredValidation("Department ID"))
                                              .DefineDataList(itemListObject));
                            }
                        }

                    }
                }
            }

            return result;
        }
    }
}
