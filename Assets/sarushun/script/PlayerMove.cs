using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField, Tooltip("移動速度")]
    float _speed;
    [SerializeField, Tooltip("ジャンプ力")]
    int _jumpForce;
    //[SerializeField] GameObject[] _enemys;
    //[SerializeField] GameObject _enemyMuzzle;
    //[SerializeField] float _radius;
    //[SerializeField] LayerMask _enemyLayer;
    //[SerializeField] float _distance;
    private int _jumpCount = 0;
    PlayerHide _playerHide;
    SpriteRenderer _sr;
    bool _isKilled;
    //bool _korosu;

    //public bool Korosu
    //{
    //    get { return _korosu; }
    //    set { _korosu = value; }
    //}
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
        //Collider[] targets = Physics.OverlapSphere(transform.position, _radius, _enemyLayer);
        //foreach (var enemys in targets)
        //{
        //    _enemyMuzzle = enemys.gameObject;
        //}
        //if (_enemyMuzzle != null)
        //{
        //    float dis = Vector2.Distance(this.gameObject.transform.position, _enemyMuzzle.gameObject.transform.position);
        //    if (dis <= _distance && Enemy1Controller.instance.IsKilled)
        //    {
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            Debug.Log("Click");
        //            _korosu = true;
        //        }
        //    }
        //}
    }

    private void OnDestroy()
    {
        SceneChanger.Instance.ChangeScene();
    }
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, 0);
        _rb.velocity = direction.normalized * _speed + new Vector2(0, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this._jumpCount < 1)//&& !_playerHide.IsHided)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jumpCount++;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _jumpCount = 0;
        }
        //string layerName = LayerMask.LayerToName(other.gameObject.layer);

        //if (layerName == "Water")
        //{
        //   Destroy(gameObject);
        //}

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "haigo")
        {
            Debug.Log("背後にいる");
            if (Input.GetMouseButtonDown(0))
            {
                collision.gameObject.GetComponent<Enemy1Controller>().EnemyDestroy();
                ScoreCount.instance.KillCountPlus(100);
            }

        }
        else
        {
            _isKilled = false;
        }
    }
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, _distance);
    //}
}
