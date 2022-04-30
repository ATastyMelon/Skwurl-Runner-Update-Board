using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class SkwurlBan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this requires your github to be public to work
        Debug.Log(PhotonNetwork.LocalPlayer.UserId); //Debug stuff to get your playerid

        UnityWebRequest webRequest = UnityWebRequest.Get("https://raw.githubusercontent.com/ATastyMelon/Skwurl-Runner-Moderation/main/bannedplayerids");
        byte[] handled = webRequest.downloadHandler.data;
        string result = BitConverter.ToString(handled, 0);
        if (result.Contains(PhotonNetwork.LocalPlayer.UserId))
        {
            //do stuff (in this case, crash the game)
            Debug.Log("You are banned! You MotherFucker!");
            Application.Quit();
        }
        else
        {
            Debug.Log("You are not banned!");
        }


    }

    // Update is called once per frame
    void Update()
    {
        foreach(Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            Debug.Log(player); //ok this is for other player ids
        }
        
    }
}
