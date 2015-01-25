using UnityEngine;
using System.Collections;

public class HataController : MonoBehaviour {

    public GameObject hataEkrani;
    public UILabel aciklama;
    public UIButton tamam;

    void Awake() {
        aciklama = aciklama.GetComponent<UILabel>();
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(hataEkrani);
    }

    public void hataMesajiAyarla(string aciklamaText) {
        aciklama.text = aciklamaText;
    }

    public void hataEkraniGoster() {
        hataEkrani.SetActive(true);
    }
    public void hataEkraniKapat() {
        hataEkrani.SetActive(false);
    }
}
