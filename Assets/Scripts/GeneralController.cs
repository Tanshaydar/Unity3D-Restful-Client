using UnityEngine;
using System;

public class GeneralController : MonoBehaviour {

    private DateTime baslangic;
    private DateTime bitis;

    private HataController hata;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        baslangic = new DateTime();
        bitis = new DateTime();
        hata = GameObject.FindObjectOfType<HataController>();
        if (PlayerPrefs.HasKey("baslangicSaat") && PlayerPrefs.HasKey("baslangicDakika") && PlayerPrefs.HasKey("bitisSaat") && PlayerPrefs.HasKey("bitisDakika"))
        {
            baslangic = new DateTime(baslangic.Year, baslangic.Month, baslangic.Day, PlayerPrefs.GetInt("baslangicSaat"), PlayerPrefs.GetInt("baslangicDakika"), 00);
            bitis = new DateTime(bitis.Year, bitis.Month, bitis.Day, PlayerPrefs.GetInt("bitisSaat"), PlayerPrefs.GetInt("bitisDakika"), 00);
        }
    }

	void FixedUpdate () {
	}

    public bool checkTime() {
        if ((baslangic.TimeOfDay <= DateTime.Now.TimeOfDay) && (bitis.TimeOfDay >= DateTime.Now.TimeOfDay))
            return true;
        else
            return false;
    }

    public void startMemoryGame() {
        if (checkTime())
        {
            Application.LoadLevel(1);
        }
        else {
            showError();
        }
    }

    public void startUnfinishedGame() {
        hata.hataMesajiAyarla("Bu oyun henüz hazır değil.");
        hata.hataEkraniGoster();
    }

    public void showError() {
        hata.hataMesajiAyarla("Şu anda zaman çizelgesinin dışındasınız.");
        hata.hataEkraniGoster();
    }

    public void saatleriAyarla(DateTime baslangic, DateTime bitis) {
        this.baslangic = baslangic;
        this.bitis = bitis;
    }
}
