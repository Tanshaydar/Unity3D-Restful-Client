using UnityEngine;
using SimpleJSON;

public class RESTful
{

    public RESTful() { }

    public bool checkDevice(string uniqueId)
    {
        JSONObject deviceObject;
        //HTTP.Request checkDevice = new HTTP.Request("get", ServerInfo.serverURL + ServerInfo.API + ServerInfo.deviceApi + "123sdgas64");
        HTTP.Request checkDevice = new HTTP.Request("get", ServerInfo.serverURL + ServerInfo.API + ServerInfo.deviceApi + uniqueId);
        checkDevice.Send((request) =>
        {
            deviceObject = new JSONObject(request.response.Text);
            Debug.Log(deviceObject);
        });
        return false;
    }
}
