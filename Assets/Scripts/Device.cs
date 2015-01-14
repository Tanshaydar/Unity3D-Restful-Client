using System;
using UnityEngine;
using System.Collections;

public class Device
{
    private string uniqueId;
    private string deviceName;
    private bool isOverriden;
    private DateTime timeStart;
    private DateTime timeEnd;
    private string notes;

    public Device() { }
    public Device(string uniqueId, string deviceName, bool isOverriden, DateTime timeStart, DateTime timeEnd, string notes)
    {
        this.uniqueId = uniqueId;
        this.deviceName = deviceName;
        this.isOverriden = isOverriden;
        this.timeStart = timeStart;
        this.timeEnd = timeEnd;
        this.notes = notes;
    }

    public string getUniqueId()
    {
        return SystemInfo.deviceUniqueIdentifier;
    }

    public string getDeviceName()
    {
        return SystemInfo.deviceName;
    }
}
