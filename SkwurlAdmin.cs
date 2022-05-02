using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using com.A_Tasty_Melon.SkwurlRunner;
using Photon.Pun;

public class SkwurlAdmin : MonoBehaviour
{
    private GetOculusUsername getName;
    private NetworkPlayerspawner nps;

    [SerializeField] private PhotonView playerPV;

    void Start()
    {
        nps = GetComponent<NetworkPlayerspawner>();
        getName = GetComponent<GetOculusUsername>();
    }

    void Update()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://raw.githubusercontent.com/ATastyMelon/Skwurl-Runner-Moderation/main/adminids");
        byte[] webHandled = request.downloadHandler.data;
        string result = BitConverter.ToString(webHandled, 0);

        if (result.Contains(getName.OculusDisplayName))
        {
            nps.hasCap = true;
        }
        else
        {
            nps.hasCap = false;
        }
    }
}
