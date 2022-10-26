using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤으로 만들기 어디서든지 접근가능하게
    public static GameManager instance;

    public enum state
    {
        Idle,    // 게임 대기
        Progress,// 게임 진행
        End      // 게임 종료
    }
    // enum 상태를 표시할때

    private state currentState;

    public state State
    { 
        get { return currentState; }
        set { currentState = value; }
        
    }


    private int score; // 스코어 라는 변수로 정의하기

    // 프로퍼티 라고 함
    // 다른 클래스에서 해당 변수의 값을 변경시킬 때 사용해야 합니다.
    public int Score // 함수 라서 앞에 대문자
    {
        // get 해당 변수를 출력해주는 기능
        get { return score; }
        //    반환    스코어

        set 
        {
            score = value; 
            // 스코어 대문자 일시 에러 뜸 , 자기 자신을 계속 불러와서

            if (100 <= score)
            {
                score = 100;
            }
             
        }
        // 해당 변수에 값을 넣어주는 기능
    }

    //private void Awake() 잠시 지우기
    //{
    //    if(instance == null) // 인스턴스가 머리 라면
    //    {
    //        instance = this; // 자기 자신 넣어주기
    //    }
    //}

    //private void Start() 확인후 지우기
    //{
    //    Score = 1000; // 쎄터 쪽에다가 10 넣고 스코어에 값이 10

    //    Debug.Log(Score);
    //}

    private void Start()
    {
        State = state.Idle; // 대기상태로 만들기
        StateMachine();// 키 눌렀을때만
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            State = state.Idle;
            StateMachine(); // 호출하기
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            State = state.Progress;
            StateMachine(); // 호출하기
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            State = state.End;
            StateMachine(); // 호출하기
        }
    }

    public void StateMachine() // 애니메이션의 상태 패턴
    {
        switch(State)
        {
            case state.Idle:
                {
                    Time.timeScale = 0;
                    //Debug.Log("게임 대기 상태");
                }
                break;
            case state.Progress:
                {
                    Time.timeScale = 1;
                    //Debug.Log("게임 진행 상태");
                }
                break;
            case state.End:
                {
                    Time.timeScale = 0;
                    //Debug.Log("게임 종료 상태");
                }
                break;
        }
    }
}
