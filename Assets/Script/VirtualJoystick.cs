using UnityEngine;
using UnityEngine.EventSystems; // Ű����, ���콺, ��ġ�� �̺�Ʈ�� ���������� �� �ִ� ���� �����̽��Դϴ�.


public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{                                           // ������ ���� �ϱ� : ���� �ؿ� ù��° ����
    [SerializeField] RectTransform lever;

    private RectTransform rectTransform;

    [SerializeField] Player player; // 10-19

    [SerializeField, Range(10f, 150f)] // �ִ밪 �ּҰ� �ۿ��� �����ϱ�

    float leverRange;

    Vector2 inputDirection; // 10-19

    bool condition; //10-19 

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

                //�巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ����");
        var inputDirection = eventData.position - rectTransform.anchoredPosition;
        lever.anchoredPosition = inputDirection;

        // �����ϴ�           ���� ������ ����
        var clampDirection = inputDirection.magnitude < leverRange ?
            inputDirection : inputDirection.normalized * leverRange;
        // �븻����¡ �ִ� ���� : ����Ű Ŧ���ϰ� �̵��Ҽ� �ֵ���

        lever.anchoredPosition = clampDirection;

        this.inputDirection = clampDirection / leverRange; // 10-19
        // ĳ������ �̵��ӵ��� 0~1 ������ ���� ����ȭ �մϴ�.

        condition = true;
    }
    // �巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ��");
        // ���� ������ �ϴ� ���� = ���� ������ ��ġ - �ڽ��� ��ġ
        var inputDirection = eventData.position - rectTransform.anchoredPosition;

        // �����ϴ�           ���� ������ ����
        // (���� : inputDirection.magnitude < leveRange)
        // ���̸� inputDirection
        // �����̸� inputDirection.normalized * leverRange
        var clampDirection = inputDirection.magnitude < leverRange ?
            inputDirection : inputDirection.normalized * leverRange;
                               // �븻����¡ �ִ� ���� : ����Ű Ŧ���ϰ� �̵��Ҽ� �ֵ���

        lever.anchoredPosition = clampDirection;

        this.inputDirection = clampDirection / leverRange; // 10-19
        // ĳ������ �̵��ӵ��� 0~1 ������ ���� ����ȭ �մϴ�.

        
    }
                // �巡�� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        player.Slip(); // 10-19 �̵��ӵ� ȣ��

        Debug.Log("�巡�� ����");
        // lever�� ��ġ�� x = 0, y = 0 ���� �ʱ�ȭ �մϴ�
        lever.anchoredPosition = Vector2.zero;

        // �÷��̾��� �̵��� �ʱ�ȭ �մϴ�.
        player.Move(Vector2.zero); // �̵��ӵ� 0 /10-19

        condition = false;
    }

    public void CharacterMove() //10-19
    {
        player.Move(inputDirection);
    }

    void Update() //10-19
    {
        if (condition == true) // ��Ƽ���� Ʈ����� �̵��Ҽ� �ְ�
        {
            CharacterMove();
        }
    }
}
