using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackGroundScroll : MonoBehaviour
{
    // Rect : UV rect 을 의미함
    private Rect rect;
    private RawImage backGround;
   
    void Start()
    {
        backGround = GetComponent<RawImage>();
    }
  
    void Update()
    {
        //0.1초 마다 배경화면 
        Scroll(0.1f);
    }

    public void Scroll(float speed)
    {
        rect = backGround.uvRect;

        rect.x += Time.deltaTime * speed;

        backGround.uvRect = rect;
    }
}
