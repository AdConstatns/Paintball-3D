using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextOne : MonoBehaviour
{
 public void NextTwoLVL()
    {
        PaintTarget.ClearAllPaint();
        SceneManager.LoadScene(0);
    }
}
