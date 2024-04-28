using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainCastle : MonoBehaviour
{
    public float MainHealth;
    private bool _loosed = false;
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;
    [SerializeField] private Transform castleTransform;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private RectTransform loosingPanel;

    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        healthSlider.maxValue = MainHealth;
        _audioSource.volume = PlayerPrefs.GetFloat("Volume");
    }
    private void LateUpdate()
    {
        if ( MainHealth <= 0 && !_loosed )
        {
            _loosed = true;
            Loose();
        }
        if (MainHealth > healthSlider.maxValue )
        MainHealth = healthSlider.maxValue;

        healthSlider.value = MainHealth;
    }


    private void Loose()
    {
        _particleSystem.Play();
        loosingPanel.GetComponent<Animation>().Play();
        StartCoroutine(CastleFallDown());
        StartCoroutine(CastleShake());
        DragonPath[] dragons = FindObjectsOfType<DragonPath>();
        foreach (DragonPath dragon in dragons)   
        dragon.End();
        TurrelWork[] turrelWorks = FindObjectsOfType<TurrelWork>();
        foreach (TurrelWork turrelWork in turrelWorks)
        turrelWork.IsWorking = false;
        FindObjectOfType<EnemySpawn>().StopAllCoroutines();
        FindObjectOfType<TimeForLevel>().Loose();
        _audioSource.Play();
    }

    private IEnumerator CastleFallDown()
    {
        for (int i = 0; i < 7 / Time.fixedDeltaTime; i++)
        {
            castleTransform.position = new Vector3(castleTransform.position.x, castleTransform.position.y + (-2.5f * Time.fixedDeltaTime), castleTransform.position.z);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator CastleShake()
    {
        float shakeX;
        float shakeZ;
        while (true)
        {
            shakeX = Random.Range(-0.5f, 0.5f);
            shakeZ = Random.Range(-0.5f, 0.5f);
            castleTransform.position = new Vector3(castleTransform.position.x + shakeX, castleTransform.position.y, castleTransform.position.z + shakeZ);
            yield return new WaitForSeconds(0.05f);
            castleTransform.position = new Vector3(castleTransform.position.x - shakeX, castleTransform.position.y, castleTransform.position.z - shakeZ);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void Menu() => SceneManager.LoadScene("DenisScene");
}
