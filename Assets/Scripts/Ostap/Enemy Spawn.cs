using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float minInterval;
    [SerializeField] private float maxInterval;

    [Header("Variants of dragons")]
    [Space(5)]
    [SerializeField] private GameObject[] dragons;

    public DragonMaterials dragonsMaterials;
    [System.Serializable]
    public class DragonMaterials
    {
        public Material[] Fast;
        public Material[] Path;
        public Material[] Shielt;
        public Material[] Slow;
    }

    private int _choosenDragonID;
    private int _choosenMaterialID;
    private GameObject _choosenDragon;
    private Material _choosenMaterial;

    [Space(10)]
    [SerializeField] private GameObject particleSystemPrefab;
    private AudioSource woodBreak;
    private void Start()
    {
        StartCoroutine(dragonSpawning());
        StartCoroutine(StartHardcore());
    }

    private IEnumerator dragonSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

            _choosenDragonID = Random.Range(0, 4);
            _choosenMaterialID = Random.Range(0, 4);
            _choosenDragon = dragons[_choosenDragonID];
            switch (_choosenDragonID)
            {
                case 0:
                    _choosenMaterial = dragonsMaterials.Fast[_choosenMaterialID];
                    break;
                case 1:
                    _choosenMaterial = dragonsMaterials.Path[_choosenMaterialID];
                    break;
                case 2:
                    _choosenMaterial = dragonsMaterials.Shielt[_choosenMaterialID];
                    break;
                case 3:
                    _choosenMaterial = dragonsMaterials.Slow[_choosenMaterialID];
                    break;
            }

            GameObject dragon = Instantiate(_choosenDragon, transform.position, Quaternion.identity);
            dragon.GetComponentInChildren<SkinnedMeshRenderer>().material = _choosenMaterial;
        }
    }

    private IEnumerator StartHardcore()
    {
        yield return new WaitForSeconds(100f);
        minInterval -= 2;
        maxInterval -= 2;
        yield return new WaitForSeconds(40f);
        minInterval = (minInterval / 2) + 1;
        maxInterval = (maxInterval / 2) + 1;
        yield return new WaitForSeconds(30f);
        minInterval = 0.5f;
        maxInterval = 2f;
        GetComponent<AudioSource>().Play();
        GlobalVar.IsHardcore = true;
        yield return new WaitForSeconds(2f);
        BreackAll();
    }

    private void BreackAll()
    {
        TurrelWork[] turrels = FindObjectsOfType<TurrelWork>();
        BarierWork[] bariers = FindObjectsOfType<BarierWork>();
        if (turrels[0] != null) woodBreak = turrels[0].GetComponent<AudioSource>();
        else if (bariers[0] != null) woodBreak = bariers[0].GetComponent<AudioSource>();
        foreach (TurrelWork turrel in turrels)
        {
            Destroy(Instantiate(particleSystemPrefab, turrel.transform.position, Quaternion.identity), 5f);
            Destroy(turrel.gameObject);
        }
        foreach (BarierWork barier in bariers)
        {
            Destroy(Instantiate(particleSystemPrefab, barier.transform.position, Quaternion.identity), 5f);
            Destroy(barier.gameObject);
        }
         woodBreak.Play();
    }
}