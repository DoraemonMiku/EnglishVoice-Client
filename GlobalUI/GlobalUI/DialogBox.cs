﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogBox : MonoBehaviour
{
    public RectTransform box;
    public UnityEngine.UI.Text text;
    public float animTime = 0.23f;
    private void Start()
    {
        box.DOLocalMoveY(0f, animTime);
    }
    /// <summary>
    /// 更改文字
    /// </summary>
    /// <param name="str"></param>
    public void ChangeText(string str)
    {
        text.text = str;
    }
    /// <summary>
    /// 关闭
    /// </summary>
    public void Close()
    {
        // StopAllCoroutines();
        box.DOKill(true);
        Destroy(gameObject);
    }
  
}
