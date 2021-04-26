using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Controllers
{
    [Authorize]
    public class InvoiceApartmentController : Controller
    {
        private readonly ILogger<InvoiceApartment> _logger;
        private readonly IInvoiceApartmentRes _invoiceApartmentRes;
        public InvoiceApartmentController(ILogger<InvoiceApartment> logger, IInvoiceApartmentRes invoiceApartmentRes)
        {
            _logger = logger;
            _invoiceApartmentRes = invoiceApartmentRes;
        }

        public IActionResult Index()
        {
            // Check quyen sau do lua chon cach thuc load
            List<InvoiceApartment> lst = _invoiceApartmentRes.GetAll();
            return View(lst);
        }

        public IActionResult Detail(int id)
        {
            InvoiceApartmentViewModel model = _invoiceApartmentRes.GetById(id);
            return View(model);
        }
        
        public IActionResult Update(int id)
        {
            
            InvoiceApartmentViewModel model = _invoiceApartmentRes.GetById(id);
            ViewBag.Tenants = GetTenantsForSection(model.invoice.invoiceOf);
            
            return View(model);
        }

        [HttpPost]
        public string UpdateConfirm(int id, InvoiceApartmentViewModel model)
        {
            return RunApi(
                id,
                () => _invoiceApartmentRes.UpdateByIdAsync(id, model)
            );
        } 

        public IActionResult Create()
        {
            ViewBag.Tenants = GetTenantsForSection(0);
            return View(new InvoiceApartmentViewModel());
        }
        /// <summary>
        /// Lấy ra danh sách Tenant để truyền vào thẻ section
        /// </summary>
        /// <returns>SelectList</returns>
        private SelectList GetTenantsForSection(int selected)
        {
            var tenants = DataProvider
                            .GetListFrom<TenantModel>(
                                "Tenant_GetIdNameAll",
                                null,
                                (DataRow row) => SQLCommand.Map<TenantModel>(row)
                            );
            return new SelectList(tenants, "ID", "name", selected);
        }
        
        [HttpPost]
        public string CreateConfirm(int id, InvoiceApartmentViewModel model)
        {
            return RunApi(
                id,
                () => _invoiceApartmentRes.Create(id, model)
            );
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                RedirectToAction("Index");
            }
            InvoiceApartmentViewModel model = _invoiceApartmentRes.GetById(id);
            return View(model);
        }

        
        public string DeleteConfirm(int id)
        {
            return RunApi(
                id,
                () => _invoiceApartmentRes.DeleteById(id)
            );
        }

        /// <summary>
        /// Kiem tra dau vao id phai khac khong.
        /// Thuc thi func va lay ket qua tra ve
        /// Ma hoa thanh json string
        /// </summary>
        /// <param name="id">ID cua doi tuong</param>
        /// <param name="func">Ham thuc hien tuong tac voi database</param>
        /// <returns>json string</returns>
        private string RunApi(int id, Func<bool> func)
        {
            if (id == 0)
            {
                return JsonSerializer.Serialize(
                    new {
                        status = false,
                        message = "Error"
                    });
            }
            
            bool result = func();
            
            return JsonSerializer.Serialize(
                        new {
                        status = result,
                        message = result ? "Success" : "Error"
                    });
        }
    }
}