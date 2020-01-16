# Contents
- Contents
- License
- Documentation / Manual
- About

# License (Short) - MIT License. Read LICENSE.txt

# Documentation (unfinished, please look at the code)

- Introduction
- CoreAPI
-- CoreGame
--- Exceptions
-- API
--- Enums
--- Exceptions
- ConsoleApp

## Intro
This project is a combination of independent projects 'API' and 'ConsoleUI'.

The 'ConsoleUI' is an implementation using the 'APIProject'.
In other words, 'ConsoleUI' is a 'UI'/'front-end' over 'APIProject'.

The 'APIProject' is made up of 2 parts. The 'API' and 'Model'.
The 'APIProject' can be used as a base for other implementation, and can be used in code.
You are FREE to alter the API for your custom Logic.

Model
/* May Be Out Of Date, no gurantee.
The 'Model' is, as it names implies, the base model(class) of a Guessing Game.
It has properties such as
    - Max
    - Min
    - Correct
    - AllowedGuesses
    - UsedGuesses

Exceptions*
They are -
    PropertyNotSetException : InvalidOperationException // When a required property hasn't been set yet

# About
                 ^ Guessing Game ^
           Developed by Stiles-X(github)
     A core API to get up to speed with making
            above-average GuessingGames.

    Features:
      -Fully error handled
      -Just enough functions, for customization
      -Amazing sample Console UI implementation
      -Made by passionate developer <3