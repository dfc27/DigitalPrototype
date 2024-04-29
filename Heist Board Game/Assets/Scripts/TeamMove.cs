using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeamMove : MonoBehaviour
{

    private Camera cam;
    public GameObject piece;
    private GameObject[] boardTiles;
    private float mousePosX;
    private float mousePosY;
    public TextMeshProUGUI cardText;


    void Start(){
        cam = Camera.main;
        piece = GameObject.FindWithTag("TeamPiece");
        boardTiles = GameObject.FindGameObjectsWithTag("DefaultBoard");
        //randomize order of the tile array
        for (int i = 0; i < boardTiles.Length; i++ ){
            GameObject temp = boardTiles[i];
            int j = Random.Range(i, boardTiles.Length);
            boardTiles[i] = boardTiles[j];
            boardTiles[j] = temp;
        }
        //place tiles in the random order from prev loop
        for (int i = 0; i < boardTiles.Length; i++ ){
            boardTiles[i].transform.position = new Vector3(5.5f+(6f*i),boardTiles[i].transform.position.y,boardTiles[i].transform.position.z);
        }
    }

    void Update(){
        if(Input.GetMouseButtonDown(0) && piece.activeSelf == true) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)){
                if (hit.collider.name == "Team Piece"){
                    piece.SetActive(false);
                }
            }
		}
        else if(Input.GetMouseButtonDown(0) && piece.activeSelf == false){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)){
                Vector3 pt = hit.point;
                piece.SetActive(true);
                piece.transform.position = new Vector3(pt.x, 2, pt.z);
            }
        }
        else{
            StartCoroutine(Wait());
        }

    } 

    IEnumerator Wait(){
        yield return new WaitForSeconds(1);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Entrance")){
            Debug.Log("colliding");
            int cardNum  = Random.Range(1, 9);
		    cardText.text = "Entrance Challenge " + cardNum.ToString();
        }
        else if (other.gameObject.CompareTag("Vault")){
            int cardNum  = Random.Range(1, 9);
		    cardText.text = "Vault Challenge " + cardNum.ToString();
        }
        else if (other.gameObject.CompareTag("DefaultBoard")){
            int cardNum  = Random.Range(1, 16);
            //fetch the name of the material of the game object being collided with, set it to a variable materialName
            //cardText.text = materialName + " Challenge " + cardNum.ToString;
        }
        else{
           StartCoroutine(Wait()); 
        }
    }

}
