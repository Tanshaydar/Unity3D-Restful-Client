using UnityEngine;
using System;

public class SaatDakikaDogrula : MonoBehaviour {
    public void OnChangeMinute()
    {
        if (String.IsNullOrEmpty(UIInput.current.value))
            return;
        int minute = Int32.Parse(UIInput.current.value);
        if (minute > 59)
        {
            UIInput.current.value = "59";
        }
    }

    public void OnChangeHour()
    {
        if (String.IsNullOrEmpty(UIInput.current.value))
            return;
        int hour = Int32.Parse(UIInput.current.value);
        if ( hour > 23) {
            UIInput.current.value = "23";
        }
    }
}
