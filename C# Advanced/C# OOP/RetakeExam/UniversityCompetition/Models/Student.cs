
namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Utilities.Messages;
    public class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private List<int> coveredExams;
        private IUniversity university;

        public Student(int studentId,string firstName,string lastName)
        {
            this.Id= studentId;
            this.FirstName= firstName;
            this.LastName= lastName;
            this.coveredExams = new List<int>();

        }

        public int Id { get { return this.id; } private set { this.id = value; } }
        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                this.lastName = value;
            }
        }
        public IReadOnlyCollection<int> CoveredExams { get { return this.coveredExams; } }
        public IUniversity University { get { return this.university;} private set { this.university = value;} }

        public void CoverExam(ISubject subject)
        {
            this.coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.University = university;
        }
    }
}
