﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Data.DTO
{
    public class EntidadesDTO
    {
        public int? IdEntidad { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string? Localidad { get; set; }
        public string? TipoEntidad { get; set; }
        public string? TipoDocumento { get; set; }
        public long? NumeroDocumento { get; set; }
        public string? Telefonos { get; set; }
        public string? URLPaginaWeb { get; set; }
        public string? URLFacebook { get; set; }
        public string? URLInstagram { get; set; }
        public string? URLTwitter { get; set; }
        public string? URLTiktok { get; set; }
        public string? CodPostal { get; set; }
        public string? CoordenadasGPS { get; set; }
        public double? LimiteCredito { get; set; }
        public string? RolUserEntidad { get; set; }
        public string? Comentario { get; set; }
        public string? Status { get; set; }
        public bool? NoEliminable { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.Now;
        public int? IdUser { get; set; }
    }
}
