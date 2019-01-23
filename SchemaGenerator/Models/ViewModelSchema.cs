using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaGenerator.Models
{
    public class ViewModelSchema
    {
        public ViewModelSchema()
        {
            this.Validations = new List<ViewModelValidation>();
            this.DataList = new List<ViewModelDataList>();
        }

        public string Type { get; set; }

        public string Label { get; set; }

        public bool IsKey { get; set; }

        public string InputType { get; set; }

        public string Name { get; set; }

        public string DisplayFieldName { get; set; }

        public List<ViewModelValidation> Validations { get; set; }
        public List<ViewModelDataList> DataList { get; set; }

        public ViewModelSchema DefineDataList(List<ViewModelDataList> listViewModelDataList)
        {
            this.DataList = listViewModelDataList;
            return this;
        }

        public ViewModelSchema AddValidator(ViewModelValidation validator)
        {
            this.Validations.Add(validator);
            return this;
        }

        public static ViewModelSchema NewViewModelSchema(string controlType, string label, string inputType, string name, bool isKey = false, string displayFieldName = "")
        {
            return new ViewModelSchema
            {
                Type = controlType, // element
                Label = label, // Name ng Form element
                IsKey = isKey, // Kung Id or not
                InputType = inputType, // element type
                Name = name, // field name sa database
                DisplayFieldName = displayFieldName // Place Holder
            };
        }
    }
}
