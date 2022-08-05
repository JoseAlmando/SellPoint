using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Data.Models
{
    public class GrupoEntidad
    {
        [Key]
        public int IdGruposEntidad { get; set; }
        public string Descripcion { get; set; }
        public string Comentario { get; set; }
        public string Status { get; set; }
        public bool NoEliminable { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
