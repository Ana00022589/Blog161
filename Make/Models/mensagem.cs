using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Make.Models
{
    public class Mensagem
    {
        public int MensagemId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("RimelId")]
        public int RimelId { get; set; }
        public virtual Rimel Rimel  { get; set; }

        [ForeignKey("ComentarioId")]
        public int ComentarioId { get; set; }
        public virtual Comentario Comentarios { get; set; }
    }
}
