using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Make.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario { get; set; }
        public string Artista { get; set; }
        public string Nome { get; set; }

        public int MensagemId { get; set; }
        [DisplayName("Mensagem")]
        [ForeignKey("MensagemId")]
        public Mensagem mensagens { get; set; }
    }
}
