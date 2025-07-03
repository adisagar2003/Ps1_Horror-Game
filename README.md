# 🕷️ Black Factory – A PS1-Style Survival Horror Experience

![image](https://github.com/user-attachments/assets/0732c08a-4835-4ea6-93b5-55b5a8c8d471)

## 🕹 Overview

**Black Factory** is a PS1-inspired survival horror game set in an abandoned factory maze, stalked by a procedurally animated spider. Your goal: find keycards, manage your inventory, restore power, and escape before it finds you.

Inspired by classic lo-fi horror, the game uses low-poly visuals, dynamic lighting, and tension-focused design to deliver a raw survival experience.

---

## 🔧 Features Implemented

✅ **Inventory System** – Cleanly separated UI & data layers with OOP principles, event-driven item pickup, and refactor-friendly architecture.  
✅ **Objective System** – Track goals like finding keycards, restoring power, and escaping.  
✅ **Event Handling** – Built with Unity events for decoupled systems and responsive gameplay flow.  
✅ **Pickable Inheritance** – Items inherit from a shared base class, enforcing clean code and reusability.  
✅ **Flashlight Drain Mechanic** – Flashlight power depletes, adding tension and resource management.  
✅ **Locked Gates** – Requires keycards to progress, encouraging exploration and item management.  
✅ **Procedurally Animated Spider Enemy** – Uses NavMesh and procedural leg animation to hunt the player dynamically.  
✅ **Shaders & Visual Effects** – Created simple shaders for interactive orbs, x-ray vision mechanic using culling and post-processing control.  
✅ **Basic Perception System** – Enemy perception built to detect and chase the player within a vision cone.  
✅ **Dynamic Post-Processing** – Control environmental effects like vignette, bloom, and scanlines for tension.  
✅ **UI for Instructions & Feedback** – Display objectives, inventory, and player hints cleanly.  
✅ **Built & Shipped on Itch.io and YouTube** – Learned the full pipeline of building, testing, packaging, and shipping a game.

---

## 🛠️ Tech Stack

- **Engine**: Unity (URP with PSX shaders)
- **Language**: C#
- **Tools**: Blender, Audacity, Krita/Photoshop, Unity Asset Store

---

## 🎮 How to Play

- **Goal**: Repair critical systems, find keycards, and escape while avoiding the spider.
- **Controls**:
  - `WASD` – Move
  - `E` – Interact / Repair
  - `Tab` – Inventory
  - `F` – Flashlight

---

## 🚧 Current Status

✅ Core gameplay loop functional  
✅ Inventory, objectives, flashlight drain, enemy AI working  
✅ Built and tested on PC

> Polish, enemy improvements, and level expansion are next.

---

## ✅ What I Learned

- Game architecture principles (clean separation of UI and data)
- OOP patterns in Unity (inheritance, event-driven systems)
- Procedural animation basics and AI pathfinding with NavMesh
- Shader basics and runtime post-processing control
- Building a complete gameplay loop and handling UX
- Shipping workflow from testing to publishing on Itch.io and YouTube

---

## 📌 Planned Features

- Cinematic intro/ending
- Enhanced AI with different states and patrol
- Polished x-ray vision mechanic
- Full sound pass with custom SFX
- Gamepad support
- Expanded level and environmental storytelling

---

This project was built to **practice and understand how to ship a real playable game**, not to be perfect. If you want to see how it plays, check out:

▶️ [Gameplay Video](https://www.youtube.com/watch?v=yFhW1GE2UnY)  
🕹️ [Play on Itch.io](https://sigaar.itch.io/black-factoryalpha)
