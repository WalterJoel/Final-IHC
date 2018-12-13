using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class BrakeLight : MonoBehaviour
    {
        public CarController car; // reference to the car controller, must be dragged in inspector

		public GameObject BrakeObj;


        private void Start()
        {
        }


        private void Update()
        {
            // enable the Renderer when the car is braking, disable it otherwise.
			BrakeObj.SetActive (car.BrakeInput > 0f);
        }
    }
}
