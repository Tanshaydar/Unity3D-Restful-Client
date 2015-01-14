using UnityEngine;
using System.Collections;

public class AyarlarButonu : MonoBehaviour {

    public GameObject oyunlar;
    public GameObject sifreEkrani;

    public void OnClick() {
        oyunlar.SetActive(false);
        gameObject.SetActive(false);
        sifreEkrani.SetActive(true);        
    }

}
