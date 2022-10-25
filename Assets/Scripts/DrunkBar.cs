
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrunkBar : MonoBehaviour
{
    public Slider drunkBar;
    public Drunkenness playerDrunkenness;

    private void Start()
    {
        playerDrunkenness = GameObject.FindGameObjectWithTag("Player").GetComponent<Drunkenness>();
        drunkBar = GetComponent<Slider>();
        drunkBar.maxValue = playerDrunkenness.maxDrunkenness;
        drunkBar.value = playerDrunkenness.maxDrunkenness;
    }

    public void SetDrunkenness(int hp)
    {
        drunkBar.value = hp;
    }
}
