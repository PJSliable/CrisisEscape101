using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEXRayCastActor : MonoBehaviour
{
    Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _direction = Quaternion.Euler(
        transform.parent.rotation.x,
        transform.parent.rotation.y,
        transform.parent.rotation.z) * new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.TransformDirection(_direction), Color.red);

        RaycastHit hitInfo;

        if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(_direction), out hitInfo, 10.0f))
        {
            if (hitInfo.collider.gameObject.GetComponent<FlameAttribute>() != null)
            {
                Debug.Log("Direct Hit!");
                hitInfo.collider.gameObject.GetComponent<FlameAttribute>().hp--;
            }
        }
    }
}
