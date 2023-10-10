
using UnityEngine;

public class Teleporter : MonoBehaviour
{
  [SerializeField] private Transform destinationTp;
    
    public Transform GetDestination()
    {
        return destinationTp;
    }
}
