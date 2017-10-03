using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
using Objectivizer.Models;

namespace Objectivizer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Objectivizer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Objectivizer.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            try
            {

                //Level level1 = new Level()
                //{
                //    Name = "Derivco",
                //    Groups = new List<Group>(),
                //    Objectives = new List<Objective>()
                //};

                Organisation derivco = new Organisation()
                {
                    Name = "Derivco",
                    Organisations = new List<Organisation>(),
                    Objectives = new List<Objective>(),
                    Weight = Weight.Company
                };

                Organisation platform = new Organisation()
                {
                    Name = "Platform",
                    Organisations = new List<Organisation>(),
                    Objectives = new List<Objective>(),
                    Weight = Weight.Group
                };

                Organisation casino = new Organisation()
                {
                    Name = "Casino",
                    Organisations = new List<Organisation>(),
                    Objectives = new List<Objective>(),
                    Weight = Weight.Group
                };

                Organisation moneysout = new Organisation()
                {
                    Name = "Money Out",
                    Organisations = new List<Organisation>(),
                    Objectives = new List<Objective>(),
                    Weight = Weight.Team
                };

                Organisation lobby = new Organisation()
                {
                    Name = "Lobby",
                    Organisations = new List<Organisation>(),
                    Objectives = new List<Objective>(),
                    Weight = Weight.Team
                };

                Organisation swift = new Organisation()
                {
                    Name = "Swift",
                    Organisations = new List<Organisation>(),
                    Objectives = new List<Objective>(),
                    Weight = Weight.Team
                };

                //Group group1 = new Group()
                //{
                //    Name = "Platform",
                //    Teams = new List<Team>(),
                //    Objectives = new List<Objective>()
                //};

                //Group group2 = new Group()
                //{
                //    Name = "Casino",
                //    Teams = new List<Team>(),
                //    Objectives = new List<Objective>()
                //};

                //Team moneyOut = new Team()
                //{
                //    Name = "Money Out",
                //    Objectives = new List<Objective>()
                //};

                //Team lobby = new Team()
                //{
                //    Name = "Lobby",
                //    Objectives = new List<Objective>()
                //};

                //Team swift = new Team()
                //{
                //    Name = "Swift",
                //    Objectives = new List<Objective>()
                //};

                Objective levelObjective = new Objective()
                {
                    Description = "Make loads of money",
                    Name = "Main Objective",
                    Weight = 55
                };

                Objective groupObjective = new Objective()
                {
                    Description = "Make good platform software",
                    Name = "Main Platform Objective",
                    Weight = 63
                };

                Objective groupObjective2 = new Objective()
                {
                    Description = "Make all platform apps run faster",
                    Name = "Secondary Platform Objective",
                    Weight = 37
                };

                Objective moneyOutObjective1 = new Objective()
                {
                    Description = "Make the best money out software",
                    Name = "Main Team Objective Objective",
                    Weight = 49
                };

                Objective moneyOutObjective2 = new Objective()
                {
                    Description = "Clear up the technical backlog",
                    Name = "Technical Backlog",
                    Weight = 20
                };

                Objective moneyOutObjective3 = new Objective()
                {
                    Description = "Fix all the bugs",
                    Name = "Bugs",
                    Weight = 31
                };


                Objective lobbyObjective1 = new Objective()
                {
                    Description = "Make the best Lobby in the world",
                    Name = "Main Team Objective Objective",
                    Weight = 56
                };

                Objective lobbyObjective2 = new Objective()
                {
                    Description = "Clear up the technical backlog",
                    Name = "Technical Backlog",
                    Weight = 23
                };

                Objective lobbyObjective3 = new Objective()
                {
                    Description = "Fix all the bugs",
                    Name = "Bugs",
                    Weight = 24
                };

                Objective swiftObjective1 = new Objective()
                {
                    Description = "Deploy Swift Everywhere",
                    Name = "Get Swift Across sites",
                    Weight = 80
                };

                Objective swiftObjective2 = new Objective()
                {
                    Description = "Clear up the technical backlog",
                    Name = "Technical Backlog",
                    Weight = 10
                };

                Objective swiftObjective3 = new Objective()
                {
                    Description = "Fix all the bugs",
                    Name = "Bugs",
                    Weight = 10
                };

                derivco.Organisations.Add(platform);
                derivco.Organisations.Add(casino);
                derivco.Objectives.Add(levelObjective);

                platform.Organisations.Add(moneysout);
                platform.Organisations.Add(lobby);
                platform.Organisations.Add(swift);

                platform.Objectives.Add(groupObjective);
                platform.Objectives.Add(groupObjective2);

                moneysout.Objectives.Add(moneyOutObjective1);
                moneysout.Objectives.Add(moneyOutObjective2);
                moneysout.Objectives.Add(moneyOutObjective3);

                lobby.Objectives.Add(lobbyObjective1);
                lobby.Objectives.Add(lobbyObjective2);
                lobby.Objectives.Add(lobbyObjective3);

                swift.Objectives.Add(swiftObjective1);
                swift.Objectives.Add(swiftObjective2);
                swift.Objectives.Add(swiftObjective3);

                if (!context.Organisations.Any())
                {
                    context.Organisations.AddOrUpdate(l => l.Name, derivco);
                    context.Organisations.AddOrUpdate(l => l.Name, platform);
                    context.Organisations.AddOrUpdate(l => l.Name, casino);
                    context.Organisations.AddOrUpdate(l => l.Name, moneysout);
                    context.Organisations.AddOrUpdate(l => l.Name, lobby);
                    context.Organisations.AddOrUpdate(l => l.Name, swift);

                    context.Users.FirstOrDefault().Organisations = new[] { 1, 2, 3 };
                }

                context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }



        }
    }
}
