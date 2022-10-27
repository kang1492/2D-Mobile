using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackGroundScroll : MonoBehaviour
{
    // Rect : UV rect �� �ǹ���
    private Rect rect;
    private RawImage backGround;
   
    void Start()
    {
        backGround = GetComponent<RawImage>();
    }
  
    void Update()
    {
        //0.1�� ���� ���ȭ�� 
        Scroll(0.1f);
    }

    public void Scroll(float speed)
    {
        rect = backGround.uvRect;

        rect.x += Time.deltaTime * speed;

        backGround.uvRect = rect;
    }
}
