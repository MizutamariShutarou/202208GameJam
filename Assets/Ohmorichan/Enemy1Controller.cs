using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy1Controller : MonoBehaviour
{
    //����̃��C���̉���
    [Header("����̃��C���̉���")]
    [SerializeField] bool _isCastLine = default;
    /// <summary>���E�̃��C���̒���</summary>
    [Tooltip("���E�̃��C���̒���")]
    [SerializeField] Vector2 _lineLength = Vector2.right;
    [Tooltip("Cast���郌�C���[")]
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>�ʏ�̏�Ԃō��E�ɓ�������</summary>
    [Header("�ʏ�̏�Ԃō��E�ɓ�������")]
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
            Debug.Log("�E�ɓ������Ƃ���" + hit.collider.gameObject.name);
            _enemyMove.Pause();
            _rb.velocity = new Vector2(1, 0);
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
    }
    public void OnFlipRight()
    {
        _lineLength *= -1f;
        Debug.Log("2");
    }
}
