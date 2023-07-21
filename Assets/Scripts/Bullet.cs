using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int power = 500; // �� �߻� �ӵ�
    public AudioClip sound; // ����
    public GameObject exp; // �Ҳ�ȭ�� ��ƼŬ ������

    private void Start()
    {
        // ��ü - ������Ʈ - �Լ�()
        this.GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }
    private void Update()
    {

    }

    // Ʈ���Ű� üũ�Ǿ� ���� �� ȣ��Ǵ� �Լ�(�������� �Ӽ����� �ܼ� �浹 ��)
    private void OnTriggerEnter(Collider col)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        GameObject copy_exp = Instantiate(exp) as GameObject; // ��ƼŬ ������

        if (col.gameObject.tag == "WALL")
        {
            copy_exp.transform.position = col.transform.position; // ���� ��ƼŬ�� ������Ű�� ��ġ
            Destroy(col.gameObject); // �浹�� ���� ������Ʈ(�Ѿ�) ���� / ���� ����
        }
        else if (col.gameObject.tag == "ENEMY")
        {
            Score.Hit++;
            if (Score.Hit > 5)
            {
                // �� ��ũ �������
                // �¸� ȭ������ ��ȯ(�� ��ȯ)
            }
        }
        else if(col.gameObject.tag == "TANK")
        {
            Score.Hit++;
            if(Score.Hit > 5)
            {
                // �� ��ũ�� �����
                // �й� ȭ�� ��ȯ (�� ��ȯ)
            }
        }
        AudioSource.PlayClipAtPoint(sound, transform.position);
        // copy_exp.transform.position = this.transform.position;
        
        Destroy(this.gameObject); // �Ѿ��� ����   
    }
}
