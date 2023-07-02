using Evento.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.DTO
{
    public class EventDetailsDto : EventDto
    {
        public IEnumerable<TicketDto> Tickets { get; set; }
    }
}
