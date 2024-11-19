using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    [SerializeField] private AudioSource _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _audio.Play();

        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;

        StartCoroutine(WaitingDie());
    }

    private IEnumerator WaitingDie()
    {
        yield return new WaitForSeconds(_audio.clip.length);

        gameObject.SetActive(false);
    }
}
