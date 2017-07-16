using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Chess.Atomic.Crawling.Models
{
    //public class PlayersController
    //{
    //    public ChessAtomicCrawlingContext db = new ChessAtomicCrawlingContext();


    //    public bool Create(Player player)
    //    {
    //        //if (player != null && !db.Players.Select(a => a.name).Contains(player.name))
    //        if (player != null && db.Players.Find(player.name) == null)
    //        {
    //            try
    //            {
    //                db.Players.Add(player);

    //                db.SaveChanges();

    //                return true;
    //            }
    //            catch (Exception exc)
    //            {
    //                return false;
    //            }
    //        }
    //        else
    //            return false;
    //    }

    //    public bool Edit(Player player)
    //    {
    //        if (player != null)
    //        {
    //            try
    //            {
    //                db.Entry(player).State = EntityState.Modified;
    //                db.SaveChanges();
                    
    //                return true;
    //            }
    //            catch (Exception exc)
    //            {
    //                return false;
    //            }
    //        }
    //        else return false;
    //    }

    //    public List<Player> GetPlayers()
    //    {
    //        return db.Players.ToList();
    //    }

    //    //public ActionResult DeleteConfirmed(int id)
    //    //{
    //    //    Player player = db.Players.Find(id);
    //    //    db.Players.Remove(player);
    //    //    db.SaveChanges();
    //    //    return RedirectToAction("Index");
    //    //}

    //}
}
