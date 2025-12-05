# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## IMPORTANT: User Learning Preferences

**This is a learning/practice repository. The user is learning C# and practicing problem-solving.**

- **NEVER provide full solutions to Advent of Code puzzles unless EXPLICITLY ASKED**
- Provide guidance, hints, and nudges in the right direction
- Help the user reach their own answers through Socratic questioning and hints
- C# language-specific help is welcome (syntax, APIs, standard library usage, etc.)
- Algorithm/approach help should be hints only, not complete implementations

The goal is to guide the user to discover solutions themselves, not to solve puzzles for them.

## Project Overview

This is an Advent of Code solution repository using C# (.NET 10.0). Solutions are organized by year in directories like `aoc2025/`, with each day implemented as a separate class (e.g., `Day1.cs`, `Day2.cs`). Each year's directory contains its own C# project with Program.cs, .csproj, and .sln files.

## Architecture

- **aoc{year}/ directories**: Each year is a self-contained C# project
  - **Program.cs**: Entry point that calls the current day's `Solve()` method
  - **AdventOfCode.csproj**: C# project file
  - **AdventOfCode.sln**: Solution file
  - **Day{N}.cs**: Solution classes for each day with static `Solve()` methods
  - **inputs/**: Directory storing puzzle input files as `Day{N}.txt`

## Building and Running

All commands should be run from within the year directory (e.g., `aoc2025/`):

- **Run the current solution**: `cd aoc2025 && dotnet run`
- **Build**: `cd aoc2025 && dotnet build`
- **Clean**: `cd aoc2025 && dotnet clean`

## Workflow for Adding New Days

When adding a new day's solution:

1. Create a new class file: `aoc{year}/Day{N}.cs`
2. Add the day's input file: `aoc{year}/inputs/Day{N}.txt`
3. Update `aoc{year}/Program.cs` to call the new day's `Solve()` method
4. Each day class should:
   - Be in the `aoc{year}` namespace
   - Have a static `Solve()` method that contains the solution logic
   - Read input from `aoc{year}/inputs/Day{N}.txt`

## Code Conventions

- Use tabs for indentation (as seen in existing Day1.cs)
- Keep solutions in separate classes for each day
- All solution classes use static methods to avoid unnecessary instantiation
