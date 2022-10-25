using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffold : MonoBehaviour
{
    // �̵� �ϰ� ���� ��ġ / �̵��ϴ� ����
    Vector3 direction;
    void Update()
    {
        // Time.time = ���� ������ �����մϴ�.
        // x������ -9.9999 ���� �̵��ϴٰ� �ٽ� 0.0001�� �̵��մϴ�.
        // ���� �����̱�
        // transform.position "+"�� ���ּž� �մϴ�.
        transform.position = 
            new Vector2
            (
             Mathf.PingPong(Time.time, 3), // x ��
             transform.position.y            // y ��
            );
    }
}
