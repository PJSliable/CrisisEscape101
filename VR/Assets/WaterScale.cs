using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScale : MonoBehaviour
{
    // Start is called before the first frame update
    //[Header("속도 조절")]
    //[SerializeField] [Range(1f, 5f)]
    float scaleSpeed = 1f;

    void Start()
    {
        InvokeRepeating("Repeating", 1f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Repeating()
    {
        transform.localScale = new Vector3
           (transform.localScale.x + 0f * scaleSpeed * Time.deltaTime,
           transform.localScale.y + 0.01f * scaleSpeed * Time.deltaTime,
           transform.localScale.z + 0f * scaleSpeed * Time.deltaTime);
        Debug.Log("Repeating Start!" + transform.localScale);
    }
}
