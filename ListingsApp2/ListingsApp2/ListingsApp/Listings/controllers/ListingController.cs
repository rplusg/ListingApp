using ListingsApp.categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListingsApp.Listings
{
    class ListingController
    {
        private ListingService listingServiceObj;
        
        private static int listCounter = 0;
        public ListingController()
        {
            listingServiceObj = new ListingService();
            
        }

        internal bool addListing(ListingModel listingModel)
        {            
            return listingServiceObj.addListing(listingModel);
        }

        internal string getNextListingId()
        {
            //new Guid().ToString(); // chosen counter for easy testing of all functions.
            return (++listCounter).ToString();
        }

        internal ListingModel getListing(string userName, string listingId)
        {
            ListingModel lm = listingServiceObj.getListing(listingId);
            if (lm != null && lm.UserName.ToLower() == userName.ToLower())
                return lm;

            return null;
        }

        internal bool deleteListing(string v1, string v2)
        {            
            if (this.getListing(v1, v2) != null)
            {
                return listingServiceObj.deleteListing(v2);
            }
            else
            {
                return false;
            }
        }

        //internal IList<ListingModel> getListingsInCategory(string userName, string categoryName, string sortParam, string type)
        //{
        //    IList<ListingModel> listingModels = listingServiceObj.getListingsInCategory(categoryName);
        //    IList<ListingModel> resultList = new List<ListingModel>();


        //    if (sortParam == "sort_price" && type == "asc")
        //    {
        //        resultList = listingModels.Where(lm => lm.UserName == userName)
        //                     .OrderBy(lm => lm.Price)
        //                     .ToList();
        //    }
        //    else if (sortParam == "sort_price" && type == "dsc")
        //    {
        //        resultList = listingModels.Where(lm => lm.UserName == userName)
        //                 .OrderByDescending(lm => lm.Price)
        //                 .ToList();
        //    }
        //    else if (sortParam == "sort_time" && type == "dsc")
        //    {
        //        resultList = listingModels.Where(lm => lm.UserName == userName)
        //                 .OrderByDescending(lm => lm.CreationTime)
        //                 .ToList();
        //    }
        //    else if (sortParam == "sort_time" && type == "asc")
        //    {
        //        resultList = listingModels.Where(lm => lm.UserName == userName)
        //                 .OrderBy(lm => lm.CreationTime)
        //                 .ToList();
        //    }
        //    return resultList;
        //}

        //internal IList<ListingModel> getListingsOfTopCategory()
        //{
        //    return listingServiceObj.getListingsOfTopCategory();
        //}
    }
}
