using ListingsApp.Listings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.categories
{
    class CategoryModel
    {        
        private string categoryName;
        private CategoryModel parentCategory; //Not being used yet.
        private List<ListingModel> listingsList;

        public CategoryModel(string categoryName, CategoryModel parentCategory=null)
        {
            this.CategoryName = categoryName;
            this.ParentCategory = parentCategory;
            this.ListingsList = new List<ListingModel>();
        }

        public string CategoryName { get => categoryName; set => categoryName = value; }
        internal CategoryModel ParentCategory { get => parentCategory; set => parentCategory = value; }
        internal List<ListingModel> ListingsList { get => listingsList; set => listingsList = value; }
    }
}
