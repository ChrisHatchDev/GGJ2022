using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alien : MonoBehaviour
{
    public Tumor[] Tumors;
    public int Health = 3; // 0 equals dead, 1 - 3 is alive

    public bool DebugHealedFlag;

    public UnityEvent OnHealed = new UnityEvent();
    public UnityEvent OnDied = new UnityEvent();
    public AudioSource _source;
    public AudioClip pain;
    public AudioClip joy;

    #if UNITY_EDITOR
    private void OnValidate()
    {
        this.Tumors = GetComponentsInChildren<Tumor>();
    }
    #endif

    private void Start()
    {
        StartCoroutine(SlowUpdate());
        GameManager.Instance.score.addAlienTreated(this);
    }

    IEnumerator SlowUpdate()
    {
        yield return new WaitForSeconds(1.0f);
        
        bool allTumorsAreHealed = true;

        foreach (Tumor item in Tumors)
        {
            if (item.Healed == false)
            {
                allTumorsAreHealed = false;
            }
        }

        if (allTumorsAreHealed)
        {
            if (OnHealed != null)
            {
                DebugHealedFlag = true;
                GameManager.Instance.EndGame();
                OnHealed.Invoke();
            }
            yield break;
        } else {
            StartCoroutine(SlowUpdate());
        }
    }

    public void DecrementHealth()
    {
        if (this.Health <= 0) return;
        this.Health--;

        if (this.Health == 0 && this.OnDied != null)
        {
            GameManager.Instance.EndGame();
            this.OnDied.Invoke();
        }
    }

    public void PainSound(){
        _source.PlayOneShot(pain, 1.0f);
    }

    public void JoySound(){
        _source.PlayOneShot(joy, 1.0f);
    }

}
