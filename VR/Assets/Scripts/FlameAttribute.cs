using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAttribute : MonoBehaviour
{

    public int hp;

    void Start()
    {
        hp = 100;
    }
   
    void Update()
    {
        if (hp <= 0) {
            FireScenarioManager.fireNum--;
            Destroy(gameObject);
        }
    }
}
