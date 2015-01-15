using UnityEngine;
using System;
using System.IO;
using System.Net;

public class GeneralController : MonoBehaviour
{

    public UILabel connectionResult;
    public UILabel connectionResult2;

    private RESTful rest;

    void Awake()
    {
        rest = GameObject.FindObjectOfType<RESTful>();
    }

    void Start()
    {
        Debug.Log("Started...");
        Invoke("checkSteps", 2f);
    }

    public void checkSteps()
    {
        if (checkInternetConnection("http://www.google.com"))
        {
            if (checkServerConnection(ServerInfo.serverURL))
            {
                Invoke("checkDeviceRegistration", 2);
            }
        }
    }

    private bool checkInternetConnection(string uri)
    {
        string HtmlText = GetHtmlFromUri(uri);
        if (HtmlText == "")
        {
            connectionResult.text = "Cihaz Durumu: [ff0000]İnternet Bağlantısı Yok![-]";
            connectionResult2.text = "Cihaz Durumu: [ff0000]İnternet Bağlantısı Yok![-]";
            return false;
        }
        else if (!HtmlText.Contains("schema.org/WebPage"))
        {
            connectionResult.text = "Cihaz Durumu: [ff0000]İnternet Bağlantısı Yok![-]";
            connectionResult2.text = "Cihaz Durumu: [ff0000]İnternet Bağlantısı Yok![-]";
            return false;
        }
        else
        {
            connectionResult.text = "Cihaz Durumu: [99ff00]İnternet Bağlantısı Mevcut![-]";
            connectionResult2.text = "Cihaz Durumu: [99ff00]İnternet Bağlantısı Mevcut![-]";
            return true;
        }
    }

    private bool checkServerConnection(string uri)
    {
        string HtmlText = GetHtmlFromUri(uri);
        Debug.Log(HtmlText);
        if (HtmlText == "")
        {
            connectionResult.text = "Cihaz Durumu: [ff0000]Sunucuya bağlanılamıyor![-]";
            connectionResult2.text = "Cihaz Durumu: [ff0000]Sunucuya bağlanılamıyor![-]";
            return false;
        }
        else
        {
            connectionResult.text = "Cihaz Durumu: [99ff00]Sunucu Bağlantısı Mevcut![-]";
            connectionResult2.text = "Cihaz Durumu: [99ff00]Sunucu Bağlantısı Mevcut![-]";
            return true;
        }
    }

    private bool checkDeviceRegistration()
    {
        if (rest.checkDevice() == 1)
        {
            connectionResult.text = "Cihaz Durumu: [99ff00]Cihaz Kayıtlı![-]";
            connectionResult2.text = "Cihaz Durumu: [99ff00]Cihaz Kayıtlı![-]";
            return true;
        }
        else if (rest.checkDevice() == 0)
        {
            connectionResult.text = "Cihaz Durumu: [ff0000]Cihaz Sisteme Kayıtlı Değil![-]";
            connectionResult2.text = "Cihaz Durumu: [ff0000]Cihaz Sisteme Kayıtlı Değil![-]";
            return false;
        }
        else if (rest.checkDevice() == -1)
        {
            connectionResult.text = "Cihaz Durumu: [ff0000]Veritabanı hatası![-]";
            connectionResult2.text = "Cihaz Durumu: [ff0000]Veritabanı hatası![-]";
            return false;
        }
        else
        {
            return false;
        }

    }

    public string GetHtmlFromUri(string resource)
    {
        string html = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);

        try
        {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        char[] cs = new char[80];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs)
                        {
                            html += ch;
                        }
                    }
                }
            }
        }
        catch
        {
            return "";
        }

        return html;
    }
}
