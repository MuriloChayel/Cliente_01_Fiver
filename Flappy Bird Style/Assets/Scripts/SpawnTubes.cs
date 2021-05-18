using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTubes : MonoBehaviour
{
    //SPAWN OBSTACLES
    [Range(1, 5)]
    public float time, startDelay;
    public GameObject prefab;
    //--

    private void Start()
    {
        StartCoroutine("Spawn", startDelay);
    }
    IEnumerator Spawn(float time)
    {
        float randY = Random.Range((int)-1, 4);
        yield return new WaitForSeconds(time);
        Instantiate(prefab, transform.position + new Vector3(0, randY), Quaternion.identity);
        StartCoroutine(Spawn(time));
    }
}
