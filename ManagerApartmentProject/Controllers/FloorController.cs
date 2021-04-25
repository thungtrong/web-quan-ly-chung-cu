using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagerApartmentProject.Repositories;
using ManagerApartmentProject.Models;
using ManagerApartmentProject;

namespace ManagerAparmentProject.Controllers
{
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
        public IActionResult Detail(int id)
        {
            Floor apartment = _floorRes.GetByID(id);
            return View(apartment);
        }

        // GET: Floor/Create
        public IActionResult Create()
        {
            var apartment = new Floor();
            return View(apartment);
        }

        // POST: Floor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Floor apartment)
        {
            try
            {
                var result = _floorRes.Insert(apartment);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(apartment);
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
        public IActionResult Update(int id, Floor apartment)
        {

            var result = _floorRes.UpdateById(id, apartment);
            if (result)
            {
                return RedirectToAction("Detail", new { id = id });
            }
            else
            {
                return View(apartment);
            }

        }

        // GET: Floor/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0){
                return RedirectToAction("Index");
            }
            Floor DelFloor = _floorRes.GetByID(id);
            return View(DelFloor);
        }

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
