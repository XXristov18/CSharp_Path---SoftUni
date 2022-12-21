using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        
        public string AddStudent(string firstName, string lastName)
        {
            if(students.FindByName(firstName+" "+lastName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            else
            {
                IStudent student = new Student(students.Models.Count + 1, firstName, lastName);
                students.AddModel(student);
                return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
            }
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType!= "EconomicalSubject" && subjectType != "HumanitySubject" && subjectType != "TechnicalSubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            else
            {
                ISubject subject ;
                switch (subjectType)
                {
                    case "EconomicalSubject": 
                        subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName); 
                        subjects.AddModel(subject);
                        break;
                    case "HumanitySubject": 
                        subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
                        subjects.AddModel(subject);
                        break;
                    case "TechnicalSubject": 
                        subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
                        subjects.AddModel(subject);
                        break;
                }
                return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType,subjectName,subjects.GetType().Name);
            }
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName)!=null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            else
            {
                List<int> requiredSubjectsId = new List<int>();
                foreach (var item in requiredSubjects)
                {
                    ISubject subject = subjects.Models.FirstOrDefault(x => x.Name == item);
                    requiredSubjectsId.Add(subject.Id);
                }
                IUniversity university = new University(universities.Models.Count + 1, universityName, category, capacity, requiredSubjectsId);
                universities.AddModel(university);
                return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName,universities.GetType().Name);
            }
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IUniversity university = universities.FindByName(universityName);
            IStudent student = students.FindByName(studentName);
            string[] names = studentName.Split(' ');
            string firstName = names[0];
            string lastName = names[1];
            int count = 0;
            foreach (int id in university.RequiredSubjects)
            {
                if (student.CoveredExams.Contains(id))
                {
                    count++;
                }
            }
            if (student==null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            else if (university==null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if (count<university.RequiredSubjects.Count)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName,universityName);
            }
            else if (student.University == university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName,universityName);
            }
            else
            {
                student.JoinUniversity(university);
                return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
            }
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);
            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }
            else if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            else if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }
            else
            {
                student.CoverExam(subject);
                return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
            }
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            List<IStudent> studentS = students.Models.Where(x => x.University == university).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***")
                .AppendLine($"Profile: {university.Category}")
                .AppendLine($"Students admitted: {studentS.Count}")
                .AppendLine($"University vacancy: {university.Capacity - studentS.Count}");
            return sb.ToString().TrimEnd();
        }
    }
}
