using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    private void Awake()
    {
        // 가져오겟다 = 메인카메라 (viewport Rect)
        Rect rect = Camera.main.rect;

        // 높이 변수  플로트값나오게     가로값                      9대 16 비율
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

    private void OnPreCull() // 화면 빈공간 어덯게 채울지 설정하는것
    {
        GL.Clear(true, true, Color.black); // 색깔 블랙으로 주로 많이 함
    }

}
