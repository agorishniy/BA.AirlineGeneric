namespace BA.Airline.Tickets
{
    public struct Ticket
    {
        public TicketClass Class { set; get; }
        public decimal Price { set; get; }

        public Ticket(TicketClass ticketClass, decimal price)
        {
            Class = ticketClass;
            Price = price;
        }
    }
}
