using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class NPCSpawner : MonoBehaviour
{
    public GameObject NPCP;
    public Health player;
    public Texture crosshair;
    public float spawnInterval = 2;
    public int NPCPoWavu = 5;
    public Transform[] spawnPoints;

    float nextSpawnTime = 0;
    int waveNumber = 1;
    bool waitingForWave = true;
    float newWaveTimer = 0;
    int NPCZaEliminisanje;
    int NPCEleminisani = 0;
    int BrojNPCa;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        newWaveTimer = 10;
        waitingForWave = true;
    }

    void Update()
    {
        if (waitingForWave)
        {
            if (newWaveTimer >= 0)
            {
                newWaveTimer -= Time.deltaTime;
            }
            else
            {
                NPCZaEliminisanje = waveNumber * NPCPoWavu;
                NPCEleminisani = 0;
                BrojNPCa = 0;
                waitingForWave = false;
            }
        }
        else
        {
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime = Time.time + spawnInterval;

                if (BrojNPCa < NPCZaEliminisanje)
                {
                    Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];

                    GameObject enemy = Instantiate(NPCP, randomPoint.position, Quaternion.identity);
                    NPC npcenemy = enemy.GetComponent<NPC>();
                    npcenemy.playerTransform = player.transform;
                    npcenemy.spawn = this;
                    BrojNPCa++;
                }
            }
        }

        if (player.HP <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                /*Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);*/
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, Screen.height - 35, 50, 25), ((int)player.HP).ToString() + " HP");
        GUI.Box(new Rect(Screen.width / 2 - 35, Screen.height - 35, 70, 20), player.manager.selected.bulletsPoMagazinu.ToString() + "/" + player.manager.selected.bulletsPoMagazinuDefault.ToString());

        if (player.HP <= 0)
        {
            GUI.Box(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 20, 150, 40), "Kraj igre\nPritisni 'Space' za Restart");
        }
        else
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 3, Screen.height / 2 - 3, 6, 6), crosshair);
        }

        GUI.Box(new Rect(Screen.width / 2 - 50, 10, 150, 25), "Broj neprijatelja: " + (NPCZaEliminisanje - NPCEleminisani).ToString());

        if (waitingForWave)
        {
            GUI.Box(new Rect(Screen.width / 2 - 125, Screen.height / 4 - 12, 250, 25), "Talas " + waveNumber.ToString() + "... - za " + ((int)newWaveTimer).ToString() + " sekundi");
        }
    }
    public void EnemyEliminated(NPC enemy)
    {
        NPCEleminisani++;

        if (NPCZaEliminisanje - NPCEleminisani <= 0)
        {
            newWaveTimer = 10;
            waitingForWave = true;
            waveNumber++;
        }
    }
}

