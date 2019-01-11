using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    // Declaring variables.
    public string name;


    // Creates the amount of lines allowed per string
    // in an array of sentences.
    [TextArea(3, 10)]
    public string[] sentences;

}
