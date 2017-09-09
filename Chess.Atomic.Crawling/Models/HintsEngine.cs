using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class HintsEngine
    {
        private static HintsEngine instance = new HintsEngine();

        private HintsEngine()
        {
            
 
        }

        public static HintsEngine Instance
        {
            get
            {
                return instance;
            }
        }

        private string[] AdditionalHints = new string[] { 

            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "d4b5c6b5" + "d1h5g7g6" + "h5b5b8c6" + "b5b6a7b6" + "f1b5e8f7" + "b5d7a8a2" + "b2b4g8h6" + "c1b2f6f5" + "g2g4h8g8" + "f2f4f8e7",
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "d4b5c6b5" + "d1h5g7g6" + "h5b5b8c6" + "b5b6a7b6" + "f1b5e8f7" + "b5d7a8a2" + "b2b4g8h6" + "h2h3",//...
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "d4b5c6b5" + "d1h5g7g6" + "h5b5b8c6" + "b5b6a7b6" + "f1b5e8f7" + "b5d7a8a2" + "b2b4g8h6" + "g2g4",//...
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "d4b5c6b5" + "d1h5g7g6" + "h5b5b8c6" + "b5b6a7b6" + "f1b5e8f7" + "b5d7a8a2" + "b2b4g8h6" + "f2f3",//...
                        
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "g2g4xxOO" + "b5a7f6f5" + "h2h4e6e5" + "f2f3f5g4" + "f1h3h6g4" + "xxOOd8f6" + "c3e4b4d2" + "e4g5h7h5" + "g5e6f6e6" + "f3f4d7d5" + "h3g4c8h3",
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "h2h3g7g6" + "b5a7h6f5",
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "b5c7e8f8" + "h2h3b8a6" + "a2a3d7d5",
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "b5c7e8f8" + "h2h3b8a6" + "f1a6d7d5" + "f2f4h6f5",
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "b5a7h6g4" + "f2f4g4f2" + "d1h5g7g6" + "h5a5b4a5",
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "b5a7h6g4" + "f2f4g4f2" + "d1h5g7g6" + "h5h6f2d3" + "e1e2d8b6",

            


            //"g1f3f7f6" + "e2e4d7d5" + "", // main line, but e7e6 maybe less familiar to opponent
            "g1f3f7f6" + "e2e4e7e6" + "f3d4b8c6" + "d4f5f8b4" + "c2c3c6d4" + "d1h5g7g6" + "f5g7e8f8",

            // tough line
            "g1f3f7f6" + "f3d4g8h6" + "e2e3h6g4" + "f2f4b7b5" + "d4f5e7e5" + "f5g7h7h5" + "c2c3d7d5" + "d1b3a7a5" + "f1b5b8d7" + "d2d3c7c6" + "h2h3g4f2" + "b3b7c8b7",
            "g1f3f7f6" + "f3d4g8h6" + "e2e3h6g4" + "f2f4b7b5" + "d4f5e7e5" + "f5g7h7h5" + "c2c3d7d5" + "d1b3a7a5" + "f1b5b8d7" + "d2d3c7c6" + "h2h3g4f2" + "b1a3a8b8",
            "g1f3f7f6" + "f3d4g8h6" + "e2e3h6g4" + "f2f4b7b5" + "d4f5e7e5" + "f5g7h7h5" + "f1d3e5e4" + "f5g7h7h5" + "c2c3d7d5" + "d1b3a7a5" + "b3a3b5b4" + "a3a4c7c6" + "h2h3g4f2",
            "g1f3f7f6" + "f3d4g8h6" + "e2e3h6g4" + "f2f4b7b5" + "d4f5e7e5" + "f5g7h7h5" + "f4f5c8b7",


            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e3d7d5" + "b1c3a7a6" + "b2b3b7b5" + "c3e4d5e4" + "d2d4c8g4" + "f2f3g4f5" + "e3e4e7e6" + "",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e3d7d5" + "d2d4b8a6" + "a2a3e7e5" + "c1d2a8b8" + "f1e2g7g6",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e3d7d5" + "f1b5c7c6",
            
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e4d7d5" + "b1a3a7a6" + "d2d4e7e5" + "c2c3h7h5" + "e4d5c8f5" + "f1b5c7c6" + "b5c4f8d6" + "c4f7e8f8" + "c1g5f5c2" + "d1d2e5e4" + "d2c1f6g5" + "g2g3d8f6" + "f2f3h5h4" + "a3c4h4g3" + "c1g5f6g5",
            //"g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e4d7d5" + "b1a3a7a6" + "d2d4e7e5" + "c2c3h7h5" + "e4d5c8f5" + "f1b5c7c6" + "b5c4f8d6" + "c4f7e8f8" + "c1g5f5c2" + "d1d2e5d4"
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "d2d4d7d5" + "e2e4b8a6" + "a2a3e7e5",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "d2d3d7d5" + "b1c3b8a6" + "c3b5c8g4" + "f2f3a6b4" + "c1h6g7h6" + "b5c7b4c2" + "a1c1a8c8" + "c1c7c8c7" + "f3g4f8h6" + "e2e3e8d7",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "d2d3d7d5" + "b1c3b8a6" + "c3b5c8g4" + "f2f3a6b4" + "c1h6g7h6" + "b5c7b4c2" + "a1c1a8c8" + "f3g4c8c2" + "c1c2e7e6" + "b2b4f8d6" + "g2g3e8d7" + "f1h3f6f5" + "e2e4h8c8",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "b1c3c7c6" + "d2d4d7d5" + "e2e4b8a6" + "c3b5c8g4" + "f2f3a6b4" + "b5c7d8c7" + "c1g5b4c2",
            //"g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "b1c3c7c6" + "d2d4d7d5" + "e2e4b8a6" + "c3b5c8g4" + "f2f3a6b4" + "b5c7d8c7" + "c1h6",

            "g1f3f7f6" + "b1c3g8h6" + "c3d5e7e6" + "h2h3e6d5" + "f3d4d7d5" + "e2e3f8b4" + "c2c3b4c3" + "d1b3c8f5" + "f1a6f5b1" + "a2a3b8a6" + "b3b4d8d6",
            "g1f3f7f6" + "b1c3g8h6" + "g2g4c7c6" + "d2d4e7e6" + "e2e4f8d6" + "f3e5d6e5" + "c3a4d7d6" + "c2c3b7b5" + "a4c5f6f5" + "c5d7d8h4" + "e1d2b5b4" + "c3c4b8a6" + "b2b3f5e4" + "d2c2a6c5" + "d4c5h6f5" + "c1g5f5e3" + "c2b2e3d1" + "g5h4c8a6" + "f1g2h7h6" + "a1d1xOOO" + "b2b1",
            "g1f3f7f6" + "b1c3g8h6" + "g2g4c7c6" + "d2d4e7e6" + "e2e4f8d6" + "f3e5d6e5" + "c3a4d7d6" + "c2c3b7b5" + "a4c5f6f5" + "c5d7d8h4" + "e1d2b5b4" + "c3c4b8a6" + "d1a4a6c5" + "d4c5a7a5",
            "g1f3f7f6" + "b1c3g8h6" + "g2g4c7c6" + "d2d4e7e6" + "e2e4f8d6" + "e4e5b8a6" + "c3a4d6b4" + "c2c3f6f5" + "f3g5f5g4" + "a4b6a7b6" + "d1h5g7g6" + "h5g5xxOO" + "f2f3f8f6" + "g5h4a8a2" + "e5f6d8h4" + "c3b4b7b5" + "c1h6c6c5" + "",
            "g1f3f7f6" + "b1c3g8h6" + "g2g4c7c6" + "d2d4e7e6" + "e2e4f8d6" + "e4e5b8a6" + "f1a6d6b4" + "a2a3f6f5" + "f3h4f5g4" + "c1g5d8b6" + "e1f1h6g4" + "f2f3b4c3" + "b2b4b6a6",
            "g1f3f7f6" + "b1c3g8h6" + "g2g4c7c6" + "c3e4e7e5" + "f3g5f6g5",

            "g1f3f7f6" + "b1c3g8h6" + "f3e5f6e5" + "e2e4h6g4" + "f2f4c7c6" + "h2h3g7g6" + "h3g4d7d5" + "g2g4f8h6" + "c3b5xxOO" + "b5a7f8f4" + "d2d4d8f8" + "c1f4c8g4",
            "g1f3f7f6" + "b1c3g8h6" + "f3e5f6e5" + "e2e4h6g4" + "f2f4c7c6" + "h2h3g7g6" + "h3g4d7d5" + "g2g4f8h6" + "c3b5xxOO" + "b5a7f8f4" + "d2d3d8f8" + "c1f4c8g4",



            "g1f3f7f6" + "b1a3g8h6" + "f3e5f6e5" + "h2h3e7e5" + "e2e3d8f6" + "f2f3f6g6",
            "g1f3f7f6" + "b1a3g8h6" + "f3e5f6e5" + "h2h3e7e5" + "g2g3f8b4" + "c2c3xxOO",


            "g1f3f7f6" + "f3e5f6e5" + "d2d4d7d5" + "c1g5g8f6" + "e2e4c8g4" + "f2f3e7e6" + "b1a3b7b5",


            "g1f3f7f6" + "d2d4e7e6" + "e2e4d7d5" + "b1a3b7b5",
            "g1f3f7f6" + "d2d4e7e6" + "d4d5f8c5" + "f3d4d7d6" + "c2c3g8h6" + "f2f3a7a6" + "e2e4d5a3" + "b2a3e6d5" + "e4e5d6d5" + "e5e6h6f5" + "d1a4b7b5" + "c1f4f5e3" + "f1d3c8e6" + "f4c7b5a4" + "b1a3a8b8" + "d3h7b8b2" + "a3c2b2b1" + "a1b1e3g2",
            "g1f3f7f6" + "d2d4e7e6" + "f3g5f6g5" + "c1g5g8f6" + "d4d5f8b4" + "c2c3xxOO" + "f2f3f6e4" + "g5e7f8f6" + "e2e3d8e8" + "e7f8g7g6" + "d5e6d7d5" + "c3b4b8c6" + "f1a6e4f2" + "d1a4b7a6" + "a4h4h7h6" + "", // можно доделать там короткие варианты до ничья/победа

            



            
            "g1h3h7h6" + "e2e3e7e6" + "b1c3f8b4" + "f1b5c7c6" + "d1h5g7g6" + "h5e5d8h4" + "g2g3h4f4" + "f2f3f4e5",
            "g1h3h7h6" + "e2e3e7e6" + "b1c3f8b4" + "d1h5g7g6" + "f1b5c7c6" + "h5e5d8h4" + "g2g3h4f4" + "f2f3f4e5",
            
            "g1h3h7h6" + "e2e3e7e6" + "b1a3d8h4" + "g2g3h4g4" + "f2f3g4b4" + "c2c3b4b2" + "",
            
            // the same after 7th move
            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "d1h5g7g6" + "h5h4d8h4" + "f1b5g8f6" + "f4e6f8g7" + "b1c3xxOO",
            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "d1h5g7g6" + "h5h4d8h4" + "f1b5g8f6" + "f4g6f8g7" + "b1c3xxOO",
            // the same after 7th move

            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "d1h5g7g6" + "h5h4d8h4" + "f4d5g8f6",
            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "f4h5f8b4" + "c2c3c6d4" + "e3d4d8h4",
            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "f4h5f8b4" + "c2c3c6d4" + "d1f3d4f3",



            "g1h3h7h6" + "e2e4e7e6" + "d2d4d7d5" + "b1a3b7b5" + "g2g3f7f5",

            "g1h3h7h6" + "e2e4e7e6" + "g2g3d8f6" + "d1f3f6f4" + "f3f4b8c6",




            "g1h3h7h6"  + "d2d4e7e6" + "e2e4b8a6" + "d1h5g7g6" + "h5b5c7c6",
            

            "g1h3h7h6" + "b1a3e7e6" + "d2d4d8h4" + "g2g3h4e4" + "c1e3b8c6",

            "g1h3h7h6" + "b1c3e7e6" + "c3e4f7f5",


            "g1h3h7h6" + "h3f4d7d5" + "f4h5b8c6" + "c2c3e7e5" + "g2g3c8g4",
            "g1h3h7h6" + "h3f4d7d5" + "e2e3c8g4" + "f2f3e7e5" + "b1c3f8b4",





            "d2d4b8a6" + "b1c3e7e6" + "g1f3d8h4" + "f3h4g8f6" + "e2e4a6b4" + "d1h5f6h5" + "c3b5a7a6" + "a2a3b4c2" + "b5c7a8c8",
            "d2d4b8a6" + "b1c3e7e6" + "g1f3d8h4" + "g2g3h4g4" + "b2b4f8b4",
            "d2d4b8a6" + "a2a3d7d5" + "g1h3f7f6",


            "b1c3e7e6" + "e2e3f8b4" + "d1h5g7g6" + "h5f3f7f5",
            "b1c3e7e6" + "g1f3d8f6" + "c3e4f6d4" + "f3d4g8f6" + "e2e4f6g4" + "f2f4h7h5" + "f1b5c7c6" + "b2b4g4f2" + "d1e2f2d3" + "e1f1c6b5" + "b4b5f8b4" + "c2c3b4c5" + "c1a3d7d6" + "a3c5b8d7" + "a1b1b7b6" + "c3c4d7c5" + "h2h4e6e5" + "g2g4g7g6" + "f4f5g6f5" + "h1g1d3f4" + "e2d1f4e2" + "g1g2f7f5" + "d2d4f5f4" + "d4c5e2c3" + "f1f2", // ok
            "b1c3e7e6" + "g1f3d8f6" + "c3e4f6d4" + "f3d4g8f6" + "e2e4f6g4" + "f2f4h7h5" + "f1b5c7c6" + "b2b4g4f2" + "d1e2f2d3" + "e1f1c6b5" + "",
            "b1c3e7e6" + "g1f3d8f6" + "c3e4f6d4" + "f3d4g8f6" + "f2f3",




            "e2e3e7e6" + "g1f3d8f6" + "f1d3f8b4" + "c2c3b4c3" + "d1a4b7b5" + "a4d4d7d6" + "e1d1e8d8" + "f3g5c7c5" + "g5f7c5d4" + "b1c3c8b7" + "e3e4g7g5" + "d2d3b8d7" + "f2f4h8f8" + "h1f1d7c5" + "f4g5f8f2" + "f1f2c5b3" + "c1g5d8e8" + "a1b1a8c8" + "d1e1b3c1" + "a2a4d6d5" + "g5e7e8d7" + "a4a5c1d3" + "e7c5d5e4" + "",
            //"e2e3e7e6" + "g1f3d8f6" + "f1d3f8b4" + "c2c3b4c3" + "d1a4b7b5" + "a4d4d7d6" + "e1d1e8d8" + "f3g5c7c5" + "g5f7c5d4" + "b1c3c8b7" + "e3e4g7g5" + "d2d4",
            "e2e3e7e6" + "g1f3d8f6" + "c2c3g8h6" + "d1a4b7b5" + "a4d4f8d6" + "e1d1f6h4" + "f3h4h6g4" + "d4a7d6h2" + "a2a4g4f2" + "a4a5xxOO" + "a5a6c8a6",
            "e2e3e7e6" + "g1f3d8f6" + "c2c3g8h6" + "d1a4b7b5" + "a4d4f8d6" + "e1d1f6h4" + "f3h4h6g4" + "d4a7d6h2" + "",

            "e2e3e7e6" + "d1h5g7g6" + "g1f3d8h4" + "g2g3h4b4" + "c2c3f7f6",




            "e2e4e7e6" + "d2d4g8h6" + "f2f3b8a6" + "c2c3f7f6" + "e4e5d7d5" + "g1h3c7c6" + "b2b4h6g4" + "f3g4g7g6" + "f1d3f8c5" + "d3g6h7h5",





            // white

            "g1f3e7e5" + "f3g5f7f5" + "d2d4b8c6" + "b2b4e5e4" + "e2e3h7h6" + "g5f7d8f6" + "d1h5f6h4" + "g2g3h4h5" + "f7h8",
            "g1f3e7e5" + "f3g5f7f5" + "d2d4b8c6" + "b2b4e5e4" + "e2e3h7h6" + "g5f7d8f6" + "d1h5f6h4" + "g2g3h4g4" + "f7e5",
            "g1f3e7e5" + "f3g5f7f5" + "d2d4d7d5" + "g5e6c8e6" + "c1g5",

            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8f5" + "d4e6f5e6" + "d1g4f6f5" + "g4g7",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8f5" + "d4e6f5e6" + "d1g4e7e6" + "g4g7",

            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e6" + "d4d5f6f5" + "h2h4g7g5" + "d5c6g8e7" + "c3b5f8g7" + "c2c3b8c6" + "b5c7e8f8" + "d1a4e7c8" + "h4g5h7h5" + "c7d5h5h4" + "g2g4h4h3" + "g4f5d8g5" + "a4f4g5f4" + "h1g1",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e6" + "d4d5f6f5" + "h2h4g7g5" + "d5c6g8e7" + "c3b5f8g7" + "c2c3b8c6" + "b5c7e8f8" + "d1a4b7b5" + "a4a6a8b8" + "c7d5e6d5" + "a6c8",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e6" + "d4d5f6f5" + "h2h4g7g5" + "d5c6g8e7" + "c3b5f8g7" + "c2c3b8c6" + "b5c7e8f8" + "d1a4b7b5" + "a4a6c6a5" + "g2g4h7h5" + "c7e8g7c3" + "b2b4e7d5" + "a2a4",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e6" + "d4d5f6f5" + "h2h4g7g5" + "d5c6g8e7" + "c3b5f8g7" + "c2c3b8c6" + "b5c7e8f8" + "d1a4b7b5" + "a4a6d6d5" + "c7e8g7e5" + "a6b7d8c7" + "f3f4",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e6" + "d4d5f6f5" + "h2h4g7g5" + "d5c6g8e7" + "c3b5f8g7" + "c2c3b8c6" + "b5c7e8f8" + "d1a4a7a5" + "h4g5h7h5" + "a4h4",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e6" + "d4d5f6f5" + "h2h4g7g5" + "d5c6g8e7" + "c3b5f8g7" + "c2c3b8c6" + "b5c7e8f8" + "d1a4c6b4" + "a4e8",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e6" + "d4d5f6f5" + "h2h4g7g5" + "d5c6a7a6" + "c3d5",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e6" + "d4d5f6f5" + "h2h4g7g5" + "d5c6b7b5" + "c3d5",
            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4c8g4" + "f2f3g4f5" + "d4e6f5e6" + "d2d4e7e5" + "c3b5c6b5" + "f1b5b8c6" + "c2c3d8a5" + "e3e4g8e6" + "f3f4g7g6" + "d4e5e8d8" + "d1g4e7f5" + "g4h3f8h6" + "e4e5h8e8" + "c1e3a5b4" + "e3b6",

            "g1f3f7f6" + "e2e3d7d6" + "b1c3c7c6" + "f3d4b7b5" + "d4e6c8e6" + "c3d5c6d5" + "d1h5g7g6" + "h5d5e7e6" + "d5b7",



            "g1f3f7f6" + "e2e3e7e6" + "f3d4f6f5" + "d1h5g7g6" + "h5g5g8f6" + "d4b5f8b4" + "c2c3b8a6" + "f2f4a6c5" + "b5d6",

            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3b7b5" + "d4f5e6f5" + "c3d5f8b4" + "c2c3g8h6" + "h2h3",




            "g1f3f7f6" + "e2e3d7d5" + "f3g5f6g5" + "d1h5g7g6" + "h5e5c8e6" + "e5c7b7b5" + "b2b3d5d4" + "f1c4b5c4" + "b1a3g8f6" + "a3b5f6g4" + "f2f3xOOO" + "f3g4e6c4" + "d2d3f8h6" + "xxOOh8f8" + "f1f7f8f7" + "c1a3c4b3" + "a1f1d8f8" + "f1f7f8f7" + "g2g4" // win
        };

        public HintModel FindHints(string prevMoves, string winner)
        {
            HintModel hints = new HintModel();

            hints.currMoves = prevMoves;

            hints.winner = winner;

            string nextMove = string.Empty;

            int startIndex = prevMoves.Length;

            string hint = AdditionalHints.FirstOrDefault(h => h.StartsWith(prevMoves));

            if (!String.IsNullOrEmpty(hint) && hint.Length >= startIndex + 4)
            {
                nextMove = hint.Substring(startIndex, 4);

                if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
                else hints.hints.Add(nextMove, 1);
            }

            //if (hints.hints.Count == 0)
            //{
            //    IEnumerable<AtomicGameInfoOld> games = GameData.Instance.prevPlayedGames.Where(g => g.moves.StartsWith(prevMoves));

            //    foreach (var g in games)
            //    {
            //        if (g.moves.Length >= startIndex + 4)
            //        {
            //            nextMove = g.moves.Substring(startIndex, 4);

            //            if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
            //            else hints.hints.Add(nextMove, 1);
            //        }
            //    }
            //}
            

            return hints;
        }

    }
}