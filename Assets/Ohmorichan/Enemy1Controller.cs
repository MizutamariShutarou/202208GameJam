using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy1Controller : MonoBehaviour
{
    //判定のラインの可視化
    [Header("判定のラインの可視化")]
    [SerializeField] bool _isCastLine = default;
    /// <summary>左右のラインの長さ</summary>
    [Tooltip("左右のラインの長さ")]
    [SerializeField] Vector2 _lineLength = Vector2.right;
    [Tooltip("Castするレイヤー")]
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>通常の状態で左右に動く距離</summary>
    [Header("通常の状態で左右に動く距離")]
    [SerializeField] float _moveDistance = 5f;
    Rigidbody2D _rb = default;
    Sequence _enemyMove;
    PlayerHide _playerHide;
    bool _isFliped;

    public static Enemy1Controller instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
        _playerHide = GetComponent<PlayerHide>();
        _rb = GetComponent<Rigidbody2D>();
        _enemyMove = DOTween.Sequence();

        _enemyMove.Append(
         transform.DOMoveX(_moveDistance, 2f)
            .SetRelative(true).SetDelay(1f)
            .OnComplete(OnFlipLeft));


        _enemyMove.Append(
         transform.DOMoveX(-_moveDistance, 2f)
            .SetRelative(true).SetDelay(1f)
            .OnComplete(OnFlipRight));

        //_enemyMove.Append(
        // transform.DOMoveX(-_moveDistance, 2f)
        //    .SetRelative(true).SetDelay(1f));

        _enemyMove.SetLoops(-1);
    }

    void Update()
    {
        Draw();
    }

    void Draw()
    {
        Vector2 current = this.transform.position;

        if (_isCastLine)
        {
            Debug.DrawLine(current, current + _lineLength);
        }

        RaycastHit2D hit = Physics2D.Linecast(current, current + _lineLength, _wallLayer);

        if (hit.collider)
        {
            Debug.Log("右に当たっとうよ" + hit.collider.gameObject.name);
            _enemyMove.Pause();
            _rb.velocity = (hit.collider.transform.position - this.transform.position).normalized;
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.EnemyDeath();
    }

    public void EnemyDestroy()
    {
        Destroy(gameObject);
    }
    public void OnFlipLeft()
    {
        _lineLength *= -1f;
        Debug.Log("1");
        transform.localScale = Vector3.one;
    }
    public void OnFlipRight()
    {
        _lineLength *= -1f;
        Debug.Log("2");
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }
}
