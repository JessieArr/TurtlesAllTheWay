using System.Collections.Generic;

namespace TATW
{
    public interface ICodeGenerator
    {
        public List<GeneratedFile> GenerateCode(CodeGenerationConfig outputConfig);
    }
}