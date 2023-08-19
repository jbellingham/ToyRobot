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
- Can I make board size private somehow?
- Add more comments - particularly around position facing
- Magic strings when parsing commands from input
- Things like xy coordinates just represented by integers can easily get orders mixed up, e.g. putting a "y" where an "x" value is expected
  - "Tiny types" - things like the example above can be represented by a type e.g. `Coordinate` - they describe a real life concept and a domain concept and they have rules e.g. a valid coordinate must have both x and y values. We can easily capture these rules in a type

## Things I like

### Implementation
- Commands are abstracted into their own class implementing an interface - we can easily extend behavior by adding new command classes or replacing existing ones
  - Would be good if we didn't have to add to the switch statement in `Program.cs` for new commands - maybe some kind of strategy pattern?
- Commands expose a single public interface to the world - their `Execute()` method. Dependencies are constructor injected, so there is basically no ambiguity in how to interact with these classes.

### Tests
- Tests are unaware of implementation (i.e. we can change the way commands behave under the hood and the tests won't just break straight away - we can refactor knowing that our tests will tell us if we've broken behaviour)