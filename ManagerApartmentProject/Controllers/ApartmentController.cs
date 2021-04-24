using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagerAparmentProject.Models;
using ManagerAparmentProject.Repositories;

namespace ManagerAparmentProject.Controllers
{
    public class ApartmentController : Controller
    {


        // GET: Apartment
        public async Task<IActionResult> Index()
        {
            var lstApartment = ApartmentRes.GetAll();
            return View(lstApartment);
        }

        // GET: Apartment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Apartment apartment = ApartmentRes.GetByID(id);
            return View(apartment);
        }

        // GET: Apartment/Create
        public IActionResult Create()
        {
            var apartment = new Apartment();
            return View(apartment);
        }

        // POST: Apartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description")] Apartment apartment)
        {
            try
            {
                var result = ApartmentRes.Insert(apartment);
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

        // GET: Apartment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Apartment EditApartment =ApartmentRes.GetByID(id);
            return View(EditApartment);
        }

        // POST: Apartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description")] Apartment apartment)
        {

            var result = ApartmentRes.Update(id, apartment);
            if (result)
            {
                return RedirectToAction("Details", new { id = id });
            }
            else
            {
                return View(apartment);
            }

        }

        // GET: Apartment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Apartment DelApartment = ApartmentRes.GetByID(id);
            return View(DelApartment);
        }

        // POST: Apartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = ApartmentRes.Delete(id);
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
