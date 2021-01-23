using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMove : MonoBehaviour
{
    public float speed=3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //背景图片移动
        transform.Translate(Vector3.up * -speed * Time.deltaTime);
    }
}
