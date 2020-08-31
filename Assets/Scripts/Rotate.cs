using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    void Update()
    {
        transform.RotateAroundLocal(Vector3.forward, _rotateSpeed * Time.deltaTime);
    }
}
