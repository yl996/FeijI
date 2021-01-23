using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    //给敌机随机产生子弹
    public GameObject ballPerfab;
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(-4, 4);
        if (x > 0)
        {
            Instantiate(ballPerfab, new Vector3(transform.position.x, transform.position.y-1, transform.position.z), Quaternion.Euler(0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
