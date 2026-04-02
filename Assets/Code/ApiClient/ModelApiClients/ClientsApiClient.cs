using Code.ApiClient.Models;
using Newtonsoft.Json;
using UnityEngine;

namespace Code.ApiClient.ModelApiClients
{
    public class ClientsApiClient : MonoBehaviour
    {
        public WebClient webClient;

        public async Awaitable<IWebRequestReponse> getClient(User user)
        {
            string route = $"/client";
            string data = JsonConvert.SerializeObject(user, JsonHelper.CamelCaseSettings);

            return await webClient.SendGetRequest(route);
        }

        public async Awaitable<IWebRequestReponse> createClientData(Client client)
        {
            string route = "/client";
            string data = JsonConvert.SerializeObject(client, JsonHelper.CamelCaseSettings);

            IWebRequestReponse response = await webClient.SendPostRequest(route, data);
            return parseClientData(response);
        }
        
        private IWebRequestReponse parseClientData(IWebRequestReponse webRequestResponse)
        {
            switch (webRequestResponse)
            {
                case WebRequestData<string> data:
                    Debug.Log("Response data raw: " + data.Data);
                    Client client = JsonConvert.DeserializeObject<Client>(data.Data);
                    WebRequestData<Client> parsedWebRequestData = new WebRequestData<Client>(client);
                    return parsedWebRequestData;
                default:
                    return webRequestResponse;
            }
        }

    }
}