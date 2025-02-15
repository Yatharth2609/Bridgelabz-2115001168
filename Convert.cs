using System;
using System.IO;

class Convert
{
    static void Main()
    {
        string filePath = "binaryfile.bin";
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fs))
        {
            int character;
            while ((character = reader.Read()) != -1)
            {
                Console.Write((char)character);
            }
        }
    }
}