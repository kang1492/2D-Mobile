using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float endTime = 0;

    private Vector3 direction;
    void Start()
    {
        // ī�޶� ���ϲ�
        direction = transform.localPosition;
        // ���� ������ ���� �� (0,0,0)
    }

    
    void Update()
    {
        // Ư���� �������� ȭ�� ����
        if(Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Shake(0.25f, 0.25f)); // ������ ��鸲
        }
    }

    // amount : ��鸲�� ����
    // duration : ��鸲�� ���ӽð�
    public IEnumerator Shake(float amount, float duration)
    {
        // endTime(0)�� duration(0~???)���� �۴ٸ� ī�޶��� ��鸲 �����մϴ�.
        while(endTime < duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * amount + direction;

            duration -= Time.deltaTime;
            // �巹�� ���� õõ�� ��

            yield return null;
        }

        transform.localPosition = direction;
    }
}
