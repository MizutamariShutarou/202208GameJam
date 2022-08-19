//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class Enemy1Controller : MonoBehaviour
//{
//    //����̃��C���̉���
//    [Header("����̃��C���̉���")]
//    [SerializeField] bool _isCastLine = default;
//    /// <summary>���E�̃��C���̒���</summary>
//    [Tooltip("���E�̃��C���̒���")]
//    [SerializeField] Vector2 _lineLength = Vector2.right;
//    [Tooltip("Cast���郌�C���[")]
//    [SerializeField] LayerMask _wallLayer = 0;
//    /// <summary>�ʏ�̏�Ԃō��E�ɓ�������</summary>
//    [Header("�ʏ�̏�Ԃō��E�ɓ�������")]
//    [SerializeField] float _moveDistance = 5f;
//    Rigidbody2D _rb = default;
//    Sequence _enemyMove;
//    PlayerHide _playerHide;
//    bool _isFliped;

//    public static Enemy1Controller instance;
//    public void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//    }
//    void Start()
//    {
//        transform.localScale = new Vector3(-1f, 1f, 1f);
//        _playerHide = GetComponent<PlayerHide>();
//        _rb = GetComponent<Rigidbody2D>();
//        _enemyMove = DOTween.Sequence();

//        _enemyMove.Append(
//         transform.DOMoveX(_moveDistance, 2f)
//            .SetRelative(true).SetDelay(1f)
//            .OnComplete(OnFlipLeft));


//        _enemyMove.Append(
//         transform.DOMoveX(-_moveDistance, 2f)
//            .SetRelative(true).SetDelay(1f)
//            .OnComplete(OnFlipRight));

//        //_enemyMove.Append(
//        // transform.DOMoveX(-_moveDistance, 2f)
//        //    .SetRelative(true).SetDelay(1f));

//        _enemyMove.SetLoops(-1);
//    }

//    void Update()
//    {
//        Draw();
//    }

//    void Draw()
//    {
//        Vector2 current = this.transform.position;

//        if (_isCastLine)
//        {
//            Debug.DrawLine(current, current + _lineLength);
//        }

//        RaycastHit2D hit = Physics2D.Linecast(current, current + _lineLength, _wallLayer);

//        if (hit.collider)
//        {
//            Debug.Log("�E�ɓ������Ƃ���" + hit.collider.gameObject.name);
//            _enemyMove.Pause();
//            _rb.velocity = (hit.collider.transform.position - this.transform.position).normalized;
//        }
//    }

//    private void OnDestroy()
//    {
//        GameManager.Instance.EnemyDeath();
//    }

//    public void EnemyDestroy()
//    {
//        Destroy(gameObject);
//    }
//    public void OnFlipLeft()
//    {
//        _lineLength *= -1f;
//        Debug.Log("1");
//        transform.localScale = Vector3.one;
//    }
//    public void OnFlipRight()
//    {
//        _lineLength *= -1f;
//        Debug.Log("2");
//        transform.localScale = new Vector3(-1f, 1f, 1f);
//    }
//}
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
    [SerializeField] GameObject _player;
    //[SerializeField, Tooltip("�E����͈�")] float _killDistance;
    /// <summary>�G�����S�������̃A�j���[�V����</summary>
    [SerializeField] GameObject _deadEffect;

    Rigidbody2D _rb = default;
    SpriteRenderer _sr;
    Sequence _enemyMove;
    PlayerHide _playerHide;
    PlayerMove _playerMove;
    bool _isMoved;
    //bool _isKilled;

    //public bool IsKilled
    //{
    //    get { return _isKilled; }
    //    set { _isKilled = value; }
    //}
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
        _isMoved = true;
        //_isKilled = true;
        this._playerMove = FindObjectOfType<PlayerMove>();
        bool k = _playerMove.Korosu;
        _playerHide = FindObjectOfType<PlayerHide>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _enemyMove = DOTween.Sequence();

        _enemyMove.Append(
         transform.DOLocalMoveX(_moveDistance, 2f)
            .SetRelative(true).SetDelay(1f)
            .OnComplete(OnFlipLeft));


        _enemyMove.Append(
         transform.DOLocalMoveX(-_moveDistance, 2f)
            .SetRelative(true).SetDelay(1f)
            .OnComplete(OnFlipRight));

        //_enemyMove.Append(
        // transform.DOMoveX(-_moveDistance, 2f)
        //    .SetRelative(true).SetDelay(1f));

        _enemyMove.SetLoops(-1);
    }

    void Update()
    {
        //Debug.Log($"_isKilled = {_isKilled}");
        Draw();
        if (_playerMove.Korosu)
        {
            Destroy(this.gameObject);
        }
    }

    void Draw()
    {
        Vector2 current = this.transform.position;

        if (_isCastLine)
        {
            Debug.DrawLine(current, current + _lineLength);
        }

        RaycastHit2D hit = Physics2D.Linecast(current, current + _lineLength, _wallLayer);

        if (hit.collider && !_playerHide.IsHided)
        {
            //Debug.Log("�E�ɓ������Ƃ���" + hit.collider.gameObject.name);
            //_isKilled = false;
            _enemyMove.Pause();
            _isMoved = false;
            _rb.velocity = (_player.gameObject.transform.position - this.transform.position).normalized;
        }

        if (_playerHide.IsHided)
        {
            if (!_isMoved)
            {
                _enemyMove.Play();
                OnFlipRight();
                _isMoved = true;
            }
            //_isKilled = true;
        }


    }

    private void OnDestroy()
    {
       // _playerMove.Korosu = false;
        GameManager.Instance.EnemyDeath();

        if (_deadEffect)
        {
            Instantiate(_deadEffect);
        }
    }

    public void EnemyDestroy()
    {
        Destroy(this.gameObject);
    }
    public void OnFlipLeft()
    {
        _lineLength *= -1f;
        //Debug.Log("1");
    }
    public void OnFlipRight()
    {
        _lineLength *= -1f;
        _sr.flipX = false;
        //Debug.Log("2");
    }
}

