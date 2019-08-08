using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Make.Models
{
    public class mensagem
    {
        public int mensagemId { get; set; }
        [ForeignKey("mensagemID")]

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime data { get; set; }
        public string Categoria { get; set; }
    }
}
