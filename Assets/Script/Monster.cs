using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] SpriteRenderer shape;// 고블린에서 우리가 알아서 이미지 넣어줘야 됨
    public int health;



    // 생성자
    // 객체가 인스턴스될 때 자동으로 호출되는 멤버 함수입니다.
    public Monster()// 생성자 이기 때문에 바루 호출됨 , 생성자 퍼블릿이야 됨
                    // <- 상속 구조에 들어갔을 때
                    // <- 자동으로 메모리 할당되기 때문에
                    // 외부에서 호출할 수 있도록 public으로 선언해주어댜 합니다.
    {
        Debug.Log("Monster 생성되었습니다.");
    }

    // 고블린 스크립 만들어서 지워도 됨.
    // 자식 클래스 활성화 시키기
    //public void Start()
    //{
    //    Goblin goblin = new Goblin();
    //}

    // 함수 구현하기
    // 가상함수
    // 하위 클래스에서 다시 정의할 멤버 함수입니다.
    virtual public void Attack() // 버추얼 가상함수
    {
        Debug.Log("공격");
    }
}

//public class Goblin : Monster // 부모가 퍼블릿이야지 상속받음.
//{
//    public Goblin()
//    {
//        Debug.Log("Goblin 생성되었습니다.");
//    }
//}
