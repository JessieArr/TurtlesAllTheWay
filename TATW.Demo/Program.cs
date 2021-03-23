using System;
using System.Collections.Generic;
using TATW.Generators;

namespace TATW.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing to generate!");
            var engine = new CodeGeneratorEngine();
            engine.Config = new CodeGenerationConfig()
            {
                ProjectRootNamespace = "TATW.Target",
                CSharpRootPath = "../../../../TATW.Target"
            };
            engine.Add(new Model()
            {
                ClassName = "Teacher",
                FilePath = "Models",
                PropertiesWithTypes = new Dictionary<string, string>()
                {
                    { "Name", "string" },
                    { "Age", "int" },
                    { "ClassSize", "int" },
                    { "Address", "string" },
                }
            });
            engine.Add(new Model()
            {
                ClassName = "Student",
                FilePath = "Models",
                PropertiesWithTypes = new Dictionary<string, string>()
                {
                    { "Name", "string" },
                    { "Age", "int" },
                    { "Address", "string" },
                }
            });
            engine.Add(new FileDataStore()
            {
                ClassName = "StudentFileStore",
                FilePath = "Data",
                FileName = "students.json",
                FileObjectType = "TATW.Target.Models.Student",
            });
            engine.WriteAllFiles();
        }
    }
}
