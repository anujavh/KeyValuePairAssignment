
using KeyValuePairAssignment.Dto;
using KeyValuePairAssignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KeyValuePairAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyValuesController : ControllerBase
    {
        private readonly IKeyValueService _keyValueService;

        public KeyValuesController(IKeyValueService keyValueService)
        {
            _keyValueService = keyValueService;
        }

        [HttpGet]
        public async Task<ActionResult<List<KeyValueModel>>> GetAllKeys()
        {
            //var result = new List<KeyValueModel> {
            //new KeyValueModel
            //{
            //    Key=1,Value="Abc"
            //}
            //};

            return await _keyValueService.GetAllKeyValues();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KeyValueModel>>? GetValueByKey(int id)
        {
            var result = await _keyValueService.GetValueByKey(id);
            if (result == null)
                return NotFound("Key Value Not Found");
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<KeyValueModel>>> PostKeyValues(ReqPostValues keyValueModel)
        {
            var result = await _keyValueService.PostKeyValues(keyValueModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<KeyValueModel>>> DeleteKeyValues(int id)
        {
            var result = await _keyValueService.DeleteKeyValues(id);
            if (result == null)
                return NotFound("Key Not Found");
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult<List<KeyValueModel>>> PutKeyValues(KeyValueModel request)
        {
            var result = await _keyValueService.PutKeyValues(request);
            if (result == null)
                return NotFound("Key Not Found");
            return Ok(result);

        }
    }
}
