using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainInfoSystem.Data;
using TrainInfoSystem.Models;

namespace TrainInfoSystem.Controllers
{
    public class HomeController : Controller
    {
        //    private readonly ApplicationDbContext _context;

        //    public HomeController(ApplicationDbContext context)
        //    {
        //        _context = context;
        //    }

        //    public IActionResult Index() => View();

        //    [HttpGet]
        //    public IActionResult SearchTrain() => View();

        //    [HttpPost]
        //    public IActionResult SearchTrain(string query)
        //    {
        //        var trains = _context.Trains.Include(t => t.TrainClasses).ThenInclude(tc => tc.Class)
        //                        .Where(t => t.TrainName.Contains(query) || t.TrainNumber.Contains(query)).ToList();
        //        ViewBag.Fares = _context.Fares.ToList();
        //        return View("TrainResults", trains);
        //    }

        //    [HttpPost]
        //    public IActionResult BookTicket(int trainId, int classId, string passengerName, DateTime journeyDate)
        //    {
        //        var booking = new Booking { TrainId = trainId, ClassId = classId, PassengerName = passengerName, JourneyDate = journeyDate };
        //        _context.Bookings.Add(booking);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    [HttpGet]
        //    public IActionResult PNRStatus() => View();

        //    [HttpPost]
        //    public IActionResult PNRStatus(string pnr)
        //    {
        //        var result = _context.PNRs.Include(p => p.Booking).ThenInclude(b => b.Train).FirstOrDefault(p => p.PNRNumber == pnr);
        //        return View("PNRResult", result);
        //    }

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // The default action will render the home page with options
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult SearchTrain() => View();

        [HttpPost]
        public IActionResult SearchTrain(string query)
        {
            var trains = _context.Trains.Include(t => t.TrainClasses).ThenInclude(tc => tc.Class)
                            .Where(t => t.TrainName.Contains(query) || t.TrainNumber.Contains(query)).ToList();
            ViewBag.Fares = _context.Fares.ToList();
            return View("TrainResults", trains);
        }

        [HttpPost]
        public IActionResult BookTicket(int trainId, int classId, string passengerName, DateTime journeyDate)
        {
            var booking = new Booking { TrainId = trainId, ClassId = classId, PassengerName = passengerName, JourneyDate = journeyDate };
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PNRStatus() => View();

        [HttpPost]
        public IActionResult PNRStatus(string pnr)
        {
            var result = _context.PNRs.Include(p => p.Booking).ThenInclude(b => b.Train).FirstOrDefault(p => p.PNRNumber == pnr);
            return View("PNRResult", result);
        }
    }

    // Controllers/AdminController.cs
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // The default action will render the home page with options
        public IActionResult Admin() => View();

        [HttpGet("add-train")]
        public IActionResult AddTrain() => View();

        [HttpPost("add-train")]
        public IActionResult AddTrain(Train train)
        {
            _context.Trains.Add(train);
            _context.SaveChanges();
            return RedirectToAction("AddTrain");
        }

        [HttpGet("pending-bookings")]
        public IActionResult PendingBookings() => View(_context.Bookings.Where(b => b.PNR == null).Include(b => b.Train).ToList());

        [HttpPost("confirm-booking")]
        public IActionResult ConfirmBooking(int bookingId, string coach, string berth)
        {
            var pnr = new PNR
            {
                BookingId = bookingId,
                PNRNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                Coach = coach,
                BerthNumber = berth,
                Status = "Confirmed"
            };
            _context.PNRs.Add(pnr);
            _context.SaveChanges();
            return RedirectToAction("PendingBookings");
        }

        [HttpGet("confirmed-bookings")]
        public IActionResult ConfirmedBookings() => View(_context.Bookings.Include(b => b.Train).Include(b => b.PNR).ToList());
    }
}
