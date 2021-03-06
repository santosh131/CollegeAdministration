﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeAdministration.Models
{
    public class Student
    {
        [BsonId]
        public ObjectId Id{ get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile{ get; set; }
        public bool ActiveInd { get; set; }
    }
}