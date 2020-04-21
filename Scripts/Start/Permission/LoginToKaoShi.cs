using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginToKaoShi : MonoBehaviour
{
    /// <summary>
    /// 登录过程中的遮罩
    /// </summary>
    public GameObject logingMask;
    public InputField ipID, ipPWD;

    
    /// <summary>
    /// 用户登录回调信息
    /// </summary>
    public static UserLoginCallback userLoginCallback;
    /// <summary>
    /// 在线模式
    /// </summary>
    public static bool onlineMode=false;

    public void GO()
    {
        StartCoroutine(GetToken());
    }
    IEnumerator GetToken()
    {
        logingMask.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("id",ipID.text);
        form.AddField("password", ipPWD.text);

        UnityWebRequest uwr = UnityWebRequest.Post(GetPermisson.GetServerAddress+"/User/Login.php",form);
        yield return uwr.SendWebRequest();
        logingMask.SetActive(false);
       // Debug.Log(uwr.downloadHandler.text);
        if (uwr.error==""||uwr.error==null)
        {
            try
            {
                UserLoginCallback ulc = JsonUtility.FromJson<UserLoginCallback>(uwr.downloadHandler.text);
                if (ulc.code == 0)
                {
                    
                    userLoginCallback = ulc;
                    GlobalUIManager.guim.CreateNewDialogBox("欢迎您!\n亲爱的 <Color='Pink'>"+ulc.data.name+"</Color> !\n<Color='Green'>今天又要元气满满的哟~</Color>");
                    onlineMode = true;//在线
                    SceneManager.LoadScene("Lobby");//加载大厅
                  
                }
                else
                {
                    GlobalUIManager.guim.CreateNewDialogBox(ulc.msg);
                  //  Debug.Log(uwr.downloadHandler.text);
                }
            }
            catch
            {
                GlobalUIManager.guim.CreateNewDialogBox("数据包解析错误!请联系开发者!");
                Debug.Log(uwr.downloadHandler.text);
            }
            

        }
        else
        {
            GlobalUIManager.guim.CreateNewDialogBox(uwr.error);
        }
    }
    
}
[System.Serializable]
public class UserLoginCallback
{
    public int code;
    public string msg = "";
    public UserData data=new UserData();
}
[System.Serializable]
public class UserData
{
    public int id = 0;
    public string name = "";
    public string pwd = "";
    public int grand = 0;
    public int level = 0;
    public int exp = 0;
    public int permission = 0;
    public string token = "";
    public string asr_token = "";
    public string reg_time = "";
    public string last_login_time = "";
}