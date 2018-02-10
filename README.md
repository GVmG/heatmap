# osu! Beatmap Heatmap
A simple program to visualize a heatmap of the note positions in your [osu!](http://osu.ppy.sh/) beatmap, so you can tell which areas of the playfield the player will be around the most.


# How to Use
It's extremely easy to use: just click the \[...] button to open a file (or just paste the filepath in the textbox), press "Load The Map!", and the program will automatically retrieve map info and draw the heatmap.
You can pick from different settings on the right, like how the program will render the heatmap, which objects it should render, etc.


# Features
- HEATMAP! It's the whole point of the program! You can pick between a greyscale "heightmap" and a coloured "heatmap".
- Show map info in the bottom right (hover for more details such as AR in milliseconds, OD hit windows etc.)
- HitObject filtering (so you can, for example, look at the distribution of circles only, or sliders only)
- Open beatmap page (mapset, difficulty or even the mapper's userpage) from the program itself
- Only render the heatmap of a certain part of the map (and you can click the time to open the map in the editor)

Upcoming Features:
- scale heatmap values better than a generic 1/sqrt(object_count)
- account for sliderbodies in soft and circle rendering (not just the sliderpoints, like it's doing right now)
- redraw the heatmap when you change properties (instead of when you click the Load The Map! button)

# Planned Features
Stuff that *might* be added to the program *eventually*, after the Upcoming Features. For now, I don't have any major plans, but feel free to contact me on **Discord @GV#5559** if you have a request or an idea!

# A tad bit of Credits
This program is developed by [Rainfall](https://osu.ppy.sh/u/6995159) (aka GV).

**Special Thanks:**
- the Mapping Mentorship people for the idea, and for some feature requests. Also for being the great people they are.
- peppy for making such a great game.
- SaxxonPike from StackOverflow for [the DirectBitmap class](https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f) (nearly 3x faster than a normal Bitmap, with GetPixel()/SetPixel()).
- 50 other different people from StackOverflow and all of their PathGradientBrush tutorials and code (which I didn't use because my stuff is a bit more specific)
- Cl8n for [the CS-to-osu!pixels formula](https://osu.ppy.sh/forum/p/4282387) and /u/Fukiyel for [the OD-to-Milliseconds formula](https://www.reddit.com/r/osugame/comments/781ot4/od_in_milliseconds/doqngos)
- Borengar for constanty using JavaScript so that my poorly performing code has something to be faster than.
- thank mr monstrata 4 da pp

&nbsp;

🍩
