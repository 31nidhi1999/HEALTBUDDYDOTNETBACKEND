using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HealthBuddyDotnetBE.Entities;

namespace Health.Entity
{
    [Table("Hospital")]
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public bool IsActive { get; set; } = true;

        [InverseProperty("Hospitals")]
        public ISet<Doctor> Doctors { get; set; }


        
    }
}
