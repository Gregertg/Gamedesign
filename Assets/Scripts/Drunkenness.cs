using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunkenness : MonoBehaviour
{
    public int curDrunkenness;
    public int maxDrunkenness = 100;

    public DrunkBar drunkBar;

    void Start()
    {
        curDrunkenness = 50;

        // Kjører funksjonen UpdateDrunkenness hvert sekund med et sekund delay i starten
        InvokeRepeating("UpdateDrunkenness", 1f, 1f);
    }

    void UpdateDrunkenness()
    {
        DamagePlayer(1);
    }

    public void DamagePlayer( int damage )
    {
        curDrunkenness -= damage;

        drunkBar.SetDrunkenness( curDrunkenness );
    }
}