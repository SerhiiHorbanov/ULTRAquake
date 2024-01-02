using HealthAndDamage;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Health currentHealth;

    public void HealthCounterText()
    {
        text.text = $"{currentHealth}";

        if (currentHealth != null)
        {
            text.text = $"Dead";
        }
    }


}
