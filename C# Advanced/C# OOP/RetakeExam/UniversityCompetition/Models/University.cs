
namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Utilities.Messages;
    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;

        public University(int id,string name, string category, int capacity, List<int> requiredSubjects)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Capacity = capacity;
            this.requiredSubjects = requiredSubjects;
        }

        public int Id { get { return this.id; } private set { this.id = value; } }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.name = value;
            }
        }
        public string Category
        {
            get { return this.category; }
            private set
            {
                if (value.ToLower() != "technical" && value.ToLower() != "economical" && value.ToLower() != "humanity")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                this.category = value;
            }
        }
        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                this.capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects { get { return this.requiredSubjects; } }
    }
}
