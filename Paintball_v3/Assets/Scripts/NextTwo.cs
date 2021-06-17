using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextTwo : MonoBehaviour
{
 public void NextTwoLVL()
    {
        PaintTarget.ClearAllPaint();
        SceneManager.LoadScene(1);
    }
}
