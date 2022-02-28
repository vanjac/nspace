﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tutorials
{
    public static TutorialPageFactory[] INTRO_TUTORIAL = new TutorialPageFactory[]
    {
        () => new SimpleTutorialPage(
            "Welcome! This is a brief tutorial that will guide you through the app. "
            + "You can access this tutorial and others at any time. Press the right arrow to continue."),
        () => new SimpleTutorialPage(
            "Right now you're looking at the interior of a room. Two walls are hidden so you can see inside. "
            + "The player is standing in the center."),
        () => new TutorialIntroNavigation(),
        () => new TutorialIntroSelectFace(),
        () => new TutorialIntroPull(),
        () => new TutorialIntroPush(),
        () => new TutorialIntroColumn(),
        () => new TutorialIntroSelectBox(),
        () => new TutorialIntroSelectWall(),
        () => new SimpleTutorialPage(
            "By selecting faces and pushing/pulling them, you can sculpt the world."),
        () => new FullScreenTutorialPage(
            "These buttons appear at the top of the screen, based on context.",
            "Tutorials/toolbar_buttons", width:1536, height:798),
        () => new SimpleTutorialPage(
            "That's enough to get started! You can access more tutorials by choosing Help in the menu."),
        () => new SimpleTutorialPage(
            "Also check out the video tutorials on YouTube and the subreddit. "
            + "There are links in the main menu.")
    };

    public static TutorialPageFactory[] PAINT_TUTORIAL = new TutorialPageFactory[]
    {
        () => new TutorialPaintStart(),
        () => new TutorialPaintPage(
            "You can use the Paint panel to paint the selected faces with <i>materials</i>."),
        () => new TutorialPaintPage(
            "Choose any of the categories to browse for a texture. Then switch to the Color tab to change its color.",
            highlight: "material type"),
        () => new TutorialPaintPage(
            "A paint is composed of two parts: an opaque base material and a transparent overlay. "
            + "Use the tabs to switch between the two parts.",
            highlight: "paint layer"),
        () => new TutorialPaintPage(
            "Use these buttons to rotate and mirror the paint.",
            highlight: "paint transform"),
        () => new TutorialPaintSky()
    };

    public static TutorialPageFactory[] BEVEL_TUTORIAL = new TutorialPageFactory[]
    {
        () => new TutorialBevelStart(),
        () => new TutorialBevelSelect(),
        () => new TutorialBevelPage(
            "<i>Tap a bevel shape in the list to bevel the edge.</i>",
            highlight: "bevel shape"),
        () => new TutorialBevelPage(
            "<i>Tap a size to change the size of the bevel.</i>",
            highlight: "bevel size"),
        () => new TutorialBevelFillSelect(),
        () => new SimpleTutorialPage(
            "<i>When you're done, tap the check button to exit.</i>",
            highlight: "bevel done")
    };

    public static TutorialPageFactory[] SUBSTANCE_TUTORIAL = new TutorialPageFactory[]
    {
        () => new SimpleTutorialPage(
            "In this tutorial you will build a moving platform using a <i>Substance.</i> "
            + "Substances are independent objects that can move and respond to interaction."),
        () => new SimpleTutorialPage(
            "First build a pit that is too wide and deep to cross by jumping."),
        () => new TutorialSubstanceObjectCreatePanel(
            "Now we'll add a substance which will become a moving platform. "
            + "<i>Select a row of faces on one side of the pit and tap the cube button.</i>"),
        () => new TutorialSubstanceCreate1(),
        () => new TutorialSubstanceCreate2(),
        () => new TutorialSubstancePage(
            "Substances are controlled by their <i>Behaviors</i>. "
            + "This substance has <i>Visible</i> and <i>Solid</i> behaviors which make it visible and solid in the game.",
            highlight: "behaviors"),
        () => new TutorialSubstanceAddBehavior(),
        () => new TutorialSubstanceEditDirection(),
        () => new TutorialSubstanceSetDirection(),
        () => new SimpleTutorialPage(
            "<i>Try playing your game.</i> The platform should move continuously in one direction. "
            + "We need to make it change directions at the ends of the pit."),
        () => new TutorialSubstancePage(
            "Substances have two states, On and Off. Behaviors can be configured to only be active in the On or Off state.",
            highlight: "behavior condition"),
        () => new TutorialSubstanceAddOppositeBehavior(),
        () => new TutorialSubstanceBehaviorConditions(),
        () => new TutorialSubstanceAddSensor(),
        () => new TutorialSubstancePulseTime(),
        () => new SimpleTutorialPage(
            "<i>Play your game now.</i> "
            + "If you built everything correctly, the platform should move across the pit and back repeatedly."),
        () => new SimpleTutorialPage(
            "Next try the <i>Objects</i> tutorial to learn about another type of interactive element.")
    };

    public static TutorialPageFactory[] OBJECT_TUTORIAL = new TutorialPageFactory[]
    {
        () => new TutorialSubstanceObjectCreatePanel(
            "<i>Select a face and tap the cube button.</i>"),
        () => new TutorialObjectCreate(),
        () => new TutorialObjectPage(
            "You have just created a ball Object. "
            + "Like substances, you can give Objects behaviors and sensors to add interactivity."),
        () => new TutorialObjectPaint(),
        () => new TutorialObjectAddBehavior(),
        () => new TutorialObjectFollowPlayer(),
        () => new SimpleTutorialPage(
            "<i>Try playing your game.</i> Next we are going to make the ball hurt you when you touch it."),
        () => new TutorialObjectAddSensor(),
        () => new TutorialObjectTouchPlayer(),
        () => new TutorialObjectAddTargetedBehavior(),
        () => new TutorialObjectPage(
            "By default, Hurt/Heal hurts the object it's attached to (the ball). "
            + "By setting a Target, we made it act upon a different object (the player)."),
        () => new TutorialObjectBehaviorCondition(),
        () => new TutorialObjectHurtRate(),
        () => new SimpleTutorialPage(
            "<i>Play your game, and try to avoid dying!</i> "
            + "You can change the speed of the ball and the hurt amount to adjust the difficulty."),
        () => new TutorialObjectAddPhysicsBehavior(),
        () => new SimpleTutorialPage(
            "Read the <i>Advanced Game Logic</i> tutorial to learn how to add more complex interactivity to games.")
    };

    public const string TIPS_AND_SHORTCUTS_TUTORIAL =
@"•  Double tap to select an entire wall. The selection will be bounded by already-selected faces.
•  Triple tap a face to select <i>all</i> faces connected to it. The selection will be bounded by already-selected faces.
•  Triple tap a substance to select the entire substance.
•  Check the ""X-ray"" box of a substance to make it transparent in the editor only. This lets you see behind it and zoom through it.
•  The paint panel keeps shortcuts for the five most recent paints. To ""copy"" a paint to another face, select the source face, open and close the paint panel, then select the destination faces and use the recent paint shortcut.
•  Sliding faces sideways along a wall moves their paints, leaving a trail behind them.
•  Check the ""Select"" section in the menu for useful shortcuts to select faces and objects.
•  You can select multiple objects/substances to edit all of their properties at once.";

    public static TutorialPageFactory[] ADVANCED_GAME_LOGIC_TUTORIAL_1 = new TutorialPageFactory[]
    {
        () => new SimpleTutorialPage(
            "Here are three floors with an elevator connecting them. "
            + "Your task is to make the elevator move when you press the buttons."),
        () => new SimpleTutorialPage(
            "(This tutorial will not check if you completed each step correctly. Good luck!)"),
        () => new SimpleTutorialPage(
            "We’ll start by making the Up button on the first floor work. <i>Give it a Tap sensor.</i>"),
        () => new SimpleTutorialPage(
            "<i>Now select the elevator, give it a Toggle sensor (Logic tab), and connect the On input to the Up button.</i>"),
        () => new SimpleTutorialPage(
            "<i>Finally, use a Move behavior to make the elevator go up only when its sensor is On.</i>"),
        () => new SimpleTutorialPage(
            "To learn more about these sensors and behaviors, you can tap their icons in the left panel."),
        () => new SimpleTutorialPage(
            "<i>Play your game.</i> The elevator should move up when you press the button. Did it work?"),
        () => new SimpleTutorialPage(
            "The elevator needs to stop when it reaches the next floor. There are multiple ways to do this. "
            + "One way is to make it turn off after 5 seconds..."),
        () => new SimpleTutorialPage(
            "<i>Replace the elevator's sensor with Pulse (Logic tab). "
            + "Change the On time to 5, and connect the input to the Up button.</i>"),
        () => new SimpleTutorialPage(
            "<i>Play your game.</i> The elevator should stop on the second floor. Why does it do this?"),
        () => new SimpleTutorialPage(
            "We have one functioning button, but there are still three more. <i>Give them all Tap sensors.</i> "
            + "We'll make the second Up button work next..."),
        () => new SimpleTutorialPage(
            "The elevator’s Pulse sensor only allows one input, but we have two Up buttons."
            + " We need to merge them into a single input..."),
        () => new SimpleTutorialPage(
            "<i>Find the hidden room near the elevator shaft.</i> "
            + "This room will never be seen in the game, so it's a good place to hide extra logic components."),
        () => new SimpleTutorialPage(
            "<i>In the hidden room, select the Up arrow cube. "
            + "Give it a Threshold sensor, and connect two inputs to both of the Up buttons.</i>"),
        () => new SimpleTutorialPage(
            "<i>Now select the elevator. Change the sensor input to the Up arrow cube in the hidden room.</i>"),
        () => new SimpleTutorialPage(
            "<i>Play your game.</i> Both Up arrows should function correctly. Why does this work?"),
        () => new SimpleTutorialPage(
            "Now the elevator needs to go down. This makes 3 possible states: "
            + "going up, going down, and stopped. But sensors can only be On/Off..."),
        () => new SimpleTutorialPage(
            "To solve this, we use Targeted Behaviors. "
            + "Remember these behaviors use their host object to turn on/off, but act on a Target object."),
        () => new SimpleTutorialPage(
            "<i>First, connect the hidden Down arrow cube to the two Down buttons, just like the Up arrow cube.</i>"),
        () => new SimpleTutorialPage(
            "<i>Next, select the red ball. Give it a Pulse sensor with On time = 5, and connect the input to the Down arrow cube.</i>"),
        () => new SimpleTutorialPage(
            "<i>Now tap Add Behavior. In the behavior menu, tap \"Target\" and select the elevator as the target. "
            + "Then choose the Move behavior.</i>"),
        () => new SimpleTutorialPage(
            "<i>Make the move behavior go Down only when the sensor is On.</i> "
            + "The sensor of the red ball will turn it on/off, but the Elevator will move!"),
        () => new SimpleTutorialPage(
            "<i>Play the game and try the Down buttons.</i> The elevator should go down and stop at each floor. You're done!"),
        () => new SimpleTutorialPage(
            "How could you improve this elevator? Add more floors? Make it go faster? "
            + "Add sliding doors? See what you can come up with!")
    };

    public static TutorialPageFactory[] ADVANCED_GAME_LOGIC_TUTORIAL_2 = new TutorialPageFactory[]
    {
        () => new SimpleTutorialPage(
            "Your task is to build a Pit of Death. Anything that falls in the pit will die."),
        () => new SimpleTutorialPage(
            "<i>Make a large room with a pit in the middle.</i> Make sure the pit isn't directly under the player."),
        () => new SimpleTutorialPage(
            "<i>Add a Trigger substance spanning the bottom of the pit.</i>"),
        () => new SimpleTutorialPage(
            "The trigger should already have a Touch sensor with the filter set to Anything. "
            + "This is good because nothing escapes the Pit of Death."),
        () => new SimpleTutorialPage(
            "<i>Tap Add Behavior. Tap the Target button, then tap \"Activators\". Then choose the Hurt/Heal behavior.</i>"),
        () => new SimpleTutorialPage(
            "This behavior targets its \"Activators\", which are the objects that \"cause\" the sensor to turn on -- "
            + "in this case, any objects that touch the trigger."),
        () => new SimpleTutorialPage(
            "<i>Make the trigger hurt the Activator by -100 points.</i>"),
        () => new SimpleTutorialPage(
            "<i>Play your game. Try jumping in the pit.</i>"),
        () => new SimpleTutorialPage(
            "<i>Now try making some balls with Physics behaviors. "
            + "Then play the game and push them all into the pit.</i> Enjoy."),
    };

    private class TutorialIntroNavigation : TutorialPage
    {
        private Quaternion startRotation;
        private Vector3 startPan;
        private bool rotate, pan;
        private float startTime;

        public override string GetText()
        {
            return "Navigation: Use two fingers to rotate and zoom, and three fingers to pan. "
                + "<i>Try looking around the room.</i> (tutorial will advance when you have completed this)";
        }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            startRotation = touchListener.pivot.rotation;
            startPan = touchListener.pivot.position;
            startTime = Time.time;
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            if (!rotate)
            {
                var currentRotation = touchListener.pivot.rotation;
                if (Quaternion.Angle(currentRotation, startRotation) > 60)
                {
                    Debug.Log("Rotate complete");
                    rotate = true;
                }
            }
            if (!pan)
            {
                var currentPan = touchListener.pivot.position;
                if ((currentPan - startPan).magnitude > 4)
                {
                    Debug.Log("Pan complete");
                    pan = true;
                }
            }
            if (rotate && pan && Time.time - startTime > 4)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialIntroSelectFace : TutorialPage
    {
        public override string GetText()
        {
            return "<i>Tap with one finger to select a single face of a block.</i>";
        }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            if (voxelArray.GetSelectedFaceNormal() != -1)
            {
                voxelArray.ClearSelection();
                voxelArray.ClearStoredSelection();
            }
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            if (voxelArray.GetSelectedFaceNormal() != -1)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialIntroPull : TutorialPage
    {
        private int faceNormal;

        public override string GetText()
        {
            string axisName = AxisNameForFaceNormal(faceNormal);
            return "<i>Pull the " + axisName + " arrow towards the center of the room to pull the block out.</i>";
        }

        public static string AxisNameForFaceNormal(int faceNormal)
        {
            switch (faceNormal)
            {
                case 0:
                case 1:
                    return "Red";
                case 2:
                case 3:
                    return "Green";
                case 4:
                case 5:
                    return "Blue";
                default:
                    return "";
            }
        }

        public static bool AxisMatchesFace(TransformAxis transformAxis, int faceNormal)
        {
            var moveAxis = transformAxis as MoveAxis;
            if (moveAxis == null)
                return false;
            if (faceNormal == -1)
                return false;
            return moveAxis.forwardDirection == Voxel.DirectionForFaceI(
                (faceNormal / 2) * 2 + 1);
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            faceNormal = voxelArray.GetSelectedFaceNormal();
            if (faceNormal == -1)
                return TutorialAction.BACK;
            if (touchListener.currentTouchOperation == TouchListener.TouchOperation.MOVE
                && AxisMatchesFace(touchListener.movingAxis, faceNormal))
            {
                int moveCount = ((MoveAxis)touchListener.movingAxis).moveCount;
                if (faceNormal % 2 == 0)
                {
                    if (moveCount <= -1)
                        return TutorialAction.NEXT;
                }
                else
                {
                    if (moveCount >= 1)
                        return TutorialAction.NEXT;
                }
            }
            return TutorialAction.NONE;
        }
    }


    private class TutorialIntroPush : TutorialPage
    {
        private Bounds startSelectedFace;
        private int faceNormal;

        public override string GetText()
        {
            string message = "<i>Now select a different face and push it away from the center of the room.</i>";
            if (faceNormal != -1)
                message += " <i>(hint: use the " + TutorialIntroPull.AxisNameForFaceNormal(faceNormal)
                    + " arrow)</i>";
            return message;
        }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            startSelectedFace = voxelArray.boxSelectStartBounds;
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (startSelectedFace == voxelArray.boxSelectStartBounds)
                faceNormal = -1; // same face selected as before
            else
                faceNormal = voxelArray.GetSelectedFaceNormal();
            if (touchListener.currentTouchOperation == TouchListener.TouchOperation.MOVE
                && TutorialIntroPull.AxisMatchesFace(touchListener.movingAxis, faceNormal))
            {
                int moveCount = ((MoveAxis)touchListener.movingAxis).moveCount;
                if (faceNormal % 2 == 0)
                {
                    if (moveCount >= 1)
                        return TutorialAction.NEXT;
                }
                else
                {
                    if (moveCount <= -1)
                        return TutorialAction.NEXT;
                }
            }
            return TutorialAction.NONE;
        }
    }


    private class TutorialIntroColumn : TutorialPage
    {
        private int lastFaceNormal = -1;

        public override string GetText()
        {
            return "<i>Now select a different face and pull it towards the center of the room. "
                + "Keep pulling until you reach the other side.</i>";
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            int faceNormal = voxelArray.GetSelectedFaceNormal();
            if (faceNormal != -1)
                lastFaceNormal = faceNormal;
            if (touchListener.currentTouchOperation == TouchListener.TouchOperation.MOVE
                && TutorialIntroPull.AxisMatchesFace(touchListener.movingAxis, lastFaceNormal)
                && !voxelArray.SomethingIsSelected())
                // just made a column
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialIntroSelectBox : TutorialPage
    {
        private bool boxWasSelected;
        private int numBoxes;
        private Bounds lastStartBounds;

        public override string GetText()
        {
            return "Tap and drag to select a group of faces in a rectangle or box. <i>Try this a few times.</i>";
        }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            voxelArray.ClearSelection();
            voxelArray.ClearStoredSelection();
        }

        private bool BoxIsSelected(VoxelArrayEditor voxelArray)
        {
            return voxelArray.selectMode == VoxelArrayEditor.SelectMode.BOX
                && voxelArray.selectionBounds.size.sqrMagnitude > 3;
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (!boxWasSelected)
            {
                if (BoxIsSelected(voxelArray))
                {
                    Debug.Log("Selected box");
                    boxWasSelected = true;
                    numBoxes++;
                    lastStartBounds = voxelArray.boxSelectStartBounds;
                }
            }
            else
            {
                if (!voxelArray.SomethingIsSelected())
                {
                    Debug.Log("Deselected box");
                    boxWasSelected = false;
                }
                else if (voxelArray.boxSelectStartBounds != lastStartBounds)
                {
                    Debug.Log("Deselected box");
                    boxWasSelected = false;
                }
            }

            if (numBoxes >= 3)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialIntroSelectWall : TutorialPage
    {
        public override string GetText()
        {
            return "<i>Double tap to select an entire wall.</i>";
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (voxelArray.selectMode == VoxelArrayEditor.SelectMode.FACE_FLOOD_FILL)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialPaintStart : TutorialPage
    {
        public override string GetText()
        {
            return "<i>Select some faces and tap the paint roller icon to open the Paint panel.</i>";
        }

        public override string GetHighlightID()
        {
            return "paint";
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (guiGameObject.GetComponent<PaintGUI>() != null)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialPaintPage : SimpleTutorialPage
    {
        private bool panelOpen;

        public TutorialPaintPage(string text, string highlight = "")
            : base(text, highlight) { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            panelOpen = guiGameObject.GetComponent<PaintGUI>() != null;
            return TutorialAction.NONE;
        }

        public override string GetText()
        {
            if (!panelOpen)
                return "<i>Reopen the paint panel. (Select some faces and tap the paint roller icon)</i>";
            else
                return base.GetText();
        }

        public override string GetHighlightID()
        {
            if (!panelOpen)
                return "paint";
            else
                return base.GetHighlightID();
        }

        public override bool ShowNextButton()
        {
            return panelOpen;
        }
    }


    private class TutorialPaintSky : TutorialPaintPage
    {
        public TutorialPaintSky()
            : base("The \"Sky\" material is special: in the game it is an unobstructed window to the sky. "
                + "In an Indoor-type world, this is the only way to see the sky.")
        { }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            PaintGUI paintPanel = guiGameObject.GetComponent<PaintGUI>();
            paintPanel.TutorialShowSky();
        }
    }


    private class TutorialBevelStart : TutorialPage
    {
        public override string GetText()
        {
            return "<i>Tap the menu button then choose \"Bevel\" to open Bevel Mode.</i>";
        }

        public override string GetHighlightID()
        {
            return "bevel";
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (guiGameObject.GetComponent<BevelGUI>() != null)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialBevelPage : SimpleTutorialPage
    {
        private bool panelOpen;

        public TutorialBevelPage(string text, string highlight = "")
            : base(text, highlight) { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            panelOpen = guiGameObject.GetComponent<BevelGUI>() != null;
            return TutorialAction.NONE;
        }

        public override string GetText()
        {
            if (!panelOpen)
                return "<i>Reopen Bevel Mode. (Tap the menu button and choose \"Bevel\")</i>";
            else
                return base.GetText();
        }

        public override string GetHighlightID()
        {
            if (!panelOpen)
                return "bevel";
            else
                return base.GetHighlightID();
        }

        public override bool ShowNextButton()
        {
            return panelOpen;
        }
    }


    private class TutorialBevelSelect : TutorialBevelPage
    {
        public TutorialBevelSelect()
            : base("Instead of selecting faces, you can now select edges. <i>Tap and drag to select.</i>") { }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            if (voxelArray.selectMode == VoxelArrayEditor.SelectMode.BOX_EDGES)
            {
                voxelArray.ClearSelection();
                voxelArray.ClearStoredSelection();
            }
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);
            if (voxelArray.selectMode == VoxelArrayEditor.SelectMode.BOX_EDGES)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialBevelFillSelect : TutorialBevelPage
    {
        public TutorialBevelFillSelect()
            : base("<i>Double tap an edge to select all contiguous edges.</i>") { }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            if (voxelArray.selectMode == VoxelArrayEditor.SelectMode.EDGE_FLOOD_FILL)
            {
                voxelArray.ClearSelection();
                voxelArray.ClearStoredSelection();
            }
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject,
            TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);
            if (voxelArray.selectMode == VoxelArrayEditor.SelectMode.EDGE_FLOOD_FILL)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialSubstanceObjectCreatePanel : TutorialPage
    {
        private string text;

        public TutorialSubstanceObjectCreatePanel(string text)
        {
            this.text = text;
        }

        public override string GetText()
        {
            return text;
        }

        public override string GetHighlightID()
        {
            return "create object";
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (guiGameObject.GetComponent<TypePickerGUI>() != null)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialSubstanceCreate1 : TutorialPage
    {
        public override string GetText()
        {
            return "<i>Choose \"Solid Substance\".</i>";
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (guiGameObject.GetComponent<CreateSubstanceGUI>() != null)
                return TutorialAction.NEXT;
            else if (guiGameObject.GetComponent<TypePickerGUI>() == null)
                return TutorialAction.BACK;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialSubstanceCreate2 : TutorialPage
    {
        public override string GetText()
        {
            return "<i>Pull outwards to build a platform.</i>";
        }

        public static bool SubstanceSelected(VoxelArrayEditor voxelArray)
        {
            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is Substance)
                    return true;
            return false;
        }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (SubstanceSelected(voxelArray))
            {
                voxelArray.ClearSelection();
                voxelArray.ClearStoredSelection();
            }
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (SubstanceSelected(voxelArray))
                return TutorialAction.NEXT;
            else if (guiGameObject.GetComponent<CreateSubstanceGUI>() == null)
                return TutorialAction.BACK;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialSubstancePage : SimpleTutorialPage
    {
        private bool substanceSelected;

        public TutorialSubstancePage(string text, string highlight = "")
            : base(text, highlight) { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            substanceSelected = TutorialSubstanceCreate2.SubstanceSelected(voxelArray)
                || guiGameObject.GetComponent<EntityPickerGUI>() != null;
            return TutorialAction.NONE;
        }

        public override string GetText()
        {
            if (!substanceSelected)
                return "<i>Tap the substance to select it again.</i>";
            else
                return base.GetText();
        }

        public override bool ShowNextButton()
        {
            return substanceSelected;
        }
    }


    private class TutorialSubstanceAddBehavior : TutorialSubstancePage
    {
        public TutorialSubstanceAddBehavior()
            : base("<i>Try adding a Move behavior to the platform.</i> Notice that behaviors are organized into multiple categories.",
            highlight: "add behavior")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is Substance)
                    foreach (EntityBehavior behavior in e.behaviors)
                        if (behavior is MoveBehavior)
                            return TutorialAction.NEXT;
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialSubstanceEditDirection : TutorialSubstancePage
    {
        public TutorialSubstanceEditDirection()
            : base("The Move behavior will make this substance move North at a constant speed. "
            + "<i>Tap the direction to edit it.</i>")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            if (guiGameObject.GetComponent<TargetGUI>() != null)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialSubstanceSetDirection : TutorialSubstancePage
    {
        private bool panelWasOpen;

        public TutorialSubstanceSetDirection()
            : base("<i>Make it move toward the other side of the pit (look at the compass rose for guidance)</i>") { }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Start(voxelArray, guiGameObject, touchListener);
            panelWasOpen = guiGameObject.GetComponent<TargetGUI>() != null;
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            if (!panelWasOpen)
                return TutorialAction.BACK;
            else if (guiGameObject.GetComponent<TargetGUI>() != null)
                return TutorialAction.NONE;
            else
                return TutorialAction.NEXT;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialSubstanceAddOppositeBehavior : TutorialSubstancePage
    {
        public TutorialSubstanceAddOppositeBehavior()
            : base("<i>Add a second Move behavior, which moves the platform in the opposite direction.</i>") { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            // check if there are two move behaviors going the opposite direction
            foreach (Entity e in voxelArray.GetSelectedEntities())
            {
                if (e is Substance)
                {
                    int direction = -1;

                    foreach (EntityBehavior behavior in e.behaviors)
                    {
                        if (behavior is MoveBehavior)
                        {
                            if (direction == -1)
                            {
                                direction = GetMoveBehaviorDirection(behavior);
                                if (direction == -1)
                                    return TutorialAction.NONE;
                            }
                            else
                            {
                                var behaviorDirection = GetMoveBehaviorDirection(behavior);
                                if (behaviorDirection == Voxel.OppositeFaceI(direction))
                                    return TutorialAction.NEXT;
                                else
                                    return TutorialAction.NONE;
                            }
                        }
                    }
                }
            }
            return TutorialAction.NONE;
        }

        private sbyte GetMoveBehaviorDirection(EntityBehavior behavior)
        {
            object value = PropertiesObjectType.GetProperty(behavior, "dir");
            if (value == null)
                return -1;
            else
                return ((Target)value).direction;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialSubstanceBehaviorConditions : TutorialSubstancePage
    {
        public TutorialSubstanceBehaviorConditions()
            : base("<i>Now make one behavior active only in the Off state, and one in the On state.</i> (the substance will start Off).",
            highlight: "behavior condition")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            bool foundOff = false, foundOn = false;

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is Substance)
                    foreach (EntityBehavior behavior in e.behaviors)
                        if (behavior is MoveBehavior)
                        {
                            if (behavior.condition == EntityBehavior.Condition.OFF)
                                foundOff = true;
                            if (behavior.condition == EntityBehavior.Condition.ON)
                                foundOn = true;
                        }
            return foundOff && foundOn ? TutorialAction.NEXT : TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialSubstanceAddSensor : TutorialSubstancePage
    {
        public TutorialSubstanceAddSensor()
            : base("A substance's On/Off state is controlled by a Sensor. "
            + "<i>Give the platform a Pulse sensor. (under the Logic tab)</i> This will make it cycle on/off repeatedly.",
            highlight: "change sensor")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is Substance && e.sensor is PulseSensor)
                    return TutorialAction.NEXT;
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialSubstancePulseTime : TutorialSubstancePage
    {
        public TutorialSubstancePulseTime()
            : base("<i>Now adjust the time the sensor spends in the on and off state "
            + "to make the platform move the full distance of the pit.</i>")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            bool onTimeSet = false, offTimeSet = false;
            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is Substance && e.sensor is PulseSensor)
                {
                    float offTime = (float)(PropertiesObjectType.GetProperty(e.sensor, "oft"));
                    if (offTime > 1)
                        offTimeSet = true;
                    float onTime = (float)(PropertiesObjectType.GetProperty(e.sensor, "ont"));
                    if (onTime > 1)
                        onTimeSet = true;
                }
            return onTimeSet && offTimeSet ? TutorialAction.NEXT : TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectCreate : TutorialPage
    {
        public override string GetText()
        {
            return "<i>Choose the Object tab, then choose Ball.</i>";
        }

        public static bool ObjectSelected(VoxelArrayEditor voxelArray)
        {
            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject)
                    return true;
            return false;
        }

        public override void Start(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (ObjectSelected(voxelArray))
            {
                voxelArray.ClearSelection();
                voxelArray.ClearStoredSelection();
            }
        }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            if (ObjectSelected(voxelArray))
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }
    }


    private class TutorialObjectPage : SimpleTutorialPage
    {
        private bool objectSelected;

        public TutorialObjectPage(string text, string highlight = "")
            : base(text, highlight) { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            objectSelected = TutorialObjectCreate.ObjectSelected(voxelArray)
                || guiGameObject.GetComponent<EntityPickerGUI>() != null;
            return TutorialAction.NONE;
        }

        public override string GetText()
        {
            if (!objectSelected)
                return "<i>Tap the ball to select it again.</i>";
            else
                return base.GetText();
        }

        public override bool ShowNextButton()
        {
            return objectSelected;
        }
    }


    private class TutorialObjectPaint : TutorialObjectPage
    {
        private Material prevMat = null;

        public TutorialObjectPaint()
            : base("<i>Try painting the ball.</i>", highlight: "paint") { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject)
                {
                    Material mat = ((BallObject)e).paint.baseMat;
                    if (prevMat == null)
                        prevMat = mat;
                    else if (prevMat != mat)
                        return TutorialAction.NEXT;
                }
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectAddBehavior : TutorialObjectPage
    {
        public TutorialObjectAddBehavior()
            : base("<i>Add a Move behavior to the ball.</i>",
            highlight: "add behavior")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject)
                    foreach (EntityBehavior behavior in e.behaviors)
                        if (behavior is MoveBehavior)
                            return TutorialAction.NEXT;
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectFollowPlayer : TutorialObjectPage
    {
        public TutorialObjectFollowPlayer()
            : base("<i>Edit the Move behavior to make the ball follow the player.</i>") { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject)
                    foreach (EntityBehavior behavior in e.behaviors)
                        if (behavior is MoveBehavior)
                        {
                            Target moveTarget = (Target)PropertiesObjectType.GetProperty(behavior, "dir");
                            if (moveTarget.entityRef.entity is PlayerObject)
                                return TutorialAction.NEXT;
                        }
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectAddSensor : TutorialObjectPage
    {
        public TutorialObjectAddSensor()
            : base("<i>Give the ball a Touch sensor.</i>",
            highlight: "change sensor")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject && e.sensor is TouchSensor)
                    return TutorialAction.NEXT;
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectTouchPlayer : TutorialObjectPage
    {
        public TutorialObjectTouchPlayer()
            : base("<i>Now configure the touch sensor so it only turns on when touching the player.</i>") { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject && e.sensor is TouchSensor)
                {
                    ActivatedSensor.Filter touchFilter =
                        (ActivatedSensor.Filter)PropertiesObjectType.GetProperty(e.sensor, "fil");
                    if (touchFilter is ActivatedSensor.EntityFilter
                            && ((ActivatedSensor.EntityFilter)touchFilter).entityRef.entity is PlayerObject)
                        return TutorialAction.NEXT;
                }
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectAddTargetedBehavior : TutorialObjectPage
    {
        public TutorialObjectAddTargetedBehavior()
            : base("<i>Tap Add Behavior. "
            + "In the behavior menu, tap the \"Target\" button and select the player as the target. "
            + "Then choose Hurt/Heal under the \"Life\" tab.</i>",
            highlight: "behavior target")
        { }

        private bool incorrectTarget = false;

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            bool hasHurtBehavior = false;
            incorrectTarget = false;
            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject)
                    foreach (EntityBehavior behavior in e.behaviors)
                        if (behavior is HurtHealBehavior)
                        {
                            hasHurtBehavior = true;
                            if (!(behavior.targetEntity.entity is PlayerObject))
                                incorrectTarget = true;
                        }
            if (hasHurtBehavior && !incorrectTarget)
                return TutorialAction.NEXT;
            else
                return TutorialAction.NONE;
        }

        public override string GetText()
        {
            if (incorrectTarget)
                return "You didn't set the target to the player. Remove the behavior and try again.";
            else
                return base.GetText();
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectBehaviorCondition : TutorialObjectPage
    {
        public TutorialObjectBehaviorCondition()
            : base("<i>Set Hurt/Heal to activate when the Sensor is On.</i> "
            + "Even though it targets the Player, it will use the Ball's sensor to turn on/off.")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject)
                    foreach (EntityBehavior behavior in e.behaviors)
                        if (behavior is HurtHealBehavior && behavior.condition == EntityBehavior.Condition.ON)
                            return TutorialAction.NEXT;
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectHurtRate : TutorialObjectPage
    {
        public TutorialObjectHurtRate()
            : base("<i>Set the Hurt/Heal rate to 1 to hurt repeatedly (every 1 second) as long as you're touching the ball.</i>") { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject)
                    foreach (EntityBehavior behavior in e.behaviors)
                        if (behavior is HurtHealBehavior)
                        {
                            float rate = (float)PropertiesObjectType.GetProperty(behavior, "rat");
                            if (rate != 0)
                                return TutorialAction.NEXT;
                        }
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }


    private class TutorialObjectAddPhysicsBehavior : TutorialObjectPage
    {
        public TutorialObjectAddPhysicsBehavior()
            : base("If you build some obstacles, you'll notice that the ball can float and move through walls. "
            + "<i>Add a Character behavior to fix this. (check the Physics tab)</i>")
        { }

        public override TutorialAction Update(VoxelArrayEditor voxelArray, GameObject guiGameObject, TouchListener touchListener)
        {
            base.Update(voxelArray, guiGameObject, touchListener);

            foreach (Entity e in voxelArray.GetSelectedEntities())
                if (e is BallObject)
                    foreach (EntityBehavior behavior in e.behaviors)
                        if (behavior is CharacterBehavior)
                            return TutorialAction.NEXT;
            return TutorialAction.NONE;
        }

        public override bool ShowNextButton()
        {
            return false;
        }
    }
}