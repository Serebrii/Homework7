using System;

namespace Facade
{
    internal class Program
    {
        class FlightAvailability
        {
            public void CheckAvailability()
            {
                Console.WriteLine("Checking flight availability...");
            }
        }

        class SeatReservation
        {
            public void ReserveSeat()
            {
                Console.WriteLine("Reserving seat...");
            }
        }


        class PaymentProcessing
        {
            public void ProcessPayment()
            {
                Console.WriteLine("Processing payment...");
            }
        }

        class BookingConfirmation
        {
            public void SendConfirmation()
            {
                Console.WriteLine("Sending booking confirmation...");
            }
        }

        class BookingFacade
        {
            FlightAvailability flightAvailability;
            SeatReservation seatReservation;
            PaymentProcessing paymentProcessing;
            BookingConfirmation bookingConfirmation;

            public BookingFacade()
            {
                flightAvailability = new FlightAvailability();
                seatReservation = new SeatReservation();
                paymentProcessing = new PaymentProcessing();
                bookingConfirmation = new BookingConfirmation();
            }

            public void BookFlight()
            {
                Console.WriteLine("\nBooking Flight ---- ");
                flightAvailability.CheckAvailability();
                seatReservation.ReserveSeat();
                paymentProcessing.ProcessPayment();
                bookingConfirmation.SendConfirmation();
                Console.WriteLine("Flight booking completed.");
            }
        }
        static void Main(string[] args)
        {
            BookingFacade facade = new BookingFacade();
            facade.BookFlight();

            Console.Read();
        }
    }
}
