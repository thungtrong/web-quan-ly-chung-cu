using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagerApartmentProject.Repositories;
using ManagerApartmentProject.Models;

namespace ManagerAparmentProject.Controllers
{
    public class EquipmentController : Controller
    {

        private readonly IEquipmentRes _equipmentRes;
        public EquipmentController(IEquipmentRes equipmentRes){
            _equipmentRes = equipmentRes;
        }

        // GET: Equipment
        public IActionResult Index()
        {
            var lstEquipment = _equipmentRes.GetAll();
            return View(lstEquipment);
        }

        // GET: Equipment/Detail/5
        public IActionResult Detail(int id)
        {
            Equipment apartment = _equipmentRes.GetByID(id);
            return View(apartment);
        }

        // GET: Equipment/Create
        public IActionResult Create()
        {
            var apartment = new Equipment();
            return View(apartment);
        }

        // POST: Equipment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Equipment apartment)
        {
            try
            {
                var result = _equipmentRes.Insert(apartment);
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

        // GET: Equipment/Update/5
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Equipment UpdateEquipment = _equipmentRes.GetByID(id);
            return View(UpdateEquipment);
        }

        // POST: Equipment/Update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Equipment apartment)
        {

            var result = _equipmentRes.UpdateById(id, apartment);
            if (result)
            {
                return RedirectToAction("Detail", new { id = id });
            }
            else
            {
                return View(apartment);
            }

        }

        // GET: Equipment/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0){
                return RedirectToAction("Index");
            }
            Equipment DelEquipment = _equipmentRes.GetByID(id);
            return View(DelEquipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var result = _equipmentRes.DeleteById(id);
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
