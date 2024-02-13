using Microsoft.AspNetCore.Mvc;
using GameStore.Models;
using System.Xml.Linq;
using GameStore.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
namespace GameStore.Controllers
{
    public class GameController : Controller
    {

        /*Check Initial Catalog for Connection String*/
        String ConnectionString = "Data Source=DESKTOP-JTP2UM0\\SQL2019;Initial Catalog=GameStoreDB;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        
        GameStoreDbContext _context;
        

        static List<Game> Games = new List<Game>();

        public GameController(GameStoreDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            Games = _context.Games.ToList();

            return View(Games);
        }



        public IActionResult Details(int Id)
        {
            Game aGame = _context.Games.Find(Id);
            return View(aGame);

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
                if (Id == 0 || Id == null)
                {
                    return NotFound();
                }
                else
                {
                    Game aGame = new Game();
                    aGame = _context.Games.Find(Id);
                    return View(aGame);
                }
        }

        [HttpPost]
        public IActionResult Edit(Game updatedGame)
        {
          
            Game oldGame = updatedGame;
            _context.Update(updatedGame);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add() {
            return View();
        
        }
        [HttpPost]
        public IActionResult Add(Game newGame)
        {
            _context.Add(newGame);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            else
            {
                Game aGame = new Game();
                aGame = _context.Games.Find(Id);
                return View(aGame);
            }
        }
        [HttpPost]
        public IActionResult DeleteGame(int Id)
        {
             /*Game deletedGame = _context.Games.Find(Id);*/
            _context.Games.Remove(_context.Games.Find(Id));
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        /*
         [HttpPost]
       public async Task<IActionResult> Edit(VideoGame vg)
       {
           if (ModelState.IsValid)
           {
               _db.Update(vg);
               await _db.SaveChangesAsync();
               return RedirectToAction("VideoGameInfo");

           }
           return View(vg);
       }
[HttpGet]
     public async Task<IActionResult> Delete(int? id)
     {
         if (id == null)
         {

             return RedirectToAction("VideoGameInfo");

         }

         var getDetails = await _db.VideoGames.FindAsync(id);

         return View(getDetails);
     }
     [HttpPost]
     public async Task<IActionResult> Delete(int id)
     {
        
          var getDetails = await _db.VideoGames.FindAsync(id);
          _db.Remove(getDetails);
          await _db.SaveChangesAsync();
          return RedirectToAction("VideoGameInfo");

     }
         */
    }
}
