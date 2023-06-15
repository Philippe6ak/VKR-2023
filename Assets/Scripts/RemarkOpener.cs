using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RemarkOpener : MonoBehaviour
{
    public GameObject uiToShow;
    public TextMeshProUGUI header;
    public TextMeshProUGUI mainText;
    public List<RemarkSO> reactions;

    public void ShowUI(int lastID)
    {
        var last = reactions.FirstOrDefault(x => x.id == lastID);
        if (last != null)
        {
            header.text = last.header;
            mainText.text = last.mainText;
        }

        uiToShow.SetActive(true);
    }

    private void OnEnable()
    {
        var lastID = DialogueLua.GetVariable("RemarkIdToShow").asInt;
        ShowUI(lastID);
    }

    //public void On;
}
