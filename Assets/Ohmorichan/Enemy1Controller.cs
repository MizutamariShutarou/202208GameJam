using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Rigidbody2D _rb = default;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
            Debug.DrawLine(current, current + _lineLength * -1f);
        }
        RaycastHit2D hit = Physics2D.Linecast(current, current + _lineLength, _wallLayer);
        RaycastHit2D hit2 = Physics2D.Linecast(current, (current + _lineLength) * -1f, _wallLayer);
    }

    void Move()
    {

    }
}
