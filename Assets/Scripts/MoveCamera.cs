using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    private void Update()
    {
        transform.position = pos + player.transform.position;
    }
}
