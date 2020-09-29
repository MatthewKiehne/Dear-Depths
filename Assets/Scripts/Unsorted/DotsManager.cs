using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsManager : MonoBehaviour {

    [SerializeField]
    private GameObject visionSpherePrefab;
    [SerializeField]
    private Material interactableMaterial;
    [SerializeField]
    private GameObject combinedPrefab;

    private MeshFilter meshFilter;

    private Transform combinedLocation;
    private Transform individualLocation;

    private int combineCounter = 0;
    private int combineSize = 1000;

    private int maxDots = 100000;
    private int dotCounter = 0;
    private GameObject[] dots = new GameObject[1000];

    public void Start() {
        this.meshFilter = this.GetComponent<MeshFilter>();
        this.combinedLocation = this.transform.Find("Combined");
        this.individualLocation = this.transform.Find("Individual");
    }

    public void makeDot(Vector3 position, string hitTag) {
        //makes a dot

        GameObject sphere = GameObject.Instantiate(this.visionSpherePrefab);
        sphere.transform.name = dotCounter+ "";
        sphere.transform.position = position;
        dots[dotCounter % combineSize] = sphere;
        dotCounter++;

        if (hitTag.Equals("Interactable")) {
            sphere.GetComponent<Renderer>().material = this.interactableMaterial;
        }

        sphere.transform.SetParent(this.individualLocation, true);

        if(dotCounter % this.combineSize == 0) {
            this.combine();
            combineCounter += 1;
        }
    }

    public bool canMakeDots() {
        //add more dots?

        return dotCounter < this.maxDots;
    }


    public void combine() {
        //combines the messes into one

        GameObject combined = Instantiate(this.combinedPrefab);
        combined.transform.name = this.combineCounter + "";
        MeshFilter combinedMeshFilter = combined.GetComponent<MeshFilter>();
        
        //MeshFilter[] meshFilters = this.individualLocation.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[this.combineSize];

        int i = 0;
        while (i < this.combineSize) {
            MeshFilter currentMesh = this.dots[i].GetComponent<MeshFilter>();
            combine[i].mesh = currentMesh.sharedMesh;
            combine[i].transform = currentMesh.transform.localToWorldMatrix;

            i++;
        }

        this.deleteDots();

        combinedMeshFilter.mesh = new Mesh();
        combinedMeshFilter.mesh.CombineMeshes(combine);
        combined.SetActive(true);

        combined.transform.SetParent(this.combinedLocation, false);
    }

    private void deleteDots() {
        //delete dots

        foreach(GameObject dot in dots) {
            GameObject.Destroy(dot);
        }
    }

    public void clearVision() {
        //clears all the dots

        this.combineCounter = 0;
        this.dotCounter = 0;

        this.deleteDots();
        dots = new GameObject[this.dots.Length];
        
        //clear combined
        foreach(Transform combined in this.combinedLocation) {
            MeshFilter filter = combined.GetComponent<MeshFilter>();
            filter.mesh.Clear(true);
            filter.mesh = null;
            GameObject.Destroy(combined.gameObject);
        }
    }

    public int DotCounter {
        get {
            return this.dotCounter;
        }
    }

    public int MaxDots {
        get {
            return this.maxDots;
        }
    }


}
