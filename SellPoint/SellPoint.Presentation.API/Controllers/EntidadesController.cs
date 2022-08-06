using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellPoint.Bussines.Services;
using SellPoint.Data.Models;

namespace SellPoint.Presentation.API.Controllers
{
    public class EntidadesController : Controller
    {
        private UnitOfWork _unitOfWork;
        private GenericRepository<Entidades> _repoEntidades;
        public EntidadesController()
        {
            _unitOfWork = new UnitOfWork();
            _repoEntidades = _unitOfWork.Repository<Entidades>();
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll(string SearchTermn)
        {
            try
            {
                var entities = new List<string>{ "GrupoEntidad", "User", "TipoEntidad" };
                var result = await _repoEntidades.GetList(
                    v => v.Descripcion.Contains(SearchTermn) || v.User.UserNameEntidad.Contains(SearchTermn), 
                    x => x.TipoEntidadModel, x => x.User, x => x.GrupoEntidad);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }
    }
}
