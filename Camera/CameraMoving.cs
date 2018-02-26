using UnityEngine;
using System.Collections;
using UnityEditor;

public class CameraMoving : MonoBehaviour
{
	float MoveSpeed = 150.0f;
	float ZoomSpeed = 15.0f;
	float minFov = 5.0f;
	float maxFov = 40.0f;
	public float translate_x, translate_y, translate_z;
	float terrainHeight, terrainWidth;
	float screenHeight, screenWidth;
	Vector3 translate;
	Vector3 right;
	Vector3 forward;
	Vector3 up;
	Vector3 moveToPosition;
	Vector3 zero;

	Vector3 startPoint;
	Vector3 endPoint;

	public Transform selected;
	public GameObject selectedPrefab;
	GameObject select;

	float value;
	float fov;

	Plane tr;

	int degrees = 8;

	bool isSelecting = false;

	GameObject currentlySelected;

	void Start(){
		right = new Vector3 (1,0,0);
		forward = new Vector3 (0,0,1);
		translate = new Vector3 ();
		up = new Vector3(0, 1, 0);
		zero = Vector3.zero;
		//tr = GameObject.Find("Plane").GetComponent<Plane>();
		terrainHeight = 500;
		terrainWidth =500;
		screenHeight = Screen.height;
		screenWidth = Screen.width;
	}

	void Update()
	{ 



		/*if (Input.GetMouseButtonDown (0)) 
		{			
			//selectCharacter ();
			isSelecting = true;
			startPoint = Input.mousePosition;



			foreach(Cube item in FindObjectsOfType<Cube>() ){

				if (IsWithinSelectionBounds(item.gameObject)) {
					Debug.Log ("1");
					item.Selected = Instantiate (selectedPrefab, item.transform.GetChild(0));
				}
			}

		}

		if (Input.GetMouseButtonUp(0)) {
			endPoint = Input.mousePosition;
			isSelecting = false;
		}
		*/
		if(Input.GetMouseButton(1))
		{
			transform.RotateAround (transform.position, up, Input.GetAxis ("Mouse X")* degrees);	
		}

		if(Input.GetAxis("Mouse ScrollWheel") !=0)
		{

			fov = Camera.main.fieldOfView;
			fov += Input.GetAxis ("Mouse ScrollWheel") * ZoomSpeed;
			fov = Mathf.Clamp (fov, minFov, maxFov);
			Camera.main.fieldOfView = fov;
		}

		if (Input.mousePosition.x >= (screenWidth - 5) && transform.position.x <= terrainWidth) {
			//transform.position += right * MoveSpeed * Time.deltaTime;
			transform.Translate (right * MoveSpeed * Time.deltaTime, Space.Self);

		} 

		if (Input.mousePosition.x <= 0 && transform.position.x >= -1) {
			//transform.position -= right * MoveSpeed * Time.deltaTime;
			transform.Translate (-(right * MoveSpeed * Time.deltaTime), Space.Self);

		}

		if (Input.mousePosition.y <= 0 && transform.position.z >= -2) {
			translate_y = Mathf.Cos (60 * Mathf.Deg2Rad) * MoveSpeed * Time.deltaTime;
			translate_z = Mathf.Sin (16.77866f * Mathf.Deg2Rad)  * MoveSpeed * Time.deltaTime;
			translate.Set (0, -translate_z, -translate_y);
			transform.Translate (translate, Space.Self);

		}

		if (Input.mousePosition.y >= (screenHeight - 5) && transform.position.z <= terrainHeight) {
			//transform.Translate (forward * MoveSpeed * Time.deltaTime, Space.Self);
			translate_y = Mathf.Cos (60 * Mathf.Deg2Rad) *  MoveSpeed * Time.deltaTime;
			translate_z = Mathf.Sin (16.77866f * Mathf.Deg2Rad) * MoveSpeed * Time.deltaTime;
			translate.Set (0, translate_z, translate_y);
			transform.Translate (translate, Space.Self);

		}

		if (Input.GetAxis ("Horizontal") != 0) {			
			/*translate_x = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;
			translate.Set (translate_x, 0,0);
			transform.position += translate;
			//transform.position += new Vector3 (translate_x, 0,0);
			value = Mathf.Clamp (transform.position.x, 0, terrainHeight);
			translate.Set (value,transform.position.y, transform.position.z);
			transform.position = translate;
			//transform.position = new Vector3 (value,transform.position.y, transform.position.z);
			*/
			translate_x = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;
			translate.Set (translate_x, 0, 0);
			transform.Translate (translate, Space.Self);
		}

		if (Input.GetAxis ("Vertical") != 0) {


			/*translate_y = Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime;
			translate.Set (0, 0, translate_y);
			transform.position += translate;
			//transform.position += new Vector3 (0,0,translate_y);
			value = Mathf.Clamp (transform.position.z, 0, terrainWidth);
			translate.Set (transform.position.x, transform.position.y, value);
			transform.position = translate;
			//transform.position = new Vector3 (transform.position.x,transform.position.y, value);
*/
			translate_y = Mathf.Cos (60 * Mathf.Deg2Rad) * Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime;
			translate_z = Mathf.Sin (16.77866f * Mathf.Deg2Rad) * Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime;
			translate.Set (0, translate_z, translate_y);
			transform.Translate (translate, Space.Self);
		}

		if (Time.frameCount % 30 == 0) {
			System.GC.Collect ();
		}
	}
}

