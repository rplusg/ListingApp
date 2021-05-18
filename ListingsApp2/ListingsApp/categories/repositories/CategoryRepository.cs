using ListingsApp.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListingsApp.categories
{
    class CategoryRepository
    {
        Dictionary<string, CategoryModel> catListings = new Dictionary<string, CategoryModel>(); //categoryName, category model
        SortedDictionary<string, int> maxCats = new SortedDictionary<string, int>(); //categoryname, count

        internal bool addListingToACategory(ListingModel listing)
        {
            try
            {
                CategoryModel catModel;
                if (catListings.TryGetValue(listing.CategoryName, out catModel))
                {
                    catModel.ListingsList.Add(listing);
                    catListings[listing.CategoryName] = catModel;
                }
                else
                {
                    catModel = new CategoryModel(listing.CategoryName);
                    catModel.ListingsList.Add(listing);
                    catListings.Add(listing.CategoryName, catModel);
                }

                int catCounter = 1;
                if (maxCats.TryGetValue(listing.CategoryName, out catCounter))
                {
                    maxCats[listing.CategoryName] = ++catCounter;
                }
                else
                {
                    catCounter = 1;
                    maxCats.Add(listing.CategoryName, catCounter);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal IList<ListingModel> getListingsOfTopCategory()
        {
            var max = maxCats.Values.Max();
            var categoryNames = maxCats.Where(pair => max.Equals(pair.Value))
                .Select(pair => pair.Key)
                .ToList();
            CategoryModel catModel;
            if (catListings.TryGetValue(categoryNames[0], out catModel))
            {
                return catModel.ListingsList;
            }
            else
            {
                return null;
            }
        }

        internal string getTopCategory()
        {
            var max = maxCats.Values.Max();
            var categoryNames = maxCats.Where(pair => max.Equals(pair.Value))
                .Select(pair => pair.Key)
                .ToList();
            if (categoryNames.Count > 0)
                return categoryNames[0];
            
            return null;
        }


        internal IList<ListingModel> getListingsInCategory(string categoryName)
        {
            CategoryModel catModel;
            if (catListings.TryGetValue(categoryName, out catModel))
            {
                return catModel.ListingsList;
            }
            else
            {
                return null;
            }
        }

        internal bool deleteListingFromACategory(ListingModel listing)
        {
            try
            {
                CategoryModel catModel;
                if (catListings.TryGetValue(listing.CategoryName, out catModel))
                {
                    ListingModel lmToRemove = catModel.ListingsList.Single(l => l.ListingId == listing.ListingId);
                    catModel.ListingsList.Remove(lmToRemove);
                    catListings[listing.CategoryName] = catModel;
                }

                int catCounter = 1;
                if (maxCats.TryGetValue(listing.CategoryName, out catCounter))
                {
                    maxCats[listing.CategoryName] = --catCounter;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
