using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonHandlingExamples
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsElectric { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Creating a JSON object for a Student");
            CreateStudentJson();
            
            Console.WriteLine("\n2. Converting a C# object into JSON format");
            ConvertCarToJson();
            
            Console.WriteLine("\n3. Reading a JSON file and extracting specific fields");
            ExtractJsonFields();
            
            Console.WriteLine("\n4. Merging two JSON objects");
            MergeJsonObjects();
            
            Console.WriteLine("\n5. Validating JSON structure");
            ValidateJsonStructure();
            
            Console.WriteLine("\n6. Converting a list of C# objects into a JSON array");
            ConvertListToJsonArray();
            
            Console.WriteLine("\n7. Parsing JSON and filtering by age");
            FilterJsonByAge();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void CreateStudentJson()
        {
            var student = new 
            {
                name = "Priya Solanki",
                age = 20,
                subjects = new[] { "Math", "Physics", "Computer Science" }
            };

            string studentJson = JsonConvert.SerializeObject(student, Formatting.Indented);
            Console.WriteLine(studentJson);
        }

        static void ConvertCarToJson()
        {
            var myCar = new Car
            {
                Make = "Skoda",
                Model = "Kushaq",
                Year = 2023,
                IsElectric = false
            };

            string carJson = JsonConvert.SerializeObject(myCar, Formatting.Indented);
            Console.WriteLine(carJson);
        }

        static void ExtractJsonFields()
        {
            // For demo purposes, we'll create a temporary JSON file
            string tempFilePath = Path.GetTempFileName();
            string sampleJson = @"{
                ""name"": ""Ram Sharma"",
                ""email"": ""ram@gmail.com"",
                ""age"": 30,
                ""address"": {
                    ""street"": ""123 ranjedra Nagar"",
                    ""city"": ""Indore""
                }
            }";
            File.WriteAllText(tempFilePath, sampleJson);
            
            try
            {
                string jsonContent = File.ReadAllText(tempFilePath);
                JObject userData = JObject.Parse(jsonContent);

                var extractedData = new
                {
                    name = (string)userData["name"],
                    email = (string)userData["email"]
                };

                string extractedJson = JsonConvert.SerializeObject(extractedData, Formatting.Indented);
                Console.WriteLine(extractedJson);
            }
            finally
            {
                // Clean up
                File.Delete(tempFilePath);
            }
        }

        static void MergeJsonObjects()
        {
            JObject firstObject = JObject.Parse("{\"name\":\"Ram\",\"age\":30}");
            JObject secondObject = JObject.Parse("{\"city\":\"Pune\",\"job\":\"Developer\"}");

            firstObject.Merge(secondObject);
            string mergedJson = firstObject.ToString(Formatting.Indented);
            Console.WriteLine(mergedJson);
        }

        static void ValidateJsonStructure()
        {
            string schemaJson = @"{
              'type': 'object',
              'properties': {
                'name': {'type':'string'},
                'age': {'type':'integer'},
                'email': {'type':'string'}
              },
              'required': ['name','email']
            }";

            JSchema schema = JSchema.Parse(schemaJson);
            
            // Valid JSON
            JObject validPerson = JObject.Parse("{\"name\":\"Priya\",\"email\":\"priya@gmail.com\"}");
            bool isValid = validPerson.IsValid(schema);
            Console.WriteLine($"Valid JSON check: {isValid}");
            
            // Invalid JSON (missing required email)
            JObject invalidPerson = JObject.Parse("{\"name\":\"Priya\",\"age\":25}");
            bool isInvalid = invalidPerson.IsValid(schema);
            Console.WriteLine($"Invalid JSON check: {isInvalid}");
        }

        static void ConvertListToJsonArray()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Make = "Toyota", Model = "Fortuner", Year = 2023, IsElectric = false },
                new Car { Make = "Tesla", Model = "Model 3", Year = 2022, IsElectric = true },
                new Car { Make = "Honda", Model = "City", Year = 2021, IsElectric = false }
            };

            string carsArrayJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(carsArrayJson);
        }

        static void FilterJsonByAge()
        {
            string peopleJson = @"[
                {""name"":""John"", ""age"":23},
                {""name"":""Jane"", ""age"":27},
                {""name"":""Bob"", ""age"":31},
                {""name"":""Alice"", ""age"":24}
            ]";

            JArray peopleArray = JArray.Parse(peopleJson);
            var filteredPeople = peopleArray.Where(p => (int)p["age"] > 25).ToList();

            string filteredJson = JsonConvert.SerializeObject(filteredPeople, Formatting.Indented);
            Console.WriteLine(filteredJson);
        }
    }
}