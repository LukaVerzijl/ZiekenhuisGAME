using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.ApiClient.ModelApiClients;
using Code.ApiClient.Models;
using Code.Utils;
using Newtonsoft.Json;
using UnityEngine;

public class ApiManager : Singleton<ApiManager>
{
    public User user;
    public Client client;

    [Header("Dependencies")]
    public GameObject ApiClientObject;

    
    private GameObject spawnedApiClient;
    private UserApiClient userApiClient;
    private ClientsApiClient clientsApiClient;

    public bool isLoggedIn = false;

    #region Init

    private new void Awake()
    {
        spawnedApiClient = Instantiate(ApiClientObject, this.gameObject.transform);
        
        userApiClient = spawnedApiClient.GetComponent<UserApiClient>();
        clientsApiClient = spawnedApiClient.GetComponent<ClientsApiClient>();
        
        DontDestroyOnLoad(this.gameObject.transform.root.gameObject);
    }

    #endregion
    #region Login

    [ContextMenu("User/Register")]
    public async Task<bool> Register()
    {
        
        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Register succes!");
                if (await Login())
                {
                    return true;
                }
                return false;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Register error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                return false;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("User/Login")]
    public async Task<bool> Login()
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Login succes!");
                isLoggedIn = true;
                return true;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Login error: " + errorMessage);
                return false;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
        
    }

    #endregion

    #region Client
    
    public async Task<bool> GetClientData()
    {
        
        IWebRequestReponse webRequestResponse = await clientsApiClient.getClient(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Loaded Client data");
                var clients = JsonConvert.DeserializeObject<List<Client>>(dataResponse.Data);
                if (clients != null && clients.Count > 0)
                {
                    client = clients[0];
                    Debug.Log($"Client loaded: {client.KindNaam}");
                    return true;
                }
                return false;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Failed to get client data: " + errorMessage);
                return false;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    public async Task<bool> CreateClientData()
    {
        IWebRequestReponse webRequestResponse = await clientsApiClient.createClientData(client);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Created client data");
                return true;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Failed to create client data: " + errorMessage);
                return false;
            default:
                return true;
        }
        
    }
    #endregion
}
