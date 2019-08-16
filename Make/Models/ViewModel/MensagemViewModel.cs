using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Make.Models.ViewModel
{
    public class MensagemViewModel
    {
        public IEnumerator<Mensagem>Mensagens { get; set; }
        public IEnumerator<Comentario> Comentarios { get; set; }
    }
}
