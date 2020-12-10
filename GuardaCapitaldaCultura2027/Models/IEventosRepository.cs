using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class IEventosRepository
    {
        public IEnumerable<Evento> Evento { get; }
    }
}
