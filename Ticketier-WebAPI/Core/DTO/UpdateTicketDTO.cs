namespace Ticketier_WebAPI.Core.DTO
{
    public class UpdateTicketDTO
    {
        public DateTime Time { get; set; }
        public string PassengerName { get; set; }
        public long PassengerSSN { get; set; }
        public int Price { get; set; }
    }
}
