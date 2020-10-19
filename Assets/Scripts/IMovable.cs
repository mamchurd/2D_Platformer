using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    bool IsLanded { get; }

    void Jump();

    void Move(Vector2 direction);

    void ChangeRotation(Vector2 direction);

}
