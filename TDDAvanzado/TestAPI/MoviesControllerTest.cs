﻿using BusinessLogic;
using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Out;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDAvanzado.Controllers;

namespace TestAPI
{
    [TestClass]
    public class MoviesControllerTest
    {
        private MoviesController _moviesController;
        private RetrieveMovieResponse _retrieveMovieResponse;
        private Movie _movie;

        [TestInitialize]
        public void Setup()
        {
            _retrieveMovieResponse = new RetrieveMovieResponse() { Title = "Avatar", Genres = new List<string>() };
            _movie = new Movie() { Title = "Avatar", Genres = new List<string>() };
        }

        [TestMethod]
        public void GetMovieByTitleOk()
        {
            //Arrange
            Mock<MovieLogic> movieLogicMock = new Mock<MovieLogic>(MockBehavior.Strict);
            _moviesController = new MoviesController(movieLogicMock.Object);
            RetrieveMovieResponse expectedResult = _retrieveMovieResponse;

            //Act
            OkObjectResult result = _moviesController.GetMovieByTitle("") as OkObjectResult;
            RetrieveMovieResponse objectResult = result.Value as RetrieveMovieResponse;

            //Assert
            movieLogicMock.VerifyAll();
            Assert.AreEqual(expectedResult, objectResult);
        }
    }
}
