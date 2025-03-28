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
    [SerializeField] private float _PushPower;

    private bool _canPushPlayer1 = true;
    private bool _canPushPlayer2 = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player1 player1 = gameObject.GetComponentInParent<Player1>();
        if (player1)
        {
            if (!_canPushPlayer1)
                return;

            if (!player1.Push)
                return;

            if (collision.gameObject.CompareTag("Player2"))
            {
                if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigid))
                {
                    if (gameObject.transform.position.x < collision.gameObject.transform.position.x)
                    {
                        rigid.AddForce(Vector2.right * _PushPower, ForceMode2D.Impulse);
                        Debug.Log("Push");
                    }
                    else if (gameObject.transform.position.x > collision.gameObject.transform.position.x)
                    {
                        rigid.AddForce(Vector2.left * _PushPower, ForceMode2D.Impulse);
                    }
                    rigid.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                    StartCoroutine(PushCooldownPlayer1());
                }
            }
        }

        Player2 player2 = gameObject.GetComponentInParent<Player2>();
        if (player2)
        {
            if (!_canPushPlayer2)
                return;

            if (!player2.Push)
                return;

            if (collision.gameObject.CompareTag("Player1"))
            {
                if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigid))
                {
                    if (gameObject.transform.position.x < collision.gameObject.transform.position.x)
                    {
                        rigid.AddForce(Vector2.right * _PushPower, ForceMode2D.Impulse);
                        Debug.Log("Push");
                    }
                    else if (gameObject.transform.position.x > collision.gameObject.transform.position.x)
                    {
                        rigid.AddForce(Vector2.left * _PushPower, ForceMode2D.Impulse);
                    }
                    rigid.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                    StartCoroutine(PushCooldownPlayer2());
                }
            }
        }
    }

    private IEnumerator PushCooldownPlayer1()
    {
        _canPushPlayer1 = false;
        yield return new WaitForSeconds(0.5f);
        _canPushPlayer1 = true;
    }

    private IEnumerator PushCooldownPlayer2()
    {
        _canPushPlayer2 = false;
        yield return new WaitForSeconds(0.5f);
        _canPushPlayer2 = true;
    }
}
