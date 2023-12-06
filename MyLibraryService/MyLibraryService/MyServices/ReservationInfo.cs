using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLibraryService.MyServices
{
    public class ReservationInfo
    {
        public int ReservationId { get; set; }
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime? DateOfReservation { get; set; }
    }
}