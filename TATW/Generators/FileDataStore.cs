using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TATW.Helpers;

namespace TATW.Generators
{
    public class FileDataStore : ICodeGenerator
    {
        public string ClassName { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileObjectType { get; set; }

        private string _TemplatePath = "./Templates/FileDataStore.liquid";
        public List<GeneratedFile> GenerateCode(CodeGenerationConfig outputConfig)
        {
            var generator = new LiquidTemplateGenerator(_TemplatePath);
            var relativeNamespace = NamespaceHelper.GetNamespaceFromPath(FilePath);
            var fileObjectNamespace = NamespaceHelper.GetNamespaceFromFullTypeName(FileObjectType);
            var fileObjectTypeName = NamespaceHelper.GetTypeFromFullTypeName(FileObjectType);
            var fileContents = generator.Render(new
            {
                Namespace = outputConfig.ProjectRootNamespace + "." + relativeNamespace,
                ClassName = ClassName,
                FileName = FileName,
                FileObjectType = fileObjectTypeName,
                FileObjectName = fileObjectTypeName,
                FileObjectNamespace = fileObjectNamespace,
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
