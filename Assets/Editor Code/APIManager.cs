using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    public const string apiLink = "https://script.google.com/macros/s/AKfycbxGZ8GUvzd_PfTlirEB-j4vDa5co69wvp1WuPWevLivBP1gjP0ToH9qUIQONU-6g5H7/exec";
    public string prompt;
    public string apiKey = "AIzaSyColxW4aPKMYYfLS8vB00vAKVzfSB2iL_g";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(1);
            StartCoroutine(SendDataToGAS());
        }
    }


    public IEnumerator SendDataToGAS()
    {
        WWWForm form = new WWWForm();
        form.AddField("parameter", prompt);
        form.AddField("apiKey", prompt);

        UnityWebRequest www = UnityWebRequest.Post(apiLink, form);

        yield return www.SendWebRequest();
        string response = "";

        if (www.result == UnityWebRequest.Result.Success)
        {
            response = www.downloadHandler.text;
        }
        else
        {
            response = "There was an error";
        }

        Debug.Log(response);
    }
}
