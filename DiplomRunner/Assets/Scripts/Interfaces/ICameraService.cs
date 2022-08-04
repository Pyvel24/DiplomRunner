using UnityEngine;

namespace DefaultNamespace.Interfaces
{
    public interface ICameraService
    {
        void SetMainCamera(Camera camera);
        void SetDefaultCamera();
    }
}