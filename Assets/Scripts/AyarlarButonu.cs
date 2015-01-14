using UnityEngine;
using System.Collections;

public class AyarlarButonu : MonoBehaviour {

    public GameObject ustKisim;
    public GameObject oyunlar;
    public GameObject sifreEkrani;

    public void OnClick() {
        ustKisim.SetActive(false);
        oyunlar.SetActive(false);
        sifreEkrani.SetActive(true);
        gameObject.SetActive(false);
    }

}
