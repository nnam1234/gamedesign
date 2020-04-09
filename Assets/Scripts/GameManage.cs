using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    private Transform[] wayPoint;
    private GameObject[] enemyArray;
    private Transform creatPoint;
    private int enemyCount;
    private int enemyNumber;
    private float times;
    private float timer;
    private int count;
    private bool isFinish;
    private GameObject gameover;
    void Start()
    {
        creatPoint = GameObject.Find("CreatPoint").transform;
        enemyCount = 5;
        enemyNumber = 5;
        times = 3;
        timer = 0.5f;
        count = 0;
        StartCoroutine(EnemyIncubator());
        isFinish = false;
        gameover = GameObject.Find("UICanvas").transform.GetChild(0).gameObject;
    }
    public Transform[] GetWayPoint
    {
        set { wayPoint = value; }
        get { return wayPoint; }
    }
    public int GetCount
    {
        set { count = value; }
        get { return count; }
    }
    public GameObject GetGameOver
    {
        set { gameover = value; }
        get { return gameover; }
    }
    void Awake()
    {
        wayPoint = GameObject.Find("EVE").transform.GetChild(0).transform.GetComponentsInChildren<Transform>();
        enemyArray = Resources.LoadAll<GameObject>("Prefabs/Enemys");
    }

    void Update()
    {
        Debug.Log("The amount of the monster is:" + count);
        if (isFinish && 0 == count)
        {
            gameover.SetActive(true);
            gameover.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "You win!";
            //UnityEditor.EditorApplication.isPaused = true;
        }

    }

    private IEnumerator EnemyIncubator()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            for (int j = 0; j < enemyNumber; j++)
            {
                GameObject.Instantiate(enemyArray[Random.Range(0, enemyArray.Length)],
                    creatPoint.position, creatPoint.rotation);
                count++;
                yield return new WaitForSeconds(timer);
            }
            yield return new WaitForSeconds(times);
        }
        isFinish = true;
        StopCoroutine(EnemyIncubator());
    }


}
