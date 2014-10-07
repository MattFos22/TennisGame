using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisGame
{
    [TestClass]
    public class TennisTests
    {
        [TestMethod]
        public void Should_Return_LoveLove()
        {
            var game = new TennisGame("0-0");

            Assert.AreEqual("0-0", game.GetCurrentScore());
        }

        [TestMethod]
        public void Should_Return_15Love_When_Player1_Scores()
        {
            var game = new TennisGame("0-0");  

            game = game.Player1Scores();
          
            Assert.AreEqual("15-0",game.GetCurrentScore());
        }

        [TestMethod]
        public void Should_Return_30Love_When_Player1_Scores_Twice()
        {
            var game = new TennisGame("0-0");

            game = game.Player1Scores().Player1Scores();

            Assert.AreEqual("30-0", game.GetCurrentScore());
        }

        [TestMethod]
        public void Should_Return_3015_When_Player1_Scores_Twice_And_Player2_Scores_Once()
        {
            var game = new TennisGame("0-0");

            game = game.Player1Scores().Player1Scores().Player2Scores();

            Assert.AreEqual("30-15", game.GetCurrentScore());
        }

    
    }
}
