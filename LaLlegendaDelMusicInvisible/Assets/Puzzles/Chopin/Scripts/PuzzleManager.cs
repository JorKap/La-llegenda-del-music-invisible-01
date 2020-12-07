using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public GameObject parentPuzzle;
    public GameObject[] pieces;
    public GameObject sortir;
    public GameObject puzzleParent;
    PuzzlePieces[] puzzlePieces;
    int[] piecesZRotation;
    int totalPieces;
    //public Button playAgainButton;
    //[SerializeField]
    //Text win;

    //Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        // playAgainButton.gameObject.SetActive(false);

      //  scene = SceneManager.GetActiveScene();
        totalPieces = parentPuzzle.transform.childCount;
        piecesZRotation = new int[totalPieces];
        pieces = new GameObject[totalPieces];
        puzzlePieces = new PuzzlePieces[totalPieces];

        //pieces = transform.GetComponentsInChildren<PipeScript>();
        for (int i = 0; i < totalPieces; i++)
        {
            pieces[i] = parentPuzzle.transform.GetChild(i).gameObject;
            pieces[i].GetComponent<Collider2D>().enabled = true;
            piecesZRotation[i] = (int)pieces[i].transform.eulerAngles.z;
            //Debug.Log("pieces: " + pieces[i].name + " " + piecesZRotation[i]);
            puzzlePieces[i] = pieces[i].GetComponent<PuzzlePieces>();
            if (Mathf.Floor(piecesZRotation[i]) == 0)
            {
                puzzlePieces[i].isPlaced = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    int correctRotation = 0;
    public void UpdateIsPlaced()
    {
        correctRotation = 0;
        for (int i = 0; i < totalPieces; i++)
        {
            // Debug.Log("pieces: " + pieces[i].name + " " + pipeScripts[i].isPlaced);
            if (puzzlePieces[i].isPlaced)
            {
                correctRotation += 1;
            }
            Debug.Log(correctRotation);

        }
        if (correctRotation == totalPieces)
        {
           // win.text = "You Win";
            for (int i = 0; i < totalPieces; i++)
            {
                pieces[i].GetComponent<Collider2D>().enabled = false;
            }
            ////  playAgainButton.gameObject.SetActive(true);

            //Debug.Log("You Win");

            StartCoroutine(Acabar());
            GetComponent<EstatCondicioReaccio>().Reacciona();

        }
    }

    IEnumerator Acabar()
    {
        yield return new WaitForSeconds(0.5f);
        puzzleParent.SetActive(false);
        sortir.SetActive(true);
    }
}
