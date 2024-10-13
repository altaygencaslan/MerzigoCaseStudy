using ContentAPI.Business.DTOs;
using Helper;
using Helper.CustomHttpClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.HttpClient
{
    public class CustomHttpClient
    {
        private readonly IHttpClientHelper _httpClientHelper;
        public CustomHttpClient(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
            _httpClientHelper.GenerateClient(nameof(ClientCodeEnums.UserService));
        }

        public async Task UpdateUserTotalContentAsync(UpdateUserDto updateItem, CancellationToken token)
        {
            try
            {
                string endpoint = "/User";
                await _httpClientHelper.Put<UpdateUserDto, UpdateUserDto>(endpoint, updateItem, token);
            }
            catch (Exception ex)
            {
                //When fail request to user
            }
        }
    }
}
