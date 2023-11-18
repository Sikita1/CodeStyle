using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _allPlacesPoint;

    private Transform[] _arrayPlaces;
    private float _speed;
    private int _currentPoint;

    private void Awake()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform target = _arrayPlaces[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position,
                                                 target.position,
                                                 _speed * Time.deltaTime);

        if (transform.position == target.position)
            GetNextPlace();
    }

    private Vector3 GetNextPlace()
    {
        _currentPoint++;

        if (_currentPoint == _arrayPlaces.Length)
            _currentPoint = 0;

        Vector3 currentPosition = _arrayPlaces[_currentPoint].transform.position;
        transform.forward = currentPosition - transform.position;
        return currentPosition;
    }


}