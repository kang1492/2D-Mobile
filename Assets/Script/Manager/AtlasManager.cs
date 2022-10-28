using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D; // SpriteAtlas class ����� �� �մ� nameSpace

public class AtlasManager : MonoBehaviour
{
    [SerializeField] SpriteAtlas atlas;

    [SerializeField] Image testImg;

    void Start()
    {
        // �������� 30���� �����մϴ�.
        Application.targetFrameRate = 30;
        testImg.sprite = atlas.GetSprite("Coin");
    }

    
    void Update()
    {
        
    }
}
