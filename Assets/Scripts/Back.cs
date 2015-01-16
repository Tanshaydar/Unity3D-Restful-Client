using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour
{
    public GameObject settingsScreen;
    public GameObject mainScreen;
    public GameObject oyunlar;
    public GameObject ustKisim;
    public GameObject sifreEkrani;
    public GameObject ayarButonu;

    public GirisKontrolu girisKontrolu;

    public void back() {
        settingsScreen.SetActive(false);
        mainScreen.SetActive(true);
        oyunlar.SetActive(true);
        ustKisim.SetActive(true);
        sifreEkrani.SetActive(false);
        ayarButonu.SetActive(true);
        girisKontrolu.Geri();
    }

}
