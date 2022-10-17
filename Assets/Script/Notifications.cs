using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleAndroidNotifications; // �޾Ҵ� ���� ��������
using System; // �ð��� ������������
using System.Text;

public class Notifications : MonoBehaviour
{
    // �˸� ����
    private string title = "�˸�";

    // �˸� ����
    private string content = "�ۿ� �����ؼ� ������ �������ּ���.";

    void Start()
    {
        OnApplicationPause(true);
    }

    private void OnApplicationPause(bool pause) // �̺�Ʈ �Լ�, �˸����& �׸��Ҳ���
    {
        // �ȵ���̵� �϶� ����Ǵ� �ڵ� �Դϴ�.
#if UNITY_ANDROID

        // ��ϵ� �˸� ��� ����
        NotificationManager.CancelAll();

        if(pause) // == true
        {
            // ���� ��� �� �� ���� �ð� �Ŀ� �˸��ϴ� ���
            // AddMinutes : ��� �Ŀ� �˸��� ���� �� �ֵ��� �����մϴ�.
            DateTime timeNotify = DateTime.Now.AddMinutes(1);
                                            // days (4) 4����

            TimeSpan time = timeNotify - DateTime.Now;
            // ������
            NotificationManager.SendWithAppIcon(time, title, content, Color.white, NotificationIcon.Bell);

            // ������ �ð��� �˸��ϴ� ���
            DateTime specifiedTime = Convert.ToDateTime("19:30:00 PM");

            TimeSpan tempTime = specifiedTime - DateTime.Now;

            if(tempTime.Ticks > 0)
            {
                NotificationManager.SendWithAppIcon(time, title, content, Color.gray, NotificationIcon.Bell);
            }
        }

#endif // �̰ɷ� ������
    }

}
