using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // TextMeshPro 사용을 위해서 임포트 합니다.

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;    // 스폰시킬 타겟의 리스트
    public TextMeshProUGUI scoreText;   // Score UI 변수
    private int score;
    private float spawnRate = 1.0f;     // 랜덤 스폰 주기

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);     // spawnRate 간격으로 호출
            int index = Random.Range(0, targets.Count);     // List 사이즈가 최대 랜덤 숫자
            Instantiate(targets[index]);

        }
    }

    // 점수 갱신용 함수
    public void UpdateScore(int scoreToAdd)
    {
        // 출력 되는 곳에서 전달받은 카운트를 추가하여 scoreUI 변수의 text 에 설정
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
}
