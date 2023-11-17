using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _bullet;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWaitShooting;

    private void Awake()
    {
        _prefab = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        bool isWork = enabled;

        WaitForSeconds delay = new WaitForSeconds(_timeWaitShooting);

        while (isWork)
        {
            Vector3 direction = (_bullet.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;

            yield return delay;
        }
    }
}