using System;
using Wild.Piccolo.Domain.Catalog;

namespace Wild.Piccolo.Domain.Catalog
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public List<Rating> Ratings { get; set; } = new List<Rating>();


        public Item(string name, string description, string brand, decimal price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (string.IsNullOrEmpty(brand))
            {
                throw new ArgumentNullException(nameof(brand));
            }

            if (price < 0.00m)
            {
                // A common practice for this is to use nameof(price) to clearly
                // indicate which parameter caused the exception, though the original 
                // code did not, so I've matched the original's message.
                throw new ArgumentException("Price must be greater than zero.");
            }

            Name = name;
            Description = description;
            Brand = brand;
            Price = price;
        }

        public void AddRating(Rating rating)
        {
            this.Ratings.Add(rating);
        }


    }
    


}