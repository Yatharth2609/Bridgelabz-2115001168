using System;
using System.Collections.Generic;

namespace FrequencyCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fruits = new List<string> { "apple", "banana", "apple", "orange" };
            Dictionary<string, int> frequency = CountFrequency(fruits);
            
            Console.WriteLine("Element frequencies:");
            foreach (var item in frequency)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        
        static Dictionary<string, int> CountFrequency(List<string> list)
        {
            Dictionary<string, int> frequencyMap = new Dictionary<string, int>();
            
            foreach (string item in list)
            {
                if (frequencyMap.ContainsKey(item))
                {
                    frequencyMap[item]++;
                }
                else
                {
                    frequencyMap[item] = 1;
                }
            }
            
            return frequencyMap;
        }
    }
}