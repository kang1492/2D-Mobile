using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon
{
    public override void Effect()
    {
        Debug.Log("�����߽��ϴ�.");
    }


    void Start()
    {
        Effect();
    }

}
