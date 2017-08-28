using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Objectivizer.Models
{
    public class Level : IOrganisation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
    }
}