using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialPrompter : MonoBehaviour
{
    public enum PromptID { One, Two, Three }
    public enum Action { Move, Look, Jump, HandBreak, Dash, GravityShift }

    public bool move, look, jump, handBreak, dash, gravityShift;
    public PromptID promptID;

    public GameObject[] toActive; //once we've collected all the objs we active this array;
    public GameObject[] toDelete;

    private TextMeshProUGUI prompt;
    private List<Action> prompts;
    private Movement moveScript;

    void Start()
    {
        switch (promptID)
        {
            case PromptID.One:
                prompt = GameObject.FindGameObjectWithTag("Prompt01").GetComponent<TextMeshProUGUI>();
                break;
            case PromptID.Two:
                prompt = GameObject.FindGameObjectWithTag("Prompt02").GetComponent<TextMeshProUGUI>();
                break;
            case PromptID.Three:
                prompt = GameObject.FindGameObjectWithTag("Prompt03").GetComponent<TextMeshProUGUI>();
                break;

        }

        if (move) { prompts.Add(Action.Move); }
        if (look) { prompts.Add(Action.Look); }
        if (jump) { prompts.Add(Action.Jump); }
        if (handBreak) { prompts.Add(Action.HandBreak); }
        if (dash) { prompts.Add(Action.Dash); }
        if (gravityShift) { prompts.Add(Action.GravityShift); }

        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }


    // Update is called once per frame
    void Update()
    {
        //prompt looks at element 0 to determine what to say
        //once play completes action delete element 0
        //element 1 will become element 0 and prompt will reflect new instructions
        //once list is empty complete prompter script

        if (prompts.Count != 0) {
            switch (prompts[0]) {
                case Action.Move:
                    prompt.text = "Use the left joystick or WASD to move.";
                    if (moveScript.move.magnitude != 0)
                        prompts.RemoveAt(0);
                    break;
                case Action.Look:
                    prompt.text = "Use the right joystick or mouse to look around.";
                    if (playerlooks)
                        prompts.RemoveAt(0);
                    break;
                case Action.Jump:
                    prompt.text = "Press the A button or Space to jump.";
                    if (playermoves)
                        prompts.RemoveAt(0);
                    break;
                case Action.HandBreak:
                    prompt.text = "Press B or right click on the mouse to engage the break.";
                    if (playermoves)
                        prompts.RemoveAt(0);
                    break;
                case Action.Dash:
                    prompt.text = "Pull the right trigger or left click on the mouse to dash.";
                    if (playermoves)
                        prompts.RemoveAt(0);
                    break;
                case Action.GravityShift:
                    prompt.text = "Press Y or E on the keyboard to invert gravity.";
                    if (playermoves)
                        prompts.RemoveAt(0);
                    break;
            }
        }
    }
}
