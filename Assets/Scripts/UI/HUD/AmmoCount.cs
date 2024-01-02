using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weapons.Ammo;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;

    [SerializeField] public AmmoManager ammo;

    public void AmmoCountText()
    {
        text.text = $"{ammo}";
    }
}
