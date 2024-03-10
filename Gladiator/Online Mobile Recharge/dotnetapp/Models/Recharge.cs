// using System;
// using dotnetapp.Data;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Text.Json.Serialization;

// namespace dotnetapp.Models
// {
//     public class Recharge
//   {
//     public long RechargeId { get; set; }
//     public int Price { get; set; }
//     public DateTime RechargeDate { get; set; }
//     public DateTime ValidityDate { get; set; }

//     // Foreign key for User table
//     [ForeignKey("User")]
//     public long UserId { get; set; }

//     // Foreign key for Plan table
//     [ForeignKey("Plan")]
//     public long PlanId { get; set; }
//    [JsonIgnore]
//     // Navigation properties
//     public virtual User? User { get; set; }
//     [JsonIgnore]
//     public virtual Plan? Plan { get; set; }
//   }
// }


using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace dotnetapp.Models
{
    public class Recharge
    {
        public long RechargeId { get; set; }
        public int Price { get; set; }
        public DateTime RechargeDate { get; set; }
        public DateTime ValidityDate { get; set; }

        // Foreign key for User table
        [ForeignKey("User")]
        public long UserId { get; set; }

        // Foreign key for Plan table
        [ForeignKey("Plan")]
        public long PlanId { get; set; }
        public long MobileNumber { get; set; }
        public long MobileOperator { get; set; }

        // Foreign key for Addon table
        [ForeignKey("Addon")]
        public long? AddonId { get; set; }

        [JsonIgnore]
        // Navigation properties
        public virtual User? User { get; set; }
        [JsonIgnore]
        public virtual Plan? Plan { get; set; }

        // Navigation property for Addon
        [JsonIgnore]
        public virtual Addon? Addon { get; set; }
    }
}


