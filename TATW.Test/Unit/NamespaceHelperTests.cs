using System;
using TATW.Helpers;
using Xunit;

namespace TATW.Test.Unit
{
    public class NamespaceHelperTests
    {
        [InlineData("Test", "")]
        [InlineData("Namespace.Test", "Namespace")]
        [InlineData("Namespace.Namespace.Test", "Namespace.Namespace")]
        [Theory]
        public void GetNamespaceFromFullTypeName_ReturnsNamespace(string className, string expectedNamespace)
        {
            var result = NamespaceHelper.GetNamespaceFromFullTypeName(className);

            Assert.Equal(expectedNamespace, result);
        }

        [InlineData("Test", "Test")]
        [InlineData("Namespace.Test", "Test")]
        [InlineData("Namespace.Namespace.Test", "Test")]
        [Theory]
        public void GetTypeFromFullTypeName_ReturnsNamespace(string className, string expectedNamespace)
        {
            var result = NamespaceHelper.GetTypeFromFullTypeName(className);

            Assert.Equal(expectedNamespace, result);
        }
    }
}
