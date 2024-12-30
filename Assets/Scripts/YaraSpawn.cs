using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaraSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnLanacakObje;
    float spawnSuresi;
    void Start()
    {
        StartCoroutine(spawnSistemi());
    }

    IEnumerator spawnSistemi(){
        while(true){
            spawnSuresi = Random.Range(1,3);
            yield return new WaitForSeconds(spawnSuresi);
            nesneOlustur();
        }
    }

    void nesneOlustur(){
        GameObject temp = Instantiate(spawnLanacakObje);
        temp.transform.position = spawnPoint.position;
    }
}
