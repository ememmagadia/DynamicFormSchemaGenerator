using SchemaGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchemaGenerator.SampleClasses
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        [List1(Identifier="List1")]
        public List<Person> List1 { get; set; }
        [List1(Identifier = "List2")]
        public List<Object> List2 { get; set; }

        //public enum darwin
        //{
        //    [DisplayName("Techincal Label")]
        //    technical,
        //    nontechnical,
        //}

    }
}
