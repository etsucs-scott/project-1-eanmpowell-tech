[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/2QC0Bpz-)
# CSCI 1260 — Project

## Project Instructions
All project requirements, grading criteria, and submission details are provided on **D2L**.  
Refer to D2L as the *authoritative source* for this assignment.

This repository is intentionally minimal. You are responsible for:
- Creating the solution and projects
- Designing the class structure
- Implementing the required functionality

---

## Getting Started (CLI)

You may use **Visual Studio**, **VS Code**, or the **terminal**.

### Create a solution
```bash
dotnet new sln -n ProjectName
```

### Create a project (example: console app)
```bash
dotnet new console -n ProjectName.App
```

### Add the project to the solution
```bash
dotnet sln add ProjectName.App
```

### Build and run
```bash
dotnet build
dotnet run --project ProjectName.App
```
Game Controls
Movement:
Use the Arrow Keys to Move around the map!
Up, Down, Left, and Right!

During battle: 
The Battles are turn-based, try to hold your own against the slasher (M)
You can Attack, Heal, and Flee.
Do this buy using A, S, and F!

Display Format:
My game using a 10x10 text grid to show your map!
The map is made of many symbols, and this is what they each mean:
"#" = Wall
. = Empty Space
@ = Player
M = Monster/Slasher
W = Weapon
P = Smore/Health Item
E = Exit Point

This text grid will update after each move to show your current position and the position of everything around you!



## Notes
- Commit early and commit often.
- Your repository history is part of your submission.
- Update this README with build/run instructions specific to your project.
