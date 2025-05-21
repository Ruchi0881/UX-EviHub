using AutoMapper;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;
using EviHub.Services.Interfaces;

namespace Evihubportal.data;


public class ManagerService:IManagerService
{
    private readonly IManagerRepository _managerrepository;
    private readonly IMapper _mapper;

    public ManagerService(IManagerRepository managerrepository,IMapper mapper)
    {
        _managerrepository = managerrepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ManagerDTO>> GetAllManagersAsync()
    {
        var man = await _managerrepository.GetAllAsync();
        return _mapper.Map<List<ManagerDTO>>(man);
    }

    

    public async Task<ManagerDTO> AddManagerAsync(ManagerDTO dto)
    {
        var man = _mapper.Map<Manager>(dto);
        var addedman = await _managerrepository.AddAsync(man);
        return _mapper.Map<ManagerDTO>(addedman);
     
    }

    public async Task<ManagerDTO> UpdateManagerAsync(int id, ManagerDTO dto)
    {
        var existingman =await _managerrepository.GetByIdAsync(id);
        if (existingman == null) return null;

        existingman.EmpId = dto.EmpId;
        existingman.FirstName = dto.FirstName;
        existingman.LastName = dto.LastName;
        existingman.Mobile = dto.Mobile;
        existingman.Email = dto.Email;
        var updated = await _managerrepository.UpdateAsync(id,existingman);
        return _mapper.Map<ManagerDTO>(existingman);
    }
    public async Task<ManagerDTO> GetManagerByIdAsync(int id)
    {
        var man = await _managerrepository.GetByIdAsync(id);
        return _mapper.Map<ManagerDTO>(man);
    }

    public async Task<bool> DeleteManagerAsync(int id)
    {
        var existing = await _managerrepository.GetByIdAsync(id);
        if (existing == null) 
        {
            throw new Exception("Manager not Found");
        }
        else
        {
            await _managerrepository.DeleteAsync(id);
            return true;
        }

    }

    
}

    