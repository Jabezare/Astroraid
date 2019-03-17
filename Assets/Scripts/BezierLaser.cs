using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierLaser : MonoBehaviour {

    public List<Transform> beamTransforms = new List<Transform>();
    public float beamCraziness = 1.0f;
    public float beamSearchRadius = 5.0f;
    public float damagePerSecond = 5.0f;
    public LayerMask beamSearchMask = -1;

    private Dictionary<GameObject, float> enemyDistance = new Dictionary<GameObject, float>();
    private CubicBezierChain beam;

    private class EnemyInfo
    {
        GameObject enemy;
        float sqrDistanceFromPlayer;
    }

	// Use this for initialization
	void Start () {
        beam = GetComponent<CubicBezierChain>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButton("Fire1"))
        {
            GetComponent<LineRenderer>().enabled = true;
            beamTransforms.Clear();
            enemyDistance.Clear();

            beamTransforms.Add(transform);

            Collider[] enemies = Physics.OverlapSphere(beamTransforms[beamTransforms.Count - 1].position, beamSearchRadius, beamSearchMask);

            while(enemies.Length > 0)
            {
                float nearestSqrDistance = Mathf.Infinity;
                GameObject nearestEnemy = null;


                foreach (Collider enemy in enemies)
                {
                    if(enemy.transform.position.y > beamTransforms[beamTransforms.Count - 1].position.y)
                    {
                        float sqrDistance = (enemy.transform.position - beamTransforms[beamTransforms.Count - 1].position).sqrMagnitude;
                        if (sqrDistance < nearestSqrDistance)
                        {
                            nearestSqrDistance = sqrDistance;
                            nearestEnemy = enemy.gameObject;
                        }
                    }
                }

                if(nearestEnemy != null && beamTransforms.Count < 5)
                {
                    enemyDistance.Add(beamTransforms[beamTransforms.Count - 1].gameObject, Mathf.Sqrt(nearestSqrDistance));
                    beamTransforms.Add(nearestEnemy.transform);

                    //Damage
                    EnemyHealth enemyHealth = nearestEnemy.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damagePerSecond * Time.deltaTime, nearestEnemy.transform.position);
                    }

                    enemies = enemies = Physics.OverlapSphere(beamTransforms[beamTransforms.Count - 1].position, beamSearchRadius, beamSearchMask);
                }
                else
                {
                    break;
                }

            }

            List<CubicBezierPoints> beamChain = new List<CubicBezierPoints>();

            for (int i = 0; i < beamTransforms.Count - 1; i++)
            {
                float distance = 0.0f;

                if (enemyDistance.ContainsKey(beamTransforms[i].gameObject))
                {
                    distance = enemyDistance[beamTransforms[i].gameObject];
                }
                CubicBezierPoints bezierPoints = new CubicBezierPoints(beamTransforms[i].position,
                                                     Vector3.Lerp(beamTransforms[i].position, beamTransforms[i + 1].position, 0.5f) + (Vector3)Random.insideUnitCircle * distance * beamCraziness,
                                                     Vector3.Lerp(beamTransforms[i].position, beamTransforms[i + 1].position, 0.5f) + (Vector3)Random.insideUnitCircle * distance * beamCraziness,
                                                     beamTransforms[i + 1].position);
                beamChain.Add(bezierPoints);
            }
            beam.SetBezierChain(beamChain);
            if (beamChain.Count > 0)
            {
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                GetComponent<AudioSource>().Stop();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<LineRenderer>().enabled = false;
        }
    }
}