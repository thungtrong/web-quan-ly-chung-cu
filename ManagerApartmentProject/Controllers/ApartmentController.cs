using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;

namespace ManagerAparmentProject.Controllers
{
    public class ApartmentController : Controller
    {

        private readonly IApartmentRes _apartmentRes;
        public ApartmentController(IApartmentRes apartmentRes){
            _apartmentRes = apartmentRes;
        }

        // GET: Apartment
        public IActionResult Index()
        {
            var lstApartment = _apartmentRes.GetAll();
            return View(lstApartment);
        }

        // GET: Apartment/Detail/5
        public IActionResult Detail(int id)
        {
            Apartment apartment = _apartmentRes.GetByID(id);
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
        public IActionResult Create(Apartment apartment)
        {
            try
            {
                var result = _apartmentRes.Insert(apartment);
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

        // GET: Apartment/Update/5
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Apartment UpdateApartment = _apartmentRes.GetByID(id);
            return View(UpdateApartment);
        }

        // POST: Apartment/Update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Apartment apartment)
        {

            var result = _apartmentRes.UpdateById(id, apartment);
            if (result)
            {
                return RedirectToAction("Detail", new { id = id });
            }
            else
            {
                return View(apartment);
            }

        }

        // GET: Apartment/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0){
                return RedirectToAction("Index");
            }
            Apartment DelApartment = _apartmentRes.GetByID(id);
            return View(DelApartment);
        }

        // POST: Apartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var result = _apartmentRes.DeleteById(id);
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
