using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface IBrandRepository
{
    IEnumerable<Brand> GetAll();
    Brand? GetById(int id);
    void Update(Brand brand);
    void Delete(int id);
}