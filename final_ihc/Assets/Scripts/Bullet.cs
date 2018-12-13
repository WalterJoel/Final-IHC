using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    /*private void OnTriggerEnter(Collider other)
    {
        GameObject color_Actual = other.gameObject;

    }*/
    public bool cambiar_carro = false;
    public GameObject modifico_este_color;
    void OnCollisionEnter(Collision collison){
        if (cambiar_carro == false)
        {
            Debug.Log("cambiar carro");
            GameObject hit = GameObject.Find(modifico_este_color.name + "(Clone)");
            //Extraigo el script cambiar carro
            CarSelect carro = hit.GetComponent<CarSelect>();
            if (carro != null)
            {
                carro.SelectCar(0);
            }
        }
        else
        {
            //GameObject hit = collison.gameObject;
            Debug.Log("collision");
            GameObject hit = GameObject.Find(modifico_este_color.name + "(Clone)");
            PaintTuning health = hit.GetComponent<PaintTuning>();
            //Health health = hit.GetComponent<Health> ();
            //Aqui pregunto si ese jugador tiene adjunto el script health nada mas (COMPROBADO)
            if (health != null) {
                Debug.Log("entro");
                //health.TakeDamage (10);
                var randomInt = Random.Range(1, 6);
                health.SetPaint(randomInt); //Le paso 6 que es distinto al otro
                //Le paso el color y el identificador de GameObject para que modifique este enemigo
                //string color = "Blue";
                //health.pintarObjeto(color);
		    }
        }
        Destroy (gameObject);
	}

}
