using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using TATW.Target.Models;

namespace TATW.Target.Data
{
    [GeneratedCode("TATW", "0.0.1")]
    public class StudentFileStore
    {
        private static string _fileName = "students.json";
        public static Student Student;

        public Student LoadFileData()
        {
            if(Student == null)
            {
                if(!File.Exists(_fileName))
                {
                    Student = new Student();
                }
                else
                {
                    var fileContents = File.ReadAllText(_fileName);
                    Student = JsonConvert.DeserializeObject<Student>(fileContents);
                }
            }            
            return Student;
        }

        public void SaveFileData(Student objectToSave)
        {
            var fileText = JsonConvert.SerializeObject(objectToSave);
            File.WriteAllText(_fileName, fileText);
        }
    }
}
