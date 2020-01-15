GuessingGame - API v0.3.0 PreRelease 1 -- ReadMe 

Contents
- Contents
- License
- Documentation / Manual
- About


License
//  As shown in LICENSE.txt
    MIT License

    Copyright (c) 2020 Wai Yan Myint Mo

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.


Documentation / Manual v0.2.0 (GuessingGameAPI v1.0.0) //Unfinished! Will update to new structure after prerelease

- Introduction
- CoreAPI
-- CoreGame
--- Exceptions
-- API
--- Enums
--- Exceptions
- ConsoleApp

This project is made up of 2 parts. The 'CoreAPI' and 'ConsoleApp'.

The 'ConsoleUI' is an implementation using the 'APIProject'.
In other words, 'ConsoleUI' is a 'UI'/'front-end' over 'APIProject'.

The 'APIProject' is amde up of 2 parts. The 'API' and 'Model'.
The 'APIProject' can be used as a base for other implementation, and can be used in code.

Model
/* May Be Out Of Date, no gurantee.
The 'Model' is, as it names implies, the base model(class) of a Guessing Game.
It has properties such as
    - Max (int) // Max Possible Guess
    - Min (int) // Min Possible Guess
    - Correct (int?) // The Correct Guess
function Guess(int) // auto-increments UsedGuesses
with properties to be used together such as
    - AllowedGuesses (int?) // How many times you are allowed to guess
    - UsedGuesses (int) // How many times you have Guess()ed. Starts at 0 by default.
Checks and exceptions have been implemented to avoid wrong things such as (but not only)
    - Setting Max higher than Min, and vice versa (ArgumentOutOfRangeException)
    - Setting Correct outside of Max / Min (ArgumentOutOfRangeException)
    - Setting Correct before setting Max / Min (PropertyNotSetException*)
    - Setting Max lower than Correct, or Min higher than Correct, after setting Correct (ArgumentOutOfRangeException)
    - Guessing without setting Correct and / or AllowedGuesses (PropertyNotSetException*)
    - Guessing Outside Of Max / Min (ArgumentOutOfRangeException)
    - Guessing after you are out of guesses (OutOfTriesException*)
    - Setting AllowedGuesses less than 0 (ArgumentOutOfRangeException)
    - Setting UsedGuesses less than 0, or more than AllowedGuesses (ArgumentOutOfRangeException)
*/
Exceptions*
They are -
    PropertyNotSetException : InvalidOperationException // When a required property hasn't been set yet

API
NotImplementedEXCEPTION()!!! Look at the code! It's clean!
The 'API' is, as it names implies, the way to interact with the base 'CoreGame' model safely.
Every instance of an API has a private CoreGame instance created automatically.

Exceptions*
There is 2 of them, and they are -
    PropertyNotSetException : InvalidOperationException // When a required property hasn't been set yet

About
                 ^ Guessing Game ^
           Developed by Stiles-X(github)
     A core API to get up to speed with making
            above-average GuessingGames.

    Features:
      -Fully error handled
      -Just enough functions, for customization
      -Amazing sample Console UI implementation
      -Have docs/ manpage. RTFM or --help
      -Made by passionate developer <3

    Special thanks :
      To my family for the support. PewDiePie
    for the entertainment. To HTMLDog, for the
    first wander into code and Mosh, for first
    programming in python. To FCC, TimCorey,
    Mark P., and more, and Reddit,StackOverflow
    and the internet. Thank you all <3