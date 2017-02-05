using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldGen : MonoBehaviour {

    public int seed = 312;

    public int Width;

    public int Height;

    public float tileSize = 40;

    public List<GameObject> WorldTiles;

    public List<GameObject> OuterTiles;

    public List<GameObject> CornerTiles;

    public GameObject Ceiling;

    

    System.Random rand;

    // Use this for initialization
    void Start ()
    {
        rand = new System.Random(seed);
        GenWorld();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void GenWorld()
    {
        if (Width <= 0 || Height <= 0)
        {
            Debug.Log("Width/Height must be larger than 0!");
            return;
        }

        if (WorldTiles.Count <= 0 || OuterTiles.Count <= 0 || CornerTiles.Count <= 0)
        {
            Debug.Log("There must be elements in WorldTiles, OuterTiles, and CornerTiles!");
            return;
        }

        //Generates inner area
        for(int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                
                GameObject tile = GameObject.Instantiate(WorldTiles[rand.Next(0, WorldTiles.Count)]);
                tile.transform.position = new Vector3(j * tileSize, 0, -i * tileSize);
                float rotation = GetRandRotation();
                //tile.transform.Rotate(0, rotation, 0);

                //if (rotation == 90)
                //    tile.GetComponentInChildren<TerrainCollider>().gameObject.transform.localPosition = new Vector3(20, .01f, -20);
                //else if(rotation == 180)
                //    tile.GetComponentInChildren<TerrainCollider>().gameObject.transform.localPosition = new Vector3(20, .01f, 20);
                //else if (rotation == 270)
                //    tile.GetComponentInChildren<TerrainCollider>().gameObject.transform.localPosition = new Vector3(-20, .01f, 20);
            }
        }

        //Gennerates outer area (top and bottom)
        for(int i = 0; i < Width; i++)
        {
            GameObject tileUpper = GameObject.Instantiate(OuterTiles[rand.Next(0, OuterTiles.Count)]);
            tileUpper.transform.position = new Vector3(i * tileSize, -10, 1 * tileSize);

            GameObject tileLower = GameObject.Instantiate(OuterTiles[rand.Next(0, OuterTiles.Count)]);
            tileLower.transform.position = new Vector3(i * tileSize, -10, -Height * tileSize);
            tileLower.transform.Rotate(0, 180, 0);
        }

        //Gennerates outer area (left and right)
        for (int i = 0; i < Height; i++)
        {
            GameObject tileLeft = GameObject.Instantiate(OuterTiles[rand.Next(0, OuterTiles.Count)]);
            tileLeft.transform.position = new Vector3(-1 * tileSize, -10, -i * tileSize);
            tileLeft.transform.Rotate(0, -90, 0);

            GameObject tileRight = GameObject.Instantiate(OuterTiles[rand.Next(0, OuterTiles.Count)]);
            tileRight.transform.position = new Vector3(Width * tileSize, -10, -i * tileSize);
            tileRight.transform.Rotate(0, 90, 0);
        }

        //Generates the corner tiles
        GameObject UpperLeft = GameObject.Instantiate(CornerTiles[rand.Next(0, CornerTiles.Count)]);
        UpperLeft.transform.position = new Vector3(-1 * tileSize, -10, 1 * tileSize);
        GameObject UpperRight = GameObject.Instantiate(CornerTiles[rand.Next(0, CornerTiles.Count)]);
        UpperRight.transform.position = new Vector3(Width * tileSize, -10, 1 * tileSize);

        GameObject LowerLeft = GameObject.Instantiate(CornerTiles[rand.Next(0, CornerTiles.Count)]);
        LowerLeft.transform.position = new Vector3(-1 * tileSize, -10, -Height * tileSize);
        LowerLeft.transform.Rotate(0, GetRandRotation(), 0);

        GameObject LowerRight = GameObject.Instantiate(CornerTiles[rand.Next(0, CornerTiles.Count)]);
        LowerRight.transform.position = new Vector3(Width * tileSize, -10, -Height * tileSize);
        LowerRight.transform.Rotate(0, GetRandRotation(), 0);

        GameObject TopCeiling = GameObject.Instantiate(Ceiling);
        TopCeiling.transform.position = new Vector3(((Width - 1) * tileSize) / 2, 189.5f, -((Height - 1) * tileSize) / 2);
        TopCeiling.transform.localScale = new Vector3(Width * tileSize, 1, Height * tileSize);







    }

    private float GetRandRotation()
    {
        int i = rand.Next(0, 4);

        switch (i)
        {
            case 0:
                return 0;
            case 1:
                return 90;
            case 2:
                return 180;
            case 3:
                return 270;
            default:
                return 0;
        }
    }




}
