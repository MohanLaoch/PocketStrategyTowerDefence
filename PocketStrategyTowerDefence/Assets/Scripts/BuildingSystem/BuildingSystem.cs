using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{

    public static BuildingSystem current;

    [Header("TileMap ")]

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap MainTilemap;
    [SerializeField] private TileBase usedTile;

    [Header("Placeable Towers")]

    public GameObject PlaceableTowerPrefab;
    public GameObject PlaceableTowerTest;

    private PlaceableObject objectToPlace;

    private bool canCreate = true;

    public Vector3 spawnPosition;

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    public void CreateTower()
    {
        if (canCreate == true)
        {
            FindObjectOfType<AudioManager>().Play("SpawnTower");
            InitializeWithObject(PlaceableTowerPrefab);
            canCreate = false;
        }
        }

        private void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FindObjectOfType<AudioManager>().Play("SpawnTower");
            InitializeWithObject(PlaceableTowerPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InitializeWithObject(PlaceableTowerTest);
        }*/

        if (!objectToPlace)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            objectToPlace.Rotate();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanBePlaced(objectToPlace))
            {
                FindObjectOfType<AudioManager>().Play("PlaceTower");
                objectToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                TakeArea(start, objectToPlace.Size);
                canCreate = true;
            }
            else
            {
                Destroy(objectToPlace.gameObject);
                canCreate = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Play("DestroyTower");
            Destroy(objectToPlace.gameObject); 
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }


    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }


    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }


    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(spawnPosition);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = placeableObject.Size;

        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);

        foreach (var b in baseArray)
        {
            if (b == usedTile)
            {
                return false;
            }
        }

        return true;
    }

    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        MainTilemap.BoxFill(start, usedTile, start.x, start.y, start.x + size.x, start.y + size.y);
    }
}
