using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Make.Models
{
    public class Rimel
    {
        public int RimelId { get; set; }
        public string Descricao { get; set; }
        public List<Mensagem> Mensagens { get; set; }
    }
}
