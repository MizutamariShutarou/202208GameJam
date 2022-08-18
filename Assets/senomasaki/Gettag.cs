using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gettag : MonoBehaviour
{
    public bool flag;

    public bool Flag { get => flag; set => flag = value; }
    // Start is called before the first frame update

    private void Start()
    {
        flag=false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            flag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        flag = false;
    }
}
