using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//飞机移动  新学  使用的方法Input.GetAxis()
public class PlayerController2 : MonoBehaviour
{
    //飞机发射子弹  创建预制体  鼠标点击发射
    public GameObject bulletPrefab;
    public GameObject enemyPrefab;   //敌人
    public float speed = 3.0f;
    //飞机生命值
    [SerializeField]private int life = 3;
    //生命值显示
    public Text text;
    private bool fixDJ = false;   //是否碰到了道具
    //子弹道具生成方向数组
    private Vector3[] BulletDJ = { new Vector3(0, 0, 0), new Vector3(0, 0, 30), new Vector3(0, 0, -30), new Vector3(0, 0, 15), new Vector3(0, 0, -15) };
    //道具预制体  随机产生道具
    public GameObject DJPerfab;

    //爆炸效果预制体
    public GameObject ExproerPrefab;

    //重新开始按钮
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 0.1f, 2);
        InvokeRepeating("CreateDJ", 0.1f, 2);
        text.text = "生命:" + life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //取得左右移动的值
        float h = Input.GetAxis("Horizontal");
        //获取飞机的屏幕坐标
        if (transform.position.x < -10.24)
        {
            //到达另一边
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
        if(transform.position.x > 9.5)
        {
            //到达另一边
            transform.position = new Vector3(-10.24f, transform.position.y, 0);
        }
        //移动
        Vector3 NextPos = transform.position + new Vector3(h, 0, 0) * speed * Time.deltaTime;   //点击后要移动到的位置
        transform.position = NextPos;

        //获取鼠标右键点击事件   Input.GetMouseButtonDown(0)    空格按下Input.GetKeyDown(KeyCode.Space)
        if (Input.GetMouseButtonDown(0))
        {
            //创建一个预制体
            //GameObject bullet = Instantiate(bulletPrefab);
            //bullet.transform.position = transform.position + new Vector3(0, 1, 0);

            if (!fixDJ) 
            {
                Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                //碰到道具
                for(int i = 0; i < 5; i++)
                {
                    Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(BulletDJ[i]));
                }
            }
        }
    }

    private void StopGame()
    {
        //暂停游戏
        Time.timeScale = 0;
    }
    private void fixDJTX()
    {
        fixDJ = false;
    }
    //实现碰撞检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("被碰撞了" + collision.name);
        //被敌机或者敌人子弹打到后  隐藏自己
        if (collision.tag.Equals("Enemy") || collision.tag.Equals("EnemyBall"))
        {
            Destroy(collision.gameObject);
            life--;
            text.text = "生命:" + life.ToString();
            if (life == 0)
            {
                Instantiate(ExproerPrefab, transform.position, Quaternion.Euler(0, 0, 0));  //爆炸效果
                gameObject.SetActive(false);   //隐藏自己
                //获取背景节点   暂停音乐
                GameObject back = GameObject.Find("BackGround");
                AudioSource audio = back.GetComponent<AudioSource>();
                audio.Stop();
                Invoke("StopGame", 1.5f);
                //PopRestartButton();    //弹出重新开始按钮
                //跳出重新开始按钮
                restartButton.SetActive(true);
            }
        }
        if (collision.tag.Equals("DaoJu"))
        {
            Destroy(collision.gameObject);
            //碰到道具后  生成五颗不同方向的子弹
            fixDJ = true;
            //道具特效只持续5秒
            Invoke("fixDJTX", 5);
        }
    }

    //创建一个敌人
    private void CreateEnemy()
    {
        float x = Random.Range(-10, 8.5f);
        float y = 8;
        Instantiate(enemyPrefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
    }

    //创建一个道具
    private void CreateDJ()
    {
        float x = Random.Range(-10, 8.5f);
        float y = 8;
        Instantiate(DJPerfab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
    }

    //退出实现
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        //游戏重新开始
        SceneManager.LoadScene(0);
    }
}
