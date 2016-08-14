// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectProviderTests.cs" company="Erik Cedheim">
//   Copyright 2016 Erik Cedheim
// </copyright>
// <summary>
//   Defines the ObjectProviderTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFCG.SSIS.Core.Tests.Unit
{
    using System.Collections.Generic;

    using FFCG.SSIS.Core.Contract.Interface;
    using FFCG.SSIS.Core.Logic.Implementation;

    using NUnit.Framework;

    /// <summary>
    /// The object provider tests.
    /// </summary>
    [TestFixture]
    public class ObjectProviderTests
    {
        /// <summary>
        /// The provider.
        /// </summary>
        private IObjectProvider provider;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.provider = new ObjectProvider();
        }

        /// <summary>
        /// The should be able to instantiate class by empty dictionary.
        /// </summary>
        [Test]
        public void ShouldBeAbleToInstantiateClassByEmptyDictionary()
        {
            var o = this.provider.CreateByDictionary<TestClass>(Data.NoParameters);
            Assert.AreEqual(default(string), o.StringValue);
            Assert.AreEqual(default(int), o.IntegerValue);
        }

        /// <summary>
        /// The should be able to instantiate class by dictionary.
        /// </summary>
        [Test]
        public void ShouldBeAbleToInstantiateClassByDictionary()
        {
            var o = this.provider.CreateByDictionary<TestClass>(Data.Parameters1);
            Assert.AreEqual(Data.StringValue, o.StringValue);
            Assert.AreEqual(Data.IntegerValue, o.IntegerValue);
        }

        /// <summary>
        /// The should be able to instantiate class by dictionary with inherited types.
        /// </summary>
        [Test]
        public void ShouldBeAbleToInstantiateClassByDictionaryWithInheritedTypes()
        {
            var o = this.provider.CreateByDictionary<TestClass>(Data.Parameters2);
            Assert.AreEqual(Data.StringValue, o.StringValue);
            Assert.AreEqual(Data.IntegerValue, o.IntegerValue);
            Assert.AreEqual(Data.TheBar, o.FooValue as Bar);
        }

        /// <summary>
        /// The should be able to instantiate class by parameter array.
        /// </summary>
        [Test]
        public void ShouldBeAbleToInstantiateClassByParameterArray()
        {
            var o = this.provider.Create<TestClass>(Data.ParameterArray);
            Assert.AreEqual(Data.StringValue, o.StringValue);
            Assert.AreEqual(Data.IntegerValue, o.IntegerValue);
            Assert.AreEqual(Data.TheBar, o.FooValue as Bar);
        }

        /// <summary>
        /// The foo.
        /// </summary>
        public class Foo
        {
        }

        /// <summary>
        /// The bar.
        /// </summary>
        public class Bar : Foo
        {
        }

        /// <summary>
        /// The test class.
        /// </summary>
        public class TestClass
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestClass"/> class.
            /// </summary>
            /// <param name="stringValue">
            /// The a string.
            /// </param>
            /// <param name="integerValue">
            /// The integer.
            /// </param>
            public TestClass(string stringValue, int integerValue)
            {
                this.StringValue = stringValue;
                this.IntegerValue = integerValue;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TestClass"/> class.
            /// </summary>
            /// <param name="stringValue">
            /// The a string.
            /// </param>
            /// <param name="integerValue">
            /// The integer.
            /// </param>
            /// <param name="fooValue">
            /// The foo.
            /// </param>
            public TestClass(string stringValue, int integerValue, Foo fooValue)
            {
                this.StringValue = stringValue;
                this.IntegerValue = integerValue;
                this.FooValue = fooValue;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TestClass"/> class.
            /// </summary>
            public TestClass()
            {
                this.StringValue = default(string);
                this.IntegerValue = default(int);
            }

            /// <summary>
            /// Gets or sets the a string.
            /// </summary>
            public string StringValue { get; set; }

            /// <summary>
            /// Gets or sets the an integer.
            /// </summary>
            public int IntegerValue { get; set; }

            /// <summary>
            /// Gets or sets the a foo.
            /// </summary>
            public Foo FooValue { get; set; }
        }

        /// <summary>
        /// The data.
        /// </summary>
        private static class Data
        {
            /// <summary>
            /// The string value.
            /// </summary>
            public const string StringValue = "StringValue";

            /// <summary>
            /// The integer value.
            /// </summary>
            public const int IntegerValue = 999;

            /// <summary>
            /// The the bar.
            /// </summary>
            public static readonly Bar TheBar = new Bar();

            /// <summary>
            /// The no parameters.
            /// </summary>
            public static readonly Dictionary<string, object> NoParameters = new Dictionary<string, object>();

            /// <summary>
            /// The parameters.
            /// </summary>
            public static readonly Dictionary<string, object> Parameters1 = new Dictionary<string, object> { { "stringValue", StringValue }, { "integerValue", IntegerValue } };

            /// <summary>
            /// The parameters 2.
            /// </summary>
            public static readonly Dictionary<string, object> Parameters2 = new Dictionary<string, object> { { "stringValue", StringValue }, { "integerValue", IntegerValue }, { "fooValue", TheBar } };

            /// <summary>
            /// The parameter array.
            /// </summary>
            public static readonly object[] ParameterArray = { StringValue, IntegerValue, TheBar };
        }
    }
}