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

    public int power; // 포 발사 속도
    public GameObject bulletPrefab; // 총알
    private Transform spPoint; // 생성 위치

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

        moveVertical = Input.GetAxis("Vertical"); // 전후진 값
        rotHorizon = Input.GetAxis("Horizontal"); // 회전 값
        rotTurret = Input.GetAxis("Window Shake X"); // 포탑 회전

        transform.Translate(Vector3.forward * move * moveVertical); 
        transform.Rotate(new Vector3(0.0f, rotate * rotHorizon, 0.0f));
        turret.transform.Rotate(Vector3.up * rotTurret * rotate);

        // 포선(GunBarrel) - 마우스 휠을 이용한 포 위 아래로 회전
        float keyGun = Input.GetAxis("Mouse ScrollWheel");
        gun.transform.Rotate(Vector3.right * keyGun * 4); // Eulers

        Vector3 ang = gun.transform.eulerAngles;
        if (ang.x > 180)
            ang.x -= 360;
        ang.x = Mathf.Clamp(ang.x, -15, 5); // Value, Min, Max
        gun.transform.eulerAngles = ang;

        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate는 복제할때 사용하며 (생성할 오브젝트, 생성위치, 생성시 회전값)을 인자값으로 가진다
            GameObject bullet = Instantiate(bulletPrefab, spPoint.position, spPoint.rotation) as GameObject;
            Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>();
            bulletAddforce.AddForce(turret.transform.forward * power);
        }
    }
}
