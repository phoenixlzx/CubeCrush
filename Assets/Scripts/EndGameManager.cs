using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public GameObject cube;

    void Start()
    {
        StartCoroutine("SpawnCubes");       
    }

    void Update()
    {

    }

    public void GameRetry()
    {
        SceneManager.LoadScene(1);
    }

    public void GameExit()
    {
        Application.Quit();
    }
    
    IEnumerator SpawnCubes()
    {
        while (true)
        {
            var clone = Instantiate(cube, new Vector3(Random.Range(-100, 100), 80, 80), Random.rotation);
            clone.transform.localScale = new Vector3(10, 10, 10);
            clone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            Destroy(clone, 10f);
            yield return new WaitForSeconds(1f); 
        }
    }
}
