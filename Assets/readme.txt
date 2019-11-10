This project implements a simple typing game, where you knock down words as they fly down the screen by typing them.

There is one scene, named FuguType. It includes:

* a daylight Basic Water object from the Unity standard assets
* a Main Camera facing down at the water
* a Score object which is a GUIText and a script that tracks the current typing accuracy
* a spawn object which has the spawn script which instantiates new instances of the flying word prefab
* a type object which has a script that checks the current typing input and displays it in a GUIText, and also checks if the enter/return key has been hit

When a word is instantiated, its font is randomly chosen from the Resources/Fonts directory. You can add (or remove) fonts there.

Another area of customization is the word list. That is an array in Spawn.js, actually an array of arrays, where the words are separated by length. Words up to 11 letters are provided.

The Main Camera has a pause menu script attached. It is a variation of the one provided on the Unify community wiki.

For questions and requests and problem reports, please visit the Fugu Games Facebook page, http://fugugames.com/facebook , or the Fugu Games support topic in the Unity forum (in the Asset Store category).

