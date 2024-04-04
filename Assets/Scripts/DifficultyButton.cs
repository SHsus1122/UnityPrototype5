using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Di : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int difficulty;      // 난이도 조절용 변수(SpawnRate 수치에 적용해서 값 적용)

    // Start is called before the first frame update
    void Start()
    {
        // 씬에 있는 Game Manager 컴포넌트를 사용해서 난이도 조절 구현
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // 버튼이 클릭 되면 호출될 함수 등록(바인딩 작업)
        button.onClick.AddListener(SetDiffiyCulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDiffiyCulty()
    {
        Debug.Log(button.gameObject.name + " was clicked"); // 확인용 Debug 로그 메시지
        gameManager.StartGame(difficulty);                  // Game Manager 로 가서 게임 시작 함수 호출 및 난이도 수치 전달
    }
}
