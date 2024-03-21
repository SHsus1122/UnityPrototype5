using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                // TextMeshPro 사용을 위해서 임포트 합니다.
using UnityEngine.SceneManagement;  // 씬을 관리하기 위해서 임포트 합니다.
using UnityEngine.UI;       // 다양한 기능이 있지만 우선 여기서는 Button 사용을 위해 임포트 합니다.

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;    // 스폰시킬 타겟의 리스트
    public TextMeshProUGUI scoreText;   // Score UI 변수
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;           // 게임 플레이 상태 가능 여부 판단 변수
    public Button restartButton;        // 게임 재시작 버튼

    private int score;
    private float spawnRate = 1.0f;     // 랜덤 스폰 주기

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
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

    public void GameOver()
    {
        isGameActive = false;                      // 게임 종료용 bool 변수 이용해서 게임 종료
        gameOverText.gameObject.SetActive(true);   // 게임종료 메시지 문구 활성화
        restartButton.gameObject.SetActive(true);  // 게임 재시작 버튼 활성화
    }

    public void RestartGame()
    {
        // 현재 사용중인 씬을 다시 로드하는 코드입니다.
        // SceneManager.GetActiveScene() 으로 현재 사용중인 씬을 인식하고 .name 로 해다 씬의 이름을 가져옵니다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
