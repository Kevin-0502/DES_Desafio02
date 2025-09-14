using JH200303Desafio2.Entites.Models;

namespace JH200303Desafio2.DAL.Interfaces
{
    public interface IInstructorRepository
    {
        Task<List<Instructor>> GetInstructoresAsync();
        Task<Instructor> GetInstructorByIdAsync(int id);
        Task<int> InsertInstructorAsync(Instructor instructor);
        Task<Instructor> UpdateInstructorAsync(Instructor instructor);
        Task<bool> DeleteInstructorAsync(int id);
    }
}
