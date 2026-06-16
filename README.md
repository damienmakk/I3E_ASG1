# I3E_ASG1

# Abandoned Research Facility

## Overview

**Abandoned Research Facility** is a first-person 3D escape game created in Unity for I3E Assignment 1. The player is trapped inside a damaged research facility and must explore different areas, collect items, avoid hazards, unlock doors, and escape safely.

The game includes locked doors, collectibles, laser hazards, acid hazards, toxic gas, checkpoints, a pushable crate puzzle, health UI, inventory UI, death screen, and a final escape screen.

---

## Game Objective

The main goal is to collect **20 total collectibles** and reach the final exit door to escape the facility.

The player must:

* Collect coins to increase score.
* Collect the keycard to unlock the first locked door.
* Collect the gas mask to survive the toxic gas room.
* Avoid lasers, acid spills, acid pools, and toxic gas.
* Push a crate in the final area to reach the exit.
* Collect all 20 items to unlock the final escape door.

---

## Controls

| Action                         | Input               |
| ------------------------------ | ------------------- |
| Move                           | W, A, S, D          |
| Look Around                    | Mouse               |
| Jump                           | Spacebar            |
| Sprint                         | Shift               |
| Interact / Collect / Open Door | E                   |
| Push Crate                     | Walk into the crate |

---

## Gameplay Areas

### Area 1: Starting Area

The player begins in Area 1. There is a locked door that requires a keycard. If the player tries to open the door without the keycard, a popup message will appear saying that the keycard is required.

### Area 2: Laser Room

The player must enter the laser room to collect the keycard. The lasers damage the player over time when touched. After collecting the keycard, the player can return to Area 1 and unlock the locked door.

### Area 3: Acid Bridge

The player must cross a bridge with acid spills. Acid spills damage the player over time. If the player falls into the acid pool below the bridge, they die instantly and respawn at the latest checkpoint.

### Area 4: Toxic Gas Room

Before entering the toxic gas area, a warning UI prompt appears telling the player to use a gas mask. If the player enters the gas room without the gas mask, they die. If the player has collected the gas mask, they can safely move through the room.

The door to the next area requires at least **15 collectibles** to unlock.

### Area 5: Crate Puzzle and Final Exit

The player must push a crate into position and jump onto it to reach the final exit door.

The final exit door requires **20 collectibles**. Once the player has collected all 20 items and interacts with the final door, the game is completed.

---

## Collectibles

There are **20 total collectibles** in the game.

Collectible types:

* Coins
* Keycard
* Gas Mask

Coins increase the player’s score.
The keycard and gas mask count as collected items but do not increase the score.

---

## UI Features

| UI Element              | Purpose                                                |
| ----------------------- | ------------------------------------------------------ |
| Score UI                | Shows the player's score                               |
| Collectible Progress UI | Shows collected items out of 20                        |
| Inventory UI            | Shows collected key items such as keycard and gas mask |
| Health UI               | Shows the player's current health                      |
| Popup Message UI        | Shows warning messages and locked door messages        |
| Death UI                | Appears when the player dies                           |
| Win Screen              | Shows final results after escaping                     |

---

## Hazards

| Hazard     | Effect                                                      |
| ---------- | ----------------------------------------------------------- |
| Laser      | Damages the player over time                                |
| Acid Spill | Damages the player over time                                |
| Acid Pool  | Instantly kills the player                                  |
| Toxic Gas  | Instantly kills the player if they do not have the gas mask |

---

## Checkpoint and Respawn System

The game includes checkpoint triggers. When the player reaches a checkpoint, their respawn point is updated.

If the player dies, they respawn at the latest checkpoint with full health restored.

---

## Win Condition

The player wins by collecting all **20 collectibles** and interacting with the final exit door.

The final result screen displays:

* Successfully escaped message
* Total deaths
* Items collected
* Final score

---

## Unity Systems Used

This project uses the following Unity systems:

* First-person player controller
* Unity Physics using colliders, triggers, and rigidbodies
* Animator for door opening and closing
* TextMeshPro UI
* Health system
* Checkpoint and respawn system
* Damage-over-time hazard system
* Instant death hazard system
* Inventory tracking
* Collectible tracking
* Pushable crate using Rigidbody physics
* Audio Source for background music and sound effects

---

## How to Run

1. Download or clone this repository.
2. Open the project in Unity.
3. Open the main scene.
4. Press the Play button.
5. Use the controls to play through the game.

---

## Platform

* Target platform: Windows Desktop
* Controls: Keyboard and mouse
* Unity version: 6000.3.13f1

---

## Known Limitations / Bugs

* UI popup messages may overlap if the player interacts with multiple objects quickly.
* The crate movement may vary depending on the direction the player pushes it from.
* The game is designed for keyboard and mouse only.
* The game has only been tested on Windows desktop.
* Some external 3D assets may have a slightly different visual style from the rest of the scene.

---

## Assets Used

The following external assets were used in this project:

### Gas Mask

**PBR Plague Doctor Masks**
Used for the gas mask collectible in the toxic gas room.

https://assetstore.unity.com/packages/3d/props/clothing/accessories/pbr-plague-doctor-masks-230420

### Coin

**Pirate Coin**
Used as the coin collectible for score and collectible progress.

https://assetstore.unity.com/packages/3d/props/pirate-coin-207743

### Keycard

**Retro PSX Horror Puzzle Item Pack (Icon + LowPoly)**
Used for the keycard collectible that unlocks the first locked door.

https://assetstore.unity.com/packages/3d/props/retro-psx-horror-puzzle-item-pack-icon-lowpoly-250188

### Crate

**Low Poly Wooden Crate**
Used as the pushable crate for the final puzzle area.

https://assetstore.unity.com/packages/3d/props/industrial/low-poly-wooden-crate-308305

---

## Disclaimer

This project was created for educational purposes as part of an Interactive 3D Experience assignment. External assets are credited above and are not claimed as original work.

