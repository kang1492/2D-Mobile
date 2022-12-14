using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D; // 리지더 바디 가져오기
    int value = 0; // 10-25

    [SerializeField] int health = 100; //10-21
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpPower = 1.0f;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameManager gameManager; // 10-25 가져오기
    

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // 캐릭터의 y축 위치가 -10보다 작다면
        if(transform.position.y <= -10)
        {
            // 캐릭터의 위치를 x(0), y(0)으로 설정합니다.
            transform.position = new Vector2(0f, 0f);// 시작 위치ㅇ
            //                   Vector2.zero;
        }
    }

    //public void Slip() // 10-19 //10-21 잠시 지우기
    //{
    //    rigid2D.velocity = Vector2.zero; // 캐릭터 이동속도 멈추개
    //}

    
    //리지더 바디에 연산 같은 경우
    //private void FixedUpdate()
    //{

    //}

    public void Move(Vector2 direction) // 10-19
    {
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical"); 

        //if (x > 0)
        //{
        //    sprite.flipX = false;
        //}
        // else if (x < 0)
        //{
        //    sprite.flipX = true;
        //}

        if (direction.x > 0)
        {
           sprite.flipX = false;
        }
        else if (direction.x < 0)
        {
            sprite.flipX = true;
        }


        // 움직이기
        transform.Translate
            (
            direction.x * speed * Time.deltaTime,
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

    public void Jump()
    {
        //int value = 0; // 10-25

        gameManager.Score = value++; // 점프를 할때마다 값을 증가 시키기 10-25

        Debug.Log(gameManager.Score);// 점프 할때 마다 값이 출력되것임

        //GameManager.instance.Score(value); // 점프 할때 마다 값 올려주기

        //if (Input.GetKeyDown(KeyCode.Space)) // 10-18 이동
        //{
        // ForceMode2D.Impulse : 무게를 적용할 때 사용합니다. 점 누르면 다른 여러가지 있음
        rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}

        // 1초 동안 진동을 울리는 함수입니다. //10-21
        Handheld.Vibrate();
    }




    // 2D 새로운 충돌 함수
    // 유니티 2D 에서는 2D Collider랑 Rigidbody 2D 는 2D 충돌 함수를 사용해야 합니다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("2D 충돌");
        if(collision.CompareTag("Portal")) // 포탈이랑 부딧치면
        {                                                       // -10 해두 됨
            //Camera.main.transform.position = new Vector3(20, 0, Camera.main.transform.position.z);
            // 캐릭터에 메인카메라 따라 가서 카메라 위치를 이동시킬 필요가 없다
            transform.position = new Vector3(12.5f, 0, 0);
        }

        if(collision.CompareTag("Potion")) // 10-21 // 포션오타
        {
            health += 10;

            // 부딪힌 객체가 파괴됩니다.
            Destroy(collision.gameObject);
        }

    }

    // 밑에 꺼는 지워도 됨.
    /*
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
    */
   
}
