using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LinqToXMLProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+++++++++++++++++++++");

            var fileName = "Data.xml";
            var projectPath = @"C:\\Users\\Sabine\\VS\\Linq\\LinqToXMLProject";

            Directory.SetCurrentDirectory(projectPath);

            //give program location of the file
            Console.WriteLine($"Current directory: {Directory.GetCurrentDirectory()}"); // ( ) introduces static function

            //specifying where we need to take this data
            var xmlDataPath = Path.Combine(Directory.GetCurrentDirectory(), fileName); //first argument is our directory above and second - filename name

            XElement xmlData = XElement.Load(xmlDataPath);

            Console.WriteLine(xmlData); //now it will print out data from Data.xml file 

            Console.WriteLine("+++++++++++++++++++++++");

            IEnumerable<XElement> orderAddress = from element in xmlData.Descendants("Address") //<> data type, same as object
                                                 select element; 

            ShowListValues(orderAddress);


            Console.WriteLine("+++++++++++++++++++++++");

            //lets specify the atribute along with the element
            IEnumerable<string> addressType = from element in xmlData.Descendants("Address") 
                                                 select (string) element.Attribute("Type"); //we need to cast the element to string as well

            foreach (string elementData in addressType)
            {
                Console.WriteLine($"{elementData}"); //---prints shipping and billing
            };
        }

        static void ShowListValues(IEnumerable<XElement> list) //static method
        {
            foreach (string elementData in list)
            {
                Console.WriteLine($"{elementData}");
            };
        }
    }
}