using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class BarierWork : MonoBehaviour
{
    private Canvas hpCanvas;
    private Slider healthSlider;
    private ParticleSystem particleSystem;
    private AudioSource audioSource;
    private MeshRenderer mainMeshRenderer;
    private MeshRenderer[] meshRenderers;
    private NavMeshObstacle navMeshObstacle;
    [SerializeField] private float liveTime = 10f;

    [SerializeField] Image fill;

    private void Awake()
    {
        hpCanvas = GetComponentInChildren<Canvas>();
        healthSlider = GetComponentInChildren<Slider>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        mainMeshRenderer = GetComponent<MeshRenderer>();
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        healthSlider.maxValue = liveTime;
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
        StartCoroutine(BarierLive());
    }

    private IEnumerator BarierLive()
    {
        yield return Time.deltaTime;
        while (liveTime > 0)
        {
            liveTime -= Time.deltaTime;
            healthSlider.value = liveTime;
            fill.color = new Color(1-(liveTime / healthSlider.maxValue), liveTime / healthSlider.maxValue, 0);
            hpCanvas.transform.rotation = Camera.main.transform.rotation;
            yield return null;
        }
        particleSystem.Play();
        audioSource.Play();
        if (mainMeshRenderer != null)
        {
            mainMeshRenderer.enabled = false;
        } 
        else
        {
            foreach (MeshRenderer meshRenderer in meshRenderers)
            meshRenderer.enabled = false;
        }
        navMeshObstacle.enabled = false;
        Destroy(healthSlider.gameObject);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
