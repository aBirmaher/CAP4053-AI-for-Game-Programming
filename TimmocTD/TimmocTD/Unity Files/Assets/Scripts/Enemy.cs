using UnityEngine;
using System.Collections;

public class Enemy {

<<<<<<< HEAD
	GameObject timmoc;
	GameObject target;
	GameObject[,] tiles;
	Object gB;
	int currX;
	int currY;
	int lastX;
	int lastY;
	public int speed;

    private Vector2 targetPosition;
	
	public Enemy(GameObject instan, int x, int y , Object gB, int speed){
        if (gB is GameBoard) {
            this.gB = (GameBoard) gB;
            this.tiles = ((GameBoard) gB).tiles;
        } else {
            this.gB = (TrainingBoard) gB;
            this.tiles = ((TrainingBoard) gB).tiles;
        }
		timmoc=instan;
		currX=x;
		currY=y;
		lastX=-1;
		lastY=-1;
		this.speed=speed;
        targetPosition = new Vector2(timmoc.transform.position.x, timmoc.transform.position.y);
	}
	
    /**
     * Tiles goes from bottom to top, left to right, it is vertically reversed version of path
     * ex 4x4 matrix in game:
     *      [3,0],[3,1],[3,2],[3,3]
     *      [2,0],[2,1],[2,2],[2,3]
     *      [1,0],[1,1],[1,2],[1,3]
     *      [0,0],[0,1],[0,2],[0,3]
     * 
     **/
    /// <summary>
    /// Checks the move.
    /// X and Y are reversed
    /// </summary>
	public void checkMove(){
        Vector2 currPos = new Vector2(timmoc.transform.position.x, timmoc.transform.position.y);
        if (Mathf.Abs(Vector2.Distance(currPos, targetPosition)) < .1f)
            timmoc.rigidbody2D.velocity = Vector2.zero;
        else
            return;

        if(currY - 1 >= 0 && tiles[currX,currY-1].GetComponent<Tile>().walkable && !(currX == lastX && currY - 1 == lastY)) {
//            Debug.Log("go left"); 
			lastX = currX;
			lastY = currY;
			currY--;
            timmoc.transform.localEulerAngles = new Vector3(0, 0, 90);
			moveTo(tiles[currX,currY]);
        } else if(currY + 1 < tiles.GetLength(1) && tiles[currX,currY+1].GetComponent<Tile>().walkable && !(currX == lastX && currY + 1 == lastY)) {
//            Debug.Log("go right");
			lastX = currX;
			lastY = currY;
			currY++;
            timmoc.transform.localEulerAngles = new Vector3(0, 0, 270);
		    moveTo(tiles[currX, currY]);
        } else if(currX + 1 < tiles.GetLength(0) && tiles[currX+1,currY].GetComponent<Tile>().walkable && !(currX + 1 == lastX && currY == lastY)) {
//            Debug.Log("go up");
			lastX = currX;
			lastY = currY;
            currX++;
            timmoc.transform.localEulerAngles = new Vector3(0, 0, 0);
		    moveTo(tiles[currX, currY]);
        } else if(currX - 1 >= 0 && tiles[currX-1,currY].GetComponent<Tile>().walkable && !(currX - 1 == lastX && currY == lastY)) {
//            Debug.Log("go down");
			lastX = currX;
			lastY = currY;
            currX--;
            timmoc.transform.localEulerAngles = new Vector3(0, 0, 180);
		    moveTo(tiles[currX, currY]);
		}
        targetPosition = new Vector2(tiles[currX,currY].GetComponent<Tile>().transform.position.x, tiles[currX,currY].GetComponent<Tile>().transform.position.y);
	}
	
	public void moveTo(GameObject target) {
		this.target = target;
		Vector3 dir = target.transform.position - timmoc.transform.position;
        dir.Normalize();
		timmoc.rigidbody2D.velocity = dir*speed;
	}
=======
		GameObject timmoc;
		GameObject target;
		GameObject[,] tiles;
		GameBoard gB;
		int currX;
		int currY;
		int lastX;
		int lastY;
		public int speed;
		
		public Enemy(GameObject instan, int x, int y , GameBoard gB, int speed){
			this.tiles = gB.tiles;	
		this.gB = gB;
			timmoc=instan;
			currX=x;
			currY=y;
			lastX=-1;
			lastY=-1;
			this.speed=speed;
		}
		
		public void checkMove(){
			if(currY -1>0){
				if(gB.path[currY-1, currX]==1){
					if(!(currX==lastX&&currY-1==lastY)){
						
						
						
						lastX=currX;
						lastY=currY;
						currY-=1;
						
						moveTo(tiles[currY,currX]);
						
					}
				}
			}
			
			//checkDown
			if(currY+1<gB.path.GetLength(0)){
				if(gB.path[currY+1,currX]==1){
					if(!(currX==lastX&&currY+1==lastY)){
						lastX=currX;
						lastY=currY;
						currY+=1;

					moveTo(tiles[currY,currX]);
					}
				}
			}
			
			//checkRight
			if(currX+1<gB.path.GetLength(1)){
				if(gB.path[currY,currX+1]==1){
					if(!(currX+1==lastX&&currY==lastY)){
						
						//stuff.transform.;
						
						
						lastX=currX;
						lastY=currY;
						currX+=1;

					moveTo(tiles[currY,currX]);
					}
				}
			}
			
			//checkLeft
			if(currX-1>0){
				if(gB.path[currY,currX-1]==1){
					if(!(currX-1==lastX&&currY==lastY)){
						//stuff.transform.;
						
						
						lastX=currX;
						lastY=currY;
						currX-=1;
					moveTo(tiles[currY,currX]);
					}
				}
			}
		}
		
		public void moveTo(GameObject target) {
			this.target = target;
			Vector3 dir = target.transform.position - timmoc.transform.position;
			timmoc.rigidbody2D.velocity = dir*speed;
			
		}
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23

	public void moveTo(Vector3 target) {
		//this.target = target;
		Vector3 dir = target- timmoc.transform.position;
		dir.Normalize();
		timmoc.rigidbody2D.velocity = dir*speed;
<<<<<<< HEAD
=======
		
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
	}



}
