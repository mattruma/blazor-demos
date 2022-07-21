﻿using System.Net.Http.Json;

namespace RazorClassLibrary1
{
    public class NamedHttpClientPersonService
    {
        private readonly HttpClient _httpClient;

        public NamedHttpClientPersonService(
            IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("NamedHttpClient");
        }

        public async Task<PersonList> ListAsync()
        {
            var httpResponseMessage =
                await _httpClient.GetAsync($"api/people");

            httpResponseMessage.EnsureSuccessStatusCode();

            var result =
                await httpResponseMessage.Content.ReadFromJsonAsync<PersonList>();

            if (result == null) return new PersonList();

            return result;
        }
    }
}
