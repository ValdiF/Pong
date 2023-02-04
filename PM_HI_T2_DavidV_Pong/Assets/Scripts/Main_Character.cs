using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_Character : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float transitionTime = 1f;
    private float yBound = 115.767f;
    public Animator transitionAnimator;

    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float movement;

        
            movement = Input.GetAxisRaw("Vertical");
        
            movement = Input.GetAxisRaw("Vertical2");
        


        Vector2 paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(paddlePosition.x + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Limit1"))
        {
            LoadNextScene();
        }
        

    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
