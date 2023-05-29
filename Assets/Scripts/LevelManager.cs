using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager sharedInstance;
    [SerializeField] private List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    [SerializeField] private List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();

    [SerializeField] private Transform levelStartPosition; //Se almacena el primer bloque

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    private void Start()
    {
        GenerateInitialBlocks();
    }

    private void Update()
    {
        
    }
    public void AddLevelBlock()
    { 
    int randomIdx = Random.Range(0,allTheLevelBlocks.Count);
        LevelBlock block;
        Vector3 spawnPosition = Vector3.zero;

        if(currentLevelBlocks.Count == 0)
        {
            block = Instantiate(allTheLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;
        }
        else
        {
            block = Instantiate(allTheLevelBlocks[randomIdx]);
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }
        block.transform.SetParent(this.transform, false);
        Vector3 correction = new Vector3(spawnPosition.x - block.startPoint.position.x, spawnPosition.y - block.startPoint.position.y, 0);

        block.transform.position = correction;
        currentLevelBlocks.Add(block);
    }

    public void RemoveLevelBlock()
    {
        LevelBlock oldBlock = currentLevelBlocks[0];
        currentLevelBlocks.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }

    public void RemoveAllLevelBlocks()
    {
        while(currentLevelBlocks.Count >0)
            {
            RemoveLevelBlock();
        }
    }

    public void GenerateInitialBlocks()
    {
        for(int i=0; i< 2; i++)
        {
            AddLevelBlock();
        }
    }
}