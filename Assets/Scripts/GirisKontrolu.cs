using UnityEngine;
using System.Collections;

public class GirisKontrolu : MonoBehaviour {

    public UIInput userName;
    public UILabel userNameText;
    public UIInput password;
    public UILabel passwordText;
    public UILabel girisButonu;
    public UILabel ayarButonuText;

    public GameObject ayarPaneli;
    public GameObject anaPanel;
    public GameObject ustKisim;
    public GameObject oyunlar;
    public GameObject sifreEkrani;

    private Ayarlar ayarlar;

    private bool inSettings = false;

    void Awake() {
        ayarlar = GameObject.FindObjectOfType<Ayarlar>();
    }

    public void OnClick()
    {
        if (inSettings)
        {
            ustKisim.SetActive(true);
            oyunlar.SetActive(true);
            sifreEkrani.SetActive(false);
            ayarButonuText.text = "Ayarlar";
            inSettings = !inSettings;
        }
        else
        {
            ustKisim.SetActive(false);
            oyunlar.SetActive(false);
            sifreEkrani.SetActive(true);
            ayarButonuText.text = "Geri";

            userNameText.text = "Kullanıcı Adı";
            passwordText.text = "Şifre";
            userName.value = "";
            password.value = "";
            inSettings = !inSettings;
        }
    }

    public void GirisiKontrolEt() {
        if (userName.value.Equals("casper") && password.value.Equals("q7a4z1"))
        {
            ayarPaneli.SetActive(true);
            anaPanel.SetActive(false);
            ayarlar.AyarlaraGir();
        }
        else {
            girisButonu.text = "Kullanıcı Adı veya Şifre Hatalı!";
        }
    }

    public void GeriAl() {
        girisButonu.text = "Giriş Yap";
    }

    public void Geri() {
        inSettings = !inSettings;
        ayarButonuText.text = "Ayarlar";
    }
}
