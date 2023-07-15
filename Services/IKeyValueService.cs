using KeyValuePairAssignment.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KeyValuePairAssignment.Services
{
    public interface IKeyValueService
    {
        Task<List<KeyValueModel>> GetAllKeyValues();
        Task<KeyValueModel>? GetValueByKey(int id);
        Task<KeyValueModel> PostKeyValues(ReqPostValues keyValueModel);
        Task<KeyValueModel>? PutKeyValues(KeyValueModel keyValueModel);
        Task<KeyValueModel>? DeleteKeyValues(int id);

    }
}
