using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class MLPlayer : Agent //MonoBehaviour
{
    public Transform reset = null;
    public TMP_Text score = null;
    private Rigidbody rb = null;
    private float points = 0;
    private bool _canJump = true;
    
    public override void Initialize()
    {
        rb = this.GetComponent<Rigidbody>();
        
        ResetMyAgent();
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float force = actions.ContinuousActions[0];
        if (_canJump && force >0.1f)
        {
            UpForce(force);
            //_canJump = false;
            //thrust.SetActive(true);
        }
        else
        {
            //thrust.SetActive(false);
        }            
    }
    public override void OnEpisodeBegin()
    {
        ResetMyAgent();
    }
    
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        /*
        actionsOut.ContinuousActions[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow) == true)
            actionsOut.ContinuousActions[0] = 1;
            */
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle") == true)
        {
            AddReward(-1.0f);          
            if(collision.gameObject.GetComponent<Obstacle>() != null) Destroy(collision.gameObject);
            EndEpisode();
        }

        if (collision.gameObject.CompareTag("Ground") == true)
        {
            _canJump = true;
            
        }

    }
    public void AddPoint()
    {

            AddReward(0.1f);
            points++;
            score.text = points.ToString();
           
    }
    private void UpForce(float force)
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
    private void ResetMyAgent()
    {
        points = 0;
        score.text = points.ToString();
        this.transform.position = new Vector3(reset.position.x, reset.position.y, reset.position.z);
    }
}