using UnityEngine;
using UnityEngine.AI;

public class MainCastle : MonoBehaviour
{
    public float MainHealth;
    private bool _loosed = false;

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
        DragonPath[] dragons = FindObjectsOfType<DragonPath>();
        foreach (DragonPath dragon in dragons)   
        dragon.End();


    }
}
