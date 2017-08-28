using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Objectivizer.Models
{
    public class Team : IOrganisation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
    }
}