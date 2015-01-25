using UnityEngine;
using System;
using System.IO;
using System.Net;

public class GameController : MonoBehaviour
{

    public UILabel connectionResult;
    public UILabel connectionResult2;

    public UIInput sunucu;
    public UIInput baslangicSaat;
    public UIInput baslangicDakika;
    public UIInput bitisSaat;
    public UIInput bitisDakika;

    private RESTful rest;
    private HataController hata;

    void Awake()
    {
        kayitliAyarlar();
        rest = GameObject.FindObjectOfType<RESTful>();
        hata = GameObject.FindObjectOfType<HataController>();
    }

    void Start()
    {
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

    public void kayitliAyarlar()
    {
        if (PlayerPrefs.HasKey("sunucu"))
        {
            sunucu.value = PlayerPrefs.GetString("sunucu");
            ServerInfo.serverURL = sunucu.value;
        }
        else
        {
            sunucu.value = ServerInfo.serverURL;
        }
        if (PlayerPrefs.HasKey("baslangicSaat"))
        {
            baslangicSaat.value = PlayerPrefs.GetInt("baslangicSaat").ToString();
        }
        if (PlayerPrefs.HasKey("baslangicDakika"))
        {
            baslangicDakika.value = PlayerPrefs.GetInt("baslangicDakika").ToString();
        }
        if (PlayerPrefs.HasKey("bitisSaat"))
        {
            bitisSaat.value = PlayerPrefs.GetInt("bitisSaat").ToString();
        }
        if (PlayerPrefs.HasKey("bitisDakika"))
        {
            bitisDakika.value = PlayerPrefs.GetInt("bitisDakika").ToString();
        }
    }


    public void ayarlariCihazaKaydet()
    {
        PlayerPrefs.SetString("sunucu", sunucu.value);
        PlayerPrefs.SetInt("baslangicSaat", Int32.Parse(baslangicSaat.value));
        PlayerPrefs.SetInt("baslangicDakika", Int32.Parse(baslangicDakika.value));
        PlayerPrefs.SetInt("bitisSaat", Int32.Parse(bitisSaat.value));
        PlayerPrefs.SetInt("bitisDakika", Int32.Parse(bitisDakika.value));
        hata.hataMesajiAyarla("Ayarlar başarıyla kaydedildi!");
        hata.hataEkraniGoster();
    }
}
