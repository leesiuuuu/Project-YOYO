using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public float margin = 2f;

    private void Awake()
    {
        object1 = GameObject.Find("Player1").GetComponent<Transform>();
        object2 = GameObject.Find("Player2").GetComponent<Transform>();
    }

    void Update()
    {
        float distance = Vector2.Distance(object1.position, object2.position);
        Camera.main.orthographicSize = Mathf.Max((distance / 2f) + margin, 7f);
    }
}
