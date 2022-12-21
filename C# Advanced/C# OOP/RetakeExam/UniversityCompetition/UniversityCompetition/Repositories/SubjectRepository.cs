namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Contracts;
    using Contracts;
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> models;

        public SubjectRepository()
        {
            this.models = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => this.models.AsReadOnly(); 

        public void AddModel(ISubject model)
        {
            this.models.Add(model);
        }
        public ISubject FindById(int id)
        {
            return this.models.FirstOrDefault(x => x.Id == id);
        }
        public ISubject FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
