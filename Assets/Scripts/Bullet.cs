using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int power = 15000; // Æ÷ ¹ß»ç ¼Óµµ
    public AudioClip sound;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "WALL")
        {
            Destroy(col.gameObject); // º®À» ¾ø¾Ú
        }
        Destroy(gameObject); // ÃÑ¾ËÀ» ¾ø¾Ú

        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
