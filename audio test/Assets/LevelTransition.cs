using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string LevelName;

    public void TransitionLevel() {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}
