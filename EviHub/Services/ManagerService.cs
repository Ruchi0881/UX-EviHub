using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;

namespace Evihubportal.data;


public class ManagerService:IManagerService
{
    private readonly IManagerRepository _repository;

    public ManagerService(IManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Manager>> GetAllManagersAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Manager> AddManagerAsync(ManagerDTO dto)
    {
        var manager = new Manager 
        {
            EmpId = dto.EmpId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Mobile = dto.Mobile,
            Email = dto.Email,
        };
        return await _repository.AddAsync(manager);
    }

    public async Task<Manager> UpdateManagerAsync(int managerId, ManagerDTO dto)
    {
        var manager = new Manager
        {
            EmpId = dto.EmpId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Mobile = dto.Mobile,
            Email = dto.Email
        };
        return await _repository.UpdateAsync(managerId, manager);
    }

    public async Task<bool> DeleteManagerAsync(int managerId)
    {
        return await _repository.DeleteAsync(managerId);
    }
}

    