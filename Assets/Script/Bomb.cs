using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon
{
    public override void Effect()
    {
        Debug.Log("폭발했습니다.");
    }


    void Start()
    {
        Effect();
    }

}
