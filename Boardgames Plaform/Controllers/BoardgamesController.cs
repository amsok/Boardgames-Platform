using BoardgamePlatform.Models;
using Boardgames_Plaform.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boardgames_Plaform.Controllers
{
    public class BoardgamesController : Controller
    {
        private Boardgames_PlatformContext _context;

        public BoardgamesController(Boardgames_PlatformContext context)
        {
            _context = context;
        }
        /// <summary>
        /// returns list of categories for boardgames
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }
        /// <summary>
        /// returns a list of all boardgames (eiter for category chosen or all categories)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> BoardgamesList(int id)
        {

            Category c = _context.Categories.Find(id);

            if (c == null)
            {
                ViewBag.CategoryChosen = "Wszystkie dostępne";
                return View(await _context.Boardgames.ToListAsync());
            }

            else
            {
                ViewBag.CategoryChosen = c.Name;
                return View(await _context.Boardgames.Where(b => b.Category == c).ToListAsync());
            }

        }
    }
}
