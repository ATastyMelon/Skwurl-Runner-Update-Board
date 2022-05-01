namespace com.A_Tasty_Melon.SkwurlRunner
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;
    using Oculus;
    using Oculus.Platform;
    using Oculus.Platform.Models;
    using Photon.Pun;
    using Photon.Realtime;

    public class GetOculusUsername : MonoBehaviour
    {
        [Tooltip("Your Oculus Username")]
        public string OculusUserName;
        [Tooltip("Your Oculus Display Name")]
        public string OculusDisplayName;

        private void Start()
        {
            string appid = "4781925418603084";
            Oculus.Platform.Core.AsyncInitialize(appid);

            Oculus.Platform.Users.GetLoggedInUser().OnComplete(EntitledCallback);
        }

        private void EntitledCallback(Message msg)
        {
            if (!msg.IsError)
            {
                Debug.Log("User is entitled");
                User user = msg.GetUser();
                string userName = user.OculusID;
                string displayName = user.DisplayName;

                OculusUserName = userName;
                OculusDisplayName = displayName;

                PhotonNetwork.LocalPlayer.NickName = OculusDisplayName;
            }
            else
            {
                Debug.Log("User is not entitled");
            }
        }
    }

}