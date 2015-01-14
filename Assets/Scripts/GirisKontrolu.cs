using UnityEngine;
using System.Collections;

public class GirisKontrolu : MonoBehaviour {

    public UIInput userName;
    public UIInput password;
    public UILabel girisButonu;

    public GameObject ayarPaneli;
    public GameObject anaPanel;

    public void GirisiKontrolEt() {
        if (userName.text.Equals("casper") && password.text.Equals("q7a4z1"))
        {
            ayarPaneli.SetActive(true);
            anaPanel.SetActive(false);
        }
        else {
            girisButonu.text = "Kullanıcı Adı veya Şifre Hatalı!";
        }
    }

    public void GeriAl() {
        girisButonu.text = "Giriş Yap";
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
