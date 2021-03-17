using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TATW
{
    public class CodeGeneratorEngine
    {
        private List<ICodeGenerator> _Generators = new List<ICodeGenerator>();
        public void Add(ICodeGenerator generator)
        {
            _Generators.Add(generator);
        }

        public CodeGenerationConfig Config { get; set; }

        public void WriteAllFiles()
        {
            foreach(var generator in _Generators)
            {
                var files = generator.GenerateCode(Config);
                foreach(var file in files)
                {
                    var info = new FileInfo(file.Path);
                    info.Directory.Create();
                    File.WriteAllText(file.Path, file.Contents);
                }
            }
        }
    }
}
