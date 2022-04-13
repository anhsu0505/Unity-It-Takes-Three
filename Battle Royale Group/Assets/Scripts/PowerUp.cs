using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType { None, AddTime, AddLife, AddScore, Invincibility };
public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
}
