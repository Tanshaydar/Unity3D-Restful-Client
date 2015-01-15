using UnityEngine;
using System.Collections;

public class ServerInfo
{

    public static string serverURL = "http://localhost/zaman";
    public static string API = "api";
    public static string deviceApi = "device";

    public static Device device = new Device();

    void Awake()
    {
        if (!PlayerPrefs.HasKey("lol"))
        {
            Debug.Log("first time yey!");
        }
    }
}
