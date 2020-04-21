using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetMyDoneExam : MonoBehaviour
{
    public static GetMyDoneExam GMDE;

    public Transform targetContent;
    //public GameObject xiangQing;

    public GameObject buttonObjs;


    private void Awake()
    {
        GMDE = this;
    }
    public void OnClickCallback()
    {
        StopAllCoroutines();
        StartCoroutine(GetMyDoneExams());
    }

    public void CleanContent()
    {
        for (int i = 0; i < targetContent.childCount; i++)
        {
            Destroy(targetContent.GetChild(i).gameObject);
        }
    }




    //Grade/GetMyDoneExam.php?token=
    // Start is called before the first frame update
    IEnumerator GetMyDoneExams()
    {
        string url = GetPermisson.GetServerAddress + "/Grade/GetMyDoneExam.php?token=" +
            LoginToKaoShi.userLoginCallback.data.token;
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            GlobalUIManager.guim.CreateNewDialogBox("获取信息时连接出现异常!"+uwr.error);
        }
        else
        {
            MyDoneExamClasses mdec = JsonUtility.FromJson<MyDoneExamClasses>(uwr.downloadHandler.text);
            CleanContent();
            if (mdec.code == 0)
            {
                for (int i = 0; i < mdec.data.Length; i++)
                {
                    MyDoneExamClasses.MyDoneExams myData = mdec.data[i];
                    GameObject gm = Instantiate(buttonObjs, targetContent);
                    DoneExamItemCtrl deic = gm.GetComponent<DoneExamItemCtrl>();
                    deic.thisExam = myData;
                    string cheakedText = "";
                    if (myData.grade!=-2)
                    {
                        cheakedText = "<Color=Green>已完成批改</Color>";
                        deic.SetStatus(1);

                    }
                    else
                    {
                        cheakedText = "<Color=Red>未完成批改</Color>";
                        deic.SetStatus(0);
                    }

                    deic.descriptText.text = string.Format("试卷代号<Color=Orange>#{0}</Color>{5}\n{1}-{2}-模式{3}\n时间{4}",
                        myData.paperID,
                        myData.paperName,
                        myData.paperType,
                        myData.paperMode,
                        myData.uploadTime,
                        cheakedText);
                }

            }
            else
            {
                GlobalUIManager.guim.CreateNewDialogBox("Code:" + mdec.code + "\n" + mdec.msg);
            }
        }
    }
    /// <summary>
    /// 我完成的考试
    /// </summary>
    [System.Serializable]
    public class MyDoneExamClasses
    {
        public int code;
        public string msg;
        public MyDoneExams[] data;
        [System.Serializable]
        public class MyDoneExams
        {
            public int resultID;
            public int paperID;
            public int gradeA;
            public int gradeB_A;
            public int gradeB_B;
            public int gradeC;
            public int grade;
            public string uploadTime;
            public string cheakTime;
            public string paperName;
            public string paperType;
            public string paperMode;
        }
    }




}
