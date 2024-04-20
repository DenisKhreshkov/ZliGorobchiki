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

    private void Start() => StartCoroutine(dragonSpawning());

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
}