using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyCanvasDrawingApp.Commands;
using MyCanvasDrawingApp.Entities;
using MyCanvasDrawingApp.Interfaces;
using System;

namespace MyCanvasDrawingApp.Tests.CommandTests
{
    [TestClass]
    public class CreateCanvasCommand_Tests
    {
        #region Private Variables

        private Mock<IReceiver> _mockReceiver;

        private ICommand _commandUnderTest;

        #endregion Private Variables

        #region Test Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            _mockReceiver = new Mock<IReceiver>();
            _commandUnderTest = new CreateCanvasCommand(_mockReceiver.Object);
        }

        #endregion Test Initialize

        #region Test CleanUp

        [TestCleanup]
        public void TestCleanup()
        {
            _mockReceiver = null;
            _commandUnderTest = null;
        }

        #endregion Test CleanUp

        #region Test Methods

        [TestMethod]
        public void Execute_Method_when_input_argument_null_then_throws_argumentNullException()
        {
            //arrange
            string[] args = null;

            try
            {
                //act
                _commandUnderTest.Execute(args);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                _mockReceiver.Verify(x => x.CreateCanvas(It.IsAny<Canvas>()), Times.Never);
            }
        }

        [TestMethod]
        public void Execute_Method_when_input_argument_are_less_than_expected_value_then_throws_argumentException()
        {
            //arrange
            string[] args = { "1" };
            try
            {
                //act
                _commandUnderTest.Execute(args);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual($"This command expects 2 arguments but only received {args.Length}", ex.Message);
                _mockReceiver.Verify(x => x.CreateCanvas(It.IsAny<Canvas>()), Times.Never);
            }
        }

        [TestMethod]
        [DataRow("1", "a")]
        [DataRow("a", "2")]
        [DataRow("-1", "-2")]
        [DataRow("a", "a")]
        [DataRow("0", "-1")]
        public void Execute_Method_when_input_argument_are_invalidType_than_expected_value_then_throws_argumentException(string input1, string input2)
        {
            //arrange
            string[] args = { input1, input2 };
            try
            {
                //act
                _commandUnderTest.Execute(args);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual($"There is some invalid arguments. Both arguments should be positive integers", ex.Message);
                _mockReceiver.Verify(x => x.CreateCanvas(It.IsAny<Canvas>()), Times.Never);
            }
        }

        [TestMethod]
        [DataRow("1", "1")]
        [DataRow("10", "20")]
        [DataRow("11", "13")]
        public void Execute_Method_when_input_argument_are_valid_than_success(string input1, string input2)
        {
            //arrange
            string[] args = { input1, input2 };
            _mockReceiver.Setup(x => x.CreateCanvas(new Canvas(Convert.ToUInt32(input1), Convert.ToUInt32(input2)))).Verifiable();

            //act
            _commandUnderTest.Execute(args);

            //assert
            _mockReceiver.Verify(x => x.CreateCanvas(It.IsAny<Canvas>()), Times.Exactly(1));
        }

        #endregion Test Methods
    }
}