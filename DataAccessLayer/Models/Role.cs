﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Role : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}