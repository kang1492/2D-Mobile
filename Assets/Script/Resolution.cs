using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    private void Awake()
    {
        // �������ٴ� = ����ī�޶� (viewport Rect)
        Rect rect = Camera.main.rect;

        // ���� ����  �÷�Ʈ��������     ���ΰ�                      9�� 16 ����
        float height = ((float)Screen.width / Screen.height) / (9.0f / 16.0f);
        float width = 1f / height;

        if(height < 1 )
        {
            rect.height = height;
            rect.y = (1f - height) / 2f;
        }

        else
        {
            rect.width = width;
            rect.x = (1f - width) / 2f;
        }

        Camera.main.rect = rect;
    }

    private void OnPreCull() // ȭ�� ����� ��F�� ä���� �����ϴ°�
    {
        GL.Clear(true, true, Color.black); // ���� ������ �ַ� ���� ��
    }

}
