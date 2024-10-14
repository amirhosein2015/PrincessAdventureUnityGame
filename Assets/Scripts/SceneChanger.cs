using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{


    [SerializeField]
    private string sceneNameToLoad;

    public void JumpToSecne()

    {
        SceneManager.LoadScene(sceneNameToLoad);


    }
}
