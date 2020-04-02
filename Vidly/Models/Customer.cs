﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name="Membership Type")]
        public MembershipType MembershipType { get; set; }

        [ForeignKey("MembershipType")]
        public byte MembershipId { get; set; }

        [Display(Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirtDate { get; set; }
    }
}