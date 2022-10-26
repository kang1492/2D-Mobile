using System.IO; // �����ϱ�
using UnityEngine;

public class Data // ���ӿ� ���õ� ���̽� �����
{
    public int money;
}

public class DataManager : MonoBehaviour
{
    // �ű������� ������ �ȴ�.�� 
    public static DataManager instance;

    public Data data = new Data();

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        //Save(); // �ε� �տ� ����� ���� 0 ���� �ʱ�ȭ ��
        Load(); // ���� �б� 

        //Debug.Log(data.money); //����� 0 ���� ǥ�õ�
        Debug.Log(Application.persistentDataPath); // ������ ã��


        // �������� ��� ����
        // ���� ����
        // ���� PC�� ��ο� �����ϰ���?? ���̽� , ������� ��ΰ� �ٳ��� ã�� ����.
        // �����, PC, WebGl �ش� ��ΰ� ��Ȯ�ϰ� ��ġ�Ǿ ��������ݴϴ�.
        // Debug.Log(Application.persistentDataPath);
    }

    private void Update() // �� ���� ��Ű��
    {
        if(Input.GetKeyDown(KeyCode.B)) // b Ű ������ ���� ���� ��Ű��
        {
            data.money++;
            Debug.Log(data.money);
            Save();
        }
    }

    public void Save()
    {
        // 2�� ���Ϸ� �����
        string json = JsonUtility.ToJson(data);

        // ��ȣȭ
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
        string code = System.Convert.ToBase64String(bytes);


        //File. << using System.IO; �����ϱ�                                  Ŭ����ȭ ��Ų�� �ֱ�
        //File.WriteAllText(Application.persistentDataPath + "/GameData.json", json);
        File.WriteAllText(Application.persistentDataPath + "/GameData.json", code); // ��ȣȭ
    }

    public void Load()
    {
        //                                 �ҷ��� ������ ���
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/GameData.json");

        //                    ��ȯ�Ѵ�
        byte[] bytes = System.Convert.FromBase64String(jsonData); // ��ȣȭ �ҷ�����
        string code = System.Text.Encoding.UTF8.GetString(bytes);

        //data = JsonUtility.FromJson<Data>(jsonData);
        data = JsonUtility.FromJson<Data>(code); // ��ȣȭ �ҷ�����
    }

}
