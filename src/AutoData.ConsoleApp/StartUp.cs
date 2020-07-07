using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AutoData.ConsoleApp
{
    internal class StartUp
    {
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

        internal void Run()
        {
            Student student = new Student();

            foreach (PropertyInfo prop in student.GetType().GetProperties())
            {
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string))
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(student, $"{prop.Name} Test");
                    }
                    if (prop.PropertyType == typeof(int))
                    {
                        prop.SetValue(student, 0);
                    }
                    if (prop.PropertyType == typeof(bool))
                    {
                        prop.SetValue(student, true);
                    }
                    if (prop.PropertyType == typeof(char))
                    {
                        prop.SetValue(student, 'A');
                    }
                    if (prop.PropertyType == typeof(double))
                    {
                        prop.SetValue(student, 0.0);
                    }
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        prop.SetValue(student, DateTime.Now);
                    }
                    if (prop.PropertyType == typeof(DateTimeOffset))
                    {
                        prop.SetValue(student, DateTimeOffset.Now);
                    }
                }
                else
                {
                    if (prop.PropertyType.IsClass)
                    {
                        if (prop.GetValue(student) == null)
                        {
                            object instance = Activator.CreateInstance(prop.PropertyType);
                            prop.SetValue(student, instance);
                        }
                    }
                }
            }

            Console.Read();
        }
    }
}
