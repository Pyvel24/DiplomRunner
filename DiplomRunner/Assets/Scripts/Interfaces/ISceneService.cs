using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Interfaces
{
    public interface ISceneService
    {
        AsyncOperation LoadScene(string name);
        AsyncOperation UnLoadScene(string name);
        bool IsLoading { get; }
        IEnumerable<GameObject> GetActiveRoots();
    }
}