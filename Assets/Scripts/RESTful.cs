using UnityEngine;
using System;
using System.Collections;
using SimpleJSON;

public class RESTful : MonoBehaviour
{

    private JSONObject deviceObject = null;
    private JSONObject zamanObject = null;

    private Ayarlar ayarlar;
    private GeneralController controller;

    void Awake()
    {
        ayarlar = GameObject.FindObjectOfType<Ayarlar>();
        controller = GameObject.FindObjectOfType<GeneralController>();
    }

    void Start()
    {
        StartCoroutine(check());
    }

    public void checkAgain()
    {
        StartCoroutine(check());
    }

    public int checkDevice()
    {
        Debug.Log(deviceObject);
        if (deviceObject == null)
        {
            return 0;
        }
        else if (deviceObject.ToString().Equals("false"))
        {
            return 0;
        }
        else if (deviceObject.ToString().Contains("error"))
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public IEnumerator check()
    {
        HTTP.Request checkDevice = new HTTP.Request("get", ServerInfo.serverURL + "/"
            + ServerInfo.API + "/"
            + ServerInfo.deviceApi + "/"
            + ServerInfo.device.getUniqueId());
        checkDevice.Send();

        while (!checkDevice.isDone)
        {
            yield return new WaitForSeconds(0.1f);
        }

        deviceObject = new JSONObject(checkDevice.response.Text);

        if (deviceObject[2].ToString().Contains("EVET"))
        {
            Debug.Log("Ozel ayarlar VAR");
            DateTime baslangicSaati = DateTime.Parse(deviceObject[3].ToString().Trim('"'));
            DateTime bitisSaati = DateTime.Parse(deviceObject[4].ToString().Trim('"'));
            Debug.Log("****************************************************************");
            Debug.Log("Başlangıc: " + baslangicSaati + "  | Bitis: " + bitisSaati);
            Debug.Log("****************************************************************");
            controller.saatleriAyarla(baslangicSaati, bitisSaati);
        }
        else {
            Debug.Log("Ozel ayarlar YOK");
            getGeneralTimeSettings();
        }
    }

    public void getGeneralTimeSettings() {
        HTTP.Request checkTime = new HTTP.Request("get", ServerInfo.serverURL + "/"
            + ServerInfo.API + "/"
            + ServerInfo.zamanApi);
        checkTime.Send((request) => {
            zamanObject = new JSONObject(checkTime.response.Text);
            DateTime baslangicSaati = DateTime.Parse(zamanObject[1].ToString().Trim('"'));
            DateTime bitisSaati = DateTime.Parse(zamanObject[2].ToString().Trim('"'));
            Debug.Log("****************************************************************");
            Debug.Log("Başlangıc: " + baslangicSaati + "  | Bitis: " + bitisSaati);
            Debug.Log("****************************************************************");
            controller.saatleriAyarla(baslangicSaati, bitisSaati);
        });
    }

    public void registerDevice()
    {
        Hashtable data = new Hashtable();
        data.Add("uniqueId", ServerInfo.device.getUniqueId());
        data.Add("deviceName", ServerInfo.device.getDeviceName());
        data.Add("override", "HAYIR");
        data.Add("timeStart", "");
        data.Add("timeEnd", "");
        data.Add("notes", "");

        HTTP.Request registerDevice = new HTTP.Request("post", ServerInfo.serverURL + "/"
            + ServerInfo.API + "/"
            + ServerInfo.deviceApi, data);

        registerDevice.Send((request) =>
        {
            Hashtable result = request.response.Object;
            if (result == null)
            {
                Debug.LogWarning("Cannot register device");
                registerFailed();
                return;
            }

            registerSuccess();

        });
    }

    public void registerFailed()
    {
        ayarlar.cihaziKaydetmeBasarisiz();
    }

    public void registerSuccess()
    {
        ayarlar.cihaziKaydetmeBasarili();
    }
}
