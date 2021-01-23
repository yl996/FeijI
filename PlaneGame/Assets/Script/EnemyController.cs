using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌人飞机
public class EnemyController : MonoBehaviour
{
    //创建敌人子弹
    //public GameObject ballPerfab;
    //怪物销毁爆炸
    public GameObject ExproerPrefab;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //敌人随机生成
        //敌人飞机向下移动
        transform.Translate(Vector3.up * - speed * Time.deltaTime);

        //离开屏幕后销毁
        Vector3 enemyPos = Camera.main.WorldToScreenPoint(transform.position);
        if (enemyPos.y<0) {
            Destroy(this.gameObject);
        }
    }
    //碰撞检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //判断是否是玩家子弹或者玩家飞机，碰到后销毁
        if (collision.tag.Equals("Player") || collision.tag.Equals("Bullet"))
        {
            Instantiate(ExproerPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            if (collision.tag.Equals("Bullet"))
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
