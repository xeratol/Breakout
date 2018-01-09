using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnClick : MonoBehaviour {

    public int levelToLoad = 1;

    public void OnClick ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
