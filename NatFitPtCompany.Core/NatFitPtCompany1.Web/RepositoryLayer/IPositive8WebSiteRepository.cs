using Pos8Company.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos8Company.Web.RepositoryLayer
{
    public interface IPositive8WebSiteRepository : IDisposable
    {
        IQueryable<BusinessContact> GetBusinessContact(int BusinessContactID);
        BusinessContact AddBusinessContact(BusinessContact businessContact);
        IQueryable<OffersContact> GetOffersContact(int OffersContactID);
        OffersContact AddOffersContact(OffersContact offersContact);
    }
}
