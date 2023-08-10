using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SellPoint.Data.Models
{
    [Index(nameof(Descripcion))]
    public class Entidades
    {
        [Key]
        public int IdEntidad { get; set; }

        [StringLength(120)]
        public string? Descripcion { get; set; }

        public string? Direccion { get; set; }

        [StringLength(40)]
        public string? Localidad { get; set; }
        [StringLength(8)]
        public string? TipoEntidad { get; set; }
        [StringLength(9)]
        public string? TipoDocumento { get; set; }

        [Range(0, 15)]
        public long? NumeroDocumento { get; set; }

        [StringLength(60)]
        public string? Telefonos { get; set; }
        [StringLength(120)]
        public string? URLPaginaWeb { get; set; }
        [StringLength(120)]
        public string? URLFacebook { get; set; }
        [StringLength(120)]
        public string? URLInstagram { get; set; }
        [StringLength(120)]
        public string? URLTwitter { get; set; }
        [StringLength(120)]
        public string? URLTiktok { get; set; }
        [StringLength(10)]
        public string? CodPostal { get; set; }
        [StringLength(255)]
        public string? CoordenadasGPS { get; set; }
        [Range(0, 15)]
        public double? LimiteCredito { get; set; }
        [StringLength(10)]
        public string? RolUserEntidad { get; set; }
        public string? Comentario { get; set; }
        [StringLength(10)]
        public string? Status { get; set; }
        public bool NoEliminable { get; set; } = false;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;


        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
