using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] SpriteRenderer shape;// ������� �츮�� �˾Ƽ� �̹��� �־���� ��
    public int health;



    // ������
    // ��ü�� �ν��Ͻ��� �� �ڵ����� ȣ��Ǵ� ��� �Լ��Դϴ�.
    public Monster()// ������ �̱� ������ �ٷ� ȣ��� , ������ �ۺ��̾� ��
                    // <- ��� ������ ���� ��
                    // <- �ڵ����� �޸� �Ҵ�Ǳ� ������
                    // �ܺο��� ȣ���� �� �ֵ��� public���� �������־�� �մϴ�.
    {
        Debug.Log("Monster �����Ǿ����ϴ�.");
    }

    // ��� ��ũ�� ���� ������ ��.
    // �ڽ� Ŭ���� Ȱ��ȭ ��Ű��
    //public void Start()
    //{
    //    Goblin goblin = new Goblin();
    //}

    // �Լ� �����ϱ�
    // �����Լ�
    // ���� Ŭ�������� �ٽ� ������ ��� �Լ��Դϴ�.
    virtual public void Attack() // ���߾� �����Լ�
    {
        Debug.Log("����");
    }
}

//public class Goblin : Monster // �θ� �ۺ��̾��� ��ӹ���.
//{
//    public Goblin()
//    {
//        Debug.Log("Goblin �����Ǿ����ϴ�.");
//    }
//}
