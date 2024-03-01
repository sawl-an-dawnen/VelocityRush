using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialPrompter : MonoBehaviour
{
    public enum PromptID { One, Two, Three }

    public bool move, look, jump, handBreak, dash, gravityShift;
    public PromptID promptID;

    public GameObject[] toActive; //once we've collected all the objs we active this array;
    public GameObject[] toDelete;

    private TextMeshProUGUI prompt;
    private List<int> prompts = new List<int>();
    private Movement moveScript;
    private Jump jumpScript;
    private Break breakScript;
    private Look lookScript;
    private Dash dashScript;
    private GravityShift gravityScript;

    void Start()
    {
        switch (promptID)
        {
            case PromptID.One:
                prompt = GameObject.FindGameObjectWithTag("Prompt01").GetComponent<TextMeshProUGUI>();
                Debug.Log("Prompt connected 01!");
                break;
            case PromptID.Two:
                prompt = GameObject.FindGameObjectWithTag("Prompt02").GetComponent<TextMeshProUGUI>();
                Debug.Log("Prompt connected 02!");
                break;
            case PromptID.Three:
                prompt = GameObject.FindGameObjectWithTag("Prompt03").GetComponent<TextMeshProUGUI>();
                Debug.Log("Prompt connected 03!");
                break;
        }

        

        //ID numbers for the actions:
        //move: 0
        //look: 1
        //jump: 2
        //handbreak: 3
        //dash: 4
        //gravity: 5

        if (move) 
            { 
            prompts.Add(0);
            Debug.Log("Adding 0");
            }
        if (look) 
            { prompts.Add(1); }
        if (jump) 
            { prompts.Add(2); }
        if (handBreak) 
            { prompts.Add(3); }
        if (dash) 
            { prompts.Add(4); }
        if (gravityShift) 
            { prompts.Add(5); }

        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        jumpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
        breakScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Break>();
        lookScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Look>();
        dashScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Dash>();
        gravityScript = GameObject.FindGameObjectWithTag("Player").GetComponent<GravityShift>();
    }


    // Update is called once per frame
    void Update()
    {
        //prompt looks at element 0 to determine what to say
        //once play completes action delete element 0
        //element 1 will become element 0 and prompt will reflect new instructions
        //once list is empty complete prompter script

        if (prompts.Count != 0)
        {
            switch (prompts[0])
            {
                case 0:
                    prompt.text = "Use the left joystick or WASD to move.";
                    if (moveScript.move.magnitude != 0)
                        prompts.RemoveAt(0);
                    break;
                case 1:
                    prompt.text = "Use the right joystick or mouse to look around.";
                    if (lookScript.freeCam.m_XAxis.m_InputAxisValue != 0f || lookScript.freeCam.m_YAxis.m_InputAxisValue != 0f)
                        prompts.RemoveAt(0);
                    break;
                case 2:
                    prompt.text = "Press the A button or Space to jump.";
                    if (jumpScript.pressed)
                        prompts.RemoveAt(0);
                    break;
                case 3:
                    prompt.text = "Press B or right click on the mouse to engage the break.";
                    if (breakScript.pressed)
                        prompts.RemoveAt(0);
                    break;
                case 4:
                    prompt.text = "Pull the right trigger or left click on the mouse to dash.";
                    if (dashScript.pressed)
                        prompts.RemoveAt(0);
                    break;
                case 5:
                    prompt.text = "Press Y or E on the keyboard to invert gravity.";
                    if (gravityScript.pressed)
                        prompts.RemoveAt(0);
                    break;
            }
        }
        else 
        {
            prompt.text = "Complete!";        
        }
    }
}
