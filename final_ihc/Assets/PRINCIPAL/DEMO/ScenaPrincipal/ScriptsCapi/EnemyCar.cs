using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyCar : NetworkBehaviour
{
    public GameObject carPrefab;
    public Transform carSpawn;
    //public int numberOfEnemies; //En este caso seria solo un carro
    //El servidor los crea nada mas
    public override void OnStartServer()
    {
        GameObject car = (GameObject)Instantiate(carPrefab, carSpawn.position, carSpawn.rotation);
        NetworkServer.Spawn(car);

        /*for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
            Quaternion spawnRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0);
            GameObject enemy = (GameObject)Instantiate(carPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }*/
    }
}


