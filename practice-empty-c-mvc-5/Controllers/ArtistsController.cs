using practice_empty_c_mvc_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practice_empty_c_mvc_5.Controllers
{
    public class ArtistsController : Controller
    {
        // GET: Artists
        public ActionResult Index()
        {
            return View();
        }

        // GET: GetArtists
        public ActionResult GetArtists()
        {
            using (dev7_musicEntities dc = new dev7_musicEntities())
            {
                var artists = dc.artists.OrderBy(a => a.art_id).ToList();
                return Json(new { data = artists }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (dev7_musicEntities dc = new dev7_musicEntities())
            {
                var artist = dc.artists.Where(a=>a.art_id == id).FirstOrDefault();
                return View(artist);
            }
        }

        [HttpPost]
        public ActionResult Save(artist artist)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (dev7_musicEntities dc = new dev7_musicEntities())
                {
                    if (artist.art_id > 0)
                    {
                        var art = dc.artists.Where(a => a.art_id == artist.art_id).FirstOrDefault();
                        if (art != null)
                        {
                            art.art_name = artist.art_name;
                            art.art_status = artist.art_status;
                        }
                    }
                    else
                    {
                        dc.artists.Add(artist);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (dev7_musicEntities dc = new dev7_musicEntities())
            {
                var artist = dc.artists.Where(a => a.art_id == id).FirstOrDefault();
                if (artist != null)
                {
                    return View(artist);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("delete")]
        public ActionResult DeleteArtist(int id)
        {
            bool status = false;
            using (dev7_musicEntities dc = new dev7_musicEntities())
            {
                var artist = dc.artists.Where(a => a.art_id == id).FirstOrDefault();
                if (artist!=null)
                {
                    dc.artists.Remove(artist);
                    dc.SaveChanges(); 
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status}};
        }
    }
}