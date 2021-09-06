using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    float SpawnInterval = 5f;

    [SerializeField]
    public int maxSpeed = 10;

    [SerializeField]
    public float endSceneDelaySec = 3f;

    [SerializeField]
    int streakToAddRemain = 10;

    [SerializeField]
    GameObject obstacle;

    [SerializeField]
    GameObject EndPanel;

    void Start()
    {
        // reset numbers
        GlobalVar.streak = 0;
        GlobalVar.score = 0;
        GlobalVar.remain = 3;
        GlobalVar.spawnSpeed = 1;
        SpawnInterval = 5f;
        StartCoroutine("SpawnObstacles");
    }

    void Update()
    {

    }

    public void CountScore(int score)
    {
        if (!gameEnded)
        {
            GlobalVar.score += score;
            GlobalVar.streak += 1;
            if (GlobalVar.streak == streakToAddRemain)
            {
                GlobalVar.streak = 0;
                GlobalVar.remain += 1;
            }
        }
        
        if (GlobalVar.score % 5 == 0) {
            if (GlobalVar.spawnSpeed < maxSpeed)
            {
                SpawnInterval /= 1.2f;
                GlobalVar.spawnSpeed += 1;
            }
        }
    }

    public void CountRemain(int remain)
    {
        if (!gameEnded)
        {
            GlobalVar.remain += remain;
            if (GlobalVar.remain < 0) {
                GameOver();
            }
        }
        
    }

    public void GameOver() 
    {
        if (!gameEnded)
        {
            gameEnded = true;
            EndPanel.SetActive(true);
            Invoke("EndGame", endSceneDelaySec);
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator SpawnObstacles()
    {
        if (!gameEnded)
        {
            while (true)
            {
                var clone = Instantiate(obstacle, new Vector3(Random.Range(-5, 5), 1, 200), Quaternion.identity);
                Destroy(clone, 10f);
                yield return new WaitForSeconds(SpawnInterval); 
            }
        }
    }
}
