using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public struct Move
    {
        public Point moveFrom;

        public Point moveTo;

        public bool castling; // xxOO - short, xOOO - long

        //public static Move ParseWhite(string move)
        //{
        //    Move res = new Move();

        //    if (move.Length != 4) throw new Exception();

        //    if (String.Equals(move, "xOOO"))
        //    {
        //        if (GameData.Instance.whiteToPlay)
        //        {
        //            res.moveFrom.x = 4;
        //            res.moveFrom.y = 0;

        //            res.moveTo.x = 0;
        //            res.moveTo.y = 0;
        //        }
        //        else
        //        {
        //            res.moveFrom.x = 4;
        //            res.moveFrom.y = 7;

        //            res.moveTo.x = 0;
        //            res.moveTo.y = 7;
        //        }

        //        res.castling = true;
        //    }
        //    else if (String.Equals(move, "xxOO"))
        //    {
        //        if (GameData.Instance.whiteToPlay)
        //        {
        //            res.moveFrom.x = 4;
        //            res.moveFrom.y = 0;

        //            res.moveTo.x = 7;
        //            res.moveTo.y = 0;
        //        }
        //        else
        //        {
        //            res.moveFrom.x = 4;
        //            res.moveFrom.y = 7;

        //            res.moveTo.x = 7;
        //            res.moveTo.y = 7;
        //        }

        //        res.castling = true;
        //    }
        //    else
        //    {

        //        string symb = move.Substring(0, 1);

        //        switch (symb)
        //        {
        //            case "a": { res.moveFrom.x = 0; break; }
        //            case "b": { res.moveFrom.x = 1; break; }
        //            case "c": { res.moveFrom.x = 2; break; }
        //            case "d": { res.moveFrom.x = 3; break; }
        //            case "e": { res.moveFrom.x = 4; break; }
        //            case "f": { res.moveFrom.x = 5; break; }
        //            case "g": { res.moveFrom.x = 6; break; }
        //            case "h": { res.moveFrom.x = 7; break; }
        //        }

        //        int second = Int32.Parse(move.Substring(1, 1));

        //        res.moveFrom.y = second - 1;

        //        symb = move.Substring(2, 1);

        //        switch (symb)
        //        {
        //            case "a": { res.moveTo.x = 0; break; }
        //            case "b": { res.moveTo.x = 1; break; }
        //            case "c": { res.moveTo.x = 2; break; }
        //            case "d": { res.moveTo.x = 3; break; }
        //            case "e": { res.moveTo.x = 4; break; }
        //            case "f": { res.moveTo.x = 5; break; }
        //            case "g": { res.moveTo.x = 6; break; }
        //            case "h": { res.moveTo.x = 7; break; }
        //        }

        //        second = Int32.Parse(move.Substring(3, 1));

        //        res.moveTo.y = second - 1;
        //    }

        //    return res;
        //}

        public static Move ParseBlack(string move)
        {
            Move res = new Move();

            if (move.Length != 4) throw new Exception();

            if (String.Equals(move, "xxOO"))
            {
                if (!GameData.Instance.whiteToPlay)
                {
                    res.moveFrom.x = 3;
                    res.moveFrom.y = 0;

                    res.moveTo.x = 0;
                    res.moveTo.y = 0;
                }
                else
                {
                    res.moveFrom.x = 3;
                    res.moveFrom.y = 7;

                    res.moveTo.x = 0;
                    res.moveTo.y = 7;
                }

                res.castling = true;
            }
            else if (String.Equals(move, "xOOO"))
            {
                if (!GameData.Instance.whiteToPlay)
                {
                    res.moveFrom.x = 3;
                    res.moveFrom.y = 0;

                    res.moveTo.x = 7;
                    res.moveTo.y = 0;
                }
                else
                {
                    res.moveFrom.x = 3;
                    res.moveFrom.y = 7;

                    res.moveTo.x = 7;
                    res.moveTo.y = 7;
                }

                res.castling = true;
            }
            else
            {
                string symb = move.Substring(0, 1);

                switch (symb)
                {
                    case "h": { res.moveFrom.x = 0; break; }
                    case "g": { res.moveFrom.x = 1; break; }
                    case "f": { res.moveFrom.x = 2; break; }
                    case "e": { res.moveFrom.x = 3; break; }
                    case "d": { res.moveFrom.x = 4; break; }
                    case "c": { res.moveFrom.x = 5; break; }
                    case "b": { res.moveFrom.x = 6; break; }
                    case "a": { res.moveFrom.x = 7; break; }
                }

                int second = Int32.Parse(move.Substring(1, 1));

                res.moveFrom.y = second - 1;

                symb = move.Substring(2, 1);

                switch (symb)
                {
                    case "h": { res.moveTo.x = 0; break; }
                    case "g": { res.moveTo.x = 1; break; }
                    case "f": { res.moveTo.x = 2; break; }
                    case "e": { res.moveTo.x = 3; break; }
                    case "d": { res.moveTo.x = 4; break; }
                    case "c": { res.moveTo.x = 5; break; }
                    case "b": { res.moveTo.x = 6; break; }
                    case "a": { res.moveTo.x = 7; break; }
                }

                second = Int32.Parse(move.Substring(3, 1));

                res.moveTo.y = second - 1;
            }

            return res;
        }

        public string ToWhite()
        {
            string res = String.Empty;

            if (castling)
            {
                if (!GameData.Instance.whiteToPlay)
                {
                    if (moveTo.x == 0 && moveTo.y == 0)
                    {
                        res = "xOOO";
                    }
                    if (moveTo.x == 7 && moveTo.y == 0)
                    {
                        res = "xxOO";
                    }
                }
                else
                {
                    if (moveTo.x == 0 && moveTo.y == 7)
                    {
                        res = "xOOO";
                    }
                    if (moveTo.x == 7 && moveTo.y == 7)
                    {
                        res = "xxOO";
                    }

                }
            }
            else
            {
                switch (moveFrom.x)
                {
                    case 0: { res += "a"; break; }
                    case 1: { res += "b"; break; }
                    case 2: { res += "c"; break; }
                    case 3: { res += "d"; break; }
                    case 4: { res += "e"; break; }
                    case 5: { res += "f"; break; }
                    case 6: { res += "g"; break; }
                    case 7: { res += "h"; break; }
                }

                res += (8 - moveFrom.y).ToString();

                switch (moveTo.x)
                {
                    case 0: { res += "a"; break; }
                    case 1: { res += "b"; break; }
                    case 2: { res += "c"; break; }
                    case 3: { res += "d"; break; }
                    case 4: { res += "e"; break; }
                    case 5: { res += "f"; break; }
                    case 6: { res += "g"; break; }
                    case 7: { res += "h"; break; }
                }

                res += (8 - moveTo.y).ToString();
            }


            return res;
        }

        public string ToBlack()
        {
            string res = String.Empty;

            if (castling)
            {
                if (GameData.Instance.whiteToPlay)
                {
                    if (moveTo.x == 0 && moveTo.y == 0)
                    {
                        res = "xxOO";
                    }
                    if (moveTo.x == 7 && moveTo.y == 0)
                    {
                        res = "xOOO";
                    }
                }
                else
                {
                    if (moveTo.x == 0 && moveTo.y == 7)
                    {
                        res = "xxOO";
                    }
                    if (moveTo.x == 7 && moveTo.y == 7)
                    {
                        res = "xOOO";
                    }
 
                }
            }
            else
            {

                switch (moveFrom.x)
                {
                    case 0: { res += "h"; break; }
                    case 1: { res += "g"; break; }
                    case 2: { res += "f"; break; }
                    case 3: { res += "e"; break; }
                    case 4: { res += "d"; break; }
                    case 5: { res += "c"; break; }
                    case 6: { res += "b"; break; }
                    case 7: { res += "a"; break; }
                }

                res += (moveFrom.y + 1).ToString();

                switch (moveTo.x)
                {
                    case 0: { res += "h"; break; }
                    case 1: { res += "g"; break; }
                    case 2: { res += "f"; break; }
                    case 3: { res += "e"; break; }
                    case 4: { res += "d"; break; }
                    case 5: { res += "c"; break; }
                    case 6: { res += "b"; break; }
                    case 7: { res += "a"; break; }
                }

                res += (moveTo.y + 1).ToString();
            }

            return res;
        }


        
    }

    public struct Point
    {
        public int x { get; set; }

        public int y { get; set; }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.x == p2.x && p1.y == p2.y); 
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return (p1.x != p2.x || p1.y != p2.y);
        }
    }
}