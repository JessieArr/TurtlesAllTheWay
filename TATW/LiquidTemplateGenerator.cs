using DotLiquid;
using DotLiquid.NamingConventions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TATW
{
    public class LiquidTemplateGenerator
    {
        public string TemplatePath { get; set; }

        public LiquidTemplateGenerator(string templatePath)
        {
            TemplatePath = templatePath;            
        }

        public string Render(object model)
        {
            var contents = File.ReadAllText(TemplatePath);
            var template = Template.Parse(contents);
            return template.Render(Hash.FromAnonymousObject(model));
        }
    }
}
