using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyCanvasDrawingApp.Commands;
using MyCanvasDrawingApp.Entities;
using MyCanvasDrawingApp.Exceptions;
using MyCanvasDrawingApp.Interfaces;
using System;

namespace MyCanvasDrawingApp.Tests.CommandTests
{
    [TestClass]
    public class CreateLineCommand_Tests
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
            _commandUnderTest = new CreateLineCommand(_mockReceiver.Object);
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
                _mockReceiver.Verify(x => x.CreateLine(It.IsAny<Line>()), Times.Never);
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
                Assert.AreEqual($"This command expects 4 arguments but only received {args.Length}", ex.Message);
                _mockReceiver.Verify(x => x.CreateLine(It.IsAny<Line>()), Times.Never);
            }
        }

        [TestMethod]
        [DataRow("1", "a", "1", "5")]
        [DataRow("a", "2", "3", "2")]
        [DataRow("-1", "2", "4", "2")]
        [DataRow("a", "a", "b", "a")]
        public void Execute_Method_when_input_argument_are_invalidType_than_expected_value_then_throws_argumentException(string input1, string input2, string input3, string input4)
        {
            //arrange
            string[] args = { input1, input2, input3, input4 };
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
                Assert.AreEqual($"There is some invalid arguments. All 4 arguments should be positive integers", ex.Message);
                _mockReceiver.Verify(x => x.CreateLine(It.IsAny<Line>()), Times.Never);
            }
        }

        [TestMethod]
        [DataRow("1", "1", "1", "4")]
        public void Execute_Method_when_input_argument_are_valid_but_Canvas_not_exist_than_fail(string input1, string input2, string input3, string input4)
        {
            //arrange
            Canvas canvas = null;
            string[] args = { input1, input2, input3, input4 };
            _mockReceiver.Setup(x => x.CurrentCanvas).Returns(canvas).Verifiable();
            _mockReceiver.Setup(x => x.CreateLine(It.IsAny<Line>())).Verifiable();
            try
            {
                //act
                _commandUnderTest.Execute(args);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //assert
                _mockReceiver.Verify(x => x.CreateLine(It.IsAny<Line>()), Times.Never);
                Assert.IsInstanceOfType(ex, typeof(CanvasNotFoundException));
                Assert.AreEqual($"No canvas exist. Please create one then try again.", ex.Message);
            }
        }

        [TestMethod]
        [DataRow("1", "1", "1", "4")]
        [DataRow("10", "5", "20", "5")]
        public void Execute_Method_when_input_argument_are_valid_than_success(string input1, string input2, string input3, string input4)
        {
            //arrange
            string[] args = { input1, input2, input3, input4 };
            _mockReceiver.Setup(x => x.CurrentCanvas).Returns(new Canvas(10, 20)).Verifiable();
            _mockReceiver.Setup(x => x.CreateLine(It.IsAny<Line>())).Verifiable();

            //act
            _commandUnderTest.Execute(args);

            //assert
            _mockReceiver.Verify(x => x.CreateLine(It.IsAny<Line>()), Times.Exactly(1));
        }

        #endregion Test Methods
    }
}