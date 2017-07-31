using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class MovesEngine
    {
        public static void MakeMove(Move move)
        {
            GameData.Instance.curMoves += String.Equals(GameData.Instance.winner, "white") ? move.ToWhite() : move.ToBlack();

            var res = HintsEngine.FindHints(GameData.Instance.curMoves, GameData.Instance.winner);

            var hint = res.hints.FirstOrDefault();

            if (hint.Key != null) GameData.Instance.curHint = Move.Parse(hint.Key);
            else GameData.Instance.curHint = Move.Parse("h1a1");
 
        }

        public static bool WhiteMoves(int[] prevPos, int[] curPos, ref Move move)
        {
            if (prevPos.Length != 64 || curPos.Length != 64) throw new Exception();

            bool res = false;

            for (int i = 0; i < 64; ++i)
            {
                if (prevPos[i] != curPos[i])
                {
                    res = true;
                    switch (prevPos[i])
                    {
                        case 0: { move.moveTo.x = i % 8; move.moveTo.y = i / 8; break; }
                        case 1: { move.moveFrom.x = i % 8; move.moveFrom.y = i / 8; break; }
                        case 2: { move.moveTo.x = i % 8; move.moveTo.y = i / 8; break; }
                    }
                }
            }

            return res;
 
        }

        public static bool BlackMoves(int[] prevPos, int[] curPos, ref Move move)
        {
            if (prevPos.Length != 64 || curPos.Length != 64) throw new Exception();

            bool res = false;

            for (int i = 0; i < 64; ++i)
            {
                if (prevPos[i] != curPos[i])
                {
                    res = true;
                    switch (prevPos[i])
                    {
                        case 0: { move.moveTo.x = i % 8; move.moveTo.y = i / 8; break; }
                        case 1: { move.moveTo.x = i % 8; move.moveTo.y = i / 8; break; }
                        case 2: { move.moveFrom.x = i % 8; move.moveFrom.y = i / 8; break; }
                    }
                }
            }

            return res;

        }
    }
}