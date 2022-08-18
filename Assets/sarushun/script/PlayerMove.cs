using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D  _rb;
    [SerializeField, Tooltip("ˆÚ“®‘¬“x")]
    float _speed;
    [SerializeField,Tooltip("ƒWƒƒƒ“ƒv—Í")] 
    int _jumpForce;
    private int _jumpCount = 0;
    PlayerHide _playerHide;
    SpriteRenderer _sr;
    //bool _isKilled;
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
        Kill();
    }
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, 0);
        _rb.velocity = direction.normalized * _speed + new Vector2(0, _rb.velocity.y);

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
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jumpCount++;
        }

    }
    void Kill()
    {
        //if(_isKilled && Input.GetMouseButtonDown(0))
        //{
        //    Enemy1Controller.instance.EnemyDestroy();
        //    _isKilled = false;
        //}
        if(Enemy1Controller.instance.IsKilled && Input.GetMouseButtonDown(0))
        {
            Enemy1Controller.instance.EnemyDestroy();
            Enemy1Controller.instance.IsKilled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _jumpCount = 0;
        }
        
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "haigo")
    //    {
    //        Debug.Log("”wŒã‚É‚¢‚é");
    //        _isKilled = true;
    //    }
    //}
}
