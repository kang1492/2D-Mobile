using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffold : MonoBehaviour
{
    // 이동 하고 싶은 위치 / 이동하는 발판
    Vector3 direction;
    void Update()
    {
        // Time.time = 게임 실행을 누적합니다.
        // x축으로 -9.9999 까지 이동하다가 다시 0.0001로 이동합니다.
        // 발판 움직이기
        // transform.position "+"로 해주셔야 합니다.
        transform.position = 
            new Vector2
            (
             Mathf.PingPong(Time.time, 3), // x 값
             transform.position.y            // y 값
            );
    }
}
