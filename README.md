# Rope Intranet

## What is this project about?

An exercise in programming in C#.  Imagine a primative communication system consisting of wires strung
between two tall buildings pictured as facing each other one on the left and other on the right.
Each wire connects an office window of one building
to an office window in the other.  Given each test case scenario, count the
number of times two wires intersect.

## Notes and Folder strucuture

January 2016: a solution using nested loops and try all combos.  O(N^2).

November 2022:

-Refactor and convert the project from .NET Framework 4 to .NET 7

-The problem website link is no longer active, but a Google search shows similar problem here:
at this address [Coding Competitions](https://codingcompetitions.withgoogle.com/codejam/round/0000000000432ccd/000000000043315a)

-The solution file now has two projects:
1.  "rope-intranet" = the original nested loops problem solution.
2.  "bentley-ottmann" = a favorite author of many people and me as well is Jon Bentley, and I stumbled upon a
Wikipedia article describing an algorithm he collaborated on creating for solving this same type of problem,
the [Bentley-Ottmann algorithm](https://en.wikipedia.org/wiki/Bentley%E2%80%93Ottmann_algorithm).
I thought I'd try their sweep line algo here.  While I was inspired by Bentley-Ottmann, it turned out
clumsy.  I had to leverage assumptions and resort to using "for" loops in my implementation.
I found this video series explaination of the technique helpful
(YouTube Phillip Kindermann)[https://www.youtube.com/watch?v=qkhUNzCGDt0].

## Problem statement

From Google Code Jam Round 1C 2010 - Rope Intranet.  Quoting from the website:

A company is located in two very tall buildings. The company
intranet connecting the buildings consists of many wires,
each connecting a window on the first building to a window
on the second building.

You are looking at those buildings from the side, so that
one of the buildings is to the left and one is to the right.
The windows on the left building are seen as points on its
right wall, and the windows on the right building are seen
as points on its left wall. Wires are straight segments
connecting a window on the left building to a window on the
right building.

You've noticed that no two wires share an endpoint (in other
words, there's at most one wire going out of each window).
However, from your viewpoint, some of the wires intersect
midway. You've also noticed that exactly two wires meet at
each intersection point.

On the above picture, the intersection points are the black
circles, while the windows are the white circles.

How many intersection points do you see?

Input

The first line of the input gives the number of test cases,
T. T test cases follow. Each case begins with a line
containing an integer N, denoting the number of wires you
see.

The next N lines each describe one wire with two integers Ai
and Bi. These describe the windows that this wire connects:
Ai is the height of the window on the left building, and Bi
is the height of the window on the right building.

Output

For each test case, output one line containing "Case #x: y",
where x is the case number (starting from 1) and y is the
number of intersection points you see.

Limits

1 ≤ T ≤ 15.
1 ≤ Ai ≤ 104.
1 ≤ Bi ≤ 104.
Within each test case, all Ai are different.
Within each test case, all Bi are different.
No three wires intersect at the same point.

Small dataset

1 ≤ N ≤ 2.

Large dataset

1 ≤ N ≤ 1000.

/Done quoting.

Write a program to read the input data file and solve each case for number of intersections.  Assume the data file is of reasonable size and contains valid data.

The problem is originally from [Google Code Jam Round 1C 2010 - Rope Intranet](https://code.google.com/codejam/contest/619102/dashboard)
