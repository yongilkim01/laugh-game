using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [Header("NPC Create status")]
    public int npcCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitStatus() {
        npcCount = 20;
    }

    private void InitNPC() {
        for(int i = 0; i < npcCount; i++) {
            InitStatus();
        }
    }
}
