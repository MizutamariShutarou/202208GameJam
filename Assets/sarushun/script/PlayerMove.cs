using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D  _rb;
    [SerializeField, Tooltip("移動速度")]
    float speed;
    [SerializeField,Tooltip("ジャンプ力")] 
    int _jumpForce;
    private int _jumpCount = 0;
    PlayerHide _playerHide;
    SpriteRenderer _sr;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        this._sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        //Kill();
    }
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, 0).normalized;

        // 移動する向きとスピードを代入 
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        if (Input.GetKeyDown(KeyCode.A))
        {
            _sr.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _sr.flipX = false;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this._jumpCount < 1 )//&& !_playerHide.IsHided)
        {
            this._rb.AddForce(transform.up * _jumpForce);
            _jumpCount++;
        }

    }
    void Kill()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Enemy1Controller.instance.EnemyDestroy();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _jumpCount = 0;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "haigo")
        {
            Debug.Log("背後にいる");
            Kill();
        }
    }
}
