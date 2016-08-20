using BowlingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Service
{
    public class BowlingService
    {
        private int _score;
        private bool _strike;
        private bool _spare;
        private int _strikesInRows;
        private bool _isInStrikeStreak;

        public ScoreModel CalculateScore(IList<Frame> frames)
        {
            int currentFrame = 0;

            foreach (var frame in frames)
            {
                currentFrame++;

                if (_strike || _spare)
                {
                    _score += CalculateStrikeOrSpare(frame);
                }

                if (currentFrame != 10)
                {
                    _score += CalculateFrameOneToNine(frame);
                }
                else
                {
                    _isInStrikeStreak = false;
                    _score += CalculateLastFrame(frame);
                }

                if (!_isInStrikeStreak && _strikesInRows > 1)
                {
                    _score += CalculateStrikeStreak(frame);
                }
            }
            return new ScoreModel() { Score = _score };
        }

        private int CalculateStrikeStreak(Frame frame)
        {
            int score = 0;

            while (_strikesInRows > 1)
            {
                if (_strikesInRows > 2)
                {
                    score += 10;
                }
                else if (_strikesInRows == 2)
                {
                    score += frame.First;
                }

                --_strikesInRows;
            }
            _strikesInRows = 0;

            return score;
        }

        private int CalculateStrikeOrSpare(Frame frame)
        {
            int score = 0;

            if (_strike)
            {
                score = frame.First + frame.Second;
            }
            else
            {
                score = frame.First;
            }

            return score;
        }

        private int CalculateFrameOneToNine(Frame frame)
        {
            int score = 0;
            if (frame.First == 10)
            {
                score += 10;
                _strike = true;
                _spare = false;
                _strikesInRows++;

                if (_strikesInRows > 1)
                    _isInStrikeStreak = true;

            }
            else if ((frame.First + frame.Second) == 10)
            {
                score += 10;
                _spare = true;
                _strike = false;
                _isInStrikeStreak = false;
            }
            else
            {
                score += frame.First + frame.Second;
                _strike = false;
                _spare = false;
                _isInStrikeStreak = false;
            }

            return score;
        }

        private int CalculateLastFrame(Frame frame)
        {
            return frame.First + frame.Second + frame.Third;
        }
    }
}

