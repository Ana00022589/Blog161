using Make.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Make.Model
{
    public class MensagemViewModel
    {
        public IEnumerator<Mensagem>Mensagens { get; set; }
        public IEnumerator<Comentario> Comentarios { get; set; }
    }
}
