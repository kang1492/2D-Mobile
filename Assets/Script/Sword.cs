using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public override void Effect()
    {
        Debug.Log("Į ���.");
    }

    void Start()
    {
        Effect();
    }

}
