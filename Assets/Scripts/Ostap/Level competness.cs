using UnityEngine;
using UnityEngine.UI;

public class Levelcompetness : MonoBehaviour
{
    [SerializeField] private int level;
    private void Start() => GetComponent<Text>().text = $"{PlayerPrefs.GetInt($"Level{level} complete")}%";
}
