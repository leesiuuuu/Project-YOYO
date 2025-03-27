using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushGlove : MonoBehaviour
{
    public float PushPower
    {
        get => _PushPower;
        set => _PushPower = value;
    }
    [SerializeField]private float _PushPower;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.CompareTag("Player"))
        {
            if (colision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigid))
            {
                if(gameObject.transform.position.x < colision.gameObject.transform.position.x)
                {
                    rigid.AddForce(Vector2.right * _PushPower, ForceMode2D.Impulse);

                }
                else if(gameObject.transform.position.x > colision.gameObject.transform.position.x)
                {
                    rigid.AddForce(Vector2.left * _PushPower, ForceMode2D.Impulse);
                }
                rigid.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            }
        }
    }
}
