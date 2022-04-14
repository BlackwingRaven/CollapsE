using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    public Image[] lives;
    public int currentLives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoseLife();
        }
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--; //-1 life
            lives[currentLives].enabled = false;    //hide life icon
            if (currentLives == 0)
            {
                Debug.Log("Game Over");
                FindObjectOfType<LevelManager>().SceneRestart();
            }
        }
        else Debug.Log("Already dead");
    }
}
