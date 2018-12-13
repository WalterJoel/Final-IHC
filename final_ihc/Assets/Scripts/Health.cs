using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public const int    maxHeath     = 100;
    public const string colorDefault = "Rojo";
    //Al estar enganchados, el valor de current health se pasa a la funcion onchange cada vez que cambia 
    //por eso deben ser del mismo tipo int ESTA FUNCION SE INVOCA EN EL SERVIDOR Y EN TODOS LOS CLIENTES
    [SyncVar(hook="OnChangeHealth")]   public int currentHealth  = maxHeath;
    [SyncVar(hook="OnChangeColor")] public string colorActual = colorDefault;

    public RectTransform healthBar;
    public RectTransform healthBar2;

    public bool destroyOnDeath; //pOR DEFECTO ES FALSO AL INICIAR

	private NetworkStartPosition[] spawnPoints;

	void Start(){
		if (isLocalPlayer) {
			spawnPoints = FindObjectsOfType <NetworkStartPosition>();
		}
	}
    public void pintarObjeto(string nombreColor)
    {
        //Se le indica al  servidor que debe variar el color
        if (!isServer)
        {
            return;
        }
        colorActual = nombreColor;        
    }
	public void TakeDamage(int amount){

        //Esto significa que primero el danio solo se aplica en el servidor, la info se queda en el servidor
		if (!isServer) {
			return;
		}
        //Solo objetos creados por el servidor pueden hacer esto creo por ahora
		currentHealth -= amount;

		if (currentHealth <= 0) {

			if (destroyOnDeath) {
				Destroy (gameObject);
			} 
			else {
				currentHealth = maxHeath;
                //El servidor manda un comando destruir
				//RpcRespawn ();
			}

		}
	}

	void OnChangeHealth(int health){
		healthBar.sizeDelta = new Vector2 (health * 2, healthBar.sizeDelta.y);
	}
    void OnChangeColor(string color)
    {
        if (color == "Rojo")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        healthBar2.sizeDelta = new Vector2(10 * 2, healthBar2.sizeDelta.y);

    }
    //Todos los clientes respawn
    [ClientRpc]
	void RpcRespawn(){
		if (isLocalPlayer) {

			Vector3 spawnPoint = Vector3.zero;
			if (spawnPoints != null && spawnPoints.Length > 0) {
				spawnPoint = spawnPoints [ Random.Range (0, spawnPoints.Length) ].transform.position;
			}

			transform.position = spawnPoint;
 		}
	}

}
