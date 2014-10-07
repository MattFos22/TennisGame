using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    class TennisGame
    {
        private string _currentScore;
        private static Dictionary<TennisGame, TennisGame[]> _games;

        #region static data structure
        static TennisGame()
        {
            _games = new Dictionary<TennisGame, TennisGame[]> 
            {
                {new TennisGame("0-0"), new TennisGame[] {new TennisGame("15-0"), new TennisGame("0-15")}},
                {new TennisGame("15-0"), new TennisGame[] {new TennisGame("30-0"), new TennisGame("15-15")}},
                {new TennisGame("30-0"), new TennisGame[] {new TennisGame("40-0"), new TennisGame("30-15")}},
                {new TennisGame("40-0"), new TennisGame[] {new TennisGame("Player 1 Wins"), new TennisGame("40-15")}},
                {new TennisGame("0-15"), new TennisGame[] {new TennisGame("15-15"), new TennisGame("0-30")}},
                {new TennisGame("0-30"), new TennisGame[] {new TennisGame("15-30"), new TennisGame("0-40")}},
                {new TennisGame("0-40"), new TennisGame[] {new TennisGame("15-40"), new TennisGame("Player 2 Wins")}},
                {new TennisGame("15-15"), new TennisGame[] {new TennisGame("30-15"), new TennisGame("15-30")}},
                {new TennisGame("30-15"), new TennisGame[] {new TennisGame("40-15"), new TennisGame("30-30")}},
                {new TennisGame("40-15"), new TennisGame[] {new TennisGame("Player 1 Wins"), new TennisGame("40-30")}},
                {new TennisGame("30-30"), new TennisGame[] {new TennisGame("40-30"), new TennisGame("30-40")}},
                {new TennisGame("30-40"), new TennisGame[] {new TennisGame("Deuce"), new TennisGame("Player 2 Wins")}},
                {new TennisGame("40-30"), new TennisGame[] {new TennisGame("Player 1 Wins"), new TennisGame("Deuce")}},
                {new TennisGame("Deuce"), new TennisGame[] {new TennisGame("A-40"), new TennisGame("40-A")}},
                {new TennisGame("40-A"), new TennisGame[] {new TennisGame("Deuce"), new TennisGame("Player 2 Wins")}},
                {new TennisGame("A-40"), new TennisGame[] {new TennisGame("Player 1 Wins"), new TennisGame("Deuce")}},
                {new TennisGame("Player 1 Wins"), new TennisGame[] {new TennisGame("0-0"), new TennisGame("0-0")}},
                {new TennisGame("Player 2 Wins"), new TennisGame[] {new TennisGame("0-0"), new TennisGame("0-0")}}

            };
        }
        #endregion

        public TennisGame(string score)
        {
            _currentScore = score;
        }

        internal string GetCurrentScore()
        {
            return _currentScore;
        }

        internal TennisGame Player1Scores()
        {
            var gameOutcomes = _games.Select(game => _games[this]);
            var value = gameOutcomes.ElementAt(0);
            return value[0];
        }

        internal TennisGame Player2Scores()
        {
            var gameOutcomes = _games.Where(game => _games.ContainsKey(this)).Select(game => _games[this]);
            var value = gameOutcomes.ElementAt(1);
            return value[1];
        }

        #region overrides
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var game = (TennisGame)obj;

            return game._currentScore == _currentScore;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
           return  _currentScore.GetHashCode();
        }
        #endregion
    }
}
