# Minesweeper Console App

## Overview
This Minesweeper Console App is a classic game implemented in C# using .NET 6.0. The game provides a text-based interface where players can uncover cells on a grid to avoid hidden mines.

## Getting Started

#### Prerequisites
.NET 6.0 SDK installed on your machine.

#### Installation

Navigate to the project directory:

```sh
cd minesweeper-console-app
```

Build the project:

```sh
dotnet build
```

Build the project:

```sh
dotnet run
```

#### Project Structure
- `Program.cs`: Main entry point for the console application.
- `Tile.cs`: Class to represent single tile in the game board.
    - `NormalTile.cs`: Class to represent single safe tile in the game board.
    - `MineTile.cs`: Class to represent single Mine tile in the game board.
- `TileGrid.cs`: The TileGrid class represents the game board in its entirety.
- `ConsoleUi.cs`: Used to maintain initial controls of the game.
- `Game.cs`: Used to maintain game related logic such as; create the game board, maintain user intractions.
- `IReader, Reader`: Helper service to manage user imputs with prompts
- `IRendomeMinePlacer, RendomeMinePlacer`: Manage mine placing related logic 
- `GameStatusChecker`: Implements game status logic 

> Note: Each code file includes detailed comments to enhance redability

#### Running Test

Navigate to the test project:

```sh
cd MinesweeperUnitTests
```

Run the tests:

```sh
dotnet test
```
