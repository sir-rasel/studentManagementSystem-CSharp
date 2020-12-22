using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace StudentManagementSystem
{
    class FileManager : IFileManager
    {
        public dynamic readFiles(string fileName, string type)
        {
            string filePath = @"..\..\..\..\files\" + fileName;
            List<string> lines;
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
            }
            catch
            {
                Console.WriteLine("File doesn't exist, try with right file path");
                return false;
            }

            List<dynamic> objectList = new List<dynamic>();

            foreach(var line in lines)
            {
                if(type == "student")
                {
                    Student obj = JsonConvert.DeserializeObject<Student>(line);
                    objectList.Add(obj);
                }
                else if(type == "semester")
                {
                    Semester obj = JsonConvert.DeserializeObject<Semester>(line);
                    objectList.Add(obj);
                }
                else
                {
                    Course obj = JsonConvert.DeserializeObject<Course>(line);
                    objectList.Add(obj);
                }
            }
            
            return objectList;
        }

        public void writeFiles(string fileName, List<dynamic> lines)
        {
            string filePath = @"..\..\..\..\files\" + fileName;

            List<string> objectList = new List<string>();
            foreach (var line in lines)
            {
                string obj = JsonConvert.SerializeObject(line);
                objectList.Add(obj);
            }

            using StreamWriter file = new StreamWriter(filePath);
            foreach (string list in objectList)
            {
                file.WriteLine(list);
            }
        }
    }
}
