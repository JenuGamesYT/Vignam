using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RutherFord
{

    public class AlphaParticale : MonoBehaviour
    {
        GoldFoil atom;
        Rigidbody rb;

        private Slider energySlider;
        private TextMeshProUGUI energyText = null;

        private float energyValue;
        private float speed = 10f;


        void Start()
        {
            SliderChange();
            energySlider.onValueChanged.AddListener(delegate { SliderChange(); });
        }

        void Awake()
        {
            atom = GameObject.FindGameObjectWithTag("GoldFoil").GetComponent<GoldFoil>();
            rb = GetComponent<Rigidbody>();

            // Disable rigidbody gravity and rotation
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            energySlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
            energyText = GameObject.FindGameObjectWithTag("mycanvas").GetComponent<TextMeshProUGUI>();
        }


        void Update()
        {
            transform.Translate(Vector3.up * (energyValue * speed) * Time.deltaTime);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("GoldFoil"))
            {
                atom.Reflect(rb);
            }
            else if (other.CompareTag("Bound"))
            {
                Destroy(this.gameObject);
            }
        }

        public void SliderChange()
        {
            energyValue = energySlider.value;
            energyText.text = (energyValue * 10f).ToString("0");
        }
    }
}










