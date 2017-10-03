using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Objectivizer.Models
{
    public class Objective
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectiveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int OrganisationId { get; set; }
        public bool Completed { get; set; }
        public string Comments { get; set; }
        public string Creator { get; set; }
    }
}