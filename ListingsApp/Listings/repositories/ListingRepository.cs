using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListingsApp.Listings
{
    class ListingRepository
    {
        Dictionary<string, ListingModel> listings = new Dictionary<string, ListingModel>(); //Listing Id, listingModel
        //Dictionary<string, List<ListingModel>> catListings = new Dictionary<string, List<ListingModel>>(); //categoryName, list of listing models belong to that category
        //SortedDictionary<string, int> maxCats = new SortedDictionary<string, int>(); //categoryname, count
        internal bool addListing(ListingModel listing)
        {
            try
            {
                listings.Add(listing.ListingId, listing);                
                //List<ListingModel> lmList = new List<ListingModel>();
                //if (catListings.TryGetValue(listing.CategoryName, out lmList))
                //{
                //    lmList.Add(listing);
                //    catListings[listing.CategoryName] = lmList;                     
                //}
                //else
                //{
                //    lmList = new List<ListingModel>();
                //    lmList.Add(listing);
                //    catListings.Add(listing.CategoryName, lmList);
                //}
                //int catCounter = 1;
                //if (maxCats.TryGetValue(listing.CategoryName, out catCounter))
                //{
                //    maxCats[listing.CategoryName] = ++catCounter;
                //}
                //else
                //{
                //    catCounter = 1;
                //    maxCats.Add(listing.CategoryName, catCounter);
                //}

                return true;
            }
            catch (Exception ex)
            {
                return false;            
            }
        }

        internal ListingModel getListing(string listingId)
        {
            try
            {
                ListingModel retModel;

                if (listings.TryGetValue(listingId, out retModel))
                    return retModel;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal bool deleteListing(string v2)
        {
            try
            {
                ListingModel lm = new ListingModel();                
                if (listings.TryGetValue(v2, out lm))
                {
                    return listings.Remove(v2);
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal IList<ListingModel> getAllListings()
        {
            return listings.Values.ToList();
        }
    }
}
