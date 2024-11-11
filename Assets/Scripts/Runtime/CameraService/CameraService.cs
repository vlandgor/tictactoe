using UnityEngine;

namespace Runtime.CameraService
{
    public class CameraService : MonoBehaviour, ICameraService
    {
        [SerializeField] private Camera _camera;
    }
}