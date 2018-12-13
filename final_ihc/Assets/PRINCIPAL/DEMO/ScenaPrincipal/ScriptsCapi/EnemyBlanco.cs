using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyBlanco : NetworkBehaviour
{
    public GameObject blancoPrefab;
    public Transform blancoSpawn;
    //El servidor los crea nada mas
    
    public override void OnStartServer()
    {
        GameObject blanco = (GameObject)Instantiate(blancoPrefab, blancoSpawn.position, blancoSpawn.rotation);
        blanco.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform,false);
        NetworkServer.Spawn(blanco);

        /*for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
            Quaternion spawnRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0);
            GameObject enemy = (GameObject)Instantiate(blancoPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }*/
    }
}


