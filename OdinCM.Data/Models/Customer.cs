using NodaTime;
using NodaTime.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Data.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Display(Name = "Customer name")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string CustomerName { get; set; }

        [NotMapped]
        public Instant CreatedAt { get; set; }

        [NotMapped]
        public Instant UpdatedAt { get; set; }


        // Buddy property (?)
        [Obsolete("This property only exists for EF-serialization purposes")]
        [DataType(DataType.DateTime)]
        [Column("CreatedAt")]
        public DateTime CreatedAtDateTime
        {
            get => CreatedAt.ToDateTimeUtc();
            // TODO: Remove this ugly hack
            set => CreatedAt = DateTime.SpecifyKind(value, DateTimeKind.Utc).ToInstant();
        }

        // Buddy property (?)
        [Obsolete("This property only exists for EF-serialization purposes")]
        [DataType(DataType.DateTime)]
        [Column("UpdatedAt")]
        public DateTime UpdatedAtDateTime
        {
            get => UpdatedAt.ToDateTimeUtc();
            set => UpdatedAt = DateTime.SpecifyKind(value, DateTimeKind.Utc).ToInstant();
        }

  
       

   }
}
