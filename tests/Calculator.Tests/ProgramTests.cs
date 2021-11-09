using CalculatorProgram;
using System;
using System.IO;
using Xunit;
using System.Text.RegularExpressions;

namespace Calculator.Tests
{
    public class ProgramTests
    {
        // Correctness of calculator operations is tested in corresponding class
        // so testing it here again would be redundant.
        // This class only tests program workflow for correctness.

        [Fact]
        public void ShouldProvideResult()
        {
            var strWriter = new StringWriter();            
            Console.SetOut(strWriter);

            var input = new string[]
            {
                "2",
                "2",
                "a",
                "n"
            };

            var strReader = new StringReader(string.Join('\n', input) + '\n');
            Console.SetIn(strReader);

            Program.Main(Array.Empty<string>());

            Assert.Matches(@"Your result: \d+(.\d+)?", strWriter.ToString());
        }

        [Fact]
        public void ShouldHandleSeveralOperations()
        {
            var strWriter = new StringWriter();
            Console.SetOut(strWriter);

            var input = new string[]
            {
                "3",
                "2",
                "s",
                "y",
                "5",
                "5",
                "m",
                "y",
                "6",
                "3",
                "d",
                "n"
            };

            var strReader = new StringReader(string.Join('\n', input) + '\n');
            Console.SetIn(strReader);

            Program.Main(Array.Empty<string>());

            var matches = Regex.Matches(strWriter.ToString(), @"Your result: \d+(.\d+)?");
            Assert.Equal(3, matches.Count);
        }

        [Fact]
        public void ShouldHandleInvalidInput()
        {
            var strWriter = new StringWriter();
            Console.SetOut(strWriter);

            var input = new string[]
            {
                "asd",
                "2",
                "asd",
                "2",
                "s",
                "n"
            };

            var strReader = new StringReader(string.Join('\n', input) + '\n');
            Console.SetIn(strReader);

            Program.Main(Array.Empty<string>());

            Assert.Contains("This is not valid input. Please enter an integer value: ", strWriter.ToString());
        }

        [Fact]
        public void ShouldHandleIncorrectOperation()
        {
            var strWriter = new StringWriter();
            Console.SetOut(strWriter);

            var input = new string[]
            {
                "2",
                "0",
                "d",
                "n"
            };

            var strReader = new StringReader(string.Join('\n', input) + '\n');
            Console.SetIn(strReader);

            Program.Main(Array.Empty<string>());

            Assert.Contains("This operation will result in a mathematical error.\n", strWriter.ToString());
        }
    }
}
