using ManagerAparmentProject.Models;
using ManagerAparmentProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerAparmentProject.Controllers
{
    public class EquipmentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var lstEquipment = EquipmentRes.GetAll();
            return View(lstEquipment);
        }

        // GET: Equipment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Equipment equipment = EquipmentRes.GetByID(id);
            return View(equipment);
        }

        // GET: Equipment/Create
        public IActionResult Create()
        {
            var equipment = new Equipment();
            return View(equipment);
        }

        // POST: Equipment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,count,equipment_of")] Equipment equipment)
        {
            try
            {
                var result = EquipmentRes.Insert(equipment);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(equipment);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Equipment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Equipment editEquipment = EquipmentRes.GetByID(id);
            return View(editEquipment);
        }

        // POST: Equipment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("name,count,equipment_of")] Equipment equipment)
        {

            var result = EquipmentRes.Update(id, equipment);
            if (result)
            {
                return RedirectToAction("Details", new { id = id });
            }
            else
            {
                return View(equipment);
            }

        }

        // GET: Equipment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Equipment delEquipment = EquipmentRes.GetByID(id);
            return View(delEquipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = EquipmentRes.Delete(id);
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
