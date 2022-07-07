using FinalProj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Property
    {
        int id;
        String name;
        String description;
        String neighborhood_overview;
        String picture_url;
        String property_type;
        String room_type;
        String accommodates; //number of ppl the property suit
        float bathrooms;
        int bedrooms;
        int beds;
        String amenities;
        int price;
        float review_scores_rating;
        float latitude;
        float longitude;
        int minimum_nights;
        int maximum_nights;
        float distance;


        public Property()
        {

        }

        public Property(int id, string name, string description, string neighborhood_overview, string picture_url, string property_type, string room_type, string accommodates, float bathrooms, int bedrooms, int beds, string amenities, int price, float review_scores_rating, float latitude, float longitude, int minimum_nights, int maximum_nights, float distance)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.neighborhood_overview = neighborhood_overview;
            this.picture_url = picture_url;
            this.property_type = property_type;
            this.room_type = room_type;
            this.accommodates = accommodates;
            this.bathrooms = bathrooms;
            this.bedrooms = bedrooms;
            this.beds = beds;
            this.amenities = amenities;
            this.price = price;
            this.review_scores_rating = review_scores_rating;
            this.latitude = latitude;
            this.longitude = longitude;
            this.minimum_nights = minimum_nights;
            this.maximum_nights = maximum_nights;
            this.distance = distance;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Neighborhood_overview { get => neighborhood_overview; set => neighborhood_overview = value; }
        public string Picture_url { get => picture_url; set => picture_url = value; }
        public string Property_type { get => property_type; set => property_type = value; }
        public string Room_type { get => room_type; set => room_type = value; }
        public string Accommodates { get => accommodates; set => accommodates = value; }
        public float Bathrooms { get => bathrooms; set => bathrooms = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public int Beds { get => beds; set => beds = value; }
        public string Amenities { get => amenities; set => amenities = value; }
        public int Price { get => price; set => price = value; }
        public float Review_scores_rating { get => review_scores_rating; set => review_scores_rating = value; }
        public float Latitude { get => latitude; set => latitude = value; }
        public float Longitude { get => longitude; set => longitude = value; }
        public int Minimum_nights { get => minimum_nights; set => minimum_nights = value; }
        public int Maximum_nights { get => maximum_nights; set => maximum_nights = value; }
        public float Distance { get => distance; set => distance = value; }

        public List<Property> GetAllProperties()
        {
            DBservices DB = new DBservices();
            return DB.GetAllProperties();
        }

      
    }
}