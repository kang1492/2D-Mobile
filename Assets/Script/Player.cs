using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D; // ������ �ٵ� ��������

    [SerializeField] int health = 100; //10-21
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpPower = 1.0f;
    [SerializeField] SpriteRenderer sprite;
    

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // ĳ������ y�� ��ġ�� -10���� �۴ٸ�
        if(transform.position.y <= -10)
        {
            // ĳ������ ��ġ�� x(0), y(0)���� �����մϴ�.
            transform.position = new Vector2(7.4f, 0.75f);// ���� ��ġ��
            //                   Vector2.zero;
        }
    }

    //public void Slip() // 10-19 //10-21 ��� �����
    //{
    //    rigid2D.velocity = Vector2.zero; // ĳ���� �̵��ӵ� ���߰�
    //}

    
    //������ �ٵ� ���� ���� ���
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


        // �����̱�
        transform.Translate
            (
            direction.x * speed * Time.deltaTime,
            //y * speed * Time.deltaTime,
            //transform.position.y, // ���� �ϱ� = ����
            0,
            transform.position.z
            );

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        // ForceMode2D.Impulse : ���Ը� ������ �� ����մϴ�. �� ������ �ٸ� �������� ����
        //    rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}
    }

    public void Jump()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) // 10-18 �̵�
        //{
            // ForceMode2D.Impulse : ���Ը� ������ �� ����մϴ�. �� ������ �ٸ� �������� ����
            rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}

        // 1�� ���� ������ �︮�� �Լ��Դϴ�. //10-21
        Handheld.Vibrate();
    }




    // 2D ���ο� �浹 �Լ�
    // ����Ƽ 2D ������ 2D Collider�� Rigidbody 2D �� 2D �浹 �Լ��� ����ؾ� �մϴ�.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("2D �浹");
        if(collision.CompareTag("Portal")) // ��Ż�̶� �ε�ġ��
        {                                                       // -10 �ص� ��
            //Camera.main.transform.position = new Vector3(20, 0, Camera.main.transform.position.z);
            // ĳ���Ϳ� ����ī�޶� ���� ���� ī�޶� ��ġ�� �̵���ų �ʿ䰡 ����
            transform.position = new Vector3(12.5f, 0, 0);
        }

        if(collision.CompareTag("Potion")) // 10-21 // ���ǿ�Ÿ
        {
            health += 10;

            // �ε��� ��ü�� �ı��˴ϴ�.
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("2D �浹 ��");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("2D �浹 ���");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("2D �浹 Collision");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("2D �浹 Collision");
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("2D �浹 ��� Collision");
    }

   
}
