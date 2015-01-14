using UnityEngine;
using System;
using System.Collections;
using SimpleJSON;

public class RESTful : MonoBehaviour 
{

    private JSONObject deviceObject = null;

    void Start() {
        StartCoroutine(check());
    }

    public bool checkDevice()
    {
        if (deviceObject.ToString().Equals("false"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public IEnumerator check() {
        HTTP.Request checkDevice = new HTTP.Request("get", ServerInfo.serverURL + ServerInfo.API + ServerInfo.deviceApi + ServerInfo.device.getUniqueId());
        checkDevice.Send();

        while (!checkDevice.isDone)
        {
            yield return new WaitForSeconds(0.1f);
        }

        deviceObject = new JSONObject(checkDevice.response.Text);        
    }
}
