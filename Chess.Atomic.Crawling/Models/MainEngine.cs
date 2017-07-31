using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Chess.Atomic.Crawling.Models
{
    public class MainEngine
    {
        public static Task<bool> Go()
        {
            Bitmap screen = GraphicsEngine.CaptureScreen();

            GraphicsEngine.ScanBoard(screen, ref GameData.Instance.curState);

            int[] newState = new int[64];

            Move lastMove = new Move();

            List<Move> moves = new List<Move>();

            while (true)
            {
                Thread.Sleep(100);

                screen = GraphicsEngine.CaptureScreen();

                Thread.Sleep(1000);

                GraphicsEngine.ScanBoard(screen, ref newState);

                if (GameData.Instance.whiteToPlay && MovesEngine.WhiteMoves(GameData.Instance.curState, newState, ref lastMove))
                {
                    MovesEngine.MakeMove(lastMove);

                    for (int i = 0; i < GameData.Instance.curState.Length; ++i)
                    {
                        GameData.Instance.curState[i] = newState[i];
                    }

                    GameData.Instance.whiteToPlay = false;

                    moves.Add(lastMove);
                }
                else if (MovesEngine.BlackMoves(GameData.Instance.curState, newState, ref lastMove))
                {
                    MovesEngine.MakeMove(lastMove);

                    for (int i = 0; i < GameData.Instance.curState.Length; ++i)
                    {
                        GameData.Instance.curState[i] = newState[i];
                    }

                    GameData.Instance.whiteToPlay = true;

                    moves.Add(lastMove);
                }
            }


 
        }
    }
}