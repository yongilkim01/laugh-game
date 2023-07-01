using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private GameEnv gameEnv;

    [Header("NPC create status")]
    public int npcCount;
    public float minX = -10.0f;
    public float maxX = 12.0f;
    public float minY = -5.0f;
    public float maxY = 8.0f;

    [Header("NPC object")]
    public GameObject npcObj;
    private void Awake() {
        gameEnv = FindObjectOfType<GameEnv>();
    }
    void Start()
    {
        InitStatus();
        InitObject();
        GenerateNPC();
    }
    void Update()
    {
        
    }
    private void InitStatus() {
        npcCount = gameEnv.npcCount;
    }
    private void InitObject() {
        npcObj = Resources.Load<GameObject>("Prefabs/Npc/Npc");
    }
    private void GenerateNPC() {
        for(int i = 0; i < npcCount; i++) {
            Vector3 _npcPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0.0f);
            Instantiate(npcObj, _npcPosition, Quaternion.identity);
        }
    }
}
