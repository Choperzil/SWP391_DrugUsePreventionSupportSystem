﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class ConsultantsAvailability
{
    public int AvailabilityId { get; set; }

    public int? ConsultantId { get; set; }

    public string DayOfWeek { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Consultant Consultant { get; set; }
}