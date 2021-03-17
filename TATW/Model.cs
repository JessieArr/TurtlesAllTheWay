using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using TATW.Helpers;

namespace TATW
{
    public class Model : ICodeGenerator
    {
        public string ClassName { get; set; }
        public string FilePath { get; set; }
        public Dictionary<string, string> PropertiesWithTypes { get; set; } = new Dictionary<string, string>();

        private string _TemplatePath = "./Templates/Model.liquid";
        public List<GeneratedFile> GenerateCode(CodeGenerationConfig outputConfig)
        {
            var generator = new LiquidTemplateGenerator(_TemplatePath);
            var relativeNamespace = NamespaceHelper.GetNamespaceFromPath(FilePath);
            var fileContents = generator.Render(new {
                Namespace = outputConfig.ProjectRootNamespace + "." + relativeNamespace,
                ClassName = ClassName,
                Properties = PropertiesWithTypes
            });
            var filePath = Path.Combine(outputConfig.CSharpRootPath, FilePath);
            return new List<GeneratedFile>()
            {
                new GeneratedFile()
                {
                    Path = $"{filePath}/{ClassName}.cs",
                    Contents = fileContents
                }
            };
        }
    }
}
