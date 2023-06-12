using UnityEngine;

public class SpawnedObjectController : MonoBehaviour
{
    private SpawnManager spawnManager;

    // Metode untuk mengatur SpawnManager
    public void SetSpawnManager(SpawnManager manager)
    {
        spawnManager = manager;
    }

    // Dipanggil saat GameObject dihancurkan
    private void OnDestroy()
    {
        if (spawnManager != null)
        {
            spawnManager.ReduceSpawnCount();
        }
    }
}
