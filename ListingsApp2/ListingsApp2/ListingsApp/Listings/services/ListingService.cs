using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Listings
{
    class ListingService
    {
        private ListingRepository listingRepositoryobj;
        public ListingService()
        {
            listingRepositoryobj = new ListingRepository();
        }

        internal bool addListing(ListingModel listingModel)
        {
            return listingRepositoryobj.addListing(listingModel);
        }

        internal ListingModel getListing(string listingId)
        {
            return listingRepositoryobj.getListing(listingId);
        }

        internal bool deleteListing(string v2)
        {
            return listingRepositoryobj.deleteListing(v2);
        }

        //internal IList<ListingModel> getListingsInCategory(string categoryName)
        //{
        //    return listingRepositoryobj.getListingsInCategory(categoryName);
        //}

        //internal IList<ListingModel> getListingsOfTopCategory()
        //{
        //    return listingRepositoryobj.getListingsOfTopCategory();
        //}
    }
}
