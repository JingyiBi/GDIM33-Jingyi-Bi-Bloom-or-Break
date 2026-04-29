
# GDIM33 Vertical Slice
## Milestone 1 Devlog
This visual script handles the logic for players acquiring power-ups. When a game object tagged with 'Player' enters the 2D trigger range of this object, the system verifies the tag using the Compare Tag function. If the object is confirmed to be the player, the script triggers a custom event named 'GetPowerUp' and immediately destroys the item object, thereby simulating the player "picking up" the Brain Buff and gaining the corresponding skill effect.
I implemented a finite state machine for the player character, which primarily consists of two core states: Unarmed State and Armed State. The logic of the state machine is very straightforward: at the start of the game, the player is in the Unarmed state by default and can only perform basic movement and jumping. Once the player picks up the "Brain Buff" item on the map, the system triggers a custom event that smoothly transitions the player to the Armed state. In this new state, the player’s script logic changes: in addition to retaining basic movement, new input listeners and skills are unlocked. Internally, the Unarmed State primarily interacts with the physics system’s Rigidbody 2D to control the character’s horizontal movement and force-driven jumping, and uses the Animator to adjust walking animations based on movement speed. The Armed State builds upon this with a significant functional expansion: it adds an On Mouse Input event listener. When the state machine is in the Armed state, the player clicking the right mouse button triggers the attack trigger in the Animator, thereby executing the laser cannon firing animation and related logic. This state machine design decouples the “movement system,” “combat system,” and “input system,” allowing me to configure the player’s behavior independently for different states, ensuring clear and scalable game logic.

<img width="694" height="361" alt="截屏2026-04-28 23 47 01" src="https://github.com/user-attachments/assets/8f1212d7-e39c-4b7c-a20b-5b2a94853b48" />
## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
NPCs and Player:
https://monopixelart.itch.io/forest-monsters-pixel-art
https://lucky-loops.itch.io/character-satyr


