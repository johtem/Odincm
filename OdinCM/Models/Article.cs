﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NodaTime;
using NodaTime.Extensions;

namespace OdinCM.Models
{
    public class Article
    {
        [Required, Key]
        public string Topic { get; set; }

        [NotMapped]
        public Instant Published { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        // Buddy property (?)
        [Obsolete("This property only exists for EF-serialization purposes")]
        [DataType(DataType.DateTime)]
        [Column("Published")]
        public DateTime PublishedDateTime
        {
            get => Published.ToDateTimeUtc();
            // TODO: Remove this ugly hack
            set => Published = DateTime.SpecifyKind(value, DateTimeKind.Utc).ToInstant();
        }
    }
}