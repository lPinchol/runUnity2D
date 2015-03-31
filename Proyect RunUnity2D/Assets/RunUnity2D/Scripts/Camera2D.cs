using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour
{
    // Var public
    public Transform _Character;
    public Transform _Camera;
    public float delay = 6.0f;

    private void Update()
    {
        //_Character.position = new Vector3(_Character.position.x + delay, transform.position.y, transform.position.z);
        _Camera.position = new Vector3(_Character.position.x + delay, _Character.position.y, _Character.position.z - 10);
    }
}