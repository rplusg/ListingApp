using ListingsApp.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListingsApp.categories
{
    class CategoryController
    {
        private CategoryService categoryServiceObj;

        public CategoryController()
        {
            this.categoryServiceObj = new CategoryService();
        }

        internal IList<ListingModel> getListingsInCategory(string userName, string categoryName, string sortParam, string type)
        {
            IList<ListingModel> listingModels = categoryServiceObj.getListingsInCategory(categoryName);
            IList<ListingModel> resultList = new List<ListingModel>();

            if (listingModels==null || listingModels.Count == 0)
                return null;

            if (sortParam == "sort_price" && type == "asc")
            {
                resultList = listingModels.Where(lm => lm.UserName == userName)
                             .OrderBy(lm => lm.Price)
                             .ToList();
            }
            else if (sortParam == "sort_price" && type == "dsc")
            {
                resultList = listingModels.Where(lm => lm.UserName == userName)
                         .OrderByDescending(lm => lm.Price)
                         .ToList();
            }
            else if (sortParam == "sort_time" && type == "dsc")
            {
                resultList = listingModels.Where(lm => lm.UserName == userName)
                         .OrderByDescending(lm => lm.CreationTime)
                         .ToList();
            }
            else if (sortParam == "sort_time" && type == "asc")
            {
                resultList = listingModels.Where(lm => lm.UserName == userName)
                         .OrderBy(lm => lm.CreationTime)
                         .ToList();
            }
            return resultList;
        }

        internal bool addListingToACategory(ListingModel listingModel)
        {
            return this.categoryServiceObj.addListingToACategory(listingModel);
        }

        internal IList<ListingModel> getListingsOfTopCategory()
        {
            return this.categoryServiceObj.getListingsOfTopCategory();
        }

        internal bool deleteListingFromACategory(ListingModel listingModel)
        {
            return this.categoryServiceObj.deleteListingFromACategory(listingModel);
        }

        internal string getTopCategory()
        {
            return this.categoryServiceObj.getTopCategory();
        }
    }
}
