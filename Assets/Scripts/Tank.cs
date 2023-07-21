using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tank : MonoBehaviour
{
    public int moveSpeed;
    public float move;
    public float moveVertical;

    public int rotSpeed;
    public float rotate;
    public float rotHorizon;

    public float rotTurret;
    public GameObject turret;
    public GameObject gun;

    public int power; // �� �߻� �ӵ�
    public GameObject bulletPrefab; // �Ѿ�
    private Transform spPoint; // ���� ��ġ

    public float destroytime = 2.0f;
    void Start()
    {
        moveSpeed = 5;
        rotSpeed = 120;
        power = 600;
        spPoint = GameObject.Find("spPoint").transform;
    }
    void Update()
    {
        move = moveSpeed * Time.deltaTime;
        rotate = rotSpeed * Time.deltaTime;

        moveVertical = Input.GetAxis("Vertical"); // ������ ��
        rotHorizon = Input.GetAxis("Horizontal"); // ȸ�� ��
        rotTurret = Input.GetAxis("Window Shake X"); // ��ž ȸ��

        transform.Translate(Vector3.forward * move * moveVertical); 
        transform.Rotate(new Vector3(0.0f, rotate * rotHorizon, 0.0f));
        turret.transform.Rotate(Vector3.up * rotTurret * rotate);

        // ����(GunBarrel) - ���콺 ���� �̿��� �� �� �Ʒ��� ȸ��
        float keyGun = Input.GetAxis("Mouse ScrollWheel");
        gun.transform.Rotate(Vector3.right * keyGun * 4); // Eulers

        Vector3 ang = gun.transform.eulerAngles;
        if (ang.x > 180)
            ang.x -= 360;
        ang.x = Mathf.Clamp(ang.x, -15, 5); // Value, Min, Max
        gun.transform.eulerAngles = ang;

        if (Input.GetMouseButtonDown(0)) // �Ѿ� ���� 
        {
            // Instantiate�� �����Ҷ� ����ϸ� (������ ������Ʈ, ������ġ, ������ ȸ����)�� ���ڰ����� ������
            GameObject bullet = Instantiate(bulletPrefab, spPoint.position, spPoint.rotation) as GameObject;
            Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>();
            bulletAddforce.AddForce(turret.transform.forward * power);
        }
    }
}
