## Things to improve

### Behaviour
- When an invalid place command occurs, it is just ignored, with no indication to the user of why
- Output from failed placement is confusing (tile index starting at zero so it says cannot place at position 5, 5 for a board size of 5 for example)

### Testing
- Boundary testing (e.g. more extensive testing of place command - can we definitely not place the robot outside of the 5x5 grid?)
- Add testing of file input parsing
- Colocated test files (e.g. LeftTests.cs in the same directory as Left.cs -- kindof a pain to do in .Net because reasons)
- Mutation testing (https://stryker-mutator.io/) - are our tests testing what we think they're testing?
- Introducing the std out redirect in the report tests meant I now have to pollute a bunch of other tests with the same code - any tests covering behavior that happens to do logging (e.g. move and place error messages)
  - This also introduced an intermittent test failure in a random test using the std out redirect - I suspect its an issue with test parallelisation and thread safety (I _think_ it might just be an issue for the tests, not the actual implementation code)
  - I only ever saw this when running tests from the command line - running from Rider they all pass consistently - lends credence to the idea that it is a parallelisation and thread safety issue, test runs in Rider happen slower, so less chance of hitting the problem

### Implementation
- Possibly excessive repetition and nesting of `CanExecute()` method
- Law of demeter violations around robot position
- File reading and command parsing is gross, error prone, not extensible...
- Error messaging is inline - probably could separate out (maybe a command's `Execute` method has a return type that contains possible error messages?)
  - Logging via the console is pretty well baked in - would be good to abstract this so that we can inject different loggers and log elsewhere e.g. SumoLogic, Datadog
- Can I make board size private somehow?
- Add more comments - particularly around position facing
- Things like xy coordinates just represented by integers can easily get orders mixed up, e.g. putting a "y" where an "x" value is expected
  - "Tiny types" - things like the example above can be represented by a type e.g. `Coordinate` - they describe a real life concept and a domain concept and they have rules e.g. a valid coordinate must have both x and y values. We can easily capture these rules in a type
- `UpdateFacing()` for the left and right commands assumes that the `Facing` enum values will be in clockwise order
- Fix naming of some things like in `Position.UpdatePosition()`
- `Robot.Move()` is a bit confusingly named


## Things I like

### Implementation
- Commands are abstracted into their own class implementing an interface - we can easily extend behavior by adding new command classes or replacing existing ones
  - Would be good if we didn't have to add to the switch statement in `Program.cs` for new commands - maybe some kind of strategy pattern?
- Commands expose a single public interface to the world - their `Execute()` method. Dependencies are constructor injected, so there is basically no ambiguity in how to interact with these classes.
- Position.MovePosition returns a new position, instead of doing object mutation - functional programming principles 
- `Main()` in `Program.cs` ended up being pretty tidy, it's fairly clear what it's doing - reading in lines from the input file, interpreting them as commands and then executing the commands. All command behavior is abstracted away into the command classes, and the behavior to parse commands - while not the nicest - is still relatively clear, _and_ it is extracted into a private method

### Tests
- Tests are unaware of implementation (i.e. we can change the way commands behave under the hood and the tests won't just break straight away - we can refactor knowing that our tests will tell us if we've broken behaviour)


## Thought process

### Architecture
`Main()` kept intentionally simple - read in the lines from the input file, parse, then execute. Method names are kept clear so that if you need to dive in any given part of the process its (hopefully) not hard to figure out where to go.

**Parsing commands** is a little bit hacky maybe, but we define the expected input structure and give example files - so this seems like an okay tradeoff for now.

**Commands** are not using any inheritance. We use some composition, with the `ICommand` interface, which also allows us to be a bit smart about how we parse and execute our commands.

Each command specified in the requirements becomes one command class - extending functionality in the form of new commands means changes in only 2 places.

`Left` and `Right` commands are essentially duplicated, but the current implementation does require them to exist separately. My first instinct would _not_ be to try to reduce this duplication. They are two separate commands whose implementations happen to look identical.

Board and Robot are our two main **domain concepts**. Position is a secondary domain concept - `Robot` can have a `Position`, and the `Board` is _aware_ of positions in so far as a position's XY coordinates refer to a tile on the board.

A position object is passed to the `Board` methods `PlaceAtPosition()` and `CanPlaceAtPosition()`. Board is only asking questions about a position, whereas the robot is actively changing the position it owns. Seems like there is a better entity structure somewhere in here...

**Board size** is specified as 5 in the challenge doc - so I've made 5 the default size. We can increase the size to whatever we want without any issue. All of the behaviour relating to size works correctly whether we leave it at 5, or if we specify say 20.


### Assumptions
- There will only ever be one robot on the board
- We will only be reporting positions to the console.