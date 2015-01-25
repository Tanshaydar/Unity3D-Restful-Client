using UnityEngine;
using System.Collections;

public class Ayarlar : MonoBehaviour {

    private GameController controller;
    private RESTful rest;
    public GameObject kaydetButonu;
    public UILabel kaydetButonuText;

    void Awake() {
        controller = GameObject.FindObjectOfType<GameController>();
        rest = GameObject.FindObjectOfType<RESTful>();
    }

	public void AyarlaraGir () {
        if (rest.checkDevice() == 1) {
            kaydetButonu.SetActive( false);
        }
	}

    public void cihaziKaydet() {
        kaydetButonu.GetComponent<UIButton>().enabled = false;
        kaydetButonuText.text = "Kaydediliyor...";
        rest.registerDevice();
    }

    public void cihaziKaydetmeBasarisiz() {
        kaydetButonu.GetComponent<UIButton>().enabled = true;
        kaydetButonuText.text = "Kaydetme BAŞARISIZ!";
        rest.checkDevice();
    }
    public void cihaziKaydetmeBasarili() {
        kaydetButonu.GetComponent<UIButton>().enabled = false;
        kaydetButonuText.text = "Kaydetme Başarılı!";
        rest.checkAgain();
        Invoke("checkAgain", 2);
    }

    private void checkAgain(){
        controller.checkSteps();
    }

}
