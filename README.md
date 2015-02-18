Karmbat Game
============

[Karmbat][1] is a simple game I created in 48 hours for the [Global Game Jam][2] 2015.

[1]: http://globalgamejam.org/2015/games/karmbat
[2]: http://globalgamejam.org/

<img src="https://raw.githubusercontent.com/mlepage/karmbat/master/screenshots/karmbat-screenshot.png" width=640 height=384>

Overview
--------

The GGJ15 theme was "What Do We Do Now" and I had a challenging time coming up with a workable idea. Eventually I thought of using the diversifier "This Is How It Feels" to illustrate what it's like for your actions to affect yourself, by using the mechanic of having your input affect your enemies as well as your own avatar.

I considered some kind of top-down scrolling shooter where enemies move when you shoot and shoot when you move, or something like that. I thought a bit about [Braid][3]'s mechanic where moving in space directly affects the position of enemies by controlling time.

Finally I settled upon a simple version of [Atari Combat][4]'s tank game where the enemy mirrors your every move. With a symmetrical arena, if you are shooting the enemy, then by definition it is also shooting you. So what do you do now? One moving block will allow you to break the symmetry...

[3]: http://braid-game.com/
[4]: http://en.wikipedia.org/wiki/Combat_%281977_video_game%29

Play Online
-----------

You can play Karmbat online in your browser using the Unity Web Player [here][5].

[5]: https://dl.dropboxusercontent.com/u/41693465/UnityWebPlayer/Karmbat/Karmbat.html

How to Play
-----------

Your tank is blue; the enemy's tank is red. Effectively, you control both tanks: left stick moves, right stick shoots. You can also use keys ESDF and IJKL.

Shots bounce off the arena's walls a few times, and only hit the enemy.

Your goal is to shoot the enemy without being shot yourself. Good luck.

Known Issues
------------

The red tank's turret glitches. This does not affect shots. This started occurring sometime during development and I did not have time to fix it.

Occasionally shots escape the arena; the game detects this and destroys them.

Source Code
-----------

The source code is available on [github][6].

[6]: https://github.com/mlepage/karmbat

License
-------

Karmbat is licensed under the [Apache License, Version 2.0][7].

InControl is a third-party library with its own license, see README-InControl.md for details.

[7]: http://www.apache.org/licenses/LICENSE-2.0

Technology Notes
----------------

The game was made in [Unity][8] using the C# programming language. The art was made with [Pixelmator][9]. The audio was made with [Bfxr][10] and [Audacity][11]. Input is controlled with the free version of [InControl][12].

[8]: http://unity3d.com/
[9]: http://www.pixelmator.com/
[10]: http://www.bfxr.net/
[11]: http://audacity.sourceforge.net/
[12]: http://www.gallantgames.com/pages/incontrol-introduction

By the Same Author
------------------

Alpha Memory is a memory game for children, featuring letters to help them learn the alphabet. It's free on [BlackBerry World][13] for BlackBerry 10 phones and PlayBook tablets. The source code is available on [github][14].

NeverMaze is a touch maze game for all ages, featuring a variety of maze generation algorithms and dynamically adjusting difficulty. It's available on [Google Play][15] for Android phones and tablets, and [BlackBerry World][16] for BlackBerry 10 phones and PlayBook tablets.

[13]: http://appworld.blackberry.com/webstore/content/29617896/
[14]: https://github.com/mlepage/memory-game
[15]: https://play.google.com/store/apps/details?id=com.krungie.sliderpuzzle
[16]: http://appworld.blackberry.com/webstore/content/29783887/
