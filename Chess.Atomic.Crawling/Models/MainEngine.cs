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
            Bitmap screen = null;

            //GraphicsEngine.ScanBoard(screen, ref GameData.Instance.curState);

            int[] newState = new int[64] {
                1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                2, 2, 2, 2, 2, 2, 2, 2,
                2, 2, 2, 2, 2, 2, 2, 2,
            };

            

            Move lastMove = new Move();

            List<Move> moves = new List<Move>();

            while (true)
            {
                
                screen = GraphicsEngine.CaptureScreen();

                //Thread.Sleep(1000);

                if (GraphicsEngine.ScanBoard(screen, ref newState))
                {

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

                if (GameData.Instance.reset)
                {
                    GameData.Instance.Reset();

                    return Task.FromResult(true);
                }

                Thread.Sleep(200);

            }


 
        }

        public static void Reset()
        {
            GameData.Instance.reset = true; ;
        }
    }
}