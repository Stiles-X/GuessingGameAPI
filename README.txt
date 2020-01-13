GuessingGame - API -- ReadMe

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


Documentation / Manual

- Introduction
- CoreAPI
-- CoreGame
-- API
-- Exceptions
- ConsoleApp

This project is made up of 2 parts. The 'CoreAPI' and 'ConsoleApp'.

The 'ConsoleApp' is an implementation using the 'CoreAPI'.
In other words, 'ConsoleApp' is a 'UI'/'front-end' over 'CoreAPI'.

The 'CoreAPI' is amde up of 2 parts. The 'API' and 'CoreGame'.

CoreGame

The 'CoreGame' is, as it names implies, the base model(class) of a Guessing Game.
It has properties such as
	- Max (int) // Max Possible Guess
	- Min (int) // Min Possible Guess
	- Correct (int?) // The Correct Guess
function Guess(int) // auto-increments UsedGuesses
with properties to be used together such as
	- AllowedGuesses (int?) // How many times you are allowed to guess
	- UsedGuesses (int) // How many times you have Guess()ed.
and helper properties such as
	- Random (int) ReadOnly // A random int between including Max and Min
	- LeftGuesses (int) ReadOnly // AllowedGuesses - LeftGuesses
	- OutOfGuesses (bool) // if (AllowedGuesses - LeftGuesses = 0) is true
Checks and exceptions have been implemented to avoid wrong things such as (but not only)
	- Setting Max higher than Min, and vice versa (ArgumentOutOfRangeException)
	- Setting Correct outside of Max / Min
	- Setting Correct before setting Max / Min (Custom* PropertyNotSetException | InvalidOperationException)
	- Setting Max lower than Correct, or Min higher than Correct, after setting Correct
	- Guessing Outside Of

API
The 'API' is, as it names implies, the way to interact with a 'CoreGame' model safely.

Exceptions
Exceptions are defined in GuessingGame.Core.Exceptions or CoreAPI/Exceptions.cs
There are 3 of them, and they are -
	PropertyNotSetException : InvalidOperationException // When a required property hasn't been set yet
	OutOfTriesException : InvalidOperationException  // When you are out of guesses
	ForbiddenException : InvalidOperationException  // When you are

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