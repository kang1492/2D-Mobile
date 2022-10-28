using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D; // SpriteAtlas class 사용할 수 잇는 nameSpace

public class AtlasManager : MonoBehaviour
{
    [SerializeField] SpriteAtlas atlas;

    [SerializeField] Image testImg;

    void Start()
    {
        // 프래임을 30으로 고정합니다.
        Application.targetFrameRate = 30;
        testImg.sprite = atlas.GetSprite("Coin");
    }

    
    void Update()
    {
        
    }
}
