using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D; // 리지더 바디 가져오기

    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpPower = 1.0f;
    [SerializeField] SpriteRenderer sprite;
    

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical"); 

        if(x > 0)
        {
            sprite.flipX = false;
        }
        else if( x < 0)
        {
            sprite.flipX = true;
        }

        // 움직이기
        transform.Translate
            (
            x * speed * Time.deltaTime,
            //y * speed * Time.deltaTime,
            //transform.position.y, // 점프 하기 = 에러
            0,
            transform.position.z
            );

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            // ForceMode2D.Impulse : 무게를 적용할 때 사용합니다. 점 누르면 다른 여러가지 있음
        //    rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}
    }
    //리지더 바디에 연산 같은 경우
    //private void FixedUpdate()
    //{
        
    //}

    public void Jump()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) // 10-18 이동
        //{
            // ForceMode2D.Impulse : 무게를 적용할 때 사용합니다. 점 누르면 다른 여러가지 있음
            rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}
    }




    // 2D 새로운 충돌 함수
    // 유니티 2D 에서는 2D Collider랑 Rigidbody 2D 는 2D 충돌 함수를 사용해야 합니다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("2D 충돌");
        if(collision.CompareTag("Portal")) // 포탈이랑 부딧치면
        {                                                       // -10 해두 됨
            Camera.main.transform.position = new Vector3(20, 0, Camera.main.transform.position.z);
            transform.position = new Vector3(12.5f, 0, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("2D 충돌 중");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("2D 충돌 벗어남");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("2D 충돌 Collision");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("2D 충돌 Collision");
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("2D 충돌 벗어남 Collision");
    }

   
}
