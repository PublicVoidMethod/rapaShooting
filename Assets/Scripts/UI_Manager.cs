using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    
    // �ɼ� �г��� ������ �ٽ� ������ �簳�ϴ� �Լ�
    public void Resume()
    {

    }

    // ������ �ٽ� �����ϵ��� �ϴ� �Լ�
    public void Restart()
    {
        SceneManager.LoadScene("ShootingMain");
        //SceneManager.LoadScene(0);
    }

    // ���� �����ϴ� �Լ�
    public void Quit()
    {
        Application.Quit();
    }
}
