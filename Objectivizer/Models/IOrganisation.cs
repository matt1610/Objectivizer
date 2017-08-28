using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objectivizer.Models
{
    public interface IOrganisation
    {
        string Name { get; set; }
        ICollection<Objective> Objectives { get; set; }
    }
}