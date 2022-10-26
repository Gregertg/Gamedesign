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
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            DamagePlayer(10);
        }
    }

    public void DamagePlayer( int damage )
    {
        curDrunkenness -= damage;

        drunkBar.SetDrunkenness( curDrunkenness );
    }
}