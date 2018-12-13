using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarPlayerController : NetworkBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    //public GameObject blancoPrefab;
    //public Transform blancoSpawn;

    // Update is called once per frame
    private void Start()
    {
        var pos = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(pos);
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //Me permite moverme
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

    }
    //Un cliente llama a este comando y el servidor ejecuta el pedido
    [Command]
    public void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;



        // Spawn the bullet on the client
        NetworkServer.Spawn(bullet);

        //GameObject blanco = (GameObject)Instantiate(blancoPrefab, blancoSpawn.position, blancoSpawn.rotation);
        //blanco.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform, false);
        //NetworkServer.Spawn(blanco);
        //Si no destruyo, permanece la bala durante todo el juego 
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2f);

    }
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
