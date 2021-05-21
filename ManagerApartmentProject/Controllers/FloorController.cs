using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagerApartmentProject.Repositories;
using ManagerApartmentProject.Models;
using ManagerApartmentProject;
using Microsoft.AspNetCore.Authorization;

namespace ManagerAparmentProject.Controllers
{
    [Authorize]
    [Authorize(Policy = "AdminOrGreater")]
    public class FloorController : Controller
    {

        private readonly IFloorRes _floorRes;
        public FloorController(IFloorRes floorRes){
            _floorRes = floorRes;
        }

        // GET: Floor
        public IActionResult Index()
        {
            var lstFloor = _floorRes.GetAll();
            
            return View(lstFloor);
        }

        // GET: Floor/Detail/5
        public IActionResult Detail(int id, [FromServices] IApartmentRes apartmentRes)
        {
            Floor floor= _floorRes.GetByID(id);
            ViewBag.apartments = apartmentRes.GetByFloorId(id);

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
        public IActionResult Create(Floor floor)
        {
            try
            {
                var result = _floorRes.Insert(floor);
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

        // GET: Floor/Update/5
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Floor UpdateFloor = _floorRes.GetByID(id);

            return View(UpdateFloor);
        }

        // POST: Floor/Update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Floor floor)
        {

            var result = _floorRes.UpdateById(id, floor);
            if (result)
            {
                return RedirectToAction("Detail", new { id = id });
            }
            else
            {
                return View(floor);
            }

        }

        [Authorize(Policy = "SuperAdmin")]
        // GET: Floor/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0){
                return RedirectToAction("Index");
            }
            Floor DelFloor = _floorRes.GetByID(id);

            return View(DelFloor);
        }
        
        [Authorize(Policy = "SuperAdmin")]
        // POST: Floor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var result = _floorRes.DeleteById(id);
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
