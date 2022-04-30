using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
using Oculus.Platform;
using Oculus.Platform.Models;

public class GetOculusUsername : MonoBehaviour
{
    public string OculusUserName;
    public string OculusDisplayName;

    private void Start()
    {
        string appid = "PRIVATE";
        Oculus.Platform.Core.AsyncInitialize(appid);

        Oculus.Platform.Entitlements.IsUserEntitledToApplication().OnComplete(EntitledCallback);
    }

    void EntitledCallback(Message msg)
    {
        if (!msg.IsError)
        {
            Debug.Log("User is entitled");
            User user = msg.GetUser();
            string userName = user.OculusID;
            string displayName = user.DisplayName;

            OculusUserName = userName;
            OculusDisplayName = displayName;
        } 
        else
        {
            UnityEngine.Application.Quit();
            Debug.Log("User is not entitled");
        }
    }
}
