using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baron : Monster
{
    public Baron()
    {
        health = 100;
        Debug.Log("바론이 생성되었습니다.");
    }

    public void Start()
    {
        Debug.Log("바론의 체력 : " + health);
    }
}
