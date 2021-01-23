using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCil : MonoBehaviour
{
    public float KuanSize = 20.48f;
    // Update is called once per frame
    void Update()
    {
        //移动补充
        if (transform.position.y <= - KuanSize)
        {
            transform.position = new Vector3(transform.position.x, KuanSize, transform.position.z);
        }

    }
}
