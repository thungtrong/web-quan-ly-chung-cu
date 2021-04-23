using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagerAparmentProject.Data;
using ManagerAparmentProject.Models;
using ManagerAparmentProject.Repositories;

namespace ManagerAparmentProject.Controllers
{
    public class FloorController : Controller
    {

        // GET: Floor
        public async Task<IActionResult> Index()
        {
            var lstFloor = FloorRes.GetAll();
            return View(lstFloor);
        }

        // GET: Floor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Floor floor = FloorRes.GetByID(id);
            return View(floor);
        }

        // GET: Floor/Create
        public IActionResult Create()
        {
            var floor = new Floor();
            return View(floor);
        }

        // POST: Floor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description")] Floor floor)
        {
            try
            {
                var result = FloorRes.Insert(floor);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(floor);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Floor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Floor EditFloor = FloorRes.GetByID(id);
            return View(EditFloor);
        }

        // POST: Floor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description")] Floor floor)
        {       

             var result = FloorRes.Update(id, floor);
             if (result)
             {
                 return RedirectToAction("Details", new { id = id });
             }
             else
             {
                 return View(floor);
             }
        
        }

            // GET: Floor/Delete/5
            public async Task<IActionResult> Delete(int? id)
        {
            Floor DelFloor = FloorRes.GetByID(id);
            return View(DelFloor);
        }

        // POST: Floor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = FloorRes.Delete(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

    }
}
