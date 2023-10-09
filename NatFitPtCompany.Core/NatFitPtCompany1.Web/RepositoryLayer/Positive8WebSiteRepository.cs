using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pos8Company.Web.Models;

namespace Pos8Company.Web.RepositoryLayer
{
    public class Positive8WebSiteRepository : IPositive8WebSiteRepository
    {

        private readonly Positive8WebSiteContext DbContext;
        private Boolean Disposed;

        public Positive8WebSiteRepository(Positive8WebSiteContext dbContext)
        {
            DbContext = dbContext;
        }

        public BusinessContact AddBusinessContact(BusinessContact businessContact)
        {

            var entityret = GetBusinessContact(businessContact.BusinessContactID).Count();

            if (entityret == 0)
            {
                DbContext.Set<BusinessContact>().Add(businessContact);

                DbContext.SaveChanges();
            }

            return businessContact;
        }

        public IQueryable<BusinessContact> GetBusinessContact(int BusinessContactID)
        {
            return DbContext.Set<BusinessContact>().Where(item => item.BusinessContactID == BusinessContactID);
        }

        public OffersContact AddOffersContact(OffersContact offersContact)
        {

            var entityret = GetOffersContact(offersContact.OffersContactID).Count();

            if (entityret == 0)
            {
                DbContext.Set<OffersContact>().Add(offersContact);

                DbContext.SaveChanges();
            }

            return offersContact;
        }

        public IQueryable<OffersContact> GetOffersContact(int OffersContactID)
        {
            return DbContext.Set<OffersContact>().Where(item => item.OffersContactID == OffersContactID);
        }


        #region IDisposable Support


        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CSAERPRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }

        #endregion
    }
}
