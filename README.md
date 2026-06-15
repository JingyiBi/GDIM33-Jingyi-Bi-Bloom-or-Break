
# GDIM33 Vertical Slice
## Milestone 1 Devlog
This visual script handles the logic for players acquiring power-ups. When a game object tagged with 'Player' enters the 2D trigger range of this object, the system verifies the tag using the Compare Tag function. If the object is confirmed to be the player, the script triggers a custom event named 'GetPowerUp' and immediately destroys the item object, thereby simulating the player "picking up" the Brain Buff and gaining the corresponding skill effect.
I implemented a finite state machine for the player character, which primarily consists of two core states: Unarmed State and Armed State. The logic of the state machine is very straightforward: at the start of the game, the player is in the Unarmed state by default and can only perform basic movement and jumping. Once the player picks up the "Brain Buff" item on the map, the system triggers a custom event that smoothly transitions the player to the Armed state. In this new state, the player’s script logic changes: in addition to retaining basic movement, new input listeners and skills are unlocked. Internally, the Unarmed State primarily interacts with the physics system’s Rigidbody 2D to control the character’s horizontal movement and force-driven jumping, and uses the Animator to adjust walking animations based on movement speed. The Armed State builds upon this with a significant functional expansion: it adds an On Mouse Input event listener. When the state machine is in the Armed state, the player clicking the right mouse button triggers the attack trigger in the Animator, thereby executing the laser cannon firing animation and related logic. This state machine design decouples the “movement system,” “combat system,” and “input system,” allowing me to configure the player’s behavior independently for different states, ensuring clear and scalable game logic.

<img width="694" height="361" alt="截屏2026-04-28 23 47 01" src="https://github.com/user-attachments/assets/8f1212d7-e39c-4b7c-a20b-5b2a94853b48" />
## Milestone 2 Devlog
### 1 
Basic steps:
1 Code the central quest manager state system and verify state changes using TextMeshPro on the HUD.
2 Write a lightweight bridge script to accept parameterless input from Visual Scripting graphs.
3 Wire map interactions into the system to update the active objective text.  
Detailed steps:
1 Add an enum called QuestState to store the active progression stage.
2 Code the singleton QuestManager.cs with an UpdateUI() method that formats objective strings based on the enum state.  
3 Add a TextMeshPro text object to the game Canvas and assign it to the manager's text slot.  
4 Build a decoupled QuestGraphBridge.cs script containing simple methods to translate external triggers.
5 Update KeyPickup.cs and FruitPickup.cs to call collection methods on the manager immediately when grabbed.  
6 Connect the Tame/Defeat path choices inside MushroomBoss.cs to trigger the respective tracking states. 
### 2 
The task breakdown activity from Week 5 was highly helpful because it forced me to organize my state tracking logic before touching any scripts. Branching storylines can easily create broken UI bugs; mapping out the clean enum changes beforehand kept the code simple. If I did it again, I would list exact editor variable types ahead of time to avoid assembly errors during Unity integration.
### 3 
Calling a custom C# method from a Visual Scripting Graph.
Because custom enums and singletons are difficult to expose cleanly in basic visual nodes, QuestGraphBridge.cs acts as a translator. As seen in <img width="763" height="484" alt="截屏2026-06-14 22 18 08" src="https://github.com/user-attachments/assets/9ff77555-f6d9-4f25-a93b-ae33a4d83728" />
right before the pickup item fires its final Game Object Destroy node inside the Buff_brain graph, a Component: Send Message node calls UnlockPlayerAttack. This safely runs the C# method on our bridge script, which seamlessly updates the objective parameters inside QuestManager.
### 4 
Grading TargetPlease grade the Quest Management and Branching Objective Navigation System for Feature (3). This architecture is driven by the persistent QuestManager component in the scene hierarchy and outputs text objectives dynamically onto the UI Canvas.


## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Final Devlog
### 1
The core gameplay loop centers on exploration, environmental puzzle-solving, and critical choice architecture. Players explore the map, engage with a narrative guide, discover upgrades or hidden progression items, and interact with a major encounter. The loop culminates in a critical path choice: the aggressive Defeat Route or the peaceful Tame Route.
### 2
### 3
1 I plan to rely heavily on task step breakdowns in future planning. While bubble diagrams are excellent for mapping macro system dependencies visually, task step breakdowns translate those abstract ideas into immediate, actionable coding tasks, which prevents implementation paralysis.
2 Breaking a major feature down into tiny steps completely shifts my understanding of project scope. It instantly highlights hidden technical hurdles, such as realizing a visual graph cannot easily talk to a static C# singleton without writing an intermediate bridge script (QuestGraphBridge). This turns a vague guess about timeline length into a highly accurate, realistic schedule.
3 This plan highlights what went well and what went poorly during this vertical slice development. What went well was the technical modularity; keeping the QuestManager state system completely separate from visual inputs made debugging incredibly clean. However, my upfront task estimation for art and rendering went poorly, causing me to run out of time for the rendering feature. Moving forward, I will utilize granular task step breakdowns much earlier in the planning phase to guarantee an accurate minimum viable product scope.
## Open-source assets
NPCs and Player:
https://monopixelart.itch.io/forest-monsters-pixel-art
https://lucky-loops.itch.io/character-satyr


