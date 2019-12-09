using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spawn : MonoBehaviour
{

    public GameObject spaceShip;
    public int maxLifes;
    int lifes;
    public Text LifeCounter;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        lifes = maxLifes;
        LifeCounter.text = "Vidas: " + lifes;
        Instantiate(spaceShip, transform.position, transform.rotation);
        LifeCounter.text = lifes.ToString();
    }

    public void SpawnShip()
    {
        if (lifes <= maxLifes && lifes > 0)
        {
            lifes--;
            LifeCounter.text = lifes.ToString();
            StartCoroutine(SpawnRoutine());
        }

        
        else
        {
            LifeCounter.text = "X-X";
            gameOver.SetActive(true);
        }
        
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(1);
        Instantiate(spaceShip, transform.position, transform.rotation);
    }

}
