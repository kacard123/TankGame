using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // public GameObject target;
    public GameObject bullet;
    public GameObject spPoint; // �Ѿ� ������ ����Ʈ

    // private NavMeshAgent nvAgent;
    private Transform target; // �Ʊ� ��ũ�� ��ġ ����
    private int rotAngle;
    private float amtToRot;
    private int power;
    private float distance; // �÷��̾� ��ũ�� �� ��ũ ���̿� �Ÿ�
    private Vector3 direction;
    private float moveSpeed;
    private float fTime; // �Ѿ��� ������ �ð�

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        //moveSpeed = 1.0f;
        //power = 10;
        //fTime = 0.0f;
        //rotAngle = 15;

        fTime = 0.0f;

        //nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // �Ʊ� �������� ȸ��
        // transform.LookAt(target.transform.position);
        // �Ѿ��� ��ũ������ ������ ������ ��
        direction = target.transform.position - this.transform.position;
        distance = Vector3.Distance(target.transform.position, this.transform.forward);
        fTime += Time.deltaTime;

        if (distance < 15.0f)
        {
            // nvAgent.destination = target.position;
            // �� ��ũ ������� ����
            if (fTime > 0.5f)
            {
                // �Ѿ� ����
                GameObject obj = Instantiate(bullet) as GameObject;
                obj.transform.position = spPoint.transform.position;
                obj.GetComponent<Rigidbody>().AddForce(direction * power);

                // �Ѿ� ������ ����(2)

                // ���� ó��
                fTime = 0.0f;

                this.transform.LookAt(target.transform.position);
                amtToRot = rotAngle * Time.deltaTime;
                transform.RotateAround(Vector3.zero, Vector3.up, amtToRot);
                this.transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed / 2);
                // Lerp �Լ��� ������ġ, ��ǥ��ġ, 0~1 ���� ���ڷ� ������, 1�� �������� �� ��������
            }
        }
    }
}
