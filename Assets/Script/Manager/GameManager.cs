using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱������� ����� ��𼭵��� ���ٰ����ϰ�
    public static GameManager instance;

    public enum state
    {
        Idle,    // ���� ���
        Progress,// ���� ����
        End      // ���� ����
    }
    // enum ���¸� ǥ���Ҷ�

    private state currentState;

    public state State
    { 
        get { return currentState; }
        set { currentState = value; }
        
    }


    private int score; // ���ھ� ��� ������ �����ϱ�

    // ������Ƽ ��� ��
    // �ٸ� Ŭ�������� �ش� ������ ���� �����ų �� ����ؾ� �մϴ�.
    public int Score // �Լ� �� �տ� �빮��
    {
        // get �ش� ������ ������ִ� ���
        get { return score; }
        //    ��ȯ    ���ھ�

        set 
        {
            score = value; 
            // ���ھ� �빮�� �Ͻ� ���� �� , �ڱ� �ڽ��� ��� �ҷ��ͼ�

            if (100 <= score)
            {
                score = 100;
            }
             
        }
        // �ش� ������ ���� �־��ִ� ���
    }

    //private void Awake() ��� �����
    //{
    //    if(instance == null) // �ν��Ͻ��� �Ӹ� ���
    //    {
    //        instance = this; // �ڱ� �ڽ� �־��ֱ�
    //    }
    //}

    //private void Start() Ȯ���� �����
    //{
    //    Score = 1000; // ���� �ʿ��ٰ� 10 �ְ� ���ھ ���� 10

    //    Debug.Log(Score);
    //}

    private void Start()
    {
        State = state.Idle; // �����·� �����
        StateMachine();// Ű ����������
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            State = state.Idle;
            StateMachine(); // ȣ���ϱ�
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            State = state.Progress;
            StateMachine(); // ȣ���ϱ�
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            State = state.End;
            StateMachine(); // ȣ���ϱ�
        }
    }

    public void StateMachine() // �ִϸ��̼��� ���� ����
    {
        switch(State)
        {
            case state.Idle:
                {
                    Time.timeScale = 0;
                    //Debug.Log("���� ��� ����");
                }
                break;
            case state.Progress:
                {
                    Time.timeScale = 1;
                    //Debug.Log("���� ���� ����");
                }
                break;
            case state.End:
                {
                    Time.timeScale = 0;
                    //Debug.Log("���� ���� ����");
                }
                break;
        }
    }
}
