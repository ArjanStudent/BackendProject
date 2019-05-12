using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reservatie.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservatie.Models.Repositories;
using Moq;
using System.Linq;
using Reservatie.API.Models;

namespace Reservatie.UnitTests.API_Controllers
{
    /// <summary>
    /// Summary description for Movie_UnitTests
    /// </summary>
    [TestClass]
    public class Movie_UnitTests
    {
        private Task<IEnumerable<Movie>> toDoTasks = Task.FromResult(new List<Movie>() as IEnumerable<Movie>);

        [TestMethod]
        public async Task TaskAPICtrlAsync_GET_ReturnsToDoTasks()
        {
            // Arrange (Mock op de interface - anders not supported exception)   
            var mockRepo = new Mock<IMovieRepo>();
            mockRepo.Setup(repo => repo.GetMoviesAsync()).Returns(movies);
            API.Controllers.MovieController controllerAPI =                
                new API.Controllers.ToDoTaskController(mockRepo.Object, null );
            // Act met await   
            var actionResult = await controllerAPI.Get();   
            var okResult = actionResult as   OkObjectResult;
            IEnumerable<Movie_TDO> Tasks = okResult.Value as IEnumerable<Movie_TDO>;
            // Assert: Controleer altijd  null + datatypes + statuscode + inhoud  
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
            Assert.IsInstanceOfType(okResult.Value, typeof(IEnumerable<movie_TDO>));
            Assert.IsTrue(Tasks.Count() == 10);   Assert.AreEqual(200, okResult.StatusCode);}


            public Movie_UnitTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
