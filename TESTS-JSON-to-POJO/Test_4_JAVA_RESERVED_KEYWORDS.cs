
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Xamasoft.JsonClassGenerator;
using Xamasoft.JsonClassGenerator.CodeWriters;

using TESTS_JSON_TO_CSHARP;

namespace TESTS_JSON_to_POJO
{
    [TestClass]
    public class Test_4_JAVA_RESERVED_KEYWORDS
    {
        [TestMethod]
        public void Run()
        {
            string path       = Directory.GetCurrentDirectory().Replace("bin\\Debug", "") + @"Test_4_JAVA_RESERVED_KEYWORDS_INPUT.txt";
            string resultPath = Directory.GetCurrentDirectory().Replace("bin\\Debug", "") + @"Test_4_JAVA_RESERVED_KEYWORDS_OUTPUT.txt";
            string input      = File.ReadAllText(path);

            JavaCodeWriter javaCodeWriter = new JavaCodeWriter();
            JsonClassGenerator jsonClassGenerator = new JsonClassGenerator();
            jsonClassGenerator.CodeWriter = javaCodeWriter;
            jsonClassGenerator.MutableClasses.Members = OutputMembers.AsPublicFields;

            string returnVal = jsonClassGenerator.GenerateClasses(input, out string errorMessage).ToString();
            string resultsCompare = File.ReadAllText(resultPath);

            Assert.AreEqual(expected: resultsCompare.NormalizeOutput(), actual: returnVal.NormalizeOutput());
            Assert.AreEqual(expected: String.Empty, actual: errorMessage);
        }
    }
}
