using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //子弹控制移动   向上移动
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //当子弹移出边界时  摧毁
        Vector3 bulletPos = Camera.main.WorldToScreenPoint(transform.position);
        if (bulletPos.y > Screen.height)
        {
            Destroy(this.gameObject);
        }
    }
}
