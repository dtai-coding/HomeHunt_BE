﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class User : BaseEntity
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Gender { get; set; }

    public DateTime Dob { get; set; }

    public string Address { get; set; }

    public double Rating { get; set; }

    public Guid RoleId { get; set; }

    public virtual ICollection<RoomApplication> Applications { get; set; } = new List<RoomApplication>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual Role Role { get; set; }
}