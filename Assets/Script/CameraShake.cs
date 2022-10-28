using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float endTime = 0;

    private Vector3 direction;
    void Start()
    {
        // 카메라에 붙일껏
        direction = transform.localPosition;
        // 방향 변수에 원래 값 (0,0,0)
    }

    
    void Update()
    {
        // 특이한 시점에서 화면 흔들기
        if(Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Shake(0.25f, 0.25f)); // 적당한 흔들림
        }
    }

    // amount : 흔들림의 강도
    // duration : 흔들림의 지속시간
    public IEnumerator Shake(float amount, float duration)
    {
        // endTime(0)이 duration(0~???)보다 작다면 카메라의 흔들림 동작합니다.
        while(endTime < duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * amount + direction;

            duration -= Time.deltaTime;
            // 드레인 값을 천천히 뺌

            yield return null;
        }

        transform.localPosition = direction;
    }
}
