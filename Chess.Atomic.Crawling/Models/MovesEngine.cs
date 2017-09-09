using Chess.Atomic.Crawling.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public enum SquareState
    {
        empty = -1,
        white = 1,
        black = 2,
        lastmove = 10        
    }

    public class MovesEngine
    {
        public static void MakeMove(Move move)
        {
            GameData.Instance.curMoves += String.Equals(GameData.Instance.winner, "white") ? move.ToWhite() : move.ToBlack();

            var res = HintsEngine.Instance.FindHints(GameData.Instance.curMoves, GameData.Instance.winner);

            var hint = res.hints.FirstOrDefault();

            //if (hint.Key != null) GameData.Instance.curHint = String.Equals(GameData.Instance.winner, "white") ? Move.ParseWhite(hint.Key) : Move.ParseBlack(hint.Key);
            //else GameData.Instance.curHint = String.Equals(GameData.Instance.winner, "white") ? Move.ParseWhite("g2b8") : Move.ParseBlack("g2b8");

            if (hint.Key != null) GameData.Instance.curHint = Move.ParseBlack(hint.Key);
            else
            {
                GameData.Instance.curHint = Move.ParseBlack("g2b8");
                MainEngine.Instance.Reset();
            }
        }

        public static bool WhiteMoves(int[] curPos, Move lastMove, Move highlighted, ref Move newMove, bool whiteToWin)
        {
            if (curPos.Length != 64) throw new Exception();

            if (lastMove.moveFrom == highlighted.moveFrom && lastMove.moveTo == highlighted.moveTo ||
                lastMove.moveFrom == highlighted.moveTo && lastMove.moveTo == highlighted.moveFrom
                )
                return false;
            else
            {
                int indFrom = whiteToWin ? (7 - highlighted.moveFrom.y) * 8 + (7 - highlighted.moveFrom.x) : highlighted.moveFrom.y * 8 + highlighted.moveFrom.x;
                int indTo = whiteToWin ? (7 - highlighted.moveTo.y) * 8 + (7 - highlighted.moveTo.x) : highlighted.moveTo.y * 8 + highlighted.moveTo.x; ;

                if (curPos[indFrom] == (int)SquareState.white && curPos[indTo] == (int)SquareState.white)
                {
                    newMove.castling = true;

                    if (String.Equals(GameData.Instance.winner, "white"))
                    {
                        if (highlighted.moveFrom.x == 0 && highlighted.moveFrom.y == 7 || highlighted.moveFrom.x == 7 && highlighted.moveFrom.y == 7)
                        {
                            newMove.moveTo.x = highlighted.moveFrom.x;
                            newMove.moveTo.y = highlighted.moveFrom.y;

                            newMove.moveFrom.x = highlighted.moveTo.x;
                            newMove.moveFrom.y = highlighted.moveTo.y;
                        }
                        else if (highlighted.moveTo.x == 0 && highlighted.moveTo.y == 7 || highlighted.moveTo.x == 7 && highlighted.moveTo.y == 7)
                        {
                            newMove.moveFrom.x = highlighted.moveFrom.x;
                            newMove.moveFrom.y = highlighted.moveFrom.y;

                            newMove.moveTo.x = highlighted.moveTo.x;
                            newMove.moveTo.y = highlighted.moveTo.y;
                        }
                        else // shouldn't reach here never
                        {
                            throw new Exception("WTF?");
                        }
                    }
                    else // winner == black
                    {
                        if (highlighted.moveFrom.x == 0 && highlighted.moveFrom.y == 0 || highlighted.moveFrom.x == 7 && highlighted.moveFrom.y == 0)
                        {
                            newMove.moveTo.x = highlighted.moveFrom.x;
                            newMove.moveTo.y = highlighted.moveFrom.y;

                            newMove.moveFrom.x = highlighted.moveTo.x;
                            newMove.moveFrom.y = highlighted.moveTo.y;
                        }
                        else if (highlighted.moveTo.x == 0 && highlighted.moveTo.y == 0 || highlighted.moveTo.x == 7 && highlighted.moveTo.y == 0)
                        {
                            newMove.moveFrom.x = highlighted.moveFrom.x;
                            newMove.moveFrom.y = highlighted.moveFrom.y;

                            newMove.moveTo.x = highlighted.moveTo.x;
                            newMove.moveTo.y = highlighted.moveTo.y;
                        }
                        else // shouldn't reach here never
                        {
                            throw new Exception("WTF?");
                        }
                    }
                }
                else
                {

                    switch (curPos[indFrom])
                    {
                        case (int)SquareState.empty: { newMove.moveTo.x = highlighted.moveFrom.x; newMove.moveTo.y = highlighted.moveFrom.y; break; }
                        case (int)SquareState.white: { newMove.moveFrom.x = highlighted.moveFrom.x; newMove.moveFrom.y = highlighted.moveFrom.y; break; }
                        case (int)SquareState.black: { newMove.moveTo.x = highlighted.moveFrom.x; newMove.moveTo.y = highlighted.moveFrom.y; break; }
                    }

                    switch (curPos[indTo])
                    {
                        case (int)SquareState.empty: { newMove.moveTo.x = highlighted.moveTo.x; newMove.moveTo.y = highlighted.moveTo.y; break; }
                        case (int)SquareState.white: { newMove.moveFrom.x = highlighted.moveTo.x; newMove.moveFrom.y = highlighted.moveTo.y; break; }
                        case (int)SquareState.black: { newMove.moveTo.x = highlighted.moveTo.x; newMove.moveTo.y = highlighted.moveTo.y; break; }
                    }
                }

                return true;
            } 
        }


        public static bool BlackMoves(int[] curPos, Move lastMove, Move highlighted, ref Move newMove, bool whiteToWin)
        {
            if (curPos.Length != 64) throw new Exception();

            if (lastMove.moveFrom == highlighted.moveFrom && lastMove.moveTo == highlighted.moveTo ||
                lastMove.moveFrom == highlighted.moveTo && lastMove.moveTo == highlighted.moveFrom
                )
                return false;
            else
            {
                int indFrom = whiteToWin ? (7 - highlighted.moveFrom.y) * 8 + (7 - highlighted.moveFrom.x) : highlighted.moveFrom.y * 8 + highlighted.moveFrom.x;
                int indTo = whiteToWin ? (7 - highlighted.moveTo.y) * 8 + (7 - highlighted.moveTo.x) : highlighted.moveTo.y * 8 + highlighted.moveTo.x; ;


                if (curPos[indFrom] == (int)SquareState.black && curPos[indTo] == (int)SquareState.black)
                {
                    newMove.castling = true;

                    if (String.Equals(GameData.Instance.winner, "black"))
                    {
                        if (highlighted.moveFrom.x == 0 && highlighted.moveFrom.y == 7 || highlighted.moveFrom.x == 7 && highlighted.moveFrom.y == 7)
                        {
                            newMove.moveTo.x = highlighted.moveFrom.x;
                            newMove.moveTo.y = highlighted.moveFrom.y;

                            newMove.moveFrom.x = highlighted.moveTo.x;
                            newMove.moveFrom.y = highlighted.moveTo.y;
                        }
                        else if (highlighted.moveTo.x == 0 && highlighted.moveTo.y == 7 || highlighted.moveTo.x == 7 && highlighted.moveTo.y == 7)
                        {
                            newMove.moveFrom.x = highlighted.moveFrom.x;
                            newMove.moveFrom.y = highlighted.moveFrom.y;

                            newMove.moveTo.x = highlighted.moveTo.x;
                            newMove.moveTo.y = highlighted.moveTo.y;
                        }
                        else // shouldn't reach here never
                        {
                            throw new Exception("WTF?");
                        }
                    }
                    else // winner == white
                    {
                        if (highlighted.moveFrom.x == 0 && highlighted.moveFrom.y == 0 || highlighted.moveFrom.x == 7 && highlighted.moveFrom.y == 0)
                        {
                            newMove.moveTo.x = highlighted.moveFrom.x;
                            newMove.moveTo.y = highlighted.moveFrom.y;

                            newMove.moveFrom.x = highlighted.moveTo.x;
                            newMove.moveFrom.y = highlighted.moveTo.y;
                        }
                        else if (highlighted.moveTo.x == 0 && highlighted.moveTo.y == 0 || highlighted.moveTo.x == 7 && highlighted.moveTo.y == 0)
                        {
                            newMove.moveFrom.x = highlighted.moveFrom.x;
                            newMove.moveFrom.y = highlighted.moveFrom.y;

                            newMove.moveTo.x = highlighted.moveTo.x;
                            newMove.moveTo.y = highlighted.moveTo.y;
                        }
                        else // shouldn't reach here never
                        {
                            throw new Exception("WTF?");
                        }
                    }
                }
                else
                {
                    switch (curPos[indFrom])
                    {
                        case (int)SquareState.empty: { newMove.moveTo.x = highlighted.moveFrom.x; newMove.moveTo.y = highlighted.moveFrom.y; break; }
                        case (int)SquareState.white: { newMove.moveTo.x = highlighted.moveFrom.x; newMove.moveTo.y = highlighted.moveFrom.y; break; }
                        case (int)SquareState.black: { newMove.moveFrom.x = highlighted.moveFrom.x; newMove.moveFrom.y = highlighted.moveFrom.y; break; }
                    }

                    switch (curPos[indTo])
                    {
                        case (int)SquareState.empty: { newMove.moveTo.x = highlighted.moveTo.x; newMove.moveTo.y = highlighted.moveTo.y; break; }
                        case (int)SquareState.white: { newMove.moveTo.x = highlighted.moveTo.x; newMove.moveTo.y = highlighted.moveTo.y; break; }
                        case (int)SquareState.black: { newMove.moveFrom.x = highlighted.moveTo.x; newMove.moveFrom.y = highlighted.moveTo.y; break; }
                    }
                }

                return true;
            }
        }


    }
}