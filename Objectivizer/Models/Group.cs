using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Objectivizer.Models
{
    public class Group : IOrganisation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int LevelId { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
    }
}