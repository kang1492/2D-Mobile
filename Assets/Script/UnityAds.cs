using UnityEngine;
using System.Collections; // 광고 안나올때 필요한 함수
using UnityEngine.Advertisements;// 광고

public class UnityAds : MonoBehaviour
{   
                            // 고유 안드로이드 ID 넣어주기
    private string androidID = "4979855";

    private int gameMoney = 0; // 10-20 
    
    void Start()
    {
        Advertisement.Initialize(androidID);
        ShowBanner();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // 키 누르면 전면광고 나오게
        {
            ShowInitialize();
        }

        if (Input.GetKeyDown(KeyCode.Return)) // 임시로 보상형 광고 나오게
        {
            ShowRewarded();
        }
    }

    public void ShowInitialize() // 전면광고
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    // 배너 광고 띠우기
    public void ShowBanner()
    {
        if(Advertisement.IsReady("Banner_Android"))
        {
            // 배너 광고의 위치 설정
            // 배너 위치 ..  바텀 센터
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
            // 배너광고 보여주기
        }
        else // 광고가 안나왔을때
        {
            StartCoroutine(RepeateBanner());
        }
    }
    
    private IEnumerator RepeateBanner()
    {
        // 1초 후에 
        yield return new WaitForSeconds(1f);
        ShowBanner();
    }

    private void HandleShowResult(ShowResult resule) // 보상형 광고
    {
        switch(resule) // 30초 다 봐야됨 스킵하면 주면 안됨
        {
            // 광고를 다 봤을 
            case ShowResult.Finished : gameMoney += 10;
                break;
            // 광고를 스킵을 했을때
            case ShowResult.Skipped:
                Debug.Log("광고를 스킵했기 때문에 보상을 받을 수 없습니다.");
                break;

            // 보상형 나오는 실패했을 때
            case ShowResult.Failed:
                Debug.LogError("광고 송출을 실패했습니다.");
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
