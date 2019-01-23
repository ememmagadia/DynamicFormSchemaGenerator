using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaGenerator.Models
{
    public class KeyValuePairCustom<T> where T : class
    {
        public string Key { get; set; }
        public List<T> Value { get; set; }
    }
}
