using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotolevel : MonoBehaviour
{
    public void SceneChange(int index) => SceneManager.LoadScene(index);
}
