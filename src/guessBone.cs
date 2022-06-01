using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class guessBone : MonoBehaviour
{
    public InputField input;
    public Transform skeleB;
    public GameObject bone;
    public GameObject tBone;
    public Transform randB;
    public GameObject skeleton;
    public int num;

    public Canvas Main;
    public Canvas GameOver;

    //private ArrayList node_list = new ArrayList(); Future Update

    // materials
    public Material farthest;
    public Material farther;
    public Material far;
    public Material close;
    public Material closer;
    public Material closest;

    void Start()
    {
        num = Random.Range(0, skeleton.transform.childCount);
        /*
        Future Update
        GraphNode head = new GraphNode("skull");
        node_list.Add(head);

        GraphNode spine = new GraphNode("spine");
        head.AddConnection(spine);
        node_list.Add(spine);

        GraphNode ribs = new GraphNode("ribs");
        spine.AddConnection(ribs);
        node_list.Add(ribs);

        GraphNode clavicle = new GraphNode("clavicle");
        ribs.AddConnection(clavicle);
        node_list.Add(clavicle);

        GraphNode scapula = new GraphNode("scapula");
        ribs.AddConnection(scapula);
        clavicle.AddConnection(scapula);
        node_list.Add(scapula);

        GraphNode rHumerus = new GraphNode("right humerus");
        scapula.AddConnection(rHumerus);
        node_list.Add(rHumerus);

        GraphNode rForearm = new GraphNode("right forearm");
        rHumerus.AddConnection(rForearm);
        node_list.Add(rForearm);

        GraphNode rHand = new GraphNode("right hand");
        rForearm.AddConnection(rHand);
        node_list.Add(rHand);

        GraphNode lHumerus = new GraphNode("left humerus");
        scapula.AddConnection(lHumerus);
        node_list.Add(lHumerus);

        GraphNode lForearm = new GraphNode("left forearm");
        lHumerus.AddConnection(lForearm);
        node_list.Add(lForearm);

        GraphNode lHand = new GraphNode("left hand");
        lForearm.AddConnection(lHand);
        node_list.Add(lHand);

        GraphNode pelvis = new GraphNode("pelvis");
        spine.AddConnection(pelvis);
        node_list.Add(pelvis);

        GraphNode rFemur = new GraphNode("right femur");
        pelvis.AddConnection(rFemur);
        node_list.Add(rFemur);

        GraphNode rCalf = new GraphNode("right calf");
        rFemur.AddConnection(rCalf);
        node_list.Add(rCalf);

        GraphNode rFoot = new GraphNode("right foot");
        rCalf.AddConnection(rFoot);
        node_list.Add(rFoot);

        GraphNode lFemur = new GraphNode("left femur");
        pelvis.AddConnection(lFemur);
        node_list.Add(lFemur);

        GraphNode lCalf = new GraphNode("left calf");
        lFemur.AddConnection(lCalf);
        node_list.Add(lCalf);

        GraphNode lFoot = new GraphNode("left foot");
        lCalf.AddConnection(lFoot);
        node_list.Add(lFoot);
        */
    }

    public void activate()
    {
        //Debug.Log(input.text);
        /*
        Future Update
        GraphNode target = null;


        foreach (GraphNode node in node_list)
        {
            Debug.Log(node.Name);
            foreach (GraphNode child in node.Children)
            {
                Debug.Log("  -child- " + child.Name);
            }
            if (node.Name == input.text)
            {
                target = node;
                break;
            }
        }
       
        if (target != null)
        {
            Debug.Log("FOUND THE TARGET: " + target.Name);
        }
        
        return;
        */
        bone = GameObject.Find(input.text);
        randB = skeleton.transform.GetChild(num);
        tBone = GameObject.Find(randB.name);
        skeleB = skeleton.transform.Find(input.text);
        if (bone) {
            Debug.Log(bone);
            Debug.Log(tBone);
            Debug.Log(skeleton.transform.childCount);
            if (bone == tBone)
            {
                num = Random.Range(0, skeleton.transform.childCount);
                Main.enabled = false;
                GameOver.gameObject.SetActive(true);
            }
            else 
            {
                //Vector3 difference = new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
                //float distance = Math.Sqrt(Math.Pow(difference.x, 2f) + Math.Pow(difference.y, 2f) + Math.Pow(difference.z, 2f));
                float distance = Vector3.Distance(bone.transform.position, tBone.transform.position);
                Debug.Log(bone.transform.position);
                Debug.Log(distance);
                if (distance <= 4) {
                    skeleB.GetComponent<MeshRenderer>().material = closest;
                } else if (distance > 4 && distance <= 6) {
                    skeleB.GetComponent<MeshRenderer>().material = closer;
                } else if (distance > 6 && distance <= 9) {
                    skeleB.GetComponent<MeshRenderer>().material = close;
                } else if (distance > 9 && distance <= 12) {
                    skeleB.GetComponent<MeshRenderer>().material = far;
                } else if (distance > 12 && distance <= 15) {
                    skeleB.GetComponent<MeshRenderer>().material = farther;
                } else if (distance > 15) {
                    skeleB.GetComponent<MeshRenderer>().material = farthest;
                }
            }
        } else {
            Debug.Log("Not a valid bone");
        }
    }
}
