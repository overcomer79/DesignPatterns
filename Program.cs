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

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }


    // low-level
    public class Relationships : IRelationshipBrowser
    {

        // Relationships can  change the way that it stores the relationships. 
        // It can change the underlying data structure because it's never exposed to the high level modules which are actually consuming it.
        private List<(Person, Relationship, Person)> relations
            = new List<(Person, Relationship, Person)>();

        public void AddParent(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var r in relations.Where(
                x => x.Item1.Name == name &&
                x.Item2 == Relationship.Parent
            ))
            {
                yield return r.Item3;
            }
        }

    }

    // high-level module
    public class Research
    {

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("Pierpaolo"))
            {
                Console.WriteLine($"Pierpaolo has a child called {p.Name}");
            }
        }
        static void Main(string[] args)
        {
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
