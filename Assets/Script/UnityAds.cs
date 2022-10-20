using UnityEngine;
using System.Collections; // ���� �ȳ��ö� �ʿ��� �Լ�
using UnityEngine.Advertisements;// ����

public class UnityAds : MonoBehaviour
{   
                            // ���� �ȵ���̵� ID �־��ֱ�
    private string androidID = "4979855";

    private int gameMoney = 0; // 10-20 
    
    void Start()
    {
        Advertisement.Initialize(androidID);
        ShowBanner();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Ű ������ ���鱤�� ������
        {
            ShowInitialize();
        }

        if (Input.GetKeyDown(KeyCode.Return)) // �ӽ÷� ������ ���� ������
        {
            ShowRewarded();
        }
    }

    public void ShowInitialize() // ���鱤��
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    // ��� ���� ����
    public void ShowBanner()
    {
        if(Advertisement.IsReady("Banner_Android"))
        {
            // ��� ������ ��ġ ����
            // ��� ��ġ ..  ���� ����
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
            // ��ʱ��� �����ֱ�
        }
        else // ���� �ȳ�������
        {
            StartCoroutine(RepeateBanner());
        }
    }
    
    private IEnumerator RepeateBanner()
    {
        // 1�� �Ŀ� 
        yield return new WaitForSeconds(1f);
        ShowBanner();
    }

    private void HandleShowResult(ShowResult resule) // ������ ����
    {
        switch(resule) // 30�� �� ���ߵ� ��ŵ�ϸ� �ָ� �ȵ�
        {
            // ���� �� ���� 
            case ShowResult.Finished : gameMoney += 10;
                break;
            // ���� ��ŵ�� ������
            case ShowResult.Skipped:
                Debug.Log("���� ��ŵ�߱� ������ ������ ���� �� �����ϴ�.");
                break;

            // ������ ������ �������� ��
            case ShowResult.Failed:
                Debug.LogError("���� ������ �����߽��ϴ�.");
                break;
        }
    }

    public void ShowRewarded()
    {
        if(Advertisement.IsReady())
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };

            Advertisement.Show("Rewarded_Android", options);
        }
    }
}
