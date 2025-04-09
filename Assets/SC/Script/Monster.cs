using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Vector3 pos1;
    [SerializeField] Vector3 pos2;

    [SerializeField] float speed;
    Vector3 desPos;
    private void Start()
    {
        desPos = pos1;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            if ((desPos - transform.position).magnitude < 0.03f)
            {
                desPos = desPos == pos1 ? pos2 : pos1;
            }
            else
            {
                transform.position += (desPos - transform.position).normalized * speed * Time.deltaTime;
            }
        }
    }
}
