using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster // �θ� ���Ͱ� MonoBehaviour ��ӹޱ� �ֱ� ������
{
    public Goblin()
    {
        health = 10; // ���Ϳ� �մ� �ｺ
        Debug.Log("Goblin�� ü�� : " + health);
        Debug.Log("Goblin ȣ��");
    }

    // �������̵�
    // ��� ���輭 ���� Ŭ������ �ִ� �Լ��� ���� Ŭ�������� �������ϴ� ����Դϴ�.
    public override void Attack()
    {
        // �θ�
        base.Attack();// ���� Ŭ������ �ִ� Attack() �Լ��� ȣ���ϰڴ�.
        Debug.Log("��� ������ �����̾�!");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Attack(); // ����
        }
    }

}
