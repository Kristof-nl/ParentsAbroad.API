﻿using ParentsAbroad.Models.Models.Interfaces;

namespace ParentsAbroad.Models.Models
{
    public class Parent : Person, IEntity
    {
        public IList<ParentLanguage> Languages { get; set; }
    }
}
