using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int power = 15000; // �� �߻� �ӵ�
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
            Destroy(col.gameObject); // ���� ����
        }
        Destroy(gameObject); // �Ѿ��� ����

        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
