using System.Collections;
using UnityEngine;

// Should be similar to Laser, but it fires more slowly, basically it's a big bullet
public class Beam : MonoBehaviour
{
    public GameObject beamPrefab;

    public float fireRate = 0.2f;

    public Transform enemyParent;

    private Transform playerTransform;

    private float timer = 0;
    void Start()
    {
        playerTransform = transform;
    }
    // Update is called once per frame
    void Update()
    {
        print(timer);
        timer += Time.deltaTime;
        if (timer > 1 / fireRate)
        {
            Transform[] enemies = new Transform[enemyParent.childCount];
            for (int i = 0; i < enemyParent.childCount; i++)
            {
                enemies[i] = enemyParent.GetChild(i);
            }

            if (enemies.Length <= 0)
            {
                return;
            }

            var enemy = getRandomEnemy(enemies);
            
            StartCoroutine(shootBeam(enemy));
            timer = 0;
        }

    }
    private Transform getRandomEnemy(Transform[] enemies)
    {
        if (enemies.Length <= 0)
        {
            return null;
        }

        int index = Random.Range(0, enemies.Length);
        return enemies[index];
    }
    private IEnumerator shootBeam(Transform enemy)
    {
        yield return null;

        var beam = Instantiate(beamPrefab, playerTransform.position, Quaternion.identity);
        var direction = (enemy.position - beam.transform.position).normalized;
        beam.transform.right = direction;

        var damager = beam.GetComponent<Damager>();
        damager.setDamage(2);

        yield return new WaitForSeconds(0.5f);

        Destroy(beam.gameObject);
    }
}
