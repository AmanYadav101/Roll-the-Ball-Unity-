/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneTrigger : MonoBehaviour
{
    public GameObject respawnPoint;
    AudioManager audioManager;
    public GameManager gameManager;
    public GameObject[] animGameObjects;
    public Animator[] anim;
    public int count = 0;
    private void Awake()
    {

        animGameObjects = GameObject.FindGameObjectsWithTag("Life");
        anim = new Animator[animGameObjects.Length];

        for(int i = 0; i < animGameObjects.Length; i++)
        {
            anim[i] = animGameObjects[i].GetComponent<Animator>();
        }

        gameManager = FindObjectOfType<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    //Triggers use OnTriggerEnter
    private void OnTriggerEnter(Collider collider)

    {
        if (collider.gameObject.name == "Sphere")
        {
            if (count >= 0)
            {
                anim[count].SetTrigger("Lost");
                StartCoroutine(WaitForAnimation(anim[count]));
                count += 1;

            }

*//*            DeleteOrb();
*//*        
            //Plays Sound on Entering the trigger
            audioManager.PlaySFX(audioManager.death);
            
            //Respawning the ball at Respawn point and making it velocity to zero
            var rb = collider.GetComponent<Rigidbody>();
            collider.gameObject.transform.position = respawnPoint.transform.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    private IEnumerator WaitForAnimation(Animator animator)
    {
        

        yield return new WaitForSeconds(1);

        DeleteOrb();
    }
    public void DeleteOrb()
    {
        gameManager.LoseLife();
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneTrigger : MonoBehaviour
{
    public GameObject respawnPoint;
    AudioManager audioManager;
    public GameManager gameManager;
   /* public GameObject[] animGameObjects;
    public Animator[] anim;
    public int count = 0;*/

    private void Awake()
    {
        /*        animGameObjects = GameObject.FindGameObjectsWithTag("Life");
                anim = new Animator[animGameObjects.Length];

                for (int i = 0; i < animGameObjects.Length; i++)
                {
                    anim[i] = animGameObjects[i].GetComponent<Animator>();
                }

        */
        gameManager = FindObjectOfType<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Sphere")
        {
            /*if (count < anim.Length)
            {
                anim[count].SetTrigger("Lost");
                StartCoroutine(WaitForAnimation(anim[count]));
                count += 1;
            }*/
            DeleteOrb();
            audioManager.PlaySFX(audioManager.death);

            var rb = collider.GetComponent<Rigidbody>();
            collider.gameObject.transform.position = respawnPoint.transform.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

   /* private IEnumerator WaitForAnimation(Animator animator)
    {
*//*        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
*//*        yield return new WaitForSeconds(1);

        DeleteOrb();
    }
*/
    public void DeleteOrb()
    {
        gameManager.LoseLife();
    }
}
