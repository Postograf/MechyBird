using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Add(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }
}