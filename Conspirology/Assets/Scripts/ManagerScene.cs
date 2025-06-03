using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    private string[] arrNameScene = new string[] { "BoardingHouse", "BootStation", "OfisFBI", "Hospital", "Factory", "University", "House", "BigHouse", "PlaneDown", "NotebookScene" };

    public static ManagerScene Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void LoadLocationScene(int index)
    {
        if (index >= 0 && index < arrNameScene.Length)
        {
            SceneManager.LoadScene(arrNameScene[index]);
        }
    }

}
