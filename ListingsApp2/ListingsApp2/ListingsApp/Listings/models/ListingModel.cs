using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Listings
{
    class ListingModel
    {
        private string title;
        private string description;
        private float price;
        private string userName;
        private DateTime creationTime;
        private string listingId;
        private string categoryName;

        public ListingModel()
        {
        }

        public ListingModel(string title, string description, float price, string userName, DateTime creationTime, string listingId, string categoryName)
        {
            this.title = title;
            this.description = description;
            this.price = price;
            this.userName = userName;
            this.creationTime = creationTime;
            this.listingId = listingId;
            this.CategoryName = categoryName;
        }

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public float Price { get => price; set => price = value; }
        public string UserName { get => userName; set => userName = value; }
        public DateTime CreationTime { get => creationTime; set => creationTime = value; }
        public string ListingId { get => listingId; set => listingId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }

        public string getModelAsString() // dummy method, just for pringing, remove later
        {
            return title + "|" + description + "|" + price + "|" + creationTime + "|" + categoryName + "|" + userName;
        }
    }
}
