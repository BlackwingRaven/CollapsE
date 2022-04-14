using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Knossos");
    }
}
