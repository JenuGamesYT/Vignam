using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace RutherFord
{
	public class GoldFoil : MonoBehaviour
	{
		[SerializeField] private GameObject protonsPrefab;
		[SerializeField] private GameObject neutronsPrefab;
		[SerializeField] private Slider protonsSlider;
		[SerializeField] private Slider neutronsSlider;
		[SerializeField] private TextMeshProUGUI neutronsText = null;
		[SerializeField] private TextMeshProUGUI protonsText = null;

		private float reflection;
		private float radius;
		private float randomrange;
		private float protonsValue = 10;
		private float neutronsValue = 10;
		private float protonsQty = 0;
		private float neutronsQty = 0;

		private void Start()
		{
			ProtonsChange();
			protonsSlider.onValueChanged.AddListener(delegate { ProtonsChange(); });

			NeutronsChange();
			neutronsSlider.onValueChanged.AddListener(delegate { NeutronsChange(); });
		}


		public void Reflect(Rigidbody body)
		{
			Vector3 gravityUp = (body.position - transform.position).normalized;
			Vector3 localUp = body.transform.up;

			// Apply downwards gravity to body		
			body.AddForce(gravityUp * reflection * GetComponent<SphereCollider>().radius);

			// Allign bodies up axis with the centre of planet
			body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
		}

		public void Au()
		{
			neutronsValue = 118;
			protonsValue = 79;
			Slider();
			ProtonsIncrease(protonsValue);
			NeutronIncrease(neutronsValue);
			ReduceProtons(protonsQty);
			ReduceNeutrons(neutronsQty);
		}

		public void Cu()
		{
			neutronsValue = 35;
			protonsValue = 29;
			Slider();
			ProtonsIncrease(protonsValue);
			NeutronIncrease(neutronsValue);
			ReduceProtons(protonsQty);
			ReduceNeutrons(neutronsQty);
		}

		public void Al()
		{
			neutronsValue = 14;
			protonsValue = 13;
			Slider();
			ProtonsIncrease(protonsValue - protonsQty);
			NeutronIncrease(neutronsValue - neutronsQty);
			ReduceNeutrons(neutronsValue);
		}

		public void ProtonsChange()
		{
			protonsValue = protonsSlider.value;
			protonsText.text = protonsValue.ToString("0");
			GetComponent<SphereCollider>().radius = (protonsValue) * 0.1f;

			ProtonsIncrease(protonsValue - protonsQty);
			ReduceProtons(protonsValue);
		}

		public void NeutronsChange()
		{
			neutronsValue = neutronsSlider.value;
			neutronsText.text = neutronsValue.ToString("0");

			NeutronIncrease(neutronsValue - neutronsQty);
			ReduceNeutrons(neutronsValue);
		}

		private void ProtonsIncrease(float Proton)
		{
			for (int i = 1; i <= Proton; i++)
			{
				randomrange = Random.Range(3, 3);
				Vector3 spawnPosition = new Vector3(randomrange, randomrange, (90 + randomrange));
				GameObject alphaParticle = Instantiate(protonsPrefab, spawnPosition, Quaternion.identity);
			}
			Debug.Log(protonsQty);
		}

		private void NeutronIncrease(float Neutron)
		{
			for (int i = 1; i <= Neutron; i++)
			{
				randomrange = Random.Range(3, 3);
				Vector3 spawnPosition = new Vector3(randomrange, randomrange, (90 + randomrange));
				GameObject alphaParticle = Instantiate(neutronsPrefab, spawnPosition, Quaternion.identity);
			}
			Debug.Log(neutronsQty);
		}

		private void ReduceNeutrons(float ReduceN)
		{
			neutronsQty = ReduceN;
			for (int i = 1; i <= ReduceN; i++)
			{
				Destroy(GameObject.FindGameObjectWithTag("Neutrons").gameObject);
			}
		}

		private void ReduceProtons(float ReduceP)
		{
			protonsQty = ReduceP;
			for (int i = 1; i <= ReduceP; i++)
			{
				Destroy(GameObject.FindGameObjectWithTag("Protons").gameObject);
			}
		}

		private void Slider()
		{
			neutronsSlider.value = neutronsValue;
			neutronsText.text = neutronsValue.ToString("0");
			protonsSlider.value = protonsValue;
			protonsText.text = protonsValue.ToString("0");
		}
	}
}

