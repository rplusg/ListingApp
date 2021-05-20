using ListingsApp.Listings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.categories
{
    class CategoryService
    {
        CategoryRepository categoryRepositoryObj;

        public CategoryService()
        {
            this.categoryRepositoryObj = new CategoryRepository();
        }

        internal IList<ListingModel> getListingsOfTopCategory()
        {
            return this.categoryRepositoryObj.getListingsOfTopCategory();
        }

        internal IList<ListingModel> getListingsInCategory(string categoryName)
        {
            return this.categoryRepositoryObj.getListingsInCategory(categoryName);
        }

        internal bool addListingToACategory(ListingModel listingModel)
        {
            return this.categoryRepositoryObj.addListingToACategory(listingModel);
        }

        internal bool deleteListingFromACategory(ListingModel listingModel)
        {
            return this.categoryRepositoryObj.deleteListingFromACategory(listingModel);
        }

        internal string getTopCategory()
        {
            return this.categoryRepositoryObj.getTopCategory();
        }
    }
}
