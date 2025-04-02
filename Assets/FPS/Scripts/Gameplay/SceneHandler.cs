using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public void OpenGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
