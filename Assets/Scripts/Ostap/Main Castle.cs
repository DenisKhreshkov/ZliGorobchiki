using UnityEngine;
using System.Collections;

public class MainCastle : MonoBehaviour
{
    public float MainHealth;
    private bool _loosed = false;
    private ParticleSystem _particleSystem;
    [SerializeField] private Transform castleTransform;


    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void FixedUpdate()
    {
        if ( MainHealth <= 0 && !_loosed )
        {
            _loosed = true;
            Loose();
        }
    }

    private void Loose()
    {
        _particleSystem.Play();
        StartCoroutine(CastleFallDown(7f));
     //   StartCoroutine(CastleShake());
        DragonPath[] dragons = FindObjectsOfType<DragonPath>();
        foreach (DragonPath dragon in dragons)   
        dragon.End();
    }

    private IEnumerator CastleFallDown(float duration)
    {
        float timeElapsed = 0f;
        Vector3 startPosition = castleTransform.position;
        Vector3 targetPosition = new Vector3(castleTransform.position.x, -18f, castleTransform.position.z);

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            castleTransform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        castleTransform.position = targetPosition;
    }

    private IEnumerator CastleShake()
    {
        float shakeX;
        float shakeZ;
        while (true)
        {
            shakeX = Random.Range(-2f, 2f);
            shakeZ = Random.Range(-2f, 2f);
            castleTransform.position = new Vector3(castleTransform.position.x + shakeX, castleTransform.position.y, castleTransform.position.z + shakeZ);
            yield return new WaitForSeconds(0.1f);
            castleTransform.position = new Vector3(castleTransform.position.x - shakeX, castleTransform.position.y, castleTransform.position.z - shakeZ);
            yield return new WaitForSeconds(0.2f);
        }
    } 
}
