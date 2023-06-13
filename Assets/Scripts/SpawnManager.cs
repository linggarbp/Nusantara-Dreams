using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.IO;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn; // List prefab GameObject 2D yang akan di-spawn
    public float xRange = 10f; // rentang koordinat x untuk spawn
    public float yRange = 10f; // rentang koordinat y untuk spawn
    public float spawnDelay; // waktu delay untuk spawn berikutnya
    public float minDistance; // jarak minimum antara GameObject
    public int maxSpawnCount; // jumlah maksimal GameObject yang akan di-spawn

    private float nextSpawnTime; // waktu spawn berikutnya
    private int spawnCount; // jumlah GameObject yang telah di-spawn
    
    [HideInInspector] public int score;
    [SerializeField] TMP_Text scoreText;

    void Start()
    {
        // Mengatur waktu spawn pertama
        nextSpawnTime = Time.time + spawnDelay;
        spawnCount = 0; // Set jumlah spawn awal ke 0
        score = 0;
    }

    void Update()
    {
        scoreText.text = "Score : " + score;

        // Spawn GameObject jika sudah melewati waktu spawn berikutnya dan belum mencapai jumlah maksimal yang di-spawn
        if (Time.time >= nextSpawnTime && spawnCount < maxSpawnCount)
        {
            // Membuat random koordinat spawn
            Vector2 spawnPosition = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));

            // Cek jarak antara GameObject yang sudah ada dengan posisi spawn
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, minDistance);
            bool isOverlap = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    isOverlap = true;
                    break;
                }
            }

            // Spawn random prefab dari list jika tidak ada GameObject yang overlap atau sangat berdekatan
            if (!isOverlap)
            {
                int randomIndex = Random.Range(0, prefabsToSpawn.Count);
                GameObject spawnedObject = Instantiate(prefabsToSpawn[randomIndex], spawnPosition, Quaternion.identity);
                nextSpawnTime = Time.time + spawnDelay;
                spawnCount++; // Increment jumlah spawn

                // Tambahkan komponen Script untuk mendeteksi penghancuran GameObject yang di-spawn
                spawnedObject.AddComponent<SpawnedObjectController>();
                SpawnedObjectController objectController = spawnedObject.GetComponent<SpawnedObjectController>();
                objectController.SetSpawnManager(this);
            }
        }
    }

    // Metode untuk mengurangi jumlah spawn ketika GameObject dihancurkan
    public void ReduceSpawnCount()
    {
        spawnCount--;
        score++;
    }
}
