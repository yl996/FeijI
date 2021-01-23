using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallController : MonoBehaviour
{
    //敌人子弹的生成
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * -speed * Time.deltaTime);
        //超出边界摧毁
        Vector3 ballPos = Camera.main.WorldToScreenPoint(transform.position);
        if (ballPos.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
