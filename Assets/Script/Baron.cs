using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baron : Monster
{
    public Baron()
    {
        health = 100;
        Debug.Log("�ٷ��� �����Ǿ����ϴ�.");
    }

    public void Start()
    {
        Debug.Log("�ٷ��� ü�� : " + health);
    }
}
