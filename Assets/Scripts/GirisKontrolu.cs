using UnityEngine;
using System.Collections;

public class GirisKontrolu : MonoBehaviour {

    public UIInput userName;
    public UILabel userNameText;
    public UIInput password;
    public UILabel passwordText;
    public UILabel girisButonu;

    public GameObject ayarPaneli;
    public GameObject anaPanel;
    public GameObject ustKisim;
    public GameObject oyunlar;
    public GameObject sifreEkrani;

    private Ayarlar ayarlar;

    void Awake() {
        ayarlar = GameObject.FindObjectOfType<Ayarlar>();
    }

    public void OnClick()
    {
        ustKisim.SetActive(false);
        oyunlar.SetActive(false);
        sifreEkrani.SetActive(true);
        gameObject.SetActive(false);
        userNameText.text = "Kullanıcı Adı";
        passwordText.text = "Şifre";
        userName.value = "";
        password.value = "";
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
}
