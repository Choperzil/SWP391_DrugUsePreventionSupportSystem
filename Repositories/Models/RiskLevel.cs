﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class RiskLevel
{
    public int RiskId { get; set; }

    public string RiskLevel1 { get; set; }

    public string RiskDescription { get; set; }

    public virtual ICollection<UserAssessment> UserAssessments { get; set; } = new List<UserAssessment>();
}