﻿namespace ParentsAbroad.Contracts
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual FamilyDto Family { get; set; }
    }
}