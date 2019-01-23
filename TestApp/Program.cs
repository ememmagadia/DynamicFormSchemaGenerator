using SchemaGenerator;
using SchemaGenerator.Models;
using SchemaGenerator.SampleClasses;
using System;
using System.Collections.Generic;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var dataList = new List<KeyValuePairCustom<ViewModelDataList>>()
            {
                new KeyValuePairCustom<ViewModelDataList>() {Key = "LIST1", Value = new List<ViewModelDataList>(){
                    new ViewModelDataList { Key="Technical key1", Value= "Technical1" },
                    new ViewModelDataList { Key="Non Technical key2", Value= "Non Technical2" }
                } },
                new KeyValuePairCustom<ViewModelDataList>() {Key = "LIST2", Value = new List<ViewModelDataList>(){
                    new ViewModelDataList { Key="124", Value="asd4"},
                    new ViewModelDataList { Key="1244", Value="asd44"}
                } },
            };

            var generator = new Generator2<KeyValuePairCustom<ViewModelDataList>>();
            var result = generator.GenerateSchema(typeof(Person), "sample", dataList);

            Console.ReadLine();
        }
    }
}
