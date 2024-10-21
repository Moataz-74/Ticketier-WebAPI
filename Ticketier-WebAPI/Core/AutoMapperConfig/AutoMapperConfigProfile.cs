using AutoMapper;
using Ticketier_WebAPI.Core.DTO;
using Ticketier_WebAPI.Core.Models;

namespace Ticketier_WebAPI.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile:Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CreateTicketDTO, Ticket>();
            CreateMap<Ticket, CreateTicketDTO>();
            CreateMap<UpdateTicketDTO, Ticket>();
        }
    }
}
