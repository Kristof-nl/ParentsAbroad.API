﻿namespace ParentsAbroad.Models.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int FamilyId { get; set; }
        public Family Family { get; set;}
    }
}
