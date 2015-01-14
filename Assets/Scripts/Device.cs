using System;
using UnityEngine;
using System.Collections;

public class Device
{
    public Device() { }

    public string getUniqueId()
    {
        return SystemInfo.deviceUniqueIdentifier;
    }

    public string getDeviceName()
    {
        return SystemInfo.deviceName;
    }

}
