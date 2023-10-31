using api.Models.DB;

namespace api.Repositories.EntityRepositories.Interfaces
{
    public interface ISubjectRepository : IRepository<SubjectModel>
    {
        Task<SubjectModel> GetSubjectWithMaterials(Ulid id);

        Task<IEnumerable<SubjectModel?>> GetSubjectsWithMaterials(Func<SubjectModel, bool> predicate);
    }
}