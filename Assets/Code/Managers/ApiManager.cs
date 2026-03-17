using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Utils;
using UnityEngine;

public class ApiManager : Singleton<ApiManager>
{
    [Header("Test data")]
    public User user;

    [Header("Dependencies")]
    public GameObject ApiClientObject;

    
    private GameObject spawnedUserApiClient;
    private UserApiClient userApiClient;


    #region Init

    private new void Awake()
    {
        spawnedUserApiClient = Instantiate(ApiClientObject, this.gameObject.transform);
        
        userApiClient = spawnedUserApiClient.GetComponent<UserApiClient>();
        
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
    
}
