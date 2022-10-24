using System.IO; // 선언하기
using UnityEngine;

public class Data // 게임에 관련되 케이스 만들기
{
    public int money;
}

public class DataManager : MonoBehaviour
{
    // 신글톤으로 만들어야 된다.돈 
    public static DataManager instance;

    public Data data = new Data();

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        //Save(); // 로드 앞에 만들면 값이 0 으로 초기화 됨
        Load(); // 파일 읽기 

        //Debug.Log(data.money); //실행시 0 으로 표시됨
        Debug.Log(Application.persistentDataPath); // 저장경로 찾기


        // 파일저장 경로 설정
        // 파일 생성
        // 현재 PC의 경로에 저장하겠죠?? 제이슨 , 모바일은 경로가 바끼어 찾지 못함.
        // 모바일, PC, WebGl 해당 경로가 정확하게 배치되어서 저장시켜줍니다.
        // Debug.Log(Application.persistentDataPath);
    }

    private void Update() // 값 증가 시키기
    {
        if(Input.GetKeyDown(KeyCode.B)) // b 키 누를때 마다 증사 시키기
        {
            data.money++;
            Debug.Log(data.money);
            Save();
        }
    }

    public void Save()
    {
        // 2진 파일로 만들기
        string json = JsonUtility.ToJson(data);

        // 암호화
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
        string code = System.Convert.ToBase64String(bytes);


        //File. << using System.IO; 선언하기                                  클레스화 시킨거 넣기
        //File.WriteAllText(Application.persistentDataPath + "/GameData.json", json);
        File.WriteAllText(Application.persistentDataPath + "/GameData.json", code); // 암호화
    }

    public void Load()
    {
        //                                 불러올 파일의 경로
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/GameData.json");

        //                    변환한다
        byte[] bytes = System.Convert.FromBase64String(jsonData); // 암호화 불러오기
        string code = System.Text.Encoding.UTF8.GetString(bytes);

        //data = JsonUtility.FromJson<Data>(jsonData);
        data = JsonUtility.FromJson<Data>(code); // 암호화 불러오기
    }

}
