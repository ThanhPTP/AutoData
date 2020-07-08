using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace AutoData.ConsoleApp
{
    internal class StartUp
    {
        #region DTO    

        public class Address
        {
            public string District { get; set; }
            public string Ward { get; set; }
            public string City { get; set; }
            public string HouseNumber { get; set; }
            public bool IsAllow { get; set; }
        }

        public class Student
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public double Point { get; set; }
            public DateTime BirthDay { get; set; }
            public DateTimeOffset BirthDayOffset { get; set; }
            public bool IsMale { get; set; }
            public Address Address { get; set; }
        }

        #endregion

        private readonly IAutoData _autoData;
        public StartUp(IAutoData autoData)
        {
            _autoData = autoData;
        }

        internal void Run()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var data = _autoData.Create<Student>(10000);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);

            Console.Read();
        }
    }
}
