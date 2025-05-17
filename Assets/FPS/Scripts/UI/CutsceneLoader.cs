using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutsceneLoader : MonoBehaviour
{
    //public string introName = "Cutscene";
    public string sceneName = "MainScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadIntroThenGame());
    }

    IEnumerator LoadIntroThenGame()
    {
        //SceneManager.LoadScene(introName);

        yield return new WaitForSeconds(33);

        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
