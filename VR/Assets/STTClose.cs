using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STTClose : MonoBehaviour
{
    public Mic mic;

    // Start is called before the first frame update
    void Start()
    {
        mic = GameObject.Find("Mic").GetComponent<Mic>();
    }

    // Update is called once per frame
    void Rec()
    {

    }
}


// 오브젝트 찾고 mic 컴포넌트를 찾으세요