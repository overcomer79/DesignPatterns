using System;
using System.Collections.Generic;
using System.Linq;

namespace patterns
{

    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        public DateTime DateOfBirth;
    }


    // low-level

    public class Relationships
    {
        private List<(Person, Relationship, Person)> relations
            = new List<(Person, Relationship, Person)>();

        public void AddParent(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;

    }

    // high-level module
    public class Research
    {

        // The problem with this scenario is that we're accessing a very low level part of the relationships class 
        // where accessing its data store and where accessing it through specifically designed property which exposes the private thing has public.
        // And what this means in practice? That relationships cannot change its mind about how to store the relations
        public Research(Relationships relationships)
        {
            var relations = relationships.Relations;
            foreach (var r in relations
            .Where(
                x => x.Item1.Name == "Pierpaolo" &&
                x.Item2 == Relationship.Parent
            )
            )
            {
                Console.WriteLine($"Pierpaolo has a child called {r.Item3.Name}");
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("SONJO QUI!!!");
            var parent = new Person { Name = "Pierpaolo" };
            var child1 = new Person { Name = "Gloria" };
            var child2 = new Person { Name = "Unkwon" };

            var relationships = new Relationships();
            relationships.AddParent(parent, child1);
            relationships.AddParent(parent, child2);

            new Research(relationships);
        }
    }
}
