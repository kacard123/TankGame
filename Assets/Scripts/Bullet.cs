using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int power = 500; // 포 발사 속도
    public AudioClip sound; // 사운드
    public GameObject exp; // 불꽃화염 파티클 프리팹

    private void Start()
    {
        // 객체 - 컴포넌트 - 함수()
        this.GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }
    private void Update()
    {

    }

    // 트리거가 체크되어 있을 때 호출되는 함수(물리적인 속성없음 단순 충돌 검)
    private void OnTriggerEnter(Collider col)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        GameObject copy_exp = Instantiate(exp) as GameObject; // 파티클 프리팹

        if (col.gameObject.tag == "WALL")
        {
            copy_exp.transform.position = col.transform.position; // 폭발 파티클을 생성시키는 위치
            Destroy(col.gameObject); // 충돌한 게임 오브젝트(총알) 삭제 / 벽을 없앰
        }
        else if (col.gameObject.tag == "ENEMY")
        {
            Score.Hit++;
            if (Score.Hit > 5)
            {
                // 적 탱크 사라진다
                // 승리 화면으로 전환(씬 전환)
            }
        }
        else if(col.gameObject.tag == "TANK")
        {
            Score.Hit++;
            if(Score.Hit > 5)
            {
                // 내 탱크가 사라짐
                // 패배 화면 전환 (씬 전환)
            }
        }
        AudioSource.PlayClipAtPoint(sound, transform.position);
        // copy_exp.transform.position = this.transform.position;
        
        Destroy(this.gameObject); // 총알을 없앰   
    }
}
