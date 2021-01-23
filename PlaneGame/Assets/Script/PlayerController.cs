using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//自己学习2d时的方法   此处使用视频的
public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;    //飞机移动速度
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()    //程序员自定义多久运行一次
    {
        
    }
    private void LateUpdate()    //所有的FixedUpdate运行完之后运行  一般写相机跟随
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //控制飞机左右移动  使用键盘
        //获取飞机的屏幕坐标
        Vector3 player = Camera.main.WorldToScreenPoint(transform.position);
        if (Input.GetKey(KeyCode.LeftArrow) && player.x > 0)
        {
            //transform.position = new Vector3(-speed * Time.deltaTime, transform.position.y, transform.position.z);   //位置变化  这是错误的
            //位置移动
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && player.x < Screen.width)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
