using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // public GameObject target;
    public GameObject bullet;
    public GameObject spPoint; // 총알 나가는 포인트

    // private NavMeshAgent nvAgent;
    private Transform target; // 아군 탱크의 위치 저장
    private int rotAngle;
    private float amtToRot;
    private int power;
    private float distance; // 플레이어 탱크와 적 탱크 사이와 거리
    private Vector3 direction;
    private float moveSpeed;
    private float fTime; // 총알이 나가는 시간

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
        // 아군 방향으로 회전
        // transform.LookAt(target.transform.position);
        // 총알이 탱크쪽으로 나가는 방향을 얻어냄
        direction = target.transform.position - this.transform.position;
        distance = Vector3.Distance(target.transform.position, this.transform.forward);
        fTime += Time.deltaTime;

        if (distance < 15.0f)
        {
            // nvAgent.destination = target.position;
            // 적 탱크 따라오기 구현
            if (fTime > 0.5f)
            {
                // 총알 생성
                GameObject obj = Instantiate(bullet) as GameObject;
                obj.transform.position = spPoint.transform.position;
                obj.GetComponent<Rigidbody>().AddForce(direction * power);

                // 총알 나가기 구현(2)

                // 사운드 처리
                fTime = 0.0f;

                this.transform.LookAt(target.transform.position);
                amtToRot = rotAngle * Time.deltaTime;
                transform.RotateAround(Vector3.zero, Vector3.up, amtToRot);
                this.transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed / 2);
                // Lerp 함수는 시작위치, 목표위치, 0~1 사이 숫자로 구성됨, 1에 가까울수록 더 빨라진다
            }
        }
    }
}
