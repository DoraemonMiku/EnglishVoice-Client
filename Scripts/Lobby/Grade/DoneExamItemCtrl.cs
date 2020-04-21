using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneExamItemCtrl : MonoBehaviour
{
    public Sprite[] statusSprites;
    public Image targetImg;
    public Text descriptText;

    public GetMyDoneExam.MyDoneExamClasses.MyDoneExams thisExam;

    public void SetStatus(int index)
    {
        targetImg.sprite = statusSprites[index];
        if (index == 0)
        {
            targetImg.color = Color.yellow;
        }else 
        if (index == 1)
        {
            targetImg.color = Color.green;
        }
    }


    public void OnClickToRun()
    {
        if(thisExam.grade==-2)
        GlobalUIManager.guim.CreateNewSelectBox("是否执行测试改卷?\n当前仅可改PartA.",delegate(bool ok) {
            if (ok)
            {
                
            }
            else
            {

            }

        });
    }
    
}
