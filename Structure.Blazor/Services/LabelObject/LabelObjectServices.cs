using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using Structure.Domain.LabelObjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
//using System.Text.Json;
using System.Threading.Tasks;

namespace Structure.Blazor.Services.LabelObject
{
    public class LabelObjectServices : ILabelObjectServices
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        private readonly ILogger<LabelObjectServices> _log;

        public LabelObjectServices(IMapper mapper, HttpClient client, ILogger<LabelObjectServices> log)
        {
            _mapper = mapper;
            _client = client;
            _log = log;
        }
        public async Task<LabelObjectDto> CreateLabel(LabelObjectCreateDto labelObjectCreate)
        {
            var labelToCreate = _mapper.Map<Structure.Domain.LabelObjects.LabelObject>(labelObjectCreate);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri("https://localhost:44345/api/app/label-objects"),
                Content = JsonContent.Create(labelToCreate)
            };

            //https://docs.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-5.0

            //requestMessage.Content.Headers.ContentType =new System.Net.Http.Headers.MediaTypeHeaderValue( "application/json");
            var response = await _client.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var created = JsonConvert.DeserializeObject<Structure.Domain.LabelObjects.LabelObject>(responseBody);
            return _mapper.Map<LabelObjectDto>(created);
        }

        public Task DeleteLabelObject(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<LabelObjectDto> GetLabel(Guid id)
        {
            //return await JsonSerializer.DeserializeAsync<LabelObjectDto>
            //    (await _client.GetStreamAsync($"https://localhost:44345/api/app/label-objects/{id}"),
            //    new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});

            var result = await _client.GetStringAsync($"https://localhost:44345/api/app/label-objects/{id}");
            return JsonConvert.DeserializeObject<LabelObjectDto>(result);
        }

        public async Task<List<LabelObjectDto>> GetList()
        {
            //return await JsonSerializer.DeserializeAsync<List<LabelObjectDto>>
            //    (await _client.GetStreamAsync("https://localhost:44345/api/app/label-objects"), 
            //    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); 

            
            var result= await _client.GetStringAsync("https://localhost:44345/api/app/label-objects" );
            return JsonConvert.DeserializeObject<List<LabelObjectDto>>(result);

            //return await _client.GetFromJsonAsync<List<LabelObjectDto>>("https://localhost:44345/api/app/label-objects");
        }

        public Task<LabelObjectDto> UpdateLabel(Guid id,LabelObjectUpdateDto labelObjectUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
