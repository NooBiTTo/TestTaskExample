# Test Task Example

Unity test consists of two tasks described with User Stories. 
Provided scene “Playground” contains a Player gameobject with basic movement and camera script and simple environment. 
Task description leaves small leeway for programmer but as long as acceptance criteria are meet, task will be passed. 
Code readability, general architecture and end result from the user's point of view are assessed. 
Along with this document, a build from an example solution of this test is attached.

1. Item interactions

As a player I want to be able to pick up items so that I can move them from place to place.
Acceptance criteria:
- Item can be picked up when:
	- close enough to player
	- is aimed at
	- player press and hold RMB
- Picked item remain in “Hold” position until RMB is released
- Picked item does not have collision and physics
- When RMB is released item falling down with gravity and physics
- Picked item can be thrown forward when LMB is pressed


2. Crafting

As a player I want to create new items from existing items so that I can obtain items that are not present initially in a scene.
Acceptance criteria:
- Whole crafting system should be designed in such way that no changes are required in crafting station code or prefab if new item or crafting recipes need to be added
- Items crafting takes place in crafting station
- Left chamber of crafting station is where player put ingredients
- Right chamber of crafting station is where new item is spawned
- Crafting is permitted only when proper type and quantity of items is placed in left chamber:
	- Red + Green = Yellow
	- Red + Green = Yellow
	- Red + Blue = Magenta
	- Blue + Green = Cyan
	- Green + Red + Blue = White
- Crafting is induced by pressing button on the machine
- Button press is executed by aiming at it and pressing LMB
- Button visually present 3 states (default, aimed at, clicked)
- Items used as crafting ingredients should be destroyed
- Player should be informed by text prompts on the machine what items are placed in ingredients chamber and what item potentially can be crafted
