
using UnityEngine;

public class CameraController : MonoBehaviour
{
  
    private Vector3 _offset;
    [SerializeField] private Transform Player;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

 
    private void Awake() => _offset = transform.position - Player.position;

    private void LateUpdate()
    {
        Vector3 targetPosition = Player.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

}