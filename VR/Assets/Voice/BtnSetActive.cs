using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetActive : MonoBehaviour
{
    public GameObject TargetBg;

    public void TargetSetActive()
    {
        TargetBg.SetActive(!TargetBg.active);
    }
}
