using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Make.Models
{
    public class Comentario
    {
        [key]
        public int ID { get; set; }
        [ForeignKey("mensagemID")]
        public mensagem mensagem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime dataComentario { get; set; }
        public string Artista { get; set; }
    }
}
