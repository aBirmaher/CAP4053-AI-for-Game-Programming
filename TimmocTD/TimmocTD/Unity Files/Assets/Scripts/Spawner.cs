using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
<<<<<<< HEAD

    public GameObject spawnHere;
    public int waveCount;   // Set this in Unity Editor
	public int currEnemies = 0;
    public bool training;

    private GameObject[,] tiles;
    private GameObject scriptMan;
    private Enemy[] enemies;
	private int delay = 0;
	private Object gB; 
	private int spawnX;
	private int spawnY;
    private int speedRandomness;

    void Awake () {
        scriptMan = GameObject.Find ("Canvas");
        if (!training) {
            gB = scriptMan.GetComponent<GameBoard>();
            tiles = ((GameBoard) gB).tiles;
            spawnX = (int)((GameBoard) gB).spawnPoint.x;
            spawnY = (int)((GameBoard) gB).spawnPoint.y;
            speedRandomness = 0;
        } else {
            gB = scriptMan.GetComponent<TrainingBoard>();
            tiles = ((TrainingBoard) gB).tiles;
            spawnX = (int)((TrainingBoard) gB).spawnPoint.x;
            spawnY = (int)((TrainingBoard) gB).spawnPoint.y;
            speedRandomness = 10;
        }
    }
=======
	public GameObject spawnHere;
	public Enemy[] enemies;
	public int waveCount = 10;
	public int currEnemies = 0;
	private int delay = 0;
	private GameBoard gB; 
	private int spawnX;
	private int spawnY;
	GameObject scriptMan;
	private bool start=true;
	public Tile[,] board;
	GameObject[,] tiles;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23

	// Use this for initialization
	void Start () {
		enemies = new Enemy[waveCount];
		//spawn left
		//stuff[0]=spawnEnemy (-256, 0, 270);
		//spawn right
		/*stuff[1]=spawnEnemy (256, 0, 90);
		//spawn up
		stuff[2]=spawnEnemy (0, 256, 180);
		// spawn down
		stuff[3]=spawnEnemy (0, -256, 0);*/
	}

	void FixedUpdate(){
<<<<<<< HEAD

		if(currEnemies < waveCount){
			if(delay % 100 == 0){
                int speedVariance = (int) (speedRandomness * Random.value * Random.value);
                GameObject timmoc = spawnEnemy (tiles[spawnX,spawnY].transform.position.x, tiles[spawnX,spawnY].transform.position.y, 180);
                enemies[currEnemies] = new Enemy(timmoc, spawnX, spawnY, gB, timmoc.GetComponent<Timmoc>().speed + speedVariance);
				currEnemies++;
			}			
		}
        delay++;
=======
		if (start) {
			
			scriptMan = GameObject.Find ("Canvas");
			gB = GetComponent<GameBoard> ();
			tiles=gB.tiles;
			Debug.Log (tiles.GetLength(0));//=y
			Debug.Log (tiles.GetLength(1));//=x

			for (int y=0; y<gB.tiles.GetLength(0); y++) {
				for (int x=0; x<gB.tiles.GetLength(1); x++) {
					if (gB.path [y,x] == 2) {
						spawnX = x;
						spawnY = y;
						gB.path [y,x] =1;
						Debug.Log (x+","+y);
					}
				}
			}
			
			start = false;
		}
		
		
		
		
		if(currEnemies<waveCount){
			if(delay%100==0){
				
				GameObject timmoc=spawnEnemy (2f + (float)spawnX * 128f, 1150f - (float)spawnY * 128f, 180);
				enemies[currEnemies]=new Enemy(timmoc, spawnX, spawnY, gB, 4);
				currEnemies++;
			}
			
			
		}
		
		for (int i=0; i<currEnemies; i++) {

			Debug.Log("call "+i);
			enemies[i].moveTo(new Vector3(tiles[5,5].transform.position.x, tiles[5,5].transform.position.y, 0));
				

			//move (stuff[i]);
		}

		delay++;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
	}

	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        for (int i=0; i<currEnemies; i++) {
            //Debug.Log("call "+i);
            enemies[i].checkMove();
            //enemies[i].moveTo(new Vector3(tiles[5,5].transform.position.x, tiles[5,5].transform.position.y, 0));
            //move (stuff[i]);
        }
	}

    /// <summary>
    /// Spawns the enemy with corresponding position.
    /// </summary>
    /// <returns>The game object of the enemy.</returns>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="z">The facing angle.</param>
	GameObject spawnEnemy(float x, float y, float z){
		return Instantiate(spawnHere, new Vector3(x, y, -1f), Quaternion.Euler(new Vector3(0, 0, z))/*Quaternion.identity*/) as GameObject;
	}

    public void setWaveCount (int count) {
        waveCount = count;
        enemies = new Enemy[waveCount];
    }

    public bool noEnemy() {
        return currEnemies == 0;
    }
=======


	}

	GameObject spawnEnemy(float x, float y, float z){
		return ((GameObject)Instantiate(spawnHere, new Vector3(((float)x / 100), ((float)y / 100), 0), Quaternion.Euler(new Vector3(0, 0, z))/*Quaternion.identity*/));
	}


>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23

}
