using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private List<AreaOptionButton> buttonsList;

    public void Create(AreaOption option, int index, Action<AreaOptionButton> callback)
    {
            buttonsList[index].Create(option, callback);   
    }
}
