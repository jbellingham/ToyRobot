# ToyRobot

ToyRobot is an interactive virtual toy robot that can be moved around a 5x5 grid by issuing commands.

## Environment setup
To run Toy Robot you need to either:
- Download and install the latest .Net 7 SDK from [here](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).
  - Ensure dotnet executable or binary is available on you system's path

OR 
- Have docker installed on your machine

Then
- Clone the ToyRobot repo from [here](https://github.com/jbellingham/ToyRobot).

## Toy robot setup

The toy robot can be instructed to move about the grid with the following commands:
- PLACE X,Y,F
  - Where X and Y are integers from 0-4, and F is a facing (North, East, South, or West)
- MOVE
- LEFT
- RIGHT
- REPORT

To issue commands, the program is set up to receive a text file `ToyRobot/input/in.txt` with one command per line - capitalisation of commands does not matter.
There are example input files in the repo at the above location.

## Running Toy robot
Run with dotnet runtime on the host machine:
- From project root, run `dotnet build`
- cd into `/ToyRobot` and then run `dotnet run`

Run in docker on the host machine:
- From project root, run ` docker build -t toyrobot:latest .`
- Run `docker run toyrobot:latest`


## Running tests
- From project root, run `dotnet test` ** (needs dotnet runtime on the host machine)
  - See `Things to improve - Testing` in `Notes.md` for a known bug while running tests from the command line

## Navigating the code
The entrypoint of the program is `Program.cs`. As mentioned above, the robot is controlled by writing commands into a document `/ToyRobot/input/in.txt`.

Implementation of commands is deferred to classes under `/Commands`, all of which implement the `ICommand` interface exposing one public method - `Execute()`.

## My thoughts
I have written up a bunch of my own thoughts about how I implemented this code challenge.
They can be found in [Notes.md](https://github.com/jbellingham/ToyRobot/blob/49742d51c5323291c76ac3c6952414cf2632da06/NOTES.md.).