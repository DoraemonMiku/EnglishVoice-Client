using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUIManager : MonoBehaviour
{
    public static GlobalUIManager guim;
    [Header("画布")]
    public Transform canvas;
    private void Awake()
    {
        guim = this;
        DontDestroyOnLoad(this); 
    }
    [Header("预制体-提示盒子")]
    public GameObject dialogBox;
    [Header("预制体-可选提示盒子")]
    public GameObject dialogBoxChoose;
    /// <summary>
    /// 创建新的提示框
    /// </summary>
    /// <param name="text"></param>
    public void CreateNewDialogBox(string text)
    {
      GameObject gm=  Instantiate(dialogBox, canvas);
        gm.GetComponent<DialogBox>().ChangeText(text);
        gm.transform.localPosition = Vector3.zero;
    }
    /// <summary>
    /// 创建新的提示框
    /// </summary>
    /// <param name="text"></param>
    /// <param name="onSelect"></param>
    public void CreateNewSelectBox(string text,System.Action<bool> onSelect)
    {
        GameObject gm = Instantiate(dialogBoxChoose, canvas);
        gm.GetComponent<DialogBoxChoose>().ChangeText(text);
        gm.GetComponent<DialogBoxChoose>().onSelect = onSelect;
        gm.transform.localPosition = Vector3.zero;
       
    }

}
