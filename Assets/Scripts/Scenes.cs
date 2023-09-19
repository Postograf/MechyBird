using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
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