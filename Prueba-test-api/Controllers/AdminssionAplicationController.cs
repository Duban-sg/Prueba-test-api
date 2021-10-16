using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;
using Prueba_test_api.Models;

namespace Prueba_test_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminssionAplicationController : ControllerBase
    {
        private readonly AdminssionAplicationService _AdminssionAplicationService;
        public AdminssionAplicationController( TestApiContext _context)
        {
            this._AdminssionAplicationService = new AdminssionAplicationService(_context);
        }
        // POST: api/Solicitud
        [HttpPost]
        public ActionResult<AdminssionAplicationViewModel> post(AdminssionAplicationInpuntModel adminssionAplicationInpunt)
        {
            var response = this._AdminssionAplicationService.save(adminssionAplicationInpunt.mapToAdminssionAplication());
            if (response.Error)
            {
                ModelState.AddModelError("Error al guardar la solicitud", response.Message);
                var detallesproblemas = new ValidationProblemDetails(ModelState);
                detallesproblemas.Status = StatusCodes.Status400BadRequest;
                return  BadRequest(detallesproblemas);
            }
            return Ok(new AdminssionAplicationViewModel(response.Data));

        }

        // GET: api/Solicitud
        [HttpGet]
        public ActionResult<List<AdminssionAplicationViewModel>> get()
        {
            var response = this._AdminssionAplicationService.get();
            if (response.Error)
            {
                ModelState.AddModelError("Error al guardar la solicitud", response.Message);
                var detallesproblemas = new ValidationProblemDetails(ModelState);
                detallesproblemas.Status = StatusCodes.Status400BadRequest;
                return BadRequest(detallesproblemas);
            }
            return Ok(response.Data.Select(p=>new AdminssionAplicationViewModel(p)));
        }

        // PUT: api/Solicitud
        [HttpPut]
        public ActionResult<AdminssionAplicationViewModel> update(AdminssionAplicationInpuntModel adminssionAplicationInpunt)
        {
            var response = this._AdminssionAplicationService.update(adminssionAplicationInpunt.mapToAdminssionAplication());
            if (response.Error)
            {
                ModelState.AddModelError("Error al guardar la solicitud", response.Message);
                var detallesproblemas = new ValidationProblemDetails(ModelState);
                detallesproblemas.Status = StatusCodes.Status400BadRequest;
                return BadRequest(detallesproblemas);
            }
            return Ok(new AdminssionAplicationViewModel(response.Data));
        }

        // DELETE: api/Solicitud
        [HttpDelete("{_identification}")]
        public ActionResult<AdminssionAplicationViewModel> delete(string _identification)
        {
            var response = this._AdminssionAplicationService.delete(_identification);
            if (response.Error)
            {
                ModelState.AddModelError("Error al guardar la solicitud", response.Message);
                var detallesproblemas = new ValidationProblemDetails(ModelState);
                detallesproblemas.Status = StatusCodes.Status400BadRequest;
                return BadRequest(detallesproblemas);
            }
            return Ok(new AdminssionAplicationViewModel(response.Data));

        }

    }
}
