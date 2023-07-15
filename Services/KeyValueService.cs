using KeyValuePairAssignment.Data;
using KeyValuePairAssignment.Dto;
using KeyValuePairAssignment.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyValuePairAssignment.Services
{
    public class KeyValueService : IKeyValueService
    {

        private readonly DataContext _dataContext;
        public KeyValueService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public static List<KeyValueModel> keyValues = new List<KeyValueModel>();

        public async Task<List<KeyValueModel>> GetAllKeyValues()
        {
            //var result = new List<KeyValueModel> {
            //new KeyValueModel
            //{
            //    Key=1,Value="Abc"
            //}
            //};

            var result = await _dataContext.KeyValues.ToListAsync();
            if (result == null)
                return null;
            return result;
        }

        public async Task<KeyValueModel>? GetValueByKey(int id)
        {
            var result = await _dataContext.KeyValues.FindAsync(id);
            if (result == null) return null;
            return result;
        }

        public async Task<KeyValueModel> PostKeyValues(ReqPostValues reqModel)
        {
            KeyValueModel keyValueModel = new KeyValueModel {
            Value = reqModel.Value };

            var result = _dataContext.KeyValues.Add(keyValueModel);
            await _dataContext.SaveChangesAsync();
            return keyValueModel;
        }

        public async Task<KeyValueModel>? PutKeyValues(KeyValueModel requestModel)
        {
            try
            {
                var result = await _dataContext.KeyValues.FirstOrDefaultAsync(x => x.Key == requestModel.Key);

                if (result == null)
                    return null;
                result.Key = requestModel.Key;
                result.Value = requestModel.Value;
                await _dataContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<KeyValueModel>? DeleteKeyValues(int id)
        {
            try
            {
                var result = await _dataContext.KeyValues.FirstOrDefaultAsync(x => x.Key == id);
                if (result == null)
                    return null;
                _dataContext.KeyValues.Remove(result);
                await _dataContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

    }
}
