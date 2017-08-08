using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Chess.Atomic.Crawling.SignalR_hubs;
using Chess.Atomic.Crawling.SignalR;

namespace Chess.Atomic.Crawling.Models
{
    public class MainEngine
    {
        private readonly static MainEngine _instance = new MainEngine();

        private MainEngine()
        {
            
        }
        
        public static MainEngine Instance
        {
            get { return _instance; }
        }

        public Task<bool> Go()
        {
            Bitmap screen = null;

            //GraphicsEngine.ScanBoard(screen, ref GameData.Instance.curState);

            int[] newState = new int[64] {
                1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1,
                -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1,
                2, 2, 2, 2, 2, 2, 2, 2,
                2, 2, 2, 2, 2, 2, 2, 2,
            };



            Move newMove = new Move();

            Move highlighted = new Move();

            while (true)
            {

                screen = GraphicsEngine.CaptureScreen();

                if (GraphicsEngine.ScanBoard(screen, ref newState, ref highlighted))
                {

                    if (GameData.Instance.whiteToPlay && MovesEngine.WhiteMoves(GameData.Instance.curState, GameData.Instance.lastMove, highlighted, ref newMove))
                    {
                        MovesEngine.MakeMove(newMove);

                        for (int i = 0; i < GameData.Instance.curState.Length; ++i)
                        {
                            GameData.Instance.curState[i] = newState[i];
                        }

                        GameData.Instance.lastMove.moveFrom.x = newMove.moveFrom.x;
                        GameData.Instance.lastMove.moveFrom.y = newMove.moveFrom.y;
                        GameData.Instance.lastMove.moveTo.x = newMove.moveTo.x;
                        GameData.Instance.lastMove.moveTo.y = newMove.moveTo.y;

                        GameData.Instance.whiteToPlay = false;

                        ConnectionBoard.Instance.UpdateBoard();
                    }
                    else if (MovesEngine.BlackMoves(GameData.Instance.curState, GameData.Instance.lastMove, highlighted, ref newMove))
                    {
                        MovesEngine.MakeMove(newMove);

                        for (int i = 0; i < GameData.Instance.curState.Length; ++i)
                        {
                            GameData.Instance.curState[i] = newState[i];
                        }

                        GameData.Instance.lastMove.moveFrom.x = newMove.moveFrom.x;
                        GameData.Instance.lastMove.moveFrom.y = newMove.moveFrom.y;
                        GameData.Instance.lastMove.moveTo.x = newMove.moveTo.x;
                        GameData.Instance.lastMove.moveTo.y = newMove.moveTo.y;

                        GameData.Instance.whiteToPlay = true;

                        ConnectionBoard.Instance.UpdateBoard();
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

        public void Reset()
        {
            GameData.Instance.reset = true; ;
        }
    }
}