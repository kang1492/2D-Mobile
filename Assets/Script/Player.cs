using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D; // ������ �ٵ� ��������

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

        // �����̱�
        transform.Translate
            (
            x * speed * Time.deltaTime,
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
    //������ �ٵ� ���� ���� ���
    //private void FixedUpdate()
    //{
        
    //}

    public void Jump()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) // 10-18 �̵�
        //{
            // ForceMode2D.Impulse : ���Ը� ������ �� ����մϴ�. �� ������ �ٸ� �������� ����
            rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}
    }




    // 2D ���ο� �浹 �Լ�
    // ����Ƽ 2D ������ 2D Collider�� Rigidbody 2D �� 2D �浹 �Լ��� ����ؾ� �մϴ�.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("2D �浹");
        if(collision.CompareTag("Portal")) // ��Ż�̶� �ε�ġ��
        {                                                       // -10 �ص� ��
            Camera.main.transform.position = new Vector3(20, 0, Camera.main.transform.position.z);
            transform.position = new Vector3(12.5f, 0, 0);
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
