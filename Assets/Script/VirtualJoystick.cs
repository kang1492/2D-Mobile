using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝보낼 수 있는 네임 스페이스입니다.


public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{                                           // 잠재적 구현 하기 : 오류 밑에 첫번째 영어
    [SerializeField] RectTransform lever;

    private RectTransform rectTransform;

    [SerializeField] Player player; // 10-19

    [SerializeField, Range(10f, 150f)] // 최대값 최소값 밖에서 설정하기

    float leverRange;

    Vector2 inputDirection; // 10-19

    bool condition; //10-19 

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

                //드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 시작");
        var inputDirection = eventData.position - rectTransform.anchoredPosition;
        lever.anchoredPosition = inputDirection;

        // 제안하다           적과 나와의 길이
        var clampDirection = inputDirection.magnitude < leverRange ?
            inputDirection : inputDirection.normalized * leverRange;
        // 노말라이징 넣는 이유 : 방향키 큔등하게 이동할수 있도록

        lever.anchoredPosition = clampDirection;

        this.inputDirection = clampDirection / leverRange; // 10-19
        // 캐릭터의 이동속도를 0~1 사이의 값을 정규화 합니다.

        condition = true;
    }
    // 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 중");
        // 내가 가고자 하는 방향 = 현재 선택한 위치 - 자신의 위치
        var inputDirection = eventData.position - rectTransform.anchoredPosition;

        // 제안하다           적과 나와의 길이
        // (조건 : inputDirection.magnitude < leveRange)
        // 참이면 inputDirection
        // 거짓이면 inputDirection.normalized * leverRange
        var clampDirection = inputDirection.magnitude < leverRange ?
            inputDirection : inputDirection.normalized * leverRange;
                               // 노말라이징 넣는 이유 : 방향키 큔등하게 이동할수 있도록

        lever.anchoredPosition = clampDirection;

        this.inputDirection = clampDirection / leverRange; // 10-19
        // 캐릭터의 이동속도를 0~1 사이의 값을 정규화 합니다.

        
    }
                // 드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        player.Slip(); // 10-19 이동속도 호출

        Debug.Log("드래그 종료");
        // lever의 위치를 x = 0, y = 0 으로 초기화 합니다
        lever.anchoredPosition = Vector2.zero;

        // 플레이어의 이동을 초기화 합니다.
        player.Move(Vector2.zero); // 이동속도 0 /10-19

        condition = false;
    }

    public void CharacterMove() //10-19
    {
        player.Move(inputDirection);
    }

    void Update() //10-19
    {
        if (condition == true) // 컨티션이 트류라면 이동할수 있개
        {
            CharacterMove();
        }
    }
}
