using System;

namespace SchemaGenerator.SampleClasses
{
    [AttributeUsage(AttributeTargets.Property,
                AllowMultiple = true)]
    public class ViewModelDataListAttribute : Attribute
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public override object TypeId
        {
            get
            {
                return this;
            }
        }
    }
}