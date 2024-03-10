using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace RutherFord
{
    public class ExperimentManager : MonoBehaviour
    {

        public GameObject alphaParticlePrefab;
        public GameObject Laser;

        public int numberOfParticles = 100;
        public float timeDelay;

        public bool gunOn = false;


        public void Gun()
        {
            if (gunOn)
            {
                gunOn = false;
                Laser.SetActive(false);
            }
            else if (!gunOn)
            {
                gunOn = true;
                StartCoroutine(SetupExperiment());
                Laser.SetActive(true);
            }
        }


        System.Collections.IEnumerator SetupExperiment()
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                if (gunOn)
                {
                    float randomX = Random.Range(-30, 30);
                    Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

                    GameObject alphaParticle = Instantiate(alphaParticlePrefab, spawnPosition, Quaternion.identity);


                    yield return new WaitForSeconds(timeDelay = Random.Range( 0.5f, 1));

                }
            }
        }

    }

}
            





