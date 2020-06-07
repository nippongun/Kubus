using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake(){
        current = this;
    }

    public event Action<int> onSelectionClick;
    public void SelectionClickEvent(int id){
        onSelectionClick(id);
    }
}
