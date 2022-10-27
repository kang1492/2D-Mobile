using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster // 부모 몬스터가 MonoBehaviour 상속받기 있기 때문에
{
    public Goblin()
    {
        health = 10; // 몬스터에 잇는 헬스
        Debug.Log("Goblin의 체력 : " + health);
        Debug.Log("Goblin 호출");
    }

    // 오버라이드
    // 상속 광계서 상위 클래스에 있는 함수를 하위 클래스에서 재정의하는 기능입니다.
    public override void Attack()
    {
        // 부모꺼
        base.Attack();// 상위 클래스에 있는 Attack() 함수를 호출하겠다.
        Debug.Log("고블린 형태의 공격이야!");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Attack(); // 공격
        }
    }

}
