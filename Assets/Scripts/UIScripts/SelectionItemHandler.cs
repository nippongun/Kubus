using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionItemHandler : MonoBehaviour
{
    public int id;

    public void OnClick(){
        Debug.Log(id);
        OnSelectionClick();
    }

    public void OnSelectionClick(){
        GameEvents.current.SelectionClickEvent(id);
    }
}
