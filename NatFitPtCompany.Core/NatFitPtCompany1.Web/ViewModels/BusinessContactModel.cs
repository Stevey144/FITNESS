using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos8Company.Web.ViewModels
{
    public class BusinessContactModel
    {
        public int BusinessContactID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrgansiationEmail { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public bool IncludeInMailingLIst { get; set; }
    }
}
