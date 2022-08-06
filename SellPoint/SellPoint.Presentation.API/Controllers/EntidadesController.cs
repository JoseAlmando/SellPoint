﻿using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellPoint.Bussines.Services;
using SellPoint.Data.Models;
using SellPoint.Data.DTO;

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
                var result = await _repoEntidades.GetList(
                    v => v.Descripcion.Contains(SearchTermn) || v.User.UserNameEntidad.Contains(SearchTermn), 
                    x => x.User);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Insert([FromBody] EntidadesDTO entidad)
        {
            try
            {
                //Get the entities of Entidades to add to model
                var user = await _unitOfWork.Repository<User>().FindWhere(x => x.Id == entidad.IdUser);
                //var grupoEntidad = await _unitOfWork.Repository<GrupoEntidad>().FindWhere(x => x.IdGruposEntidad == entidad.IdGrupoEntidad);
                //var tipoEntidad = await _unitOfWork.Repository<TipoEntidad>().FindWhere(x => x.IdTipoEntidad == entidad.IdTipoEntidad);

                var NewEntidad = new Entidades()
                {
                    Descripcion = entidad.Descripcion,
                    Direccion = entidad.Direccion,
                    Localidad = entidad.Localidad,
                    TipoEntidad = entidad.TipoEntidad,
                    TipoDocumento = entidad.TipoDocumento,
                    NumeroDocumento = entidad.NumeroDocumento,
                    Telefonos = entidad.Telefonos,
                    URLPaginaWeb = entidad.URLPaginaWeb,
                    URLFacebook = entidad.URLFacebook,
                    URLInstagram = entidad.URLInstagram,
                    URLTwitter = entidad.URLTwitter,
                    URLTiktok = entidad.URLTiktok,
                    CodPostal = entidad.CodPostal,
                    CoordenadasGPS = entidad.CoordenadasGPS,
                    LimiteCredito = entidad.LimiteCredito,
                    RolUserEntidad = entidad.RolUserEntidad,
                    Comentario = entidad.Comentario,
                    Status = entidad.Status,
                    NoEliminable = entidad.NoEliminable,
                    User = user
                };

                var InsertedRow = await _repoEntidades.Add(NewEntidad);
                if (InsertedRow)
                    return Ok(NewEntidad);
                return Ok("Usuario no creado, verifique los datos suministrados.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Entidades entidad)
        {
            try
            {
                if (!await _repoEntidades.Exists(x => x.IdEntidad == entidad.IdEntidad))
                {
                    return StatusCode(StatusCodes.Status404NotFound, "El usuario no existe.");
                }
                else
                {
                    var UpdatedRow = await _repoEntidades.Update(entidad);
                    return Ok(UpdatedRow);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var objectToDelete = await _repoEntidades.FindWhere(x => x.IdEntidad == Id);
                if (objectToDelete == null)
                    return Ok("El usuario no existe");

                return Ok(await _repoEntidades.Delete(objectToDelete));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
