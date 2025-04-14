using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer line;
    public Transform Player;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        Player = transform.parent.GetComponent<Transform>();
    }

    private void Start()
    {
        line.positionCount = 2;
    }

    private void Update()
    {
        line.SetPosition(0, Player.transform.position);
        line.SetPosition(1, gameObject.transform.position);
    }
}
