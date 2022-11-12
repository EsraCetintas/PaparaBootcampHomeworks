﻿using Microsoft.AspNetCore.Http;
using System;

namespace Owner.API.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
