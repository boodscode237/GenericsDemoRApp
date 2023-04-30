using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemoR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();

            string test = "";
            test = "joe";
            intList.Add(1);
            stringList.Add(test);
            foreach (string str in stringList)
            {
                Console.WriteLine(str);
            }

            string result = FizzBuzz("test");
            Console.WriteLine($"Test = {result}");
            
            Console.WriteLine($"Test = {FizzBuzz("max")}");
            Console.WriteLine($"Test = {FizzBuzz("maxmaxmaxmaxmax")}");

            result = FizzBuzz(new PersonModel { FirstName = "a", LastName = "" });
            Console.WriteLine($"Person Model {result}");

            GenericHelper<PersonModel> peopleHelper = new GenericHelper<PersonModel>();
            
            peopleHelper.CheckItemAndAdd(new PersonModel { FirstName = "a", HasError = true });
            foreach (var item in peopleHelper.RejectedItems)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} was rejected");
            }

            Console.ReadLine();
        }


        private static string FizzBuzz<T>(T item)
        {
            int itemLength = item.ToString().Length;
            string output = "";
            if (itemLength % 3 == 0)
            {
                output += "FIzz";
            }

            if(itemLength % 5 == 0)
            {
                output += "Buzz";
            }
            return output;
        }

        public class PersonModel : IErrorCheck
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool HasError { get; set; }

        }

        public class GenericHelper<T> where T: IErrorCheck
        {
            public List<T> Items { get; set; } = new List<T>();
            public List<T> RejectedItems { get; set; } = new List<T>();
            public void CheckItemAndAdd(T item)
            {
                if (item.HasError == false)
                {
                    Items.Add(item);
                }
                else
                {
                    RejectedItems.Add(item);
                }
            }
        }

        public class CarModel : IErrorCheck
        {
            public string Manufacturer { get; set; }
            public int YearManufactured { get; set; }
            public bool HasError { get; set; }
        }

        public interface IErrorCheck
        {
            bool HasError { get; set; }
        }

    }


}
