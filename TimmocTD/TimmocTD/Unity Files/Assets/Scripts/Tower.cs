using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
<<<<<<< HEAD
<<<<<<< HEAD
    public string name;
=======
    public string towerName;
>>>>>>> ck
    public string description;
    public int price;
	public Texture texture;
    public float attackRange;
    public GameObject attackAreaPrefab;

    private bool selected, showRange;
    private int level;
    private int vectorCount;
    private GameObject attackArea;
=======
	public int price;
	public Texture texture;
	public string description;

	private bool selected;
	private int level;
	private GameObject towerOption, towerMenu;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
//	GameObject objRef;
//	public static Transform tower = (Transform)Resources.Load("BaseTower");
//	float xPixel, yPixel;
//	int xTile, yTile;

	void Start() {
<<<<<<< HEAD
		level = 1;
	}

    void FixedUpdate () {
        if (showRange) {
            LineRenderer line = GetComponent<LineRenderer> ();
            for (int i = 0; i < vectorCount; i++) {
                Vector3 pos = transform.position + transform.up * i;
                line.SetPosition (i, pos);
            }
        }
    }

    public void showAttackRange() {
        addAttackDirection();
        showRange = true;
        attackArea = Instantiate(attackAreaPrefab, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity) as GameObject;
        attackArea.transform.localScale = new Vector3(attackRange, attackRange, 1);
    }

    public void destroyAttackRange() {
        if (attackArea != null) {
            Destroy(GetComponent<LineRenderer>());
            Destroy(attackArea);
        }
        showRange = false;
    }

    private void addAttackDirection() {
        vectorCount = (int)attackRange * 2;
        LineRenderer line = gameObject.AddComponent<LineRenderer> ();
        line.useWorldSpace = true;
        line.material = new Material (Shader.Find ("Particles/Additive"));
        line.SetColors (Color.cyan, Color.red);
        line.SetVertexCount (vectorCount);
        line.SetWidth (0.02f, 0.02f);
    }
=======
		towerMenu = GameObject.Find ("Tower Menu");
		towerOption = GameObject.Find ("Tower Option");
		level = 1;
	}

	void OnMouseDown() {
		towerMenu.SetActive (selected);
		selected = !selected;
		if (selected) {
			towerOption.GetComponent<RectTransform>().localPosition = new Vector3(-310.74f, 33, 0);
		} else {
			resetOptionUI();
		}
		Debug.Log (selected);
	}

	public void resetOptionUI() {
		towerMenu.SetActive (true);
		towerOption.GetComponent<RectTransform>().localPosition = new Vector3(-636f, 33, 0);
	}
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
}
