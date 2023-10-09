using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos8Company.Web.Models
{
    public class OffersContact
    {
        public int OffersContactID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganisationEmail { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public bool IncludeInMailingLIst { get; set; }
        public string Message { get; set; }

    }
}
