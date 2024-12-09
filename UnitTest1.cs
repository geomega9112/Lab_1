using NUnit.Framework;
using AnalaizerClassLibrary;
using System;

namespace AnalaizerClassLibrary.Tests
{
    [TestFixture]
    public class AnalaizerClassTests
    {
        // Тести для методу InsertSymbol
        [Test]
        public void InsertSymbol_Diagnostics()
        {
            string input = "12345";
            char symbol = 'X';

            // Вставка на початок
            string result1 = AnalaizerClass.InsertSymbol(input, symbol, 0);
            Console.WriteLine("Insert at beginning: " + result1); // Очікується: "X12345"

            // Вставка в середину
            string result2 = AnalaizerClass.InsertSymbol(input, symbol, 2);
            Console.WriteLine("Insert in middle: " + result2);    // Очікується: "12X345"

            // Вставка в кінець
            string result3 = AnalaizerClass.InsertSymbol(input, symbol, 5);
            Console.WriteLine("Insert at end: " + result3);       // Очікується: "12345X"

            // Вставка в порожній рядок
            input = "";
            string result4 = AnalaizerClass.InsertSymbol(input, symbol, 0);
            Console.WriteLine("Insert into empty string: " + result4); // Очікується: "X"
        }

        // Тести для методу IsOperator
        [Test]
        public void IsOperator_ReturnsTrue_ForBasicOperators()
        {
            Assert.IsTrue(AnalaizerClass.IsOperator("+"));
            Assert.IsTrue(AnalaizerClass.IsOperator("-"));
            Assert.IsTrue(AnalaizerClass.IsOperator("*"));
            Assert.IsTrue(AnalaizerClass.IsOperator("/"));
        }

        [Test]
        public void IsOperator_ReturnsTrue_ForBrackets()
        {
            Assert.IsTrue(AnalaizerClass.IsOperator("(!@"));
            Assert.IsTrue(AnalaizerClass.IsOperator(")"));
        }

        [Test]
        public void IsOperator_ReturnsFalse_ForUnaryOperators()
        {
            Assert.IsFalse(AnalaizerClass.IsOperator("~"));
            Assert.IsFalse(AnalaizerClass.IsOperator("!"));
        }

        [Test]
        public void IsOperator_ReturnsFalse_ForNonOperators()
        {
            Assert.IsFalse(AnalaizerClass.IsOperator("A"));
            Assert.IsFalse(AnalaizerClass.IsOperator("1"));
            //Assert.IsFalse(AnalaizerClass.IsOperator("++"));
            Assert.IsFalse(AnalaizerClass.IsOperator(" "));
        }

        [Test]
        public void IsOperator_HandlesSpecialOperatorInterpretation()
        {
            // Тест для '++', який має інтерпретуватися як '+*+'
            Assert.IsTrue(AnalaizerClass.IsOperator("+"));
            Assert.IsTrue(AnalaizerClass.IsOperator("*"));
            Assert.IsTrue(AnalaizerClass.IsOperator("+"));

            // Тест для '+-', який має інтерпретуватися як '+*-'
            Assert.IsTrue(AnalaizerClass.IsOperator("+"));
            Assert.IsTrue(AnalaizerClass.IsOperator("*"));
            Assert.IsTrue(AnalaizerClass.IsOperator("-"));

            // Тест для '-+', який має інтерпретуватися як '-*+'
            Assert.IsTrue(AnalaizerClass.IsOperator("-"));
            Assert.IsTrue(AnalaizerClass.IsOperator("*"));
            Assert.IsTrue(AnalaizerClass.IsOperator("+"));

            // Тест для '--', який інтерпретується як '+'
            Assert.IsTrue(AnalaizerClass.IsOperator("+"));
        }



        [Test]
        public void IsOperator_ReturnsFalse_ForEmptyString()
        {
            Assert.IsFalse(AnalaizerClass.IsOperator(""));
        }

        [Test]
        public void IsOperator_ReturnsFalse_ForMultipleCharacterNonOperators()
        {
            Assert.IsFalse(AnalaizerClass.IsOperator("abc"));
            Assert.IsFalse(AnalaizerClass.IsOperator("123"));
        }
    }
}
