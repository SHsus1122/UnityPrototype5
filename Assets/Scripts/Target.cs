using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public ParticleSystem explosionParticle;    // Destroy 식 이펙트
    public int pointValue;                      // Target 의 점수 포인트

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        // 이름으로부터 게임 내의 있는 오브젝트를 가져와서 GameManager 타입의 컴포넌트로 가져옵니다.(즉, 형변환)
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // 랜덤하게 위로 힘을 줘서 스폰시 튀어오르게 하는 힘에 대한 코드입니다.
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        // 회전하는 방향에 대한 힘을 주는 코드입니다.
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        // 랜덤 생성하는 위치에 대한 코드입니다.
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 마우스 커서가 마우스를 누르거나(Down) 풀 때(Up)를 감지하는 유니티 내장 함수
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            // 파괴된 해당 위치에 파티클을 생성해서 보여주도록 합니다.
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    // 오브젝트 자동 파괴 함수
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
